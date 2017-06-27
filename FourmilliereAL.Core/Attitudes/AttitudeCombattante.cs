namespace FourmilliereAL.Core
{
    class AttitudeCombattante : Attitude
    {
        public AttitudeCombattante() : base() { }

        public override void ExecuteFourmi(Fourmi destFourmi)
        {
            if (destFourmi.Comportement.ToString().Equals("AttitudeEnnemi"))
            {
                destFourmi.Vie -= 5;
            }
        }
    }
}
