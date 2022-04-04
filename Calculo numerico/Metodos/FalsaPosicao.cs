using System;

namespace Calculo_numerico.Metodos {
    class FalsaPosicao {
        double erro; //número do erro
        int max; //número máximo de interações
        double a0, b0; //pontos
        char erroTipo; //Qual tipo de erro a ser comparado
        string casas; //formato a ser mostrado os resultados

        //Construtor
        public FalsaPosicao (double e, int m, double a, double b, char t, string c) {
            erro = e;
            max = m;
            a0 = a;
            b0 = b;
            erroTipo = t;
            casas = c;
        }

        //Método limitado por interações
        public void FindZeroMax() {
            //pontos
            double ak; //an
            double bk; //bn
            double xk; //xn
            double xk1 = 0; //xn+1

            //valores dos pontos na função
            double fa, fb, fx;

            Console.WriteLine("n\tan\t\tbn\t\tf(an)\t\tf(bn)\t\txn+1\t\tf(xn+1)");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");

            ak = a0;
            bk = b0;

            for(int i = 0; i < max; i++) {
                xk = xk1;

                fa = Funcao.F(ak);
                fb = Funcao.F(bk);

                //média ponderada
                xk1 = ((ak * Math.Abs(fb)) + (bk * Math.Abs(fa))) / (Math.Abs(fb) + Math.Abs(fa));
                fx = Funcao.F(xk1);

                Console.WriteLine(i + "\t" + ak.ToString(casas) + "\t" + bk.ToString(casas) + "\t" + fa.ToString(casas) + "\t" + fb.ToString(casas) + "\t" + xk1.ToString(casas) + "\t" + fx.ToString(casas));

                //Verifica se a raiz foi achado
                if(fx == 0)
                    return;

                //Verifica qual tipo de erro a ser usado e o compara com o erro informado
                if(erroTipo == 'a' && Math.Abs(xk1 - xk) < erro)
                        return;
                
                if(erroTipo == 'r' && Math.Abs((xk1 - xk)/xk1) < erro)
                        return;

                if(erroTipo == 'f' && Math.Abs(fx) < erro)
                    return;

                if((fa * fx) > 0)
                    ak = xk1;
                else
                    bk = xk1;
            }

        }

        //Método limitado apenas pelo erro
        public void FindZeroErro() {
            //pontos
            double ak; //an
            double bk; //bn
            double xk; //xn
            double xk1 = 0; //xn+1

            //valores dos pontos na função
            double fa, fb, fx;

            Console.WriteLine("n\tan\t\tbn\t\tf(an)\t\tf(bn)\t\txn+1\t\tf(xn+1)");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");

            ak = a0;
            bk = b0;

            int i = 0;
            while(true) {
                xk = xk1;
                fa = Funcao.F(ak);
                fb = Funcao.F(bk);

                //média ponderada
                xk1 = ((ak * Math.Abs(fb)) + (bk * Math.Abs(fa))) / (Math.Abs(fb) + Math.Abs(fa));
                fx = Funcao.F(xk1);

                Console.WriteLine(i + "\t" + ak.ToString(casas) + "\t" + bk.ToString(casas) + "\t" + fa.ToString(casas) + "\t" + fb.ToString(casas) + "\t" + xk1.ToString(casas) + "\t" + fx.ToString(casas));

                //Verifica se a raiz foi achado
                if(fx == 0)
                    return;

                //Verifica qual tipo de erro a ser usado e o compara com o erro informado
                if(erroTipo == 'a' && Math.Abs(xk1 - xk) < erro)
                    return;

                if(erroTipo == 'r' && Math.Abs((xk1 - xk) / xk1) < erro)
                    return;

                if(erroTipo == 'f' && Math.Abs(fx) < erro)
                    return;

                i++;

                if((fa * fx) > 0)
                    ak = xk1;
                else
                    bk = xk1;
            } 

        }
    }
}
