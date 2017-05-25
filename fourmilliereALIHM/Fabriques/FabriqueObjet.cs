using System;

namespace FourmilliereAL.Fabriques
{
    public class FabriqueObjet : FabriqueFourmilliere
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
            throw new NotImplementedException();
        }

        public override FabriqueObjet CreerObjet()
        {
            return new FabriqueObjet();
        }
    }
}