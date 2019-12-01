using System;
using MetodosExtensao.Extensoes; //Importando método porque não tem o mesmo namespace

namespace MetodosExtensao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o que quer inverter: ");
            string frase = Console.ReadLine();
            Console.WriteLine("Sua nova frase é {0} ", frase.InverterCaixas(true));
            Console.ReadKey();

        }
    }
}
