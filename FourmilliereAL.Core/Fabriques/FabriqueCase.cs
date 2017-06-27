using System;

namespace FourmilliereAL.Core
{
    public class FabriqueCase : Fabrique
    {
        public override Attitude CreerAttitude(string nomAttitude)
        {
            throw new NotImplementedException();
        }

        public override Case CreerCase(string nomCase, int x, int y)
        {
            switch (nomCase)
            {
                case "Eau":
                    return new Eau(x, y);
                case "Herbe":
                    return new Herbe(x, y);
                case "Terrain":
                    return new Terrain(x, y);
                default:
                    return new Case(x, y);
            }
        }

        public override Fourmi CreerFourmi(string nom, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Objet CreerObjet(string objet, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}