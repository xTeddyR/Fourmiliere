using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL
{
    public class FabriqueAttitude
    {
        public Attitude CreerAttitude(string nomAttitude)
        {
            switch (nomAttitude)
            {
                case "AttitudeAucune":
                    return new AttitudeAucune();
                case "AttitudeCombattante":
                    return new AttitudeCombattante();
                case "AttitudeCueilleuse":
                    return new AttitudeCueilleuse();
                case "AttitudeEnnemi":
                    return new AttitudeEnnemi();
                case "AttitudeGarou":
                    return new AttitudeGarou();
                case "AttitudeReine":
                    return new AttitudeReine();
                default:
                    return new AttitudeAucune();
            }
        }
    }
}
