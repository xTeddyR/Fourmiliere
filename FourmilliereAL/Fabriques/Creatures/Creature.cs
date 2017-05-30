using System;
using System.Collections.ObjectModel;

namespace FourmilliereAL.Fabriques
{
    public class Creature
    {
        protected static Random Hasard = new Random();
        public string Nom { get; set; }
        public int Vie { get; set; }
        public ObservableCollection<Etape> ListEtape { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public virtual void AvanceUnTour(int dimX, int dimY)
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