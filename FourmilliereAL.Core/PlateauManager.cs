using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace FourmilliereAL.Core
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

        public List<Case> CasesList { get; set; }

        private PlateauManager() { }

        public void CreationDesCases()
        {
            CasesList = new List<Case>();
            for (int i = 0; i < Config.GRILLE_LARGEUR; i++)
            {
                for (int j = 0; j < Config.GRILLE_HAUTEUR; j++)
                {
                    CasesList.Add(FabriqueSimulation.CreerFabrique("FabriqueCase").CreerCase(i, j));
                }
            }
        }

        public void DeplacementCreature(Fourmi fourmi, Case destCase)
        {
            var crtCase = GetCaseFromFourmi(fourmi);
            crtCase.RetirerCreature(fourmi);
            destCase.AjouterCreature(fourmi);
        }


        public Case GetCaseFromFourmi(Fourmi fourmi)
        {
            return CasesList.Where(c => c.GetCreaturesSurCase().Contains(fourmi)).First();
        }

        public Case GetCaseFromPosition(int x, int y)
        {
            return CasesList.Where(c => c.Position.X == x && c.Position.Y == y).First();
        }

        /// <summary>
        /// Get all fourmi in CasesList
        /// </summary>
        /// <returns>All fourmi in CasesList</returns>
        public List<Fourmi> GetAllFourmis()
        {
            var allFourmi = new List<Fourmi>();

            allFourmi.AddRange(CasesList.Where(c => c.GetCreaturesSurCase().Count() > 0).SelectMany(c => c.GetCreaturesSurCase()));

            return allFourmi;
        }
    }
}
