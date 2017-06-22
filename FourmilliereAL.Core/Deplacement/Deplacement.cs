namespace FourmilliereAL.Core
{
    public class Deplacement
    {
        protected PlateauManager plateauManager;

        protected int dimesionX = Config.GrilleLargeur;
        protected int dimensionY = Config.GrilleHauteur;

        public Deplacement()
        {
            plateauManager = PlateauManager.Instance;
        }

        public virtual void Avance(Fourmi fourmi) { }

        public virtual void Avance(Fourmi fourmi, Location Destination) { }
    }
}
