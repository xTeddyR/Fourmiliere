using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;


namespace FourmilliereAL.Core
{
    public class FourmilliereModel
    {
        private PlateauManager plateauManager;
        private Deplacement hazard;
        private Deplacement courtChemin;
        private Environnement environnement;

        public string TitreApplication { get; set; }
        public ObservableCollection<Fourmi> FourmisList { get; set; }
        public Fourmi FourmisSelect { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public bool EnCours { get; set; }
        public int VitesseExecution {get;set;}
        public int NbTours { get; set; }

        public FourmilliereModel(ObservableCollection<Fourmi> FourmisList)
        {
            TitreApplication = Config.APPLICATION_TITRE;
            DimensionX = Config.GRILLE_LARGEUR;
            DimensionY = Config.GRILLE_HAUTEUR;
            VitesseExecution = Config.VITESSE_EXECUTION;
            plateauManager = PlateauManager.Instance;
            environnement = Environnement.Instance;
            plateauManager.CreationDesCases();
            NbTours = 0;

            hazard = new AvanceHazard();
            courtChemin = new CourtChemin();
           
            this.FourmisList = FourmisList;
            environnement.Meteo = new Meteo(ref FourmisList);
            environnement.Heure = new Timer(environnement.Meteo);

            AjouterFourmi("Zero", 0, 0);

            AjouteObjet(0, 1, "Baton");
            AjouteObjet(1, 0, "Baton");
            AjouteObjet(1, 1, "Baton");
            AjouteObjet(ConfigFourmi.FOURMILIERE_POSITION_X, ConfigFourmi.FOURMILIERE_POSITION_Y, "Pomme");

            AjouterFourmi("Teddy", 0, 10);
            AjouterFourmi("Jeremy", 10, 0);
            AjouterFourmi("Maxime", 19, 10);
            AjouterFourmi("Julien", 10, 29);
            AjouterFourmi("Warrior", 19, 29, "AttitudeCombattante");
            AjouterFourmi("Bad Ant", 15, 16, "AttitudeEnnemi");
            AjouterFourmi("TestCourtChemin", 1, 3);

        }

        public void AjouterFourmi(string nom, int x, int y, string comportement = "AttitudeAucune")
        {
            var fourmi = FabriqueSimulation.CreerFabrique("FabriqueFourmi").CreerFourmi(nom, x, y);
            fourmi.Comportement = FabriqueSimulation.CreerFabrique("FabriqueAttitude").CreerAttitude(comportement);
            plateauManager.GetCaseFromPosition(fourmi.Position.X, fourmi.Position.Y).AjouterCreature(fourmi);
            FourmisList.Add(fourmi);
        }

        public void AjouteObjet(int x, int y, string objet = "")
        {
            var myObjet = FabriqueSimulation.CreerFabrique("FabriqueObjet").CreerObjet(objet, x, y);
            plateauManager.GetCaseFromPosition(x, y).Objet = myObjet;
        }

        public void AjouterFourmis()
        {
            AjouterFourmi("Fourmis N° " + FourmisList.Count, ConfigFourmi.FOURMILIERE_POSITION_X, ConfigFourmi.FOURMILIERE_POSITION_Y);
            environnement.Meteo.DisplayObservator();
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
            NbTours++;
            Console.WriteLine("nbTours: " + NbTours);

            environnement.Heure.OnNouveauTour();

            Random random = new Random();

            if (NbTours % ConfigFourmi.FOURMI_ENNEMIE_NB_TOURS == 0)
            {
                AjouterFourmi("Bad Ant", 
                    random.Next(1, ConfigFourmi.FOURMILIERE_ROUGE_RANGE_X),
                    random.Next(Config.GRILLE_HAUTEUR - ConfigFourmi.FOURMILIERE_ROUGE_RANGE_Y, Config.GRILLE_HAUTEUR),
                    "AttitudeEnnemi");
            }

            for(int i = 0; i < FourmisList.Count; i++)
            {
                Fourmi actuel = FourmisList[i];

                if (FourmisList[i].Nom == "TestCourtChemin") {

                    Location dest = new Location {
                        X = 3,
                        Y = 1
                    };

                    courtChemin.Avance(actuel, dest);
                } else {
                    hazard.Avance(FourmisList[i]);
                }
                FourmisList[i].Vie--;
                VerifierVieFourmi(FourmisList[i]);

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
            var saveGame = new SauvegarderPartie();
            saveGame.SaveDataToXML();
        }

        public void LoadDataFromXml(string fileName)
        {
            var saveGame = new SauvegarderPartie();
            saveGame.LoadDataFromXML(fileName);
            FourmisList.Clear();
            plateauManager.GetAllFourmis().ForEach(f => FourmisList.Add(f));
        }
    }
}
