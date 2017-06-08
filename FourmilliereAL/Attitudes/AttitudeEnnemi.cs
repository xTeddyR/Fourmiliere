using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL
{
    class AttitudeEnnemi : Attitude
    {
        public AttitudeEnnemi() : base() { }

        public override void ExecuteFourmi(Fourmi destFourmi)
        {
            destFourmi.Vie -= 5;
            if (destFourmi.Vie <= 0)
            {
                plateauManager.SupprimerFourmi(destFourmi);
            }
        }
    }
}
