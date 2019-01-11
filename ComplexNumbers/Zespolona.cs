using System;

namespace AlgorytmyKwantowe
{
    class Zespolona
    {
        public double Re;
        public double Im;

        public Zespolona(double real, double imaginary) //konstruktor dla 2x double
        {
            this.Re = real;
            this.Im = imaginary;
        }

        public Zespolona(Zespolona c)  //konstruktor dla zesp
        {
            this.Re = c.Re;
            this.Im = c.Im;
        }

        public Zespolona(double real)  //konstruktor dla real
        {
            this.Re = real;
            this.Im = 0;
        }

        public static readonly Zespolona I = new Zespolona(0, 1);
        public static readonly Zespolona Zero = new Zespolona(0, 0);
        public static readonly Zespolona One = new Zespolona(1, 0);

        public static Zespolona operator -(Zespolona c)  //negacja
        {
            return new Zespolona(-c.Re, -c.Im);
        }

        public static Zespolona operator +(Zespolona c1, Zespolona c2) //dodawanie
        {
            return new Zespolona(c1.Re + c2.Re, c1.Im + c2.Im);
        }

        public static Zespolona operator -(Zespolona c1, Zespolona c2) //odejmowanie
        {
            return new Zespolona(c1.Re - c2.Re, c1.Im - c2.Im);
        }

        public static Zespolona operator *(Zespolona c1, Zespolona c2) //mnozenie
        {
            return new Zespolona(c1.Re * c2.Re - c1.Im * c2.Im, c1.Re * c2.Im + c1.Im * c2.Re);
        }

        public static Zespolona operator /(Zespolona c, double n) //dzielenie przez n
        {
            return new Zespolona(c.Re / n, c.Im / n);
        }

        public static Zespolona operator /(Zespolona c1, Zespolona c2) // dzielenie
        {
            return c1 * c2.Conjugate() / (c2.Re * c2.Re + c2.Im * c2.Im);
        }

        public double Abs() //wartosc bezwzgledna
        {
            return Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2));
        }

        public Zespolona Conjugate() //sprezenie zespolone
        {
            return new Zespolona(Re, -Im);
        }

        public double Norm()//indukcja
        {
            double temp = Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2));
            return temp;
        }

        public static bool operator ==(Zespolona c1, Zespolona c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Zespolona c1, Zespolona c2)
        {
            return !c1.Equals(c2);
        }

        public override bool Equals(object obj)
        {
            Zespolona c = (Zespolona)obj;
            return c.Re == Re && c.Im == Im;
        }

        public override string ToString()
        {
            string temp = "";
            if (Re != 0)
            {
                temp += string.Format("{0}", Re);
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