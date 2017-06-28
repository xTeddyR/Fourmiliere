using System.Collections.Generic;

namespace FourmilliereAL.Core
{
    /// <summary>
    /// Données de design pour <see cref="FourmiListItemDesignModel"/>
    /// </summary>
    public class FourmiListItemDesignModel : FourmiListItemViewModel
    {
        #region Singleton
        /// <summary>
        /// Une instance unique du modèle de design
        /// </summary>
        public static FourmiListItemDesignModel Instance => new FourmiListItemDesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// Le constructeur par défaut
        /// </summary>
        public FourmiListItemDesignModel()
        {
            Nom = "Fourmiz";
            Vie = 20;
            Comportement = new AttitudeAucune();
            ListEtape = new List<Etape> {
                new Etape {
                tour = 10,
                lieu = "Paris, Fr"
            },

            new Etape {
                tour = 15,
                lieu = "Paris, Fr"
            },

            new Etape {
                tour = 12,
                lieu = "Paris, Fr"
            }
        };

        }

        #endregion
    }
}
