using System.Collections.Generic;

namespace FourmilliereAL.Core { 

    /// <summary>
    /// un View Model pour chaque item de la liste de fourmis
    /// </summary>
    public class FourmiListItemViewModel
    {
        /// <summary>
        /// Le nom à afficher d'un item
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// La vie d'un item
        /// </summary>
        public int Vie { get; set; }

        /// <summary>
        /// La liste des étapes d'un item
        /// </summary>
        public List<Etape> ListEtape { get; set; }

        /// <summary>
        /// Le comportement d'un item
        /// </summary>
        public Attitude Comportement { get; set; }
    }
}
