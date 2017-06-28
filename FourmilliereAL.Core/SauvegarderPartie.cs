using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FourmilliereAL.Core
{
    public class SauvegarderPartie
    {
        private PlateauManager plateauManager;
        private Environnement environnement;

        public SauvegarderPartie()
        {
            plateauManager = PlateauManager.Instance;
            environnement = Environnement.Instance;
        }

        public void SaveDataToXML(string fileName)
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.ConformanceLevel = ConformanceLevel.Auto;
            setting.Indent = true;
            setting.IndentChars = " ";
            setting.NewLineChars = "\r\n";
            setting.NewLineHandling = NewLineHandling.Replace;

            using (XmlWriter writer = XmlWriter.Create(fileName, setting))
            {
                writer.WriteStartElement("Fourmiliere");
                writer.WriteStartElement("Environnement");
                writer.WriteElementString("Meteo", environnement.Meteo.Etat.ToString());
                writer.WriteStartElement("Temps");
                writer.WriteElementString("Heure", environnement.Heure.NbHeure.ToString());
                writer.WriteElementString("Minute", environnement.Heure.NbMinute.ToString());
                writer.WriteEndElement(); // </Temps>
                writer.WriteEndElement(); // </Environnement>
                writer.WriteElementString("NbTours", FourmilliereModel.NbTours.ToString());
                writer.WriteStartElement("PlateauManager");
                writer.WriteStartElement("CasesList");
                foreach (var uneCase in plateauManager.CasesList)
                {
                    writer.WriteStartElement("Case");
                    writer.WriteElementString("X", uneCase.Position.X.ToString());
                    writer.WriteElementString("Y", uneCase.Position.Y.ToString());
                    if (uneCase.Objet != null)
                    {
                        writer.WriteStartElement("Objet");
                        writer.WriteElementString("Type", uneCase.Objet.ToString());
                        writer.WriteElementString("X", uneCase.Objet.Position.X.ToString());
                        writer.WriteElementString("Y", uneCase.Objet.Position.Y.ToString());
                        writer.WriteEndElement(); // </Objet>
                    }
                    if (uneCase.GetCreaturesSurCase().Count() > 0)
                    {
                        foreach (var fourmi in uneCase.GetCreaturesSurCase())
                        {
                            writer.WriteStartElement("Fourmi");
                            writer.WriteElementString("Nom", fourmi.Nom);
                            writer.WriteElementString("Vie", fourmi.Vie.ToString());
                            writer.WriteElementString("X", fourmi.Position.X.ToString());
                            writer.WriteElementString("Y", fourmi.Position.Y.ToString());
                            writer.WriteElementString("Attitude", fourmi.Comportement.ToString());
                            writer.WriteEndElement(); // </Fourmi>
                        }
                    }
                    writer.WriteEndElement(); // </Case>
                }
                writer.WriteEndElement(); // </CasesList>
                writer.WriteEndElement(); // </PlateauManager>
                writer.WriteEndElement(); // </Fourmiliere>
                writer.Flush();
            }
        }

        public void LoadDataFromXML(string fileName)
        {
            using (XmlReader xmlReader = XmlReader.Create(fileName))
            {
                xmlReader.ReadToFollowing("Meteo");
                environnement.Meteo.Etat = (MeteoType) Enum.Parse(typeof(MeteoType), xmlReader.ReadElementContentAsString());
                xmlReader.ReadToFollowing("Heure");
                environnement.Heure.NbHeure = xmlReader.ReadElementContentAsInt();
                xmlReader.ReadToFollowing("Minute");
                environnement.Heure.NbMinute = xmlReader.ReadElementContentAsInt();
                xmlReader.ReadToFollowing("NbTours");
                FourmilliereModel.NbTours = xmlReader.ReadElementContentAsInt();
                var casesList = new List<Case>();
                while (xmlReader.ReadToFollowing("Case"))
                {
                    xmlReader.ReadToFollowing("X");
                    int x = xmlReader.ReadElementContentAsInt();
                    xmlReader.ReadToFollowing("Y");
                    int y = xmlReader.ReadElementContentAsInt();
                    var myCase = FabriqueSimulation.CreerFabrique("FabriqueCase").CreerCase(x, y);
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
                    casesList.Add(myCase);
                }
                plateauManager.CasesList = casesList;
            }
        }
    }
}
