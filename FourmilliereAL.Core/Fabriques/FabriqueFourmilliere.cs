namespace FourmilliereAL.Core
{
    public abstract class FabriqueFourmilliere
    {
        public abstract Fourmi CreerFourmi(string nom,int x, int y);

        public abstract Case CreerCase(int x, int y);

        public abstract Objet CreerObjet(int x, int y);

        public abstract Environnement CreerEnvironnement();
    }
}
