using System;

namespace FourmilliereAL.Fabriques
{
    public class FabriqueFourmi : FabriqueFourmilliere
    {
        public override FabriqueCase CreerCase()
        {
            throw new NotImplementedException();
        }

        public override FabriqueEnvironnement CreerEnvironnement()
        {
            throw new NotImplementedException();
        }

        public override FabriqueFourmi CreerFourmi()
        {
            return new FabriqueFourmi();
        }

        public override FabriqueObjet CreerObjet()
        {
            throw new NotImplementedException();
        }
    }
}