namespace FourmilliereAL.Core
{
    class AttitudeCombattante : Attitude
    {
        public AttitudeCombattante() : base() { }

        public override void ExecuteFourmi(Fourmi self)
        {
            plateauManager.GetCaseFromFourmi(self).GetCreaturesSurCase().ForEach(f => {
                if(f.Comportement.ToString() == "AttitudeEnnemi") {
                    f.Vie = 0;
                }
            });
        }
    }
}
