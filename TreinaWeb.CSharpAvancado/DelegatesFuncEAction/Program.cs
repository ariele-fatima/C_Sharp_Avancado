using System;

namespace DelegatesFuncEAction
{
    class Program
    {
        //Delegate só pode chamar métodos com a mesma assinatura (retorno e parametros iguais)

        //Antes estavamos criando delegates da seguinte forma
        //delegate T CalculoMatematico<T>(T a, T b);
        static void Main(string[] args)
        {

            //Criando um objeto
            Program p = new Program();

            //E usavamos o delegate da seguinte forma
            //CalculoMatematico<int> calculoNaoEstatico = new CalculoMatematico<int>(p.Somar);

            //***********
            //   FUNC
            //***********
            //No delegate do tipo Func, primeiro vc especifica o tipo de cada paramentro depois o retornodo método
            //O delegate do tipo Func é usado em métodos que retornam algo

            //o método Somar recebe dois parametros int e retorna um int (então Func<int, int, int>)
            Func<int, int, int> calculoNaoEstatico = p.Somar;
            Console.WriteLine(calculoNaoEstatico(1, 1));

            //o método NumerosEmString recebe dois parametros int e retorna uma string (então Func<int, int, string>)
            Func<int, int, string> calculo = p.NumerosEmString;
            Console.WriteLine(calculo(1, 1));

            //o método RetornaString não recebe parametro e retorna uma string (então Func<string>)
            Func<string> retornaString = p.RetornaString;
            Console.WriteLine(retornaString());


            //***********
            //   ACTION
            //***********
            //No delegate do tipo Action, vc especifica o tipo de cada paramentro
            //O delegate do tipo Action é usado em métodos que não retornam algo (void)

            //o método ImprimirResultado recebe um parametro int (então Action<int>)
            Action<int> impressao = p.ImprimirResultado;
            impressao(2);

            //o método ImprimirResultadoInfo recebe um parametro int e um paramentro string (então Action<int, string>)
            Action<int, string> impressaoInfo = p.ImprimirResultadoInfo;
            impressaoInfo(2, "teste");

            Console.ReadKey();
        }


        int Somar(int a, int b)
        {
            return a + b;
        }
        string RetornaString()
        {
            return "teste";
        }

        string NumerosEmString(int a, int b)
        {
            return $"numero {a} e numero {b}";
        }

        void ImprimirResultado(int resultado)
        {
            Console.WriteLine(resultado);
        }

        void ImprimirResultadoInfo(int resultado, string info )
        {
            Console.WriteLine($"o numero {resultado} é {info}");
        }

    }
}
