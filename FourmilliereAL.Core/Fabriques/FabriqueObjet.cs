using System;

namespace FourmilliereAL.Core
{
    public class FabriqueObjet : Fabrique
    {
        public override Attitude CreerAttitude(string nomAttitude)
        {
            throw new NotImplementedException();
        }

        public override Case CreerCase(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Fourmi CreerFourmi(string nom, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Objet CreerObjet(string objet, int x, int y)
        {
            switch (objet)
            {
                case "Baton":
                    return new Baton(x, y);
                case "Panier":
                    return new Panier(x, y);
                case "Pomme":
                    return new Pomme(x, y);
                default:
                    return null;
            }
        }

        public override Deplacement CreerDeplacement(string nomDeplacement)
        {
            throw new NotImplementedException();
        }
    }
}