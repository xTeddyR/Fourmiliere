namespace FourmilliereAL.Core
{
    class AttitudeEnnemi : Attitude
    {
        public AttitudeEnnemi() : base() { }

        public override void ExecuteFourmi(Fourmi destFourmi)
        {
            if (!destFourmi.Comportement.ToString().Equals("AttitudeEnnemi") && !destFourmi.Comportement.ToString().Equals("AttitudeCombattante"))
            {
                destFourmi.Vie = 0;
            }
        }
    }
}
