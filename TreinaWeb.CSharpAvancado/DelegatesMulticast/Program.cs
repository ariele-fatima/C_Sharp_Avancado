using System;

namespace DelegatesMulticast
{
    class Program
    {
        //Lembrando que um método delegate pode apontar para métodos que possuem a mesma assinatura(retorno e parametros)
        delegate void VerificacaoIdade(int idade);
        static VerificacaoIdade verificacaoIdade;
        static void Main(string[] args)
        {
            //Usuaio informa se ele é homem ou mulher
            //Usuário também informa a idade
            //Se for homem
            // Se tiver menos que 21 anos: "Você ainda está crescendo"
            // Se tiver mais que 21 anos: "Você já cresceu"
            // Se tiver mais que 25 anos: "Você pode carregar bastante peso"
            // Se tiver menos que 25 anos: "Você não pode carregar tanto peso"
            //Se for mulher
            // Se tiver menos que 18 anos: "Você ainda está crescendo"
            // Se tiver mais que 18 anos: "Você "Você já cresceu""
            // Se tiver mais que 30 anos: "Você pode carregar bastante peso"
            // Se tiver menos que 30 anos: "Você não pode carregar tanto peso" 

            Console.Write("Digite seu sexo: ");
            string sexoUsusario = Console.ReadLine();
            Console.Write("Digite sua idade: ");
            int idadeUsusario = Convert.ToInt32(Console.ReadLine());
            if(sexoUsusario.Equals("H"))
            {
                //Com uma única instância é possível apontar para mais de um método, este é o recurso de multicast do delegate
                verificacaoIdade = new VerificacaoIdade(VerficaIdadeHomem);
                verificacaoIdade += VerficaCarregamentoPesoHomem;
            }
            else
            {
                verificacaoIdade = new VerificacaoIdade(VerficaIdadeMulher);
                verificacaoIdade += VerficaCarregamentoPesoMulher;
            }
            //Depois de passar a ordem de execução dos métodos para o delegate, passa-se o valor do parametro pedido
            verificacaoIdade(idadeUsusario);
            Console.ReadKey();
        }

        //Homens
        static void VerficaIdadeHomem(int idade)
        {
            if(idade < 21)
            {
                Console.WriteLine("Você ainda está crescendo");
            }
            else
            {
                Console.WriteLine("Você já cresceu");
            }
        }

        //Mulheres
        static void VerficaCarregamentoPesoHomem(int idade)
        {
            if (idade > 25)
            {
                Console.WriteLine("Você pode carregar bastante peso");
            }
            else
            {
                Console.WriteLine("Você não pode carregar tanto peso");
            }
        }

        static void VerficaIdadeMulher(int idade)
        {
            if (idade < 18)
            {
                Console.WriteLine("Você ainda está crescendo");
            }
            else
            {
                Console.WriteLine("Você já cresceu");
            }
        }

        static void VerficaCarregamentoPesoMulher(int idade)
        {
            if (idade > 30)
            {
                Console.WriteLine("Você pode carregar bastante peso");
            }
            else
            {
                Console.WriteLine("Você não pode carregar tanto peso");
            }
        }
    }
}
