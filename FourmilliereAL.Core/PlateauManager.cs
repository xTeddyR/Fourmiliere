﻿using System;
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

        /// <summary>
        /// Récupération d'une case à partir d'un objet
        /// </summary>
        /// <param name="objet">Objet utilisé pour la recherche</param>
        /// <returns>La case trouvé</returns>
        public Case GetCaseFromObjet(Objet objet)
        {
            return CasesList.Where(c => objet.Equals(c.Objet)).First();
        }

        /// <summary>
        /// Récupération d'une case à partir d'une fourmi
        /// </summary>
        /// <param name="fourmi">Fourmi utilisé pour la recherche</param>
        /// <returns>La case trouvé</returns>
        public Case GetCaseFromFourmi(Fourmi fourmi)
        {
            return CasesList.Where(c => c.GetCreaturesSurCase().Contains(fourmi)).First();
        }

        /// <summary>
        /// Récupération d'une case à partir de coordonnées X et Y
        /// </summary>
        /// <param name="x">Coordonnée X utilisé pour la recherche</param>
        /// <param name="y">Coordonnée Y utilisé pour la recherche</param>
        /// <returns>La case trouvé</returns>
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

        /// <summary>
        /// Get all objet in CasesList
        /// </summary>
        /// <returns>All objet in CasesList</returns>
        public List<Objet> GetAllObjet()
        {
            var allObjet = new List<Objet>();

            allObjet.AddRange(CasesList.Where(c => c.Objet != null).Select(c => c.Objet));

            return allObjet;
        }
    }
}
