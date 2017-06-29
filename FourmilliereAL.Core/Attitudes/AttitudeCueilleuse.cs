using System.Linq;

namespace FourmilliereAL.Core
{
    public class AttitudeCueilleuse : Attitude
    {
        public override void ExecuteObjet(Objet destObjet)
        {
            if (destObjet.ToString().Equals("Pomme"))
            {
                var fourmi = plateauManager.CasesList.Where(c => destObjet.Equals(c.Objet)).First().GetCreaturesSurCase().First();
                fourmi.Objet = destObjet;
            }
        }
    }
}
