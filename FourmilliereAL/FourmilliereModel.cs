using FourmilliereAL.Fabriques;
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
        public string TitreApplication { get; set; }
        public ObservableCollection<Fourmi> FourmisList { get; set; }
        public Fourmi FourmisSelect { get; set; }
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
            FourmisList = new ObservableCollection<Fourmi>();
            FourmisList.Add(new Fourmi("Alain"));
            FourmisList.Add(new Fourmi("Cecile"));
            FourmisList.Add(new Fourmi("Pierre"));
            FourmisList.Add(new Fourmi("Denis"));
        }
        public void AjouterFourmis()
        {
            FourmisList.Add(new Fourmi("Fourmis N°"+ FourmisList.Count));
        }
        public void SupprimerFourmis()
        {
            FourmisList.Remove(FourmisSelect);
        }

        public void TourSuivant()
        {
            foreach(Fourmi fourmis in FourmisList)
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
