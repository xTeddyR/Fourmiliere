using System;

namespace FourmilliereAL.Fabriques
{
    public class FabriqueObjet : FabriqueFourmilliere
    {
        public override Case CreerCase()
        {
            throw new NotImplementedException();
        }

        public override Creature CreerCreature()
        {
            throw new NotImplementedException();
        }

        public override Environnement CreerEnvironnement()
        {
            throw new NotImplementedException();
        }

        public override Objet CreerObjet()
        {
            return new Objet();
        }
    }
}