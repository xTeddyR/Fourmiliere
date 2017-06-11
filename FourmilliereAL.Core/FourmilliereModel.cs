﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;


namespace FourmilliereAL
{
    public class FourmilliereModel
    {
        private FabriqueFourmi fourmiFactory;
        private PlateauManager plateauManager;

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
            DimensionX = 20;
            DimensionY = 30;
            VitesseExecution = 500;
            plateauManager = PlateauManager.Instance;
            plateauManager.CreationDesCases();

            this.FourmisList = FourmisList;

            fourmiFactory = new FabriqueFourmi();
            AddFourmiWithName("Teddy", 0, 10);
            AddFourmiWithName("Jeremy", 10, 0);
            AddFourmiWithName("Maxime", 19, 10);
            AddFourmiWithName("Julien", 10, 29);

            var fourmi = fourmiFactory.CreerFourmi("Warrior", 19, 29);
            fourmi.Comportement = new AttitudeCombattante();
            plateauManager.CasesList.Where(c => c.Position.X == fourmi.Position.X && c.Position.Y == fourmi.Position.Y).First().AjouterCreature(fourmi);
            
            FourmisList.Add(fourmi);
        }

        public void AddFourmiWithName(string name, int x, int y, Attitude comportement = null)
        {
            var fourmi = fourmiFactory.CreerFourmi(name, x, y);
            if (comportement != null) fourmi.Comportement = comportement;
            plateauManager.GetCaseFromPosition(fourmi.Position.X, fourmi.Position.Y).AjouterCreature(fourmi);
            FourmisList.Add(fourmi);
        }

        public void AjouterFourmis()
        {
            if (plateauManager.GetCaseFromPosition(Config.FourmilierePositionX, Config.FourmilierePositionY).GetCreaturesSurCase().Where(f => f != null).Count() < 2)
            {
                AddFourmiWithName("Fourmis N°" + FourmisList.Count, Config.FourmilierePositionX, Config.FourmilierePositionY);
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
                FourmisList[i].AvanceUnTour(DimensionX, DimensionY);

                SupprimerFourmiMorte(FourmisList[i]);
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

        private void SupprimerFourmiMorte(Fourmi fourmiAVerifier)
        {
            if(fourmiAVerifier.Vie < 0) {
                SupprimerFourmi(fourmiAVerifier);
            }
        }
    }
}