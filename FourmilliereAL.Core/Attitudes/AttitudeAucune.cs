using System.Linq;

namespace FourmilliereAL.Core
{
    public class AttitudeAucune : Attitude
    {
        public override void ExecuteObjet(Objet destObjet)
        {
            var myCase = plateauManager.CasesList.Where(c => destObjet.Equals(c.Objet)).First();
            var fourmi = myCase.GetCreaturesSurCase()[0];

            switch (destObjet.ToString())
            {
                case "Baton":
                    fourmi.Comportement = FabriqueSimulation.CreerFabrique("FabriqueAttitude").CreerAttitude("AttitudeCombattante");
                    break;
                case "Panier":
                    fourmi.Comportement = FabriqueSimulation.CreerFabrique("FabriqueAttitude").CreerAttitude("AttitudeCueilleuse");
                    break;
                default:
                    break;
            }
            myCase.Objet = null;
        }
    }
}
