using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL
{
    public class Deplacement
    {
        protected PlateauManager plateauManager;

        public Deplacement()
        {
            plateauManager = PlateauManager.Instance;
        }

        public virtual void Avance(Fourmi fourmi, int dimX, int dimY) { }
    }
}
