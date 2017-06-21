using System;

namespace FourmilliereAL.Core
{
    public class FabriqueEnvironnement : FabriqueFourmilliere
    {
        public override Case CreerCase(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Environnement CreerEnvironnement()
        {
            return new Environnement();
        }

        public override Fourmi CreerFourmi(string nom, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Objet CreerObjet(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}