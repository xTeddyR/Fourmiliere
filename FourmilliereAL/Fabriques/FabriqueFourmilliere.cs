using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Fabriques
{
    public abstract class FabriqueFourmilliere
    {

        public abstract Case CreerCase(int x, int y);

        public abstract Objet CreerObjet(int x, int y);

        public abstract Environnement CreerEnvironnement();
    }
}
