using System;
using System.Diagnostics;
using System.Linq;


namespace AlgorytmyGenetyczne
{
    class Qubit
    {
        
        public Complex Alpha; // Alpha |0>
        public Complex Beta; // Beta  |1>

        public Qubit(Complex alpha, Complex beta)
        {
            this.Alpha = alpha;
            this.Beta = beta;
        }

        public static readonly Qubit One = new Qubit(Complex.Zero, Complex.One);    // |1>
        public static readonly Qubit Zero = new Qubit(Complex.One, Complex.Zero);   // |0>

        public Qubit gateH()
        {
            return new Qubit((Alpha + Beta) / Math.Sqrt(2), (Alpha - Beta) / Math.Sqrt(2));
            //    1    [ 1  1 ]
            // sqrt(2) [ 1 -1 ]
        }

        public Qubit gateX()
        {
            return new Qubit(Beta, Alpha);
            // [ 0  1 ]
            // [ 1  0 ]
        }

        public Qubit gateY()
        {
            return new Qubit(Complex.I * Alpha, -Complex.I * Beta);
            // [ 0  -i ]
            // [ i   0 ]
        }

        public Qubit gateZ()
        {
            return new Qubit(Alpha, -Beta);
            // [ 1  0 ]
            // [ 0 -1 ]
        }


        //CNOT gate
        // [ 1 0 0 0 ]
        // [ 0 1 0 0 ]
        // [ 0 0 0 1 ]
        // [ 0 0 1 0 ]

        public static Qubit gateCONT(Qubit q1, Qubit q2) 
        {
            Complex[] Tensor = IloczynTensor(q1, q2);

            Complex[] result = new Complex[4];

            result[0] = Tensor[0];
            result[1] = Tensor[1];
            result[2] = Tensor[3];
            result[3] = Tensor[2];

            if (q1.Alpha != Complex.Zero)
            {
                return new Qubit(result[0] / q1.Alpha, result[1] / q1.Alpha);
            }
            else
            {
                return new Qubit(result[2] / q1.Beta, result[3] / q1.Beta);
            }
        }

        private static Complex[] IloczynTensor(Qubit q1, Qubit q2)
        {
            return new Complex[]
            {
                q1.Alpha * q2.Alpha,
                q1.Alpha * q2.Beta,
                q1.Beta * q2.Alpha,
                q1.Beta * q2.Beta
            };
        }

        public override string ToString()
        {
            var a = Alpha.ToString();
            var b = Beta.ToString();
            if (a.Contains('+') || a.Contains('-')) a = "(" + a + ")";
            if (b.Contains('+') || b.Contains('-')) b = "(" + b + ")";
            return a + "|0> + " + b + "|1>";
        }

        public static bool operator ==(Qubit q1, Qubit q2)
        {
            return q1.Equals(q2);
        }

        public static bool operator !=(Qubit q1, Qubit q2)
        {
            return !q1.Equals(q2);
        }
    }
}
