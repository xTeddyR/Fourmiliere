namespace FourmilliereAL.Core
{
    public abstract class Fabrique
    {
        public abstract Attitude CreerAttitude(string nomAttitude);

        public abstract Fourmi CreerFourmi(string nom,int x, int y);

        public abstract Case CreerCase(string nomCase, int x, int y);

        public abstract Objet CreerObjet(string objet, int x, int y);
    }
}
