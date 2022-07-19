using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryElectricalObjects
{
    public class TransformatorSplitWinding : ElectricalObjects
    {

        private double U;

        public double Unom
        {
            get { return U * 1000; } //приведем кВ к В
            set
            {
                if (value < 0) U = 0;
                else U = value;
            }
        }
        private double S;

        public double Snom
        {
            get { return S * 1000; } //приведем кВт к Вт
            set
            {
                if (value < 0) S = 0;
                else S = value;
            }
        }

        public double Uкз { get; set; }
        public double Pкз { get; set; }
        public double Pxx { get; set; }



        public TransformatorSplitWinding(int U, int S, double Uкз, int Pкз, int Pxx)
        {
            Unom = U;
            Snom = S;
            this.Uкз = Uкз;
            this.Pкз = Pкз;
            this.Pxx = Pxx;
        }

        public override double Reactance()
        {
            
            return 2*Uкз * Math.Pow(Unom, 2) / (100 * Snom);
        }

        public override double Resistance()
        {
            return Pкз * Math.Pow(Unom / Snom, 2);
        }

        public override double Impedance()
        {
            return base.Impedance();
        }
    }
}
