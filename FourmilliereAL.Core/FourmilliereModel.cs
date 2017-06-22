using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;


namespace FourmilliereAL.Core
{
    public class FourmilliereModel
    {
        private FabriqueFourmi fourmiFactory;
        private FabriqueObjet objetFactory;
        private PlateauManager plateauManager;
        private Deplacement deplacementService;
        private Meteo meteo;

        public string TitreApplication { get; set; }
        public ObservableCollection<Fourmi> FourmisList { get; set; }
        public Fourmi FourmisSelect { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public bool EnCours { get; set; }
        public int VitesseExecution {get;set;}
        public FourmilliereModel(ObservableCollection<Fourmi> FourmisList)
        {
            TitreApplication = Config.ApplicationTitle;
            DimensionX = Config.GrilleLargeur;
            DimensionY = Config.GrilleHauteur;
            VitesseExecution = Config.VitesseExecution;
            plateauManager = PlateauManager.Instance;
            plateauManager.CreationDesCases();

            deplacementService = new AvanceHazard();

            this.FourmisList = FourmisList;
            meteo = new Meteo(ref FourmisList);
            fourmiFactory = new FabriqueFourmi();
            objetFactory = new FabriqueObjet();

            AjouterFourmi("Zero", 0, 0);

            AjouteObjet(0, 1, "Baton");
            AjouteObjet(1, 0, "Baton");
            AjouteObjet(1, 1, "Baton");

            AjouterFourmi("Teddy", 0, 10);
            AjouterFourmi("Jeremy", 10, 0);
            AjouterFourmi("Maxime", 19, 10);
            AjouterFourmi("Julien", 10, 29);
            AjouterFourmi("Warrior", 19, 29, "AttitudeCombattante");
            AjouterFourmi("Bad Ant", 15, 16, "AttitudeEnnemi");

        }

        public void AjouterFourmi(string nom, int x, int y, string comportement = "AttitudeAucune")
        {
            var fourmi = fourmiFactory.CreerFourmi(nom, x, y);
            fourmi.Comportement = new FabriqueAttitude().CreerAttitude(comportement);
            plateauManager.GetCaseFromPosition(fourmi.Position.X, fourmi.Position.Y).AjouterCreature(fourmi);
            FourmisList.Add(fourmi);
        }

        public void AjouteObjet(int x, int y, string objet = "")
        {
            var myObjet = objetFactory.CreerObjet(objet, x, y);
            plateauManager.GetCaseFromPosition(x, y).Objet = myObjet;
        }

        public void AjouterFourmis()
        {
            if (plateauManager.GetCaseFromPosition(ConfigFourmi.FourmilierePositionX, ConfigFourmi.FourmilierePositionY).GetCreaturesSurCase().Count() < 2)
            {
                AjouterFourmi("Fourmis N° " + FourmisList.Count, ConfigFourmi.FourmilierePositionX, ConfigFourmi.FourmilierePositionY);
                meteo.DisplayObservator();
            }
        }

        public void SupprimerFourmisSelect()
        {
            plateauManager.GetCaseFromFourmi(FourmisSelect).RetirerCreature(FourmisSelect);
            FourmisList.Remove(FourmisSelect);
        }

        public void SupprimerFourmi(Fourmi fourmiAsupprimer)
        {
            plateauManager.GetCaseFromFourmi(fourmiAsupprimer).RetirerCreature(fourmiAsupprimer);
            FourmisList.Remove(fourmiAsupprimer);

        }

        public void TourSuivant()
        {
            for(int i = 0; i < FourmisList.Count; i++)
            {
                deplacementService.Avance(FourmisList[i], DimensionX, DimensionY);
                var objet = plateauManager.GetCaseFromFourmi(FourmisList[i]).Objet;
                if (objet != null) FourmisList[i].Comportement.ExecuteObjet(objet);
                VerifierVieFourmi(FourmisList[i]);
            }
        }

        public void Stop()
        {
            EnCours = false;
        }

        public void Avance()
        {
            EnCours = true;
            while (EnCours)
            {
                Thread.Sleep(VitesseExecution);
                TourSuivant();
            }
        }

        private void VerifierVieFourmi(Fourmi fourmiAVerifier)
        {
            if(fourmiAVerifier.Vie < 0) {
                SupprimerFourmi(fourmiAVerifier);
            }
        }

        public void SaveDataToXML()
        {
            plateauManager.SaveDataToXML();
        }

        public void LoadDataFromXml(string fileName)
        {
            plateauManager.LoadDataFromXML(fileName);
            FourmisList.Clear();
            plateauManager.GetAllFourmis().ForEach(f => FourmisList.Add(f));
        }
    }
}
