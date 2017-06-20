using System;

namespace FourmilliereAL
{
    public class FabriqueObjet : FabriqueFourmilliere
    {
        public override Case CreerCase(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Fourmi CreerFourmi(string nom, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Objet CreerObjet(int x, int y)
        {
            return new Objet(x, y);
        }
    }
}