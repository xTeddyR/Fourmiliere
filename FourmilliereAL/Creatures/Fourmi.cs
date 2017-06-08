using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FourmilliereAL
{
    public class Fourmi
    {
        private PlateauManager plateauManager;

        protected static Random Hasard = new Random();
        public string Nom { get; set; }
        public int Vie { get; set; }
        public ObservableCollection<Etape> ListEtape { get; set; }
        public Location Position { get; set; }
        public Attitude Comportement { get; set; }

        public Fourmi(string v, int x, int y)
        {
            this.Nom = v;
            this.Vie = 20;
            ListEtape = new ObservableCollection<Etape>();
            Position = new Location(x, y);
            plateauManager = PlateauManager.Instance;
            Comportement = new AttitudeAucune();
            int nbEtapes = Hasard.Next(10);
            for(int i = 0; i < nbEtapes; i++)
            {
                ListEtape.Add(new Etape());
            }
        }
        public virtual void AvanceUnTour(int dimX, int dimY)
        {
            AvanceHasard(dimX, dimY);
            ListEtape.Add(new Etape());
            Vie--;
            RegardeVieFourmi();
        }

        private void AvanceHasard(int dimX, int dimY)
        {
            int newX = Position.X + Hasard.Next(3) - 1;
            int newY = Position.Y + Hasard.Next(3) - 1;
            bool flag = false;
            if (newX >= 0 && newX < dimX) Position.X = newX;flag = true;
            if (newY >= 0 && newY < dimY) Position.Y = newY;flag = true;
            if (flag) plateauManager.DeplacementCreature(this, plateauManager.CasesList.Where(c => c.Position.X == Position.X && c.Position.Y == Position.Y).First());
        }

        private void RegardeVieFourmi()
        {
            if (Vie <= 0)
            {
                plateauManager.SupprimerFourmi(this);
            }
        }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}