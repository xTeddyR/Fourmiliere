namespace FourmilliereAL.Core
{
    public class Attitude
    {
        protected PlateauManager plateauManager;

        public Attitude()
        {
            plateauManager = PlateauManager.Instance;
        }
        public virtual void ExecuteFourmi(Fourmi destFourmi) { }
        public virtual void ExecuteObjet(Objet destObjet) { }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
