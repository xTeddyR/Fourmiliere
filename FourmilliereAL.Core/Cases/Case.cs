﻿using System.Linq;

namespace FourmilliereAL.Core
{
    public class Case
    {
        protected Objet objetSurCase;

        protected Fourmi[] creaturesSurCase;
    
        public Location Position;

        public Objet Objet
        {
            get
            {
                return objetSurCase;
            }
            set
            {
                objetSurCase = value;
            }
        }

        public Fourmi[] Creatures
        {
            get
            {
                return creaturesSurCase;
            }
        }

        public Case(int x, int y)
        {
            creaturesSurCase = new Fourmi[2];
            Position = new Location(x, y);
        }

        public Fourmi[] GetCreaturesSurCase()
        {
            return creaturesSurCase.Where(f => f != null).ToArray();
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

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}