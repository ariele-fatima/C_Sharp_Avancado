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

            //Sem utilizar os métodos de extensão do System.Linq (lembra mais o SQL)

            //var pessoasMaisDoisIrmaos = from pessoa in pessoas //Para cada pessoa na lista de pessoas
            //                            where pessoa.QuantidadeIrmaos > 2 //onde a qtd de irmaõs seja maior que 2
            //                            select pessoa; //seleciona a pessoa de acordo com as condições acima, para fazer uma projeção do resultado


            //Utilizando os métodos de extensão do System.Linq (utilizando lambda, lembra mais com o C#)

            //Não é necessário utilizar from nem select, porque já subentende-se que estamos nos referindo a pessoas
            //O compilador irá fazer um cast de var para IEnumerable então pode-se colocar IEnumerable direto
            IEnumerable<Pessoa> pessoasMaisDoisIrmaos = pessoas.Where(p => p.QuantidadeIrmaos > 2);

            foreach (Pessoa p in pessoasMaisDoisIrmaos) //foreach para mostrar na tela o resultado da consulta LINQ
            {
                Console.WriteLine("{0}, {1}, {2} ", p.Nome, p.Idade, p.QuantidadeIrmaos);
            }

            Console.WriteLine("*************************************");

            //2. Nome e idade de todas as pessoas maiores de idade

            //Sem utilizar os métodos de extensão do System.Linq (lembra mais o SQL)

            //var pessoasMaioresIdade = from pessoa in pessoas //Para cada pessoa na lista de pessoas
            //                          where pessoa.Idade > 18 //onde a idade seja maior que 18
            //                          orderby pessoa.Idade //orderne pela idade de forma ascendente (para descendente utilize "descending" no final dessa linha)
            //                          select new { pessoa.Nome, pessoa.Idade }; //Pode-se usar tipo anônimo para criar a projeção apenas com as propriedades necessárias


            //Utilizando os métodos de extensão do System.Linq (utilizando lambda, lembra mais com o C#)            
            
            var pessoasMaioresIdade = pessoas //Por aqui já sabe que estamos utilizando pessoas
                                        .Where(p => p.Idade > 18) //onde a idade seja maior que 18
                                        .OrderBy(p => p.Idade) //Para ordernação temos os métodos OrderBy e OrderByDescending
                                        .ThenBy(p => p.Nome.Length) //Para mais de uma ordenação na mesma consulta, sa segunda em diante usa-se o ThenBy
                                        .Select(p => new { p.Nome, p.Idade }); //Utilizamos o método Select para criar um tipo anônimo

            foreach (var p in pessoasMaioresIdade)
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
