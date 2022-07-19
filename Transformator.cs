﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryElectricalObjects
{
    public class Transformator : ElectricalObjects
    {


        private double U;

        public double Unom
        {
            get { return U*1000; } //приведем кВ к В
            set
            {
                if (value < 0) U = 0;
                else U = value;
            }
        }
        private double S;

        public double Snom
        {
            get { return S*1000; } //приведем кВт к Вт
            set
            {
                if (value < 0) S = 0;
                else S = value;
            }
        }

        public double Uкз { get; set; }
        public double Pкз { get; set; }
        public double Pxx { get; set; }



        public Transformator(int U, int S, double Uкз, int Pкз, int Pxx)
        {
            Unom = U;
            Snom = S;
            this.Uкз = Uкз;
            this.Pкз = Pкз;
            this.Pxx = Pxx;
        }

        public override double Resistance()
        {
            return Pкз * Math.Pow(Unom / Snom, 2);
        }
        public override double Reactance()
        {

            return Uкз * Math.Pow(Unom, 2) / (100 * Snom);
                
        }
        public override double Impedance()
        {
            return base.Impedance();
        }

        //перегруженный метод создает массив точек для построения графика нагрузочных потерь трансформатора

        
        /// <summary>
        /// возвращает массив значений для переменной мощности осьХ
        /// </summary>
        /// <param name="step" шаг в киловольтах ></param>
        /// <param name="length"></param>
    
        public static double[] LoadLossesTrans(int step, double length)
        {

            double[] VariablePower = new double[(int)(length / step) + 1];

            for (int i = 0; i < VariablePower.Length; i++)
            {
                VariablePower[i] = i * step;
            }

            return VariablePower;
        }

        /// <summary>
        /// Метод возвращает массив значений нагрузочных потерь основного трансформатора
        /// </summary>
        /// <param name="step">Шаг в киловольтах</param>
        /// <param name="firstTrans">Параметры основного трансформатора</param>
          public static double[] LoadLossesTrans(int step, Transformator firstTrans)
        {

            double[] ArrOneTrans = new double[(int)(firstTrans.Snom * 2 / step) + 1];


            for (int i = 0; i < ArrOneTrans.Length; i++)
            {
               
                ArrOneTrans[i] = Math.Pow(i * step / firstTrans.Snom, 2) * firstTrans.Pкз + firstTrans.Pxx;

            }

            return ArrOneTrans;
        }

        // осьY 
        /// <summary>
        /// Метод возвращает массив значений нагрузочных потерь двух параллельных трансформаторов
        /// </summary>
        /// <param name="step">Шаг в киловольтах</param>
        /// <param name="firstTrans">Параметры основного трансформатора</param>
        /// <param name="SecondTrans">Параметры основного дополнительного трансформатора</param>
             public static double[] LoadLossesTrans(int step, Transformator firstTrans, Transformator SecondTrans)
        {

            double[] ArrTwoTrans = new double[(int)(firstTrans.Snom * 2 / step) + 1];

            for (int i = 0; i < ArrTwoTrans.Length; i++)
            {
                ArrTwoTrans[i] = Math.Pow(i * step / firstTrans.Snom, 2) * (firstTrans.Pкз * SecondTrans.Pкз / (firstTrans.Pкз + SecondTrans.Pкз)) + (firstTrans.Pxx + SecondTrans.Pxx);

            }

            return ArrTwoTrans;

        }
        //метод для нахождения точки пересечения двух графиков

        //public double CrossLine(int step, Transformator one, Transformator two)
        //{
        //    double[] arr1 = Transformator.LoadLossesTrans(step, one);
        //    double[] arr2 = Transformator.LoadLossesTrans(step, two);

        //    return a;
        //}
    }
}

