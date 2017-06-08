using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public FourmilliereModel()
        {
            TitreApplication = "Application FourmilliereAL";
            DimensionX = 20;
            DimensionY = 30;
            VitesseExecution = 500;
            plateauManager = PlateauManager.Instance;
            plateauManager.CreationDesCases();

            FourmisList = new ObservableCollection<Fourmi>();

            fourmiFactory = new FabriqueFourmi();
            AddFourmiWithName("Teddy", 0, 10);
            AddFourmiWithName("Jeremy", 10, 0);
            AddFourmiWithName("Maxime", 19, 10);
            AddFourmiWithName("Julien", 10, 29);
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
            AddFourmiWithName("Fourmis N°" + FourmisList.Count, 10, 10);
        }

        public void SupprimerFourmis()
        {
            plateauManager.GetCaseFromFourmi(FourmisSelect).RetirerCreature(FourmisSelect);
            FourmisList.Remove(FourmisSelect);
        }

        public void TourSuivant()
        {
            for(int i = 0; i < FourmisList.Count; i++)
            {
                FourmisList[i].AvanceUnTour(DimensionX, DimensionY);
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
    }
}
