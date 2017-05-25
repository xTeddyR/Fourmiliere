using System;

namespace FourmilliereAL.Fabriques
{
    public class FabriqueCase : FabriqueFourmilliere
    {
        public override FabriqueCase CreerCase()
        {
            return new FabriqueCase();
        }

        public override FabriqueEnvironnement CreerEnvironnement()
        {
            throw new NotImplementedException();
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