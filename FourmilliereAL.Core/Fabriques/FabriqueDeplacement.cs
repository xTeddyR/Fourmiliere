using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Core.Fabriques
{
    public class FabriqueDeplacement : Fabrique
    {
        public override Attitude CreerAttitude(string nomAttitude)
        {
            throw new NotImplementedException();
        }

        public override Case CreerCase(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Deplacement CreerDeplacement(string nomDeplacement)
        {
            switch (nomDeplacement)
            {
                case "AvanceHazard":
                    return new AvanceHazard();
                case "CourtChemin":
                    return new CourtChemin();
                default:
                    return null;
            }
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
