using System;

namespace FourmilliereAL.Fabriques
{
    public class FabriqueCase : FabriqueFourmilliere
    {
        public override Case CreerCase()
        {
            return new Case();
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
            throw new NotImplementedException();
        }
    }
}