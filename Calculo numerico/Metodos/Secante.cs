using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_numerico.Metodos {
    class Secante {
        double erro; //número do erro
        int max; //número máximo de interações
        double x; //xn
        double x0; //x0
        char erroTipo; //Qual tipo de erro a ser comparado
        string casas; //formato a ser mostrado os resultados

        //Construtor para o método com parada pelo erro
        public Secante(double e, double x, double x0, char t, string c) {
            erro = e;
            erroTipo = t;
            this.x = x;
            this.x0 = x0;
            casas = c;
        }
        
        //Construtor para o método com parada por interações
        public Secante(double e, int m, double x, double x0, char t, string c) {
            erro = e;
            erroTipo = t;
            this.x = x;
            this.x0 = x0;
            max = m;
            casas = c;
        }

        //Método limitado por interações
        public void FindZeroMax() {
            //pontos
            double _x = x; //xn-1
            double xk = x0; //xm
            double xk1; //xn+1

            //funções
            double _fx; //f(xn-1)
            double fx; //f(xn)
            double fx1; //f(xn+1)

            Console.WriteLine("n\txn-1\t\txn\t\txn+1\t\tf(xn-1)\t\tf(xn)\t\tf(xn+1)");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");

            for(int i = 0; i < max; i++) {
                fx = Funcao.F(xk);
                _fx = Funcao.F(_x);

                xk1 = ((_x * fx) - (xk * _fx)) / (fx - _fx);
                fx1 = Funcao.F(xk1);

                Console.WriteLine(i + "\t" + _x.ToString(casas) + "\t" + xk.ToString(casas) + "\t" + xk1.ToString(casas) + "\t" + _fx.ToString(casas) + "\t" + fx.ToString(casas) + "\t" + fx1.ToString(casas));

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

                _x = xk;
                xk = xk1;
            }
        }

        //Método limitado apenas pelo erro
        public void FindZeroErro() {
            //pontos
            double _x = x; //xn-1
            double xk = x0; //xm
            double xk1; //xn+1

            //funções
            double _fx; //f(xn-1)
            double fx; //f(xn)
            double fx1; //f(xn+1)

            Console.WriteLine("\tn\txn-1\t\txn\t\txn+1\t\tf(xn-1)\t\tf(xn)\t\tf(xn+1)");
            Console.WriteLine("\t------------------------------------------------------------------------------------------------------");

            int i = 0;
            while(true) {
                fx = Funcao.F(xk);
                _fx = Funcao.F(_x);

                xk1 = ((_x * fx) - (xk * _fx)) / (fx - _fx);
                fx1 = Funcao.F(xk1);

                Console.WriteLine("\t" + i + "\t" + _x.ToString(casas) + "\t" + xk.ToString(casas) + "\t" + xk1.ToString(casas) + "\t" + _fx.ToString(casas) + "\t" + fx.ToString(casas) + "\t" + fx1.ToString(casas));

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

                _x = xk;
                xk = xk1;
                i++;
            }
        }
    }
}
