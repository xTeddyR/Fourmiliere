namespace FourmilliereAL.Core
{
    class AttitudeEnnemi : Attitude
    {
        public AttitudeEnnemi() : base() { }

        public override void ExecuteFourmi(Fourmi destFourmi)
        {
            destFourmi.Vie -= 5;
        }
    }
}
