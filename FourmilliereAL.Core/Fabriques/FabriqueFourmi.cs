using System;

namespace FourmilliereAL.Core
{
    public class FabriqueFourmi : Fabrique
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

        public void RandomizeCoodinates()
        {
            Random random = new Random();
            coordX = random.Next(1, 20);
            coordY = random.Next(1, 30);
        }

        public override Fourmi CreerFourmi(string nom, int x, int y)
        {
            return new Fourmi(nom, x, y);
        }

        public override Objet CreerObjet(string objet, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
