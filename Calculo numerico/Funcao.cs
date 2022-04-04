using System;
using MathNet.Numerics;

namespace Calculo_numerico {
    class Funcao {
        public static double F (double a) {
            //Implementação da função desejada
            return  5 - 20 * (Math.Pow(Math.E, -0.2 * a) - Math.Pow(Math.E, -0.75 * a));
        }
        public static double DF(double a) {
            //Deriva a função acima
            return Differentiate.FirstDerivative(F, a);
        }
    }
}
