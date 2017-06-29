using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Core
{
    public class FabriqueSimulation
    {
        // Fabrique Abstraite qui fabrique les fabriques
        public static Fabrique CreerFabrique(string nomFabrique)
        {
            switch (nomFabrique)
            {
                case "FabriqueAttitude":
                    return new FabriqueAttitude();
                case "FabriqueCase":
                    return new FabriqueCase();
                case "FabriqueFourmi":
                    return new FabriqueFourmi();
                case "FabriqueObjet":
                    return new FabriqueObjet();
                case "FabriqueDeplacement":
                    return new FabriqueDeplacement();
                default:
                    return null;
            }
        }
    }
}
