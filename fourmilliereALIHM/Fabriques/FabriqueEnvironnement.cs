using System;

namespace FourmilliereAL.Fabriques
{
    public class FabriqueEnvironnement : FabriqueFourmilliere
    {
        public override FabriqueCase CreerCase()
        {
            throw new NotImplementedException();
        }

        public override FabriqueEnvironnement CreerEnvironnement()
        {
            return new FabriqueEnvironnement();
        }

        public override FabriqueFourmi CreerFourmi()
        {
            throw new NotImplementedException();
        }

        public override FabriqueObjet CreerObjet()
        {
            throw new NotImplementedException();
        }
    }
}