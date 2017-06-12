using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace FourmilliereAL
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
            var casesFactory = new FabriqueCase();
            for (int i = 0; i < Config.GrilleLargeur; i++)
            {
                for (int j = 0; j < Config.GrilleHauteur; j++)
                {
                    CasesList.Add(casesFactory.CreerCase(i, j));
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

        public void SaveDataToXML()
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.ConformanceLevel = ConformanceLevel.Auto;

            using (XmlWriter writer = XmlWriter.Create("data.xml", setting))
            {
                writer.WriteStartElement("PlateauManager");
                writer.WriteStartElement("CasesList");
                foreach (var uneCase in CasesList)
                {
                    writer.WriteStartElement("Case");
                    writer.WriteElementString("X", uneCase.Position.X.ToString());
                    writer.WriteElementString("Y", uneCase.Position.Y.ToString());
                    if (uneCase.Objet != null)
                    {
                        writer.WriteStartElement("Objet");
                        writer.WriteElementString("X", uneCase.Objet.Position.X.ToString());
                        writer.WriteElementString("Y", uneCase.Objet.Position.Y.ToString());
                        writer.WriteEndElement();
                    }
                    if (uneCase.Creatures.Where(f => f != null).Count() > 0)
                    {
                        writer.WriteStartElement("Creatures");
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
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }
        }
    }
}
