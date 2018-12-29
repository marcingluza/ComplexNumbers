using System;

namespace ComplexNumbers
{
    class Complex
    {
        public double R;
        public double Im;

        public Complex(double real, double imaginary) //konstruktor dla 2x double
        {
            this.R = real;
            this.Im = imaginary;
        }

        public Complex(Complex c)  //konstruktor dla zesp
        {
            this.R = c.R;
            this.Im = c.Im;
        }

        public Complex(double real)  //konstruktor dla real
        {
            this.R = real;
            this.Im = 0;
        }

        public static readonly Complex I = new Complex(0, 1);
        public static readonly Complex Zero = new Complex(0, 0);
        public static readonly Complex One = new Complex(1, 0);

        public static Complex operator -(Complex c)  //negacja
        {
            return new Complex(-c.R, -c.Im);
        }

        public static Complex operator +(Complex c1, Complex c2) //dodawanie
        {
            return new Complex(c1.R + c2.R, c1.Im + c2.Im);
        }

        public static Complex operator -(Complex c1, Complex c2) //odejmowanie
        {
            return new Complex(c1.R - c2.R, c1.Im - c2.Im);
        }

        public static Complex operator *(Complex c1, Complex c2) //mnozenie
        {
            return new Complex(c1.R * c2.R - c1.Im * c2.Im, c1.R * c2.Im + c1.Im * c2.R);
        }

        public static Complex operator /(Complex c, double n) //dzielenie przez n
        {
            return new Complex(c.R / n, c.Im / n);
        }

        public static Complex operator /(Complex c1, Complex c2) // dzielenie
        {
            return c1 * c2.Conjugate() / (c2.R * c2.R + c2.Im * c2.Im);
        }

        public double Abs() //wartosc bezwzgledna
        {
            return Math.Sqrt(Math.Pow(R, 2) + Math.Pow(Im, 2));
        }

        public Complex Conjugate() //sprezenie zespolone
        {
            return new Complex(R, -Im);
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
            return c.R == R && c.Im == Im;
        }

        public override string ToString()
        {
            string temp = "";
            if (R != 0)
            {
                temp += string.Format("{0}", R);
            }
            if (Im != 0)
            {
                if (Im < 0)
                {
                    temp += string.Format("-{0}i", -Im);
                }
                else
                {
                    if (temp != "")
                    {
                        temp += string.Format("+{0}i", Im);
                    }
                    else
                    {
                        temp += string.Format("{0}i", Im);
                    }
                }
            }
            return temp;
        }
    }
}