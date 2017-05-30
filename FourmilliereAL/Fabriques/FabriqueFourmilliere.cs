using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Fabriques
{
    public abstract class FabriqueFourmilliere
    {

        public abstract Case CreerCase();

        public abstract Objet CreerObjet();

        public abstract Environnement CreerEnvironnement();

        public abstract Creature CreerCreature();
    }
}
