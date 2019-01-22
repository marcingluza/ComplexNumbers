using System;
using System.Linq;


namespace AlgorytmyKwantowe
{
    class Kubit
    {
        
        public Zespolona Alpha; // Alpha |0>
        public Zespolona Beta; // Beta  |1>

        public Kubit(Zespolona alpha, Zespolona beta)
        {
            this.Alpha = alpha;
            this.Beta = beta;
        }

        public static readonly Kubit One = new Kubit(Zespolona.Zero, Zespolona.One);    // |1>
        public static readonly Kubit Zero = new Kubit(Zespolona.One, Zespolona.Zero);   // |0>

        public Kubit gateH()
        {
            return new Kubit((Alpha + Beta) / Math.Sqrt(2), (Alpha - Beta) / Math.Sqrt(2));
        }

        public Kubit gateX()
        {
            return new Kubit(Beta, Alpha);
        }

        public Kubit gateY()
        {
            return new Kubit(Zespolona.I * Alpha, -Zespolona.I * Beta);
        }

        public Kubit gateZ()
        {
            return new Kubit(Alpha, -Beta);
        }


        //CNOT gate
        // [ 1 0 0 0 ]
        // [ 0 1 0 0 ]
        // [ 0 0 0 1 ]
        // [ 0 0 1 0 ]

        public static Kubit gateCONT(Kubit q1, Kubit q2) 
        {
            Zespolona[] Tensor = Rejestry(q1, q2);

            Zespolona[] result = new Zespolona[4];

            result[0] = Tensor[0];
            result[1] = Tensor[1];
            result[2] = Tensor[3];
            result[3] = Tensor[2];

            if (q1.Alpha != Zespolona.Zero)
            {
                return new Kubit(result[0] / q1.Alpha, result[1] / q1.Alpha);
            }
            else
            {
                return new Kubit(result[2] / q1.Beta, result[3] / q1.Beta);
            }
        }

        private static Zespolona[] Rejestry(Kubit q1, Kubit q2)
        {
            return new Zespolona[]
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

        public static bool operator ==(Kubit q1, Kubit q2)
        {
            return q1.Equals(q2);
        }

        public static bool operator !=(Kubit q1, Kubit q2)
        {
            return !q1.Equals(q2);
        }
    }
}
