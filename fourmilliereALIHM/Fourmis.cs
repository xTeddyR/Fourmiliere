using System;
using System.Collections.ObjectModel;

namespace fourmilliereALIHM
{
    public class Fourmis
    {
        private static Random Hasard = new Random();
        public string Nom { get; set; }
        public ObservableCollection<Etape> ListEtape { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Fourmis(string v)
        {
            this.Nom = v;
            ListEtape = new ObservableCollection<Etape>();
            X = 10;
            Y = 10;
            int nbEtapes = Hasard.Next(10);
            for(int i = 0; i < nbEtapes; i++)
            {
                ListEtape.Add(new Etape());
            }
        }
        public override string ToString()
        {
            return "Ma fourmis" + this.Nom;
        }

        public void AvanceUnTour(int dimX, int dimY)
        {
            AvanceHasard(dimX, dimY);
            ListEtape.Add(new Etape());
        }

        private void AvanceHasard(int dimX, int dimY)
        {
            int newX = X + Hasard.Next(3) - 1;
            int newY = Y + Hasard.Next(3) - 1;
            if (newX >= 0 && newX < dimX) X = newX;
            if (newY >= 0 && newY < dimY) Y = newY;
        }
    }
}