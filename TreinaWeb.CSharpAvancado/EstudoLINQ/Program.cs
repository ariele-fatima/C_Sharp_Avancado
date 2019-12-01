using System;
using System.Collections.Generic;
using System.Linq;

namespace EstudoLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pessoa> pessoas = CarregarListaPessoas();

            //1. Todas as pessoas com mais de 2 irmãos
            var pessoasMaisDoisIrmaos = from pessoa in pessoas //Para cada pessoa na lista de pessoas
                                        where pessoa.QuantidadeIrmaos > 2 //onde a qtd de irmaõs seja maior que 2
                                        select pessoa; //seleciona a pessoa de acordo com as condições acima, para fazer uma projeção do resultado
            foreach(Pessoa p in pessoasMaisDoisIrmaos) //foreach para mostrar na tela o resultado da consulta LINQ
            {
                Console.WriteLine("{0}, {1}, {2} ", p.Nome, p.Idade, p.QuantidadeIrmaos);
            }

            Console.WriteLine("****************");

            //2. Nome e idade de todas as pessoas maiores de idade
            var pessoasMaioresIdade = from pessoa in pessoas //Para cada pessoa na lista de pessoas
                                      where pessoa.Idade > 18 //onde a idade seja maior que 18
                                      orderby pessoa.Idade //orderne pela idade de forma ascendente (para descendente utilize "descending" no final dessa linha)
                                      select new { pessoa.Nome, pessoa.Idade }; //Pode-se usar tipo anônimo para criar a projeção apenas com as propriedades necessárias
            foreach(var p in pessoasMaioresIdade)
            {
                Console.WriteLine("{0}, {1} ", p.Nome, p.Idade);
            }
            Console.ReadKey();
        }

        static List<Pessoa> CarregarListaPessoas()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(new Pessoa 
            { 
                Nome = "João",
                Idade = 18,
                QuantidadeIrmaos = 2
            });
            pessoas.Add(new Pessoa
            {
                Nome = "Maria",
                Idade = 30,
                QuantidadeIrmaos = 0
            });
            pessoas.Add(new Pessoa
            {
                Nome = "José",
                Idade = 50,
                QuantidadeIrmaos = 6
            });
            return pessoas;
        }
    }

    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int QuantidadeIrmaos { get; set; }
    }
}
