using System;
namespace FourmilliereAL.Core
{
    /// <summary>
    /// Une classe gérant le temps écoulé
    /// </summary>
    public class Timer
    {
        public Meteo Meteo { get; set; }
        private int Heure;
        private int Minute;
        private int NombreMinuteAjouter;

        public int NbHeure { get { return Heure; } set { Heure = value; } }
        public int NbMinute { get { return Minute; } set { Minute = value; } }

        /// <summary>
        /// Le constructeur par défaut
        /// </summary>
        /// <param name="Meteo"></param>
        public Timer(Meteo Meteo)
        {
            this.Meteo = Meteo;
            Heure = 0;
            Minute = 0;
            NombreMinuteAjouter = TimerConstants.MINUTE_PAR_HEURE / 2;
        }

        /// <summary>
        /// Retourne l'heure actuel en string au format Heure : Minute
        /// </summary>
        /// <returns></returns>
        public string GetFormattedTime()
        {
            return "" + Heure.ToString() + " : " + Minute.ToString(); 
        }

        public void OnNouveauTour()
        {
            AjouterTour();
            FormaterHeureMinute();
            VerifierChangementEtat();
            Console.WriteLine(GetFormattedTime());
            Console.WriteLine(Meteo.Etat.ToString());
        }

        public void AjouterTour()
        {
            Minute += NombreMinuteAjouter;

        }

        private void FormaterHeureMinute()
        {
            FormaterMinute();
            FormaterHeure();
        }

        private void FormaterMinute()
        {
            if(TimerConstants.MINUTE_PAR_HEURE > Minute) {
                return;
            }

            int nbHeure = Minute / TimerConstants.MINUTE_PAR_HEURE;
            int nbMinute = Minute % TimerConstants.MINUTE_PAR_HEURE;

            if(nbMinute == TimerConstants.MINUTE_PAR_HEURE) {
                Minute = 0;
            } else {
                Minute = nbMinute;
            }

            Heure += nbHeure;
        }

        private void FormaterHeure()
        {
            if(Heure == TimerConstants.FORMAT_HEURE) {
                Heure = 0;
                return;
            }

            if(Heure > TimerConstants.FORMAT_HEURE) {
                Heure = Heure % TimerConstants.FORMAT_HEURE;
            }
        }

        /// <summary>
        /// Verifie si un changement de Météo doit s'effectuer
        /// </summary>
        public void VerifierChangementEtat()
        {
            if(TimerConstants.HEURE_JOUR <= Heure && Meteo.Etat != MeteoType.Jour) {
                ChangementMeteo(MeteoType.Jour);
                return;
            }

            if (TimerConstants.HEURE_NUIT <= Heure || TimerConstants.HEURE_JOUR > Heure && Meteo.Etat != MeteoType.Nuit) {
                ChangementMeteo(MeteoType.Nuit);
                return;
            }
        }

        private void ChangementMeteo(MeteoType Type)
        {
            Meteo.Etat = Type;
        }


    }
}
