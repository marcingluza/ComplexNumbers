using System;

namespace AlgorytmyGenetyczne
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(1, 3);
            Complex c2 = new Complex(2, -4);
            Console.WriteLine("Zespolona c1: "+ c1.ToString());
            Console.WriteLine("Zespolona c2: "+ c2.ToString());
            Complex temp = c1 + c2;
            Console.WriteLine("Dodawanie: c1+c2 " + temp);
            temp = c1 - c2;
            Console.WriteLine("Odejmowanie: c1-c2 " + temp);
            temp = c1 / c2;
            Console.WriteLine("Dzielenie: c1/c2 " + temp);
            double temp2 = c1.Abs();
            Console.WriteLine("|c1| " + temp2);
            temp = c1.Conjugate();
            Console.WriteLine("Sprezenie zespolone: c1 " + temp);
            temp2 = c2.Induction();
            Console.WriteLine("||c2|| " + temp2);

            Qubit X = Qubit.One.gateX();
            Console.WriteLine("Bramka X " + X.ToString());

            Qubit X0 = Qubit.Zero.gateX();
            Console.WriteLine("Bramka X0 " + X0.ToString());

            Qubit Y = Qubit.One.gateY();
            Console.WriteLine("Bramka Y " + Y.ToString());

            Qubit Z = Qubit.One.gateZ();
            Console.WriteLine("Bramka Z " + Z.ToString());

            Qubit H = Qubit.One.gateH();
            Console.WriteLine("Bramka H " + H.ToString());



            Qubit q0 = Qubit.Zero;
            Qubit q1 = Qubit.One;
            Console.WriteLine(q0);
            Console.WriteLine(q1);
            Console.WriteLine(Qubit.gateCONT(q0, q0));
            Console.WriteLine(Qubit.gateCONT(q0, q1));
            Console.WriteLine(Qubit.gateCONT(q1, q0));
            Console.WriteLine(Qubit.gateCONT(q1, q1));


            Qubit control = Qubit.Zero.gateH();
            Console.WriteLine(Qubit.gateCONT(control, q0));
            Console.WriteLine(Qubit.gateCONT(control, q1));
            control = Qubit.One.gateH();
            Console.WriteLine(Qubit.gateCONT(control, q0));
            Console.WriteLine(Qubit.gateCONT(control, q1));

            Qubit target = Qubit.One.gateH();
            Console.WriteLine(Qubit.gateCONT(q0, target));
            Console.WriteLine(Qubit.gateCONT(q1, target));

            Console.ReadKey();
        }


    }
}
