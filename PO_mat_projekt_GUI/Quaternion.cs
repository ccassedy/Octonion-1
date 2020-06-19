using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_mat_projekt_GUI
{
    internal class Quaternion
    {
        #region properties
        public Complex Number0 { get; set; }
        public Complex Number1 { get; set; }
        #endregion

        #region konstruktory
        public Quaternion(double num0, double num1, double num2, double num3)
        {
            Number0 = new Complex(num0, num1);
            Number1 = new Complex(num2, num3);
        }

        public Quaternion(Complex com0, Complex com1)
        {
            Number0 = com0;
            Number1 = com1;
        }
        #endregion

        #region podstawowe działania
        public double Sum()
        {
            return Number0.Sum() + Number1.Sum();
        }
        public double Modulus()
        {
            return Math.Sqrt(Sum());
        }

        public Quaternion Reciprocal()
        {
            return (1.0 / Modulus()) * Conjugate();
        }

        public Quaternion Conjugate()
        {
            return new Quaternion(Number0.Conjugate(), (-1.0) * Number1);
        }

        #endregion

        #region operatory 
        public static Quaternion operator *(Quaternion quat0, Quaternion quat1)
        {
            return new Quaternion(quat0.Number0 * quat1.Number0 - quat0.Number1 * quat1.Number1.Conjugate(), quat0.Number0 * quat1.Number1 + quat0.Number1 * quat1.Number0.Conjugate());
        }
        public static Quaternion operator *(double alpha, Quaternion quat1)
        {
            return new Quaternion(alpha * quat1.Number0, alpha * quat1.Number1);
        }
        public static Quaternion operator +(Quaternion quat0, Quaternion quat1)
        {
            return new Quaternion(quat0.Number0 + quat1.Number0, quat0.Number1 + quat1.Number1);
        }
        public static Quaternion operator -(Quaternion quat0, Quaternion quat1)
        {
            return new Quaternion(quat0.Number0 - quat1.Number0, quat0.Number1 - quat1.Number1);
        }
        public static Quaternion operator /(Quaternion quat0, Quaternion quat1)
        {
            return quat0 * quat1.Reciprocal();
        }

        #endregion

        #region pozostałe metody 
        public List<double> Coordinate()
        {
            List<double> array = new List<double>();
            array.AddRange(Number0.Coordinate());
            array.AddRange(Number1.Coordinate());
            return array;
        }
        #endregion
    }


}
