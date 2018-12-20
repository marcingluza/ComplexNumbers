using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Complex
    {
        public double Real;
        public double Imaginary;

        public Complex(double real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public Complex(Complex c)
        {
            this.Real = c.Real;
            this.Imaginary = c.Imaginary;
        }

        public Complex(double real)
        {
            this.Real = real;
            this.Imaginary = 0;
        }

        public static readonly Complex I = new Complex(0, 1);
        public static readonly Complex Zero = new Complex(0, 0);
        public static readonly Complex One = new Complex(1, 0);

        public static Complex operator -(Complex c)
        {
            return new Complex(-c.Real, -c.Imaginary);
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public static implicit operator Complex(double real)
        {
            return new Complex(real);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary, c1.Real * c2.Imaginary + c1.Imaginary * c2.Real);
        }

        public static Complex operator /(Complex c, double divisor)
        {
            return new Complex(c.Real / divisor, c.Imaginary / divisor);
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            return c1 * c2.Conjugate() / (c2.Real * c2.Real + c2.Imaginary * c2.Imaginary);
        }

        public double Abs()
        {
            return Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        }

        public Complex Conjugate()
        {
            return new Complex(Real, -Imaginary);
        }

        /// <summary>
        /// Create complex from Euler's formula.
        /// </summary>
        /// <param name="radians">Radians in radians</param>
        /// <returns>cos(x) + i*sin(x)</returns>
        public static Complex Exp(double radians)
        {
            return new Complex(Math.Cos(radians), Math.Sin(radians));
        }

        public static bool operator ==(Complex c1, Complex c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Complex c1, Complex c2)
        {
            return !c1.Equals(c2);
        }

        public override bool Equals(object obj)
        {
            Complex c = (Complex)obj;
            return c.Real == Real && c.Imaginary == Imaginary;
        }

        // Override the ToString() method to display a complex number 
        // in the traditional format:
        public override string ToString()
        {
            string temp = "";
            if (Real != 0)
            {
                temp += string.Format("{0}", Real);
            }
            if (Imaginary != 0)
            {
                if (Imaginary < 0)
                {
                    temp += string.Format("-{0}i", -Imaginary);
                }
                else
                {
                    if (temp != "")
                    {
                        temp += string.Format("+{0}i", Imaginary);
                    }
                    else
                    {
                        temp += string.Format("{0}i", Imaginary);
                    }
                }
            }
            return temp;
        }
    }
}