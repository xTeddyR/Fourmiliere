using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Core
{
    class AttitudeAucune : Attitude
    {
        public override void ExecuteObjet(Objet destObjet)
        {
            var myCase = plateauManager.CasesList.Where(c => destObjet.Equals(c.Objet)).First();
            var fourmi = myCase.GetCreaturesSurCase()[0];

            var factoryAttitude = new FabriqueAttitude();
            switch (destObjet.ToString())
            {
                case "Baton":
                    fourmi.Comportement = factoryAttitude.CreerAttitude("AttitudeCombattante");
                    break;
                case "Panier":
                    fourmi.Comportement = factoryAttitude.CreerAttitude("AttitudeCueilleuse");
                    break;
                default:
                    break;
            }
            myCase.Objet = null;
        }
    }
}
