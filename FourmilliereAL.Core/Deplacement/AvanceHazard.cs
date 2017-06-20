using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL { 
    class AvanceHazard : Deplacement
    {
        
        protected static Random Hasard = new Random();
        
        public override void Avance(Fourmi fourmi,int dimX, int dimY)
        {
            
            int newX = fourmi.Position.X + Hasard.Next(3) - 1;
            int newY = fourmi.Position.Y + Hasard.Next(3) - 1;
            bool flag = false;
            if (newX >= 0 && newX < dimX) fourmi.Position.X = newX; flag = true;
            if (newY >= 0 && newY < dimY) fourmi.Position.Y = newY; flag = true;
            if (flag) plateauManager.DeplacementCreature(fourmi, plateauManager.CasesList.Where(c => c.Position.X == fourmi.Position.X && c.Position.Y == fourmi.Position.Y).First());
        }
    }
}
