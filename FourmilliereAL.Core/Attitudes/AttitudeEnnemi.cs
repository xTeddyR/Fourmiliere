namespace FourmilliereAL.Core
{
    class AttitudeEnnemi : Attitude
    {
        public AttitudeEnnemi() : base() { }

        public override void ExecuteFourmi(Fourmi self)
        {
            var creatures = plateauManager.GetCaseFromFourmi(self).GetCreaturesSurCase();

            for (int i = 0; i < creatures.Count; i++)
            {
                if (!creatures[i].Comportement.ToString().Equals("AttitudeEnnemi") && !creatures[i].Comportement.ToString().Equals("AttitudeCombattante"))
                {
                    creatures[i].Vie = 0;
                    //plateauManager.GetCaseFromFourmi(creatures[i]).RetirerCreature(creatures[i]);
                }
            }
        }
    }
}
