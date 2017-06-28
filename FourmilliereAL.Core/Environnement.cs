using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Core
{
    public class Environnement : INotifyPropertyChanged
    {
        private static Environnement instance;

        private Environnement() { }

        private Meteo meteo;
        private Timer heure;

        public static Environnement Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Environnement();
                }
                return instance;
            }
        }

        public Meteo Meteo
        {
            get
            {
                return meteo;
            }
            set
            {
                meteo = value;
                OnPropertyChanged();
            }
        }
        public Timer Heure
        {
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
