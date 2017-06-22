using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Core
{
    public class FabriqueAttitude : Fabrique
    {
        public override Attitude CreerAttitude(string nomAttitude)
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

        public override Case CreerCase(string nomCase, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Fourmi CreerFourmi(string nom, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Objet CreerObjet(string objet, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
