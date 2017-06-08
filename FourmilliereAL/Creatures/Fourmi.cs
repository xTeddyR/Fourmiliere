using System;
using System.Collections.ObjectModel;

namespace FourmilliereAL
{
    public class Fourmi
    {
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
        }

        private void AvanceHasard(int dimX, int dimY)
        {
            int newX = Position.X + Hasard.Next(3) - 1;
            int newY = Position.Y + Hasard.Next(3) - 1;
            if (newX >= 0 && newX < dimX) Position.X = newX;
            if (newY >= 0 && newY < dimY) Position.Y = newY;
        }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}