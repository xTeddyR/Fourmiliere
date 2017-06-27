using System;

namespace FourmilliereAL.Core
{
    public class FabriqueObjet : Fabrique
    {
        private int coordX = 0;
        private int coordY = 0;

        public override Attitude CreerAttitude(string nomAttitude)
        {
            throw new NotImplementedException();
        }

        public override Case CreerCase(string nomCase, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Fourmi CreerFourmi(string nom, int x, int y)
        {
            throw new NotImplementedException();
        }

        public void RandomizeCoodinates()
        {
            Random random = new Random();
            coordX = random.Next(1, Config.GRILLE_LARGEUR);
            coordY = random.Next(1, Config.GRILLE_HAUTEUR);
        }

        public override Objet CreerObjet(string objet, int x, int y)
        {
            coordX = x;
            coordY = y;

            /*Console.WriteLine("Avant Randomize");
            Console.WriteLine("CoordX: " + coordX + " / CoordY: " + coordY);*/

            while(coordX == ConfigFourmi.FOURMILIERE_POSITION_X || coordY == ConfigFourmi.FOURMILIERE_POSITION_Y) {
                RandomizeCoodinates();
            }

            /*Console.WriteLine("Après Randomize");
            Console.WriteLine("CoordX: " + coordX + " / CoordY: " + coordY);*/

            switch (objet)
            {
                case "Baton":
                    return new Baton(coordX, coordY);
                case "Panier":
                    return new Panier(coordX, coordY);
                case "Pomme":
                    return new Pomme(coordX, coordY);
                default:
                    return new Objet(coordX, coordY);
            }
        }
    }
}