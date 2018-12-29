using System;
using System.Diagnostics;

namespace ComplexNumbers
{
    class Program
    {
        static void Main(string[] args)
        {


            Qubit q0 = Qubit.Zero;
            Qubit q1 = Qubit.One;
            Console.WriteLine(q0);
            Console.WriteLine(q1);
            Console.WriteLine(Qubit.gateCONT(q0, q0));
            Console.WriteLine(Qubit.gateCONT(q0, q1));
            Console.WriteLine(Qubit.gateCONT(q1, q0));
            Console.WriteLine(Qubit.gateCONT(q1, q1));

            // Test with gateH on q0 as control...
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
