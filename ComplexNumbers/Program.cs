using System;

namespace AlgorytmyKwantowe
{
    class Program
    {
        static void Main(string[] args)
        {
            Zespolona c1 = new Zespolona(1, 3);
            Zespolona c2 = new Zespolona(2, -4);
            Zespolona c3 = new Zespolona(3, 2);
            Zespolona c4 = new Zespolona(4, -1);
            Console.WriteLine("Zespolona c1: "+ c1.ToString());
            Console.WriteLine("Zespolona c2: "+ c2.ToString());
            Zespolona temp = c1 + c2;
            Console.WriteLine("Dodawanie: c1+c2 " + temp);
            temp = c1 - c2;
            Console.WriteLine("Odejmowanie: c1-c2 " + temp);
            temp = c1 / c2;
            Console.WriteLine("Dzielenie: c1/c2 " + temp);
            double temp2 = c1.Abs();
            Console.WriteLine("|c1| " + temp2);
            temp = c1.Conjugate();
            Console.WriteLine("Sprezenie zespolone: c1 " + temp);
            temp2 = c2.Norm();
            Console.WriteLine("||c2|| " + temp2);
            Console.WriteLine("-----------------------------------------");
            Zespolona[] zv1 = new Zespolona[] { c1, c2 };
            Zespolona[] zv2 = new Zespolona[] { c3, c4 };
            Console.WriteLine("Wektor 1");
            Console.WriteLine("|" + zv1[0].ToString() + "|");
            Console.WriteLine("|" + zv1[1].ToString() + "|");
            Console.WriteLine("Wektor 2");
            Console.WriteLine("|" + zv2[0].ToString() + "|");
            Console.WriteLine("|" + zv2[1].ToString() + "|");
            ZespolonyWektor v1 = new ZespolonyWektor(zv1);
            ZespolonyWektor v2 = new ZespolonyWektor(zv2);
            Console.WriteLine("Suma v1 + v2: ");
            ZespolonyWektor testV = v1 + v2;
            Console.WriteLine("|" + testV.ComplexVector[0].ToString() + "|");
            Console.WriteLine("|" + testV.ComplexVector[1].ToString() + "|");

            Console.WriteLine("Roznica v1 - v2: ");
            testV = v1 - v2;
            
            Console.WriteLine("|" + testV.ComplexVector[0].ToString() + "|");
            Console.WriteLine("|" + testV.ComplexVector[1].ToString() + "|");

            Console.WriteLine("Iloczyn salarny v1ov2: ");
            Zespolona testZ = ZespolonyWektor.IloczynSkalarny(v1, v2);
            Console.WriteLine(testZ.ToString());

            Console.WriteLine("-----------------------------------------");
            Kubit X = Kubit.One.gateX();
            Console.WriteLine("Bramka X " + X.ToString());

            Kubit X0 = Kubit.Zero.gateX();
            Console.WriteLine("Bramka X0 " + X0.ToString());

            Kubit Y = Kubit.One.gateY();
            Console.WriteLine("Bramka Y " + Y.ToString());

            Kubit Z = Kubit.One.gateZ();
            Console.WriteLine("Bramka Z " + Z.ToString());

            Kubit H = Kubit.One.gateH();
            Console.WriteLine("Bramka H " + H.ToString());

           // Kubit fi = new Kubit(Zespolona.)



            Kubit q0 = Kubit.Zero;
            Kubit q1 = Kubit.One;
            Console.WriteLine(q0);
            Console.WriteLine(q1);
            Console.WriteLine(Kubit.gateCONT(q0, q0));
            Console.WriteLine(Kubit.gateCONT(q0, q1));
            Console.WriteLine(Kubit.gateCONT(q1, q0));
            Console.WriteLine(Kubit.gateCONT(q1, q1));


            Kubit test1 = Kubit.Zero.gateH();
            Console.WriteLine(Kubit.gateCONT(test1, q0));
            Console.WriteLine(Kubit.gateCONT(test1, q1));
            test1 = Kubit.One.gateH();
            Console.WriteLine(Kubit.gateCONT(test1, q0));
            Console.WriteLine(Kubit.gateCONT(test1, q1));

            Kubit test2 = Kubit.One.gateH();
            Console.WriteLine(Kubit.gateCONT(q0, test2));
            Console.WriteLine(Kubit.gateCONT(q1, test2));

            Console.ReadKey();
        }


    }
}
