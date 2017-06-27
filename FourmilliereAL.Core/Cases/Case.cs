using System.Collections.Generic;
using System.Linq;

namespace FourmilliereAL.Core
{
    public class Case
    {
        protected Objet objetSurCase;

        protected List<Fourmi> creaturesSurCase;
    
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

        public Case(int x, int y)
        {
            creaturesSurCase = new List<Fourmi>();
            Position = new Location(x, y);
        }

        public List<Fourmi> GetCreaturesSurCase()
        {
            return creaturesSurCase.Where(f => f != null).ToList();
        }

        public void AjouterCreature(Fourmi creature)
        {
                creaturesSurCase.Add(creature);
        }

        public void RetirerCreature(Fourmi creature)
        {
            creaturesSurCase.Remove(creature);
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}