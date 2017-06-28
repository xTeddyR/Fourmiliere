using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Core
{
    public class Environnement
    {
        private static Environnement instance;

        private Environnement() { }

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

        public Meteo Meteo { get; set; }
        public Timer Heure { get; set; }
    }
}
