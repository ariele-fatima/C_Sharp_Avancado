using System;
using System.Collections.Generic;
using System.Text; 

namespace MetodosExtensao.Extensoes // Se o namespace não for o mesmo onde você vai usar o método é só importar
{
    //Para criar métodos de extensão há 3 regras:

    //1 - A classe tem que ser estática 
    public static class StringExtensions
    {
        //2 - O método tem que ser estático
        //3 - O primeiro parâmetro passado no método na verdade é o tipo de dado que o método pode se conectar, por isso deve começar com a keyword this.
        //Você pode também, se precisar, passar mais parâmetros (ex:bool estadoInicial) 
        //e esses não precisam ser do mesmo tipo de dado o qual o método foi conectado (aqui o método é para uma string mas recebe um bool)
        //o retorno do método também não precisa ser do mesmo tipo de dado o qual o método foi conectado

        public static string InverterCaixas (this string frase, bool estadoInicial)
        {
            bool isUpperCase = estadoInicial;
            string resultado = "";
            for (int i = 0; i < frase.Length; i++)
            {
                resultado += isUpperCase ? frase[i].ToString().ToUpper() : frase[i].ToString().ToLower();
                isUpperCase = !isUpperCase;
            };
            return resultado;
        }
    }
}
