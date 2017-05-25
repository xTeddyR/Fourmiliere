using System;
using System.Collections.Generic;

namespace FourmilliereAL.Fabriques
{
    public class Case
    {
        protected Objet objetSurCase;

        protected List<Creature> creaturesSurCase;

        public int X { get; set; }
        public int Y { get; set; }

        public Case()
        {
            creaturesSurCase = new List<Creature>();
        }

        public void AjouterObjet(Objet objet)
        {
            objetSurCase = objet;
        }

        public void RetirerObjet()
        {
            objetSurCase = null;
        }

        public void AjouterCreature(Creature creature)
        {
            creaturesSurCase.Add(creature);
        }

        public void RetirerCreature(Creature creature)
        {
            creaturesSurCase.Remove(creature);
        }
    }
}