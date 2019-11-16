using System;

namespace DelegatesGenericos
{
    class Program
    {
        //Delegate só pode chamar métodos com a mesma assinatura (retorno e parametros iguais)
        //Criado então um delegate com tipo generico para usar tanto com int como com decimal
        delegate T CalculoMatematico<T>(T a, T b);
        static void Main(string[] args)
        {
            //Agora é só especificar qual o tipo (int ou decimal), que delegate será capaz de utilizar o método (Somar ou SomarDecimal)
            CalculoMatematico<int> calculoMatematico = new CalculoMatematico<int>(Somar);
            CalculoMatematico<decimal> calculoMatematicoDecimal = new CalculoMatematico<decimal>(SomarDecimal);

            Console.WriteLine(calculoMatematico(1, 1));
            //No caso de decimal é obrigatório o uso do M para o compilador saber que e decimal e não um double
            Console.WriteLine(calculoMatematicoDecimal(1.1M, 1.1M));

            //Não é necessário passar o tipo utilizado no delegate para o método InfoDelegate, o compilador trabalha por inferencia, então
            //se calculoMatematico foi criado usando int é int
            InfoDelegate(calculoMatematico);
            //e se calculoMatematicoDecimal foi criado usando decimal é decimal
            InfoDelegate(calculoMatematicoDecimal);
            //se você escrever assim também funciona, mas é escrever código a mais
            //InfoDelegate<int>(calculoMatematico);

            
            //Criando um objeto
            Program p = new Program();
            //Acessando um método não estático
            CalculoMatematico<int> calculoNaoEstatico = new CalculoMatematico<int>(p.SomarNaoEstatico);
            Console.WriteLine(calculoNaoEstatico(1, 1));
            InfoDelegate(calculoNaoEstatico);
            Console.ReadKey();
        }

        //Utilizando generics aqui é póssivel usar tanto com calculoMatematico(que é int) como calculoMatematicoDecimal(que é decimal)
        private static void InfoDelegate<T>(CalculoMatematico<T> calculo)
        {
            //A propriedade Target mostra qual instancia está apontando 
            //Quando vem de calculoMatematico ou calculoMatematicoDecimal fica vazia porque está apontando para métodos estaticos(métodos estáticos não são instanciados)
            //Quando vem de calculoNaoEstatico retorna um valor porque está apontando para um objeto (p)
            Console.WriteLine(calculo.Target);
            //A propriedade Method mostra para qual método o delegate está apontando
            Console.WriteLine(calculo.Method);
        }

        static int Somar(int a, int b)
        {
            return a + b;
        }
        static decimal SomarDecimal(decimal a, decimal b)
        {
            return a + b;
        }

        int SomarNaoEstatico(int a, int b)
        {
            return a + b;
        }

    }
}
