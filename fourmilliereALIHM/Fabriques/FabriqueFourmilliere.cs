using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Fabriques
{
    public abstract class FabriqueFourmilliere
    {
        public string Name { get; set; }

        public abstract FabriqueCase CreerCase();

        public abstract FabriqueObjet CreerObjet();

        public abstract FabriqueEnvironnement CreerEnvironnement();

        public abstract FabriqueFourmi CreerFourmi();
    }
}
