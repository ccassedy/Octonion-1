using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_mat_projekt_GUI
{
    internal class Octonion
    {
        #region properties
        public Quaternion Number0 { get; set; }
        public Quaternion Number1 { get; set; }
        #endregion

        #region konstruktory
        public Octonion(double num0, double num1, double num2, double num3, double num4, double num5, double num6, double num7)
        {
            Number0 = new Quaternion(num0, num1, num2, num3);
            Number1 = new Quaternion(num4, num5, num6, num7);
        }

        public Octonion(Quaternion quat0, Quaternion quat1)
        {
            Number0 = quat0;
            Number1 = quat1;
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

        public Octonion Reciprocal()
        {
            return (1.0 / Modulus()) * Conjugate();
        }

        public Octonion Conjugate()
        {
            return new Octonion(Number0.Conjugate(), (-1.0) * Number1);
        }
        #endregion

        #region operatory
        public static Octonion operator *(Octonion oct0, Octonion oct1)
        {
            return new Octonion(oct0.Number0 * oct1.Number0 - oct1.Number1.Conjugate() * oct0.Number1, oct1.Number1 * oct0.Number0 + oct0.Number1 * oct1.Number0.Conjugate());
        }
        public static Octonion operator *(double alpha, Octonion oct1)
        {
            return new Octonion(alpha * oct1.Number0, alpha * oct1.Number1);
        }
        public static Octonion operator +(Octonion oct0, Octonion oct1)
        {
            return new Octonion(oct0.Number0 + oct1.Number0, oct0.Number1 + oct1.Number1);
        }
        public static Octonion operator -(Octonion oct0, Octonion oct1)
        {
            return new Octonion(oct0.Number0 - oct1.Number0, oct0.Number1 - oct1.Number1);
        }
        public static Octonion operator /(Octonion oct0, Octonion oct1)
        {
            return oct0 * oct1.Reciprocal();
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
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Coordinate().Count(); i++)
            {
                if (Coordinate()[i]!=0)
                {
                    s += $"{Coordinate()[i]}*e{i + 1} ";
                }
                if (i != Coordinate().Count() - 1 && Coordinate()[i + 1] > 0 && s!="")
                {
                    s += "+";
                }

            }
            if (s=="")
            {
                s = "0";
            }
            
            return s;
        }
        #endregion

    }
}
