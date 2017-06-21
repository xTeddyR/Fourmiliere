using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Core
{
    class AttitudeCombattante : Attitude
    {
        public AttitudeCombattante() : base() { }

        public override void ExecuteFourmi(Fourmi destFourmi)
        {
            if (destFourmi.Comportement.ToString().Equals("AttitudeEnnemi"))
            {
                destFourmi.Vie -= 5;
            }
        }
    }
}
