using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_mat_projekt_GUI
{
    internal class Complex
    {
        #region properties
        public double Number0 { get; set; }
        public double Number1 { get; set; }
        #endregion

        #region konstruktor
        public Complex(double num0, double num1)
        {
            Number0 = num0;
            Number1 = num1;
        }

        #endregion

        #region podstawowe działania
        public Complex Conjugate()
        {
            return new Complex(Number0, -1.0 * Number1);
        }
        public double Sum()
        {
            return Math.Pow(Number0, 2) + Math.Pow(Number1, 2);
        }
        public double Modulus()
        {
            return Math.Sqrt(Sum());
        }

        public Complex Reciprocal()
        {
            return (1.0 / Modulus()) * Conjugate();
        }
        #endregion

        #region operatory 
        public static Complex operator *(Complex com0, Complex com1)
        {
            return new Complex(com0.Number0 * com1.Number0 - com0.Number1 * com1.Number1, com0.Number0 * com1.Number1 + com0.Number1 * com1.Number0);
        }
        public static Complex operator *(double alpha, Complex com1)
        {
            return new Complex(alpha * com1.Number0, alpha * com1.Number1);
        }
        public static Complex operator +(Complex com0, Complex com1)
        {
            return new Complex(com0.Number0 + com1.Number0, com0.Number1 + com1.Number1);
        }
        public static Complex operator -(Complex com0, Complex com1)
        {
            return new Complex(com0.Number0 - com1.Number0, com0.Number1 - com1.Number1);
        }
        public static Complex operator /(Complex com0, Complex com1)
        {
            return com0 * com1.Reciprocal();
        }
        #endregion

        #region pozostałe metody
        public List<double> Coordinate()
        {
            List<double> array = new List<double>();
            array.Add(Math.Round(Number0,2));
            array.Add(Math.Round(Number1, 2));
            return array;
        }
        #endregion
    }
}
