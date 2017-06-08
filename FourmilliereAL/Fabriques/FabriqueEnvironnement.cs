using System;

namespace FourmilliereAL.Fabriques
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

        public override Objet CreerObjet(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}