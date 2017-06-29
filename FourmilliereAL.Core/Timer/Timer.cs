using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FourmilliereAL.Core
{
    /// <summary>
    /// Une classe gérant le temps écoulé
    /// </summary>
    public class Timer : INotifyPropertyChanged
    {
        public Meteo Meteo { get; set; }
        private int heure;
        private int minute;
        private int NombreMinuteAjouter;

        public int Heure {
            get
            {
                return heure;
            }
            set
            {
                heure = value;
                OnPropertyChanged();
            }
        }
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                minute = value;
                OnPropertyChanged();
            }

        }

        /// <summary>
        /// Le constructeur par défaut
        /// </summary>
        /// <param name="Meteo"></param>
        public Timer(Meteo Meteo)
        {
            this.Meteo = Meteo;
            Heure = TimerConstants.HEURE_DEMARRAGE;
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
            FormaterHeureMinute(AjouterTour());
            VerifierChangementEtat();
            //Console.WriteLine(GetFormattedTime());
            Console.WriteLine(Meteo.Etat.ToString());
        }

        public int AjouterTour()
        {
            int temps = minute;
            temps += NombreMinuteAjouter;

            return temps;
        }

        private void FormaterHeureMinute(int temps)
        {
            FormaterMinute(temps);
            FormaterHeure();
        }

        private void FormaterMinute(int temps)
        {
            if(TimerConstants.MINUTE_PAR_HEURE > temps) {
                Minute = temps;
                return;
            }

            int nbHeure = temps / TimerConstants.MINUTE_PAR_HEURE;
            int nbMinute = temps % TimerConstants.MINUTE_PAR_HEURE;

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
            if(heure >= TimerConstants.HEURE_JOUR && heure < TimerConstants.HEURE_NUIT && Meteo.Etat != MeteoType.Jour) {
                ChangementMeteo(MeteoType.Jour);
                return;
            }

            if (TimerConstants.HEURE_NUIT <= heure || TimerConstants.HEURE_JOUR > heure && Meteo.Etat != MeteoType.Nuit) {
                ChangementMeteo(MeteoType.Nuit);
                return;
            }
        }

        private void ChangementMeteo(MeteoType Type)
        {
            Meteo.Etat = Type;
            Meteo.Notify();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
