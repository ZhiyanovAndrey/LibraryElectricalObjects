using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryElectricalObjects
{
    public abstract class ElectricalObjects
    {

        /// <summary>
        /// Возвращает активное сопротивление
        /// </summary>
        public abstract double Resistance();

        /// <summary>
        /// Возвращает реактивное сопротивление
        /// </summary>
        public abstract double Reactance();

        /// <summary>
        /// Возвращает полное сопротивление
        /// </summary>
        public virtual double Impedance()
        {
            double r = Resistance();
            double x = Reactance();

            return Math.Sqrt(Math.Pow(r, 2) + Math.Pow(x, 2));
        }
    }
}
