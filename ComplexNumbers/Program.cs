using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex comp1 = new Complex(1, 2);
            Complex comp2 = new Complex(3, 4);

            Console.WriteLine("Zespolona 1: " + Complex.WriteComplex(comp1));
            Console.WriteLine("Zespolona 2: " + Complex.WriteComplex(comp2));

            Console.WriteLine("+: " + Complex.WriteComplex(comp1+comp2));
            Console.WriteLine("-: " + Complex.WriteComplex(comp1 - comp2));
            Console.WriteLine("*: " + Complex.WriteComplex(comp1 * comp2));
            Console.WriteLine("/: " + Complex.WriteComplex(comp1 / comp2));
            Console.WriteLine("con1: " + Complex.WriteComplex(Complex.con(comp1)));
            Console.WriteLine("con2: " + Complex.WriteComplex(Complex.con(comp2)));
            Console.WriteLine("mod1: " + (Complex.mod(comp1)));
            Console.WriteLine("mod2: " + (Complex.mod(comp2)));

            Console.ReadKey();
        }
    }
}
