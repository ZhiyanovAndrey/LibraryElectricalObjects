using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryElectricalObjects
{
    public class OverHeadPowerLine : ElectricalObjects
    {

        private double resistivity;  //сопротивление постоянному току одного километра провода
        private double reactivity;  //индуктивное сопротивление прямой последовательности зависит от напряжения
        private double length;
        private const int n = 3;    //для ВЛ трех фазной системы




        public OverHeadPowerLine(double resistivity, double reactivity, double length)
        {
            this.resistivity = resistivity;
            this.reactivity = reactivity;
            this.length = length;
        }

        public  override double Resistance()
        {

            double R =  resistivity * length/n; //расчет активного сопротивления для ВЛ
            return R;
        }
        
        
        public override double Reactance()
        {
            double X = reactivity * length/n; //расчет реактивного сопротивления для ВЛ
            return X;
        }

        public override double Impedance()
        {
            return base.Impedance();
        }




    }

}
