namespace FourmilliereAL.Core
{
    class AttitudeCombattante : Attitude
    {
        public AttitudeCombattante() : base() { }

        public override void ExecuteFourmi(Fourmi self)
        {
            var creatures = plateauManager.GetCaseFromFourmi(self).GetCreaturesSurCase();

            for (int i = 0; i < creatures.Count; i++)
            {
                if (creatures[i].Comportement.ToString() == "AttitudeEnnemi")
                {
                    creatures[i].Vie = 0;
                    //plateauManager.GetCaseFromFourmi(creatures[i]).RetirerCreature(creatures[i]);
                }
            }
        }
    }
}
