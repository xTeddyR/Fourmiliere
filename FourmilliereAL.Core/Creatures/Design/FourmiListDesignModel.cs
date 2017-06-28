using System.Collections.Generic;

namespace FourmilliereAL.Core
{
    /// <summary>
    /// Le modele de design de la list de fourmi
    /// </summary>
    public class FourmiListDesignModel : FourmiListViewModel
    {
        #region Singleton

        /// <summary>
        /// Une instance unique du design model
        /// </summary>
        public static FourmiListDesignModel Instance => new FourmiListDesignModel();
        #endregion

        #region Attributs

        /// <summary>
        /// Une liste d'étapes pour le modèle
        /// </summary>
        public List<Etape> Etapes = new List<Etape> {
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

        #endregion

        #region Constructor
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public FourmiListDesignModel()
        {
            FourmisList = new List<FourmiListItemViewModel> {

                new FourmiListItemViewModel {
                    Nom = "Teddy",
                    Vie = 20,
                    ListEtape = Etapes,
                    Comportement=  new AttitudeAucune()
                },

                new FourmiListItemViewModel {
                    Nom = "Jérémy",
                    Vie = 20,
                    ListEtape = Etapes,
                    Comportement=  new AttitudeAucune()
                },

                new FourmiListItemViewModel {
                    Nom = "Julien",
                    Vie = 20,
                    ListEtape = Etapes,
                    Comportement=  new AttitudeAucune()
                },

                new FourmiListItemViewModel {
                    Nom = "Maxime",
                    Vie = 20,
                    ListEtape = Etapes,
                    Comportement=  new AttitudeAucune()
                },

                new FourmiListItemViewModel {
                    Nom = "Warrior",
                    Vie = 20,
                    ListEtape = Etapes,
                    Comportement=  new AttitudeCombattante()
                },

                new FourmiListItemViewModel {
                    Nom = "Bad Ant",
                    Vie = 20,
                    ListEtape = Etapes,
                    Comportement=  new AttitudeEnnemi()
                }
            };
        }

        #endregion

    }
}
