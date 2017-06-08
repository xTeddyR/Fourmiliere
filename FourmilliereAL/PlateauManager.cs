using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL
{
    public sealed class PlateauManager
    {
        private static volatile PlateauManager instance; // volatile empêche l'accès a la variable si le Set est en cours
        private static object syncRoot = new Object();

        public static PlateauManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot) // lock object for MultiThread
                    {
                        if (instance == null)
                            instance = new PlateauManager();
                    }
                }

                return instance;
            }
        }

        public List<Case> CasesList { get; private set; }

        private PlateauManager() { }

        public void CreationDesCases()
        {
            CasesList = new List<Case>();
            var casesFactory = new FabriqueCase();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    CasesList.Add(casesFactory.CreerCase(i, j));
                }
            }
        }

        public void DeplacementCreature(Fourmi fourmi, Case destCase)
        {
            var crtCase = GetCaseDeFourmi(fourmi);
            crtCase.RetirerCreature(fourmi);
            destCase.AjouterCreature(fourmi);
        }

        public Case GetCaseDeFourmi(Fourmi fourmi)
        {
            return CasesList.Where(c => c.GetCreaturesSurCase().Contains(fourmi)).First();
        }
    }
}
