using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Complex
    {
        public int R { get; set; }
        public int I { get; set; }

        public Complex(int _R, int _I)
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

        public static double mod(Complex num1)
        {
            double _mod = Math.Sqrt(Math.Pow(num1.R, 2) + Math.Pow(num1.I, 2));
            return _mod;
        }


    }

    class ComplexV
    {
        public Complex[] vector;

        private ComplexV(Complex[] W)
        {
            this.vector = W;
        }

        public static Complex[] AddVectors (ComplexV W, ComplexV V)
        {
            Complex[] add = new Complex[W.vector.Length];
            for(int i=0; i<W.vector.Length; i++)
            {
               // add[i] = new Complex(W.vector[i].R + V.vector[i].R, W.vector[i].I + V.vector[i].I);
                add[i] = W.vector[i] + V.vector[i];
            }

            return add;
        }

        public static Complex[] SubVectors(ComplexV W, ComplexV V)
        {
            Complex[] sub = new Complex[W.vector.Length];
            for (int i = 0; i < W.vector.Length; i++)
            {
                sub[i] = W.vector[i] - V.vector[i];
            }

            return sub;
        }

        public static Complex[] Multip(ComplexV W, int a)
        {
            Complex[] multip = new Complex[W.vector.Length];
            for (int i = 0; i < W.vector.Length; i++)
            {
                multip[i] = new Complex(W.vector[i].R * a, W.vector[i].I * a);
            }

            return multip;
        }

        public static Complex[] conV(ComplexV W, ComplexV V)
        {
            Complex[] multip = new Complex[W.vector.Length];
            for (int i = 0; i < W.vector.Length; i++)
            {
                multip[i] = W.vector[i] * Complex.con(V.vector[i]);
            }

            return multip;
        }
    }
}
