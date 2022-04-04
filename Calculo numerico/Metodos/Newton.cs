using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_numerico.Metodos {
    class Newton {
        double erro; //número do erro
        int max; //número máximo de interações
        double x0; //x0
        char erroTipo; //Qual tipo de erro a ser comparado
        string casas; //formato a ser mostrado os resultados

        //Construtor para o método com parada pelo erro
        public Newton(double e, double x, char t, string c) {
            erro = e;
            erroTipo = t;
            x0 = x;
            casas = c;
        }
        
        //Construtor para o método com parada por interações
        public Newton(double e, int m, double x, char t, string c) {
            erro = e;
            erroTipo = t;
            x0 = x;
            max = m;
            casas = c;
        }

        //Método limitado por interações
        public void FindZeroMax() {
            //pontos
            double xk = x0; //xn
            double xk1; //xn+1

            //funções
            double fx; //f(x)
            double dfx; //f'(x)

            Console.WriteLine("n\txn\t\tf(xn)\t\tf'(xn)");
            Console.WriteLine("--------------------------------------------------------");

            for(int i = 0; i < max; i++) {
                fx = Funcao.F(xk);
                dfx = Funcao.DF(xk);

                xk1 = xk - (fx / dfx);

                Console.WriteLine(i + "\t" + xk.ToString(casas) + "\t" + fx.ToString(casas) + "\t" + dfx.ToString(casas));

                //Verifica se a raiz foi achado
                if(xk == 0)
                    return;

                //Verifica qual tipo de erro a ser usado e o compara com o erro informado
                if(erroTipo =='a' && Math.Abs(xk1 - xk) < erro)
                    return;
                if(erroTipo == 'r' && Math.Abs((xk1 - xk)/xk1)< erro)
                    return;
                if(erroTipo == 'f' && Math.Abs(fx) < erro)
                    return;

                xk = xk1;
            }
        }

        //Método limitado apenas pelo erro
        public void FindZeroErro() {
            //pontos
            double xk = x0; //xn
            double xk1; //xn+1

            //funções
            double fx; //f(x)
            double dfx; //f'(x)

            Console.WriteLine("n\txn\t\tf(xn)\t\tf'(xn)");
            Console.WriteLine("--------------------------------------------------------");

            int i = 0;
            while(true) {
                fx = Funcao.F(xk);
                dfx = Funcao.DF(xk);

                xk1 = xk - (fx / dfx);

                Console.WriteLine(i + "\t" + xk.ToString(casas) + "\t" + fx.ToString(casas) + "\t" + dfx.ToString(casas));

                //Verifica se a raiz foi achado
                if(xk == 0)
                    return;

                //Verifica qual tipo de erro a ser usado e o compara com o erro informado
                if(erroTipo == 'a' && Math.Abs(xk1 - xk) < erro)
                    return;
                if(erroTipo == 'r' && Math.Abs((xk1 - xk) / xk1) < erro)
                    return;
                if(erroTipo == 'f' && Math.Abs(fx) < erro)
                    return;

                xk = xk1;
                i++;
            }
        }
    }
}
