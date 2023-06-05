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



        /// <summary>
        /// Присвоить значения из справочника для воздушной или кабельной линии: Сопротивление постоянному току, Индуктивное сопротивление прямой последовательности, Длина линии.
        /// </summary>
        /// <param name="resistivity">Сопротивление постоянному току</param>
        /// <param name="reactivity">Индуктивное сопротивление прямой последовательности</param>
        /// <param name="length">длина линии</param> 
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

        /// <summary>
        /// Возвращает сопротивление системы из указанных напряжения и мощности системы
        /// </summary>
        /// <param name="U">напряжение в кВ</param>
        /// <param name="Ssys">мощность в МВА</param>
        /// <returns></returns>
        public static double SystemRessistance(double U, double Ssys)
        {
            return U / Math.Sqrt(3) * Ssys;
        }


    }

}
