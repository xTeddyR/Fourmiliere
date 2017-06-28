using System;
using System.Linq;

namespace FourmilliereAL.Core
{
    class AvanceHazard : Deplacement
    {
        
        protected static Random Hasard = new Random();
        
        public override void Avance(Fourmi fourmi)
        {
            int newX = fourmi.Position.X + Hasard.Next(3) - 1;
            int newY = fourmi.Position.Y + Hasard.Next(3) - 1;
            bool flag = false;
            if (newX >= 0 && newX < dimesionX) fourmi.Position.X = newX; flag = true;
            if (newY >= 0 && newY < dimensionY) fourmi.Position.Y = newY; flag = true;
            if (flag) plateauManager.DeplacementCreature(fourmi, plateauManager.CasesList.Where(c => c.Position.X == fourmi.Position.X && c.Position.Y == fourmi.Position.Y).First());
        }
    }
}
