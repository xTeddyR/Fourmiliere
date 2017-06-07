using System;

namespace FourmilliereAL.Fabriques
{
    public class FabriqueEnvironnement : FabriqueFourmilliere
    {
        public override Case CreerCase()
        {
            throw new NotImplementedException();
        }

        public override Environnement CreerEnvironnement()
        {
            return new Environnement();
        }

        public override Objet CreerObjet()
        {
            throw new NotImplementedException();
        }
    }
}