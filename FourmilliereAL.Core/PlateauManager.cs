using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace FourmilliereAL.Core
{
    public sealed class PlateauManager
    {
        private static volatile PlateauManager instance; // volatile empêche l'accès a la variable si le Set est en cours
        private static object syncRoot = new Object();

        public static PlateauManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot) // lock object for MultiThread
                    {
                        if (instance == null)
                            instance = new PlateauManager();
                    }
                }

                return instance;
            }
        }

        public List<Case> CasesList { get; private set; }

        private PlateauManager() { }

        public void CreationDesCases()
        {
            CasesList = new List<Case>();
            for (int i = 0; i < Config.GrilleLargeur; i++)
            {
                for (int j = 0; j < Config.GrilleHauteur; j++)
                {
                    CasesList.Add(FabriqueSimulation.CreerFabrique("FabriqueCase").CreerCase("", i, j));
                }
            }
        }

        public void DeplacementCreature(Fourmi fourmi, Case destCase)
        {
            var crtCase = GetCaseFromFourmi(fourmi);
            crtCase.RetirerCreature(fourmi);
            destCase.AjouterCreature(fourmi);
        }


        public Case GetCaseFromFourmi(Fourmi fourmi)
        {
            return CasesList.Where(c => c.GetCreaturesSurCase().Contains(fourmi)).First();
        }

        public Case GetCaseFromPosition(int x, int y)
        {
            return CasesList.Where(c => c.Position.X == x && c.Position.Y == y).First();
        }

        /// <summary>
        /// Get all fourmi in CasesList
        /// </summary>
        /// <returns>All fourmi in CasesList</returns>
        public List<Fourmi> GetAllFourmis()
        {
            var allFourmi = new List<Fourmi>();

            allFourmi.AddRange(CasesList.Where(c => c.GetCreaturesSurCase().Length > 0).SelectMany(c => c.GetCreaturesSurCase()));

            return allFourmi;
        }

        public void SaveDataToXML()
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.ConformanceLevel = ConformanceLevel.Auto;
            setting.Indent = true;
            setting.IndentChars = " ";
            setting.NewLineChars = "\r\n";
            setting.NewLineHandling = NewLineHandling.Replace;

            using (XmlWriter writer = XmlWriter.Create("data.xml", setting))
            {
                writer.WriteStartElement("PlateauManager");
                writer.WriteStartElement("CasesList");
                foreach (var uneCase in CasesList)
                {
                    writer.WriteStartElement("Case");
                    writer.WriteElementString("Type", uneCase.ToString());
                    writer.WriteElementString("X", uneCase.Position.X.ToString());
                    writer.WriteElementString("Y", uneCase.Position.Y.ToString());
                    if (uneCase.Objet != null)
                    {
                        writer.WriteStartElement("Objet");
                        writer.WriteElementString("Type", uneCase.Objet.ToString());
                        writer.WriteElementString("X", uneCase.Objet.Position.X.ToString());
                        writer.WriteElementString("Y", uneCase.Objet.Position.Y.ToString());
                        writer.WriteEndElement();
                    }
                    if (uneCase.Creatures.Where(f => f != null).Count() > 0)
                    {
                        foreach (var fourmi in uneCase.Creatures.Where(f => f != null))
                        {
                            writer.WriteStartElement("Fourmi");
                            writer.WriteElementString("Nom", fourmi.Nom);
                            writer.WriteElementString("Vie", fourmi.Vie.ToString());
                            writer.WriteElementString("X", fourmi.Position.X.ToString());
                            writer.WriteElementString("Y", fourmi.Position.Y.ToString());
                            writer.WriteElementString("Attitude", fourmi.Comportement.ToString());
                            writer.WriteEndElement();
                        }
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }
        }

        public void LoadDataFromXML(string fileName)
        {
            using (XmlReader xmlReader = XmlReader.Create(fileName))
            {
                CasesList = new List<Case>();
                while (xmlReader.ReadToFollowing("Case"))
                {
                    xmlReader.ReadToFollowing("Type");
                    string typeCase = xmlReader.ReadElementContentAsString();
                    xmlReader.ReadToFollowing("X");
                    int x = xmlReader.ReadElementContentAsInt();
                    xmlReader.ReadToFollowing("Y");
                    int y = xmlReader.ReadElementContentAsInt();
                    var myCase = FabriqueSimulation.CreerFabrique("FabriqueCase").CreerCase(typeCase, x, y);
                    xmlReader.MoveToContent();
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Objet")
                    {
                        xmlReader.ReadToFollowing("Type");
                        string typeObjet = xmlReader.ReadElementContentAsString();
                        xmlReader.ReadToFollowing("X");
                        int xObjet = xmlReader.ReadElementContentAsInt();
                        xmlReader.ReadToFollowing("Y");
                        int yObjet = xmlReader.ReadElementContentAsInt();
                        myCase.Objet = FabriqueSimulation.CreerFabrique("FabriqueObjet").CreerObjet(typeObjet, xObjet, yObjet);
                        xmlReader.MoveToContent();
                    }
                    while (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Fourmi")
                    {
                        xmlReader.ReadToFollowing("Nom");
                        string nomFourmi = xmlReader.ReadElementContentAsString();
                        xmlReader.ReadToFollowing("Vie");
                        int vieFourmi = xmlReader.ReadElementContentAsInt();
                        xmlReader.ReadToFollowing("X");
                        int xFourmi = xmlReader.ReadElementContentAsInt();
                        xmlReader.ReadToFollowing("Y");
                        int yFourmi = xmlReader.ReadElementContentAsInt();
                        xmlReader.ReadToFollowing("Attitude");
                        string attitudeFourmi = xmlReader.ReadElementContentAsString();
                        var myFourmi = FabriqueSimulation.CreerFabrique("FabriqueFourmi").CreerFourmi(nomFourmi, xFourmi, yFourmi);
                        myFourmi.Vie = vieFourmi;
                        myFourmi.Comportement = FabriqueSimulation.CreerFabrique("FabriqueAttitude").CreerAttitude(attitudeFourmi);
                        myCase.AjouterCreature(myFourmi);
                        xmlReader.MoveToContent();
                    }
                    CasesList.Add(myCase);
                }
            }
        }
    }
}
