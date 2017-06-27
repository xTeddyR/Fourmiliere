using System;

namespace FourmilliereAL.Core
{
    public class FabriqueFourmi : Fabrique
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
            throw new NotImplementedException();
        }

        public override Fourmi CreerFourmi(string nom, int x, int y)
        {
            return new Fourmi(nom, x, y);
        }

        public override Objet CreerObjet(string objet, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
