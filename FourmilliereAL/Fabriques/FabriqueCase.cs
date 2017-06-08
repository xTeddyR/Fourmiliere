using System;

namespace FourmilliereAL.Fabriques
{
    public class FabriqueCase : FabriqueFourmilliere
    {
        public override Case CreerCase(int x, int y)
        {
            return new Case(x, y);
        }

        public override Environnement CreerEnvironnement()
        {
            throw new NotImplementedException();
        }

        public override Objet CreerObjet(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}