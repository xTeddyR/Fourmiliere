namespace FourmilliereAL.Core
{
    public class Deplacement
    {
        protected PlateauManager plateauManager;

        protected int dimesionX = Config.GRILLE_LARGEUR;
        protected int dimensionY = Config.GRILLE_HAUTEUR;

        public Deplacement()
        {
            plateauManager = PlateauManager.Instance;
        }

        public virtual void Avance(Fourmi fourmi) { }

        public virtual void Avance(Fourmi fourmi, Location Destination) { }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
