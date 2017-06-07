using System;
using System.Collections.Generic;
using System.Linq;

namespace FourmilliereAL.Fabriques
{
    public class Case
    {
        protected Objet objetSurCase;

        protected Fourmi[] creaturesSurCase;

        public int X { get; set; }
        public int Y { get; set; }

        public Case()
        {
            creaturesSurCase = new Fourmi[2];
        }

        public void AjouterObjet(Objet objet)
        {
            objetSurCase = objet;
        }

        public void RetirerObjet()
        {
            objetSurCase = null;
        }

        public void AjouterCreature(Fourmi creature)
        {
            if(creaturesSurCase[0] == null)
            {
                creaturesSurCase[0] = creature;
            }
            else
            {
                creaturesSurCase[1] = creature;
            }
        }

        public void RetirerCreature(Fourmi creature)
        {
            if (creaturesSurCase[0] == creature)
            {
                creaturesSurCase[0] = null;
                if(creaturesSurCase[1] != null)
                {
                    creaturesSurCase[0] = creaturesSurCase[1];
                }
            }
            else
            {
                creaturesSurCase[1] = null;
            }
        }
    }
}