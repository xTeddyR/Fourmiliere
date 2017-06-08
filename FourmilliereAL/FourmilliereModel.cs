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

            var fourmi = fourmiFactory.CreerFourmi("Warrior", 19, 29);
            fourmi.Comportement = new AttitudeCombattante();
            plateauManager.CasesList.Where(c => c.Position.X == fourmi.Position.X && c.Position.Y == fourmi.Position.Y).First().AjouterCreature(fourmi);
            
            FourmisList.Add(fourmi);
        }

        public void AddFourmiWithName(string name, int x, int y)
        {
            var fourmi = fourmiFactory.CreerFourmi(name, x, y);
            plateauManager.CasesList.Where(c => c.Position.X == fourmi.Position.X && c.Position.Y == fourmi.Position.Y).First().AjouterCreature(fourmi);
            FourmisList.Add(fourmi);
        }
        public void AjouterFourmis()
        {
            AddFourmiWithName("Fourmis N°" + FourmisList.Count, 10, 10);
        }
        public void SupprimerFourmis()
        {
            var caseARetirerFourmi = plateauManager.CasesList.Where(c => c.GetCreaturesSurCase().Contains(FourmisSelect)).First();
            caseARetirerFourmi.RetirerCreature(FourmisSelect);
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
