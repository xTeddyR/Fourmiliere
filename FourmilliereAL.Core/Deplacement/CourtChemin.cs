using System;

namespace FourmilliereAL.Core
{
    /// <summary>
    /// Calcul le deplacement vers un point donné
    /// </summary>
    class CourtChemin : Deplacement
    {
        /// <summary>
        /// Met à jour la position de la fourmi
        /// </summary>
        /// <param name="fourmi"></param>
        /// <param name="Destination"></param>
        public override void Avance(Fourmi fourmi, Location Destination)
        {
            Location Resultat = new Location() {
                X = fourmi.Position.X - Destination.X,
                Y = fourmi.Position.Y - Destination.Y
            };

            fourmi.Position.X += AjouterDeplacment(Resultat.X);
            fourmi.Position.Y += AjouterDeplacment(Resultat.Y);

            AfficherResultat(fourmi.Position, Destination);
        }

        /// <summary>
        /// Afficher la nouvelle position de la fourmi ainsi que la destination
        /// </summary>
        /// <param name="fourmi"></param>
        /// <param name="dest"></param>
        public void AfficherResultat(Location fourmi, Location dest) 
        {
            Console.WriteLine("Départ : x = " + fourmi.X + " y = " + fourmi.Y);
            Console.WriteLine("Destination : x = " + dest.X + " y = " + dest.Y);
        }

        /// <summary>
        /// Determine si la direction est positive, négative ou nulle
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private int AjouterDeplacment(int pos)
        {
            if (pos > 0) {
                return -1;
            }

            if (pos < 0) {
                return 1;
            }

            return 0;
        }
    }
}

