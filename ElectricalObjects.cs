using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryElectricalObjects
{
    public abstract class ElectricalObjects
    {

        public abstract double Reactance();

        public abstract double Resistance();


/// <summary>
/// Метод для вычисления полного сопротивления
/// </summary>
/// <returns></returns>
        public virtual double Impedance()
        {
            double r = Reactance();
            double x = Reactance();

            return Math.Sqrt(Math.Pow(r, 2) + Math.Pow(x, 2));
        }
    }
}
