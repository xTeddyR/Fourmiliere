using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL.Core
{
    class FourmiliereItem
    {

        private static FourmiliereItem instance = null;
        private static readonly object padlock = new object();
        public Location Position { get; set; }

        private FourmiliereItem(int x, int y)
        {
        }

        public static FourmiliereItem Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FourmiliereItem(ConfigFourmi.FourmilierePositionX, ConfigFourmi.FourmilierePositionY);
                    }
                    return instance;
                }
            }
        }
    }
}
