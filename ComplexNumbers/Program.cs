using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Complex comp1 = new Complex(1, 2);
            //Complex comp2 = new Complex(3, 4);
            //Complex comp3 = new Complex(5, 6);

            //Console.WriteLine("Zespolona 1: " + Complex.WriteComplex(comp1));
            //Console.WriteLine("Zespolona 2: " + Complex.WriteComplex(comp2));

            //Console.WriteLine((string)("+: " + Complex.WriteComplex((Complex)(comp1 + comp2))));
            //Console.WriteLine((string)("-: " + Complex.WriteComplex((Complex)(comp1 - comp2))));
            //Console.WriteLine((string)("*: " + Complex.WriteComplex((Complex)(comp1 * comp2))));
            //Console.WriteLine((string)("/: " + Complex.WriteComplex((Complex)(comp1 / comp2))));
            //Console.WriteLine("con1: " + Complex.WriteComplex(Complex.con(comp1)));
            //Console.WriteLine("con2: " + Complex.WriteComplex(Complex.con(comp2)));
            //Console.WriteLine("mod1: " + (Complex.mod(comp1)));
            //Console.WriteLine("mod2: " + (Complex.mod(comp2)));


            //Complex[] complexVector1 = new Complex[2];
            //complexVector1[0] = comp1;
            //complexVector1[1] = comp2;

            //Complex[] complexVector2 = new Complex[2];
            //complexVector2[0] = comp3;
            //complexVector2[1] = comp1;

            //ComplexV complexV1 = new ComplexV(complexVector1);
            //ComplexV complexV2 = new ComplexV(complexVector2);

            //Complex[] temp = ComplexV.AddVectors(complexV1, complexV2);
            //temp = ComplexV.SubVectors(complexV1, complexV2);
            //temp = ComplexV.Multip(complexV1, 8);
            //temp = ComplexV.Multip(complexV2, 3);
            //temp = ComplexV.conV(complexV1, complexV2);


            Qubit q0 = Qubit.Zero;
            Qubit q1 = Qubit.One;
            Console.WriteLine(q0);
            Console.WriteLine(q1);
            Console.WriteLine(Qubit.CNOT(q0, q0));
            Console.WriteLine(Qubit.CNOT(q0, q1));
            Console.WriteLine(Qubit.CNOT(q1, q0));
            Console.WriteLine(Qubit.CNOT(q1, q1));

            Test1();

            // Test with Hadarmard on q0 as control...
            Qubit control = Qubit.Zero.Hadamard();
            Console.WriteLine(Qubit.CNOT(control, q0));
            Console.WriteLine(Qubit.CNOT(control, q1));
            control = Qubit.One.Hadamard();
            Console.WriteLine(Qubit.CNOT(control, q0));
            Console.WriteLine(Qubit.CNOT(control, q1));

            Qubit target = Qubit.One.Hadamard();
            Console.WriteLine(Qubit.CNOT(q0, target));
            Console.WriteLine(Qubit.CNOT(q1, target));

            Console.ReadKey();
        }

        public static void Test1()
        {
            Qubit q0 = Qubit.Zero;
            Qubit q1 = Qubit.One;
            Debug.Assert(Qubit.CNOT(q0, q0) == q0);
            Debug.Assert(Qubit.CNOT(q0, q1) == q1);
            Debug.Assert(Qubit.CNOT(q1, q0) == q1);
            Debug.Assert(Qubit.CNOT(q1, q1) == q0);
        }
    }
}
