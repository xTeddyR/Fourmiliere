using System;

namespace FourmilliereAL.Core
{
    class FabriqueFourmi : FabriqueFourmilliere
    {
        public override Case CreerCase(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Fourmi CreerFourmi(string nom, int x, int y)
        {
            return new Fourmi(nom, x, y);
        }

        public override Objet CreerObjet(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
