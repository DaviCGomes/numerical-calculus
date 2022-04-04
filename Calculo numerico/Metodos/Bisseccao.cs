using System;

namespace Calculo_numerico.Metodos {
    class Bisseccao {
        double erro; //número do erro
        int max; //número máximo de interações
        double a0, b0; //pontos
        string casas; //formato a ser mostrado os resultados

        //Contrutor da classe
        public Bisseccao(double e, int m, double a, double b, string c) {
            erro = e;
            max = m;
            a0 = a;
            b0 = b;
            casas = c;
        }

        //Método limitado por interações
        public void FindZeroMax() {
            //pontos
            double ak; //an
            double bk; //bn
            double xk1; //xn+1

            //valores dos pontos na função
            double fa, fb, fx;

            Console.WriteLine("n\tan\t\tbn\t\tf(an)\t\tf(bn)\t\txn+1\t\tf(xn+1)");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");

            ak = a0;
            bk = b0;

            for(int i = 0; i < max; i++) {
                //média
                xk1 = (bk + ak) / 2;

                fa = Funcao.F(ak);
                fb = Funcao.F(bk);
                fx = Funcao.F(xk1);

                Console.WriteLine(i + "\t" + ak.ToString(casas) + "\t" + bk.ToString(casas) + "\t" + fa.ToString(casas) + "\t" + fb.ToString(casas) + "\t" + xk1.ToString(casas) + "\t" + fx.ToString(casas));

                //Compara se achou a raiz ou compara com o erro
                if(fx == 0 || Math.Abs((bk - ak) / 2) < erro)
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
            double xk1; //xn+1

            //valores dos pontos na função
            double fa, fb, fx;

            Console.WriteLine("n\tan\t\tbn\t\tf(an)\t\tf(bn)\t\txn+1\t\tf(xn+1)");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");

            ak = a0;
            bk = b0;

            int i = 0;
            while (true) {
                //média
                xk1 = (bk + ak) / 2;

                fa = Funcao.F(ak);
                fb = Funcao.F(bk);
                fx = Funcao.F(xk1);

                Console.WriteLine(i + "\t" + ak.ToString(casas) + "\t" + bk.ToString(casas) + "\t" + fa.ToString(casas) + "\t" + fb.ToString(casas) + "\t" + xk1.ToString(casas) + "\t" + fx.ToString(casas));

                //Compara se achou a raiz ou compara com o erro
                if(fx == 0 || Math.Abs((bk - ak) / 2) < erro)
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
