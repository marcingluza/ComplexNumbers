using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Complex
    {
        public double R { get; set; }
        public double I { get; set; }

        private Complex(double _R, double _I)
        {
            R = _R;
            I = _I;
        }

        public static Complex operator +(Complex num1, Complex num2)
        {
            return new Complex(num1.R + num2.R, num2.I + num2.I);
        }

        public static Complex operator -(Complex num1, Complex num2)
        {
            return new Complex(num1.R - num2.R, num2.I - num2.I);
        }

        public static Complex operator *(Complex num1, Complex num2)
        {
            return new Complex(
            num1.R * num2.R - num1.I * num2.I,
            num1.R * num2.I + num1.I * num2.R);
        }

        public static Complex operator /(Complex num1, Complex num2)
        {
            Complex con = new Complex(num1.R, -num2.I);
            num2 *= con;

            Complex numerator = num1 * con;

            return new Complex(
                numerator.R / num2.R,
                numerator.I / num2.R);
        }

        public static Complex con(Complex num1)
        {
            return new Complex(num1.R, -num1.I);
        }

        public static Complex mod(Complex num1)
        {
            return new Complex(num1.R, -num1.I);
        }


    }
}
