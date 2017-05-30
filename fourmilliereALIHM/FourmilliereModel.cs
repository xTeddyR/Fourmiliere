using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fourmilliereALIHM
{
    public class FourmilliereModel
    {
        public string TitreApplication { get; set; }
        public ObservableCollection<Fourmis> FourmisList { get; set; }
        public Fourmis FourmisSelect { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public bool EnCours { get; set; }
        public int VitesseExecution {get;set;}
        public  FourmilliereModel()
        {
            TitreApplication = "Application FourmilliereAL";
            DimensionX = 20;
            DimensionY = 30;
            VitesseExecution = 500;
            FourmisList = new ObservableCollection<Fourmis>();
            FourmisList.Add(new Fourmis("Alain"));
            FourmisList.Add(new Fourmis("Cecile"));
            FourmisList.Add(new Fourmis("Pierre"));
            FourmisList.Add(new Fourmis("Denis"));
        }
        public void AjouterFourmis()
        {
            FourmisList.Add(new Fourmis("Fourmis N°"+ FourmisList.Count));
        }
        public void SupprimerFourmis()
        {
            FourmisList.Remove(FourmisSelect);
        }

        public void TourSuivant()
        {
            foreach(Fourmis fourmis in FourmisList)
            {
                fourmis.AvanceUnTour(DimensionX, DimensionY);
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
