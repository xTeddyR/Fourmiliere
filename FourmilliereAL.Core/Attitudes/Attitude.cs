using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL
{
    public class Attitude
    {
        protected PlateauManager plateauManager;

        public Attitude()
        {
            plateauManager = PlateauManager.Instance;
        }
        public virtual void ExecuteFourmi(Fourmi destFourmi) { }
        public virtual void ExecuteObjet(Objet destObjet) { }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
