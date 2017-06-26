using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL
{
    class AvanceInteligent : Deplacement
    {
        public override void Avance(Fourmi fourmi, int dimX, int dimY)
        {
            /*
            if (FourmiY < objetY) { FourmiY++; };
            if (FourmiY > objetY) { FourmiY--; };
            if (FourmiX < objetX) { FourmiX++; };
            if (FourmiX > objetX) { FourmiX--; };*/
        }

        private Double Distance(Location locationA, Location locationB)
        {
            int dx = Math.Abs(locationA.X - locationB.X);
            int dy = Math.Abs(locationA.Y - locationB.Y);
            return Math.Sqrt((dx * dx) + (dy * dy));
        }
    }
}
