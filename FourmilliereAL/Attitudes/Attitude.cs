using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmilliereAL
{
    public class Attitude
    {
        public virtual void Execute(Fourmi fourmi) { }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
