using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Qubit
    {
        /// <summary>
        /// Alpha (α = |0>) component of the qubit.
        /// </summary>
        public Complex Alpha;

        /// <summary>
        /// Beta (β = |1>) component of the qubit.
        /// </summary>
        public Complex Beta;

        /// <summary>
        /// Constructs a qubit.
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        public Qubit(Complex alpha, Complex beta)
        {
            Debug.Assert(Math.Pow(alpha.Abs(), 2) + Math.Pow(beta.Abs(), 2) - 1 < 0.000001);
            this.Alpha = alpha;
            this.Beta = beta;
        }

        /// <summary>
        /// |1>
        /// </summary>
        public static readonly Qubit One = new Qubit(Complex.Zero, Complex.One);    // TODO: correct?

        /// <summary>
        /// |0>
        /// </summary>
        public static readonly Qubit Zero = new Qubit(Complex.One, Complex.Zero);   // TODO: correct?

        /// <summary>
        /// [ 0 1 ] [ alpha ]
        /// [ 1 0 ] [ beta  ]
        /// </summary>
        /// <returns></returns>
        public Qubit Not()
        {
            return new Qubit(Beta, Alpha);
        }

        /// <summary>
        /// Hadamard gate
        ///    1    [ 1  1 ]
        /// sqrt(2) [ 1 -1 ]
        /// </summary>
        /// <returns></returns>
        public Qubit Hadamard()
        {
            return new Qubit((Alpha + Beta) / Math.Sqrt(2), (Alpha - Beta) / Math.Sqrt(2));
        }


        /// <summary>
        /// X gate
        /// [ 0  1 ]
        /// [ 1  0 ]
        /// </summary>
        /// <returns></returns>
        public Qubit PauliX()
        {
            return new Qubit(Beta, Alpha);
        }

        /// <summary>
        /// Y gate
        /// [ 0  -i ]
        /// [ i   0 ]
        /// </summary>
        /// <returns></returns>
        public Qubit PauliY()
        {
            return new Qubit(Complex.I * Alpha, -Complex.I * Beta);
        }

        /// <summary>
        /// Z gate
        /// [ 1  0 ]
        /// [ 0 -1 ]
        /// </summary>
        /// <returns></returns>
        public Qubit PauliZ()
        {
            return new Qubit(Alpha, -Beta);
        }

        /// <summary>
        /// Phase shift gate
        /// [ ieΘ   0  ]
        /// [  0   ieΦ ]
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="phi"></param>
        /// <returns></returns>
        public Qubit PhaseShift(double theta, double phi)
        {
            return new Qubit(Complex.Exp(theta) * Alpha, Complex.Exp(phi) * Beta);
        }

        /// <summary>
        /// Controlled not (CNOT) gate.
        /// [ 1 0 0 0 ]
        /// [ 0 1 0 0 ]
        /// [ 0 0 0 1 ]
        /// [ 0 0 1 0 ]
        /// 
        /// The CNOT gate works by combining the two input qubits (control and target) into a vector (of length 4, using tensor product).
        /// Then it uses the assumption that the output control qubit is constant to calculate the target output qubit.
        /// </summary>
        /// <returns>Target qubit affected by the CNOT gate. The target qubit os constant (and is therefore not returned).</returns>
        public static Qubit CNOT(Qubit control, Qubit target)   // TODO: introduce qubit pair? or Qubit vector?
        {
            // First get tensor product of the two qubits
            Complex[] tensorProduct = TensorProduct(control, target);

            // Put result here
            Complex[] result = new Complex[4];

            // Multiply with CNOT gate matrix
            result[0] = tensorProduct[0];
            result[1] = tensorProduct[1];
            result[2] = tensorProduct[3];
            result[3] = tensorProduct[2];

            // Assumptions
            // 1) control output qubit α equals control qubit α
            // 2) control output qubit β equals control qubit β
            // =>
            // result[0] = α_control * α2 => α2 = result[0] / α_control 
            // result[1] = α_control * β2 => β2 = result[1] / α_control
            // => (or, if α_control is zero)
            // result[2] = β_control * α2 => α2 = result[2] / β_control
            // result[3] = β_control * β2 => β2 = result[3] / β_control
            if (control.Alpha != Complex.Zero)
            {
                return new Qubit(result[0] / control.Alpha, result[1] / control.Alpha);
            }
            else
            {
                return new Qubit(result[2] / control.Beta, result[3] / control.Beta);
            }
        }

        /// <summary>
        /// Performs tensor product of two qubit components.
        /// See http://www.quantiki.org/wiki/Tensor_product.
        /// See http://www.cs.miami.edu/~burt/learning/Csc687.041/notes/qgates.html.
        ///                 [ α1 α2 ]
        /// [ α1 ] [ α2 ] = [ α1 β2 ]
        /// [ β1 ] [ β2 ] = [ β1 α2 ]
        ///                 [ β1 β2 ]
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns>Returns an array of four items.</returns>
        private static Complex[] TensorProduct(Qubit q1, Qubit q2)
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

        public override bool Equals(object obj)
        {
            Qubit q = (Qubit)obj;
            return q.Alpha.Equals(Alpha) && q.Beta.Equals(Beta);
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
