namespace FourmilliereAL.Core
{
    public abstract class Fabrique
    {
        public abstract Attitude CreerAttitude(string nomAttitude);

        public abstract Deplacement CreerDeplacement(string nomDeplacement);

        public abstract Fourmi CreerFourmi(string nom,int x, int y);

        public abstract Case CreerCase(int x, int y);

        public abstract Objet CreerObjet(string objet, int x, int y);
    }
}
