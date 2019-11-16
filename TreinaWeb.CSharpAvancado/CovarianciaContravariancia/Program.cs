using System;

namespace CovarianciaContravariancia
{
    class Program
    {
        static void Main(string[] args)
        {
            ManipuladorFTP<Nivel2> ftp = new ManipuladorFTP<Nivel2>();

            //Contravariancia: um tipo mais genérico é convertido para um tipo mais específico
            //IArmazenador Nivel3(que é mais especifico das classes) consegue receber ftp que é Nivel2(mais generico que Nivel3) graças a keyword in na Interface IArmazenador
            IArmazenador<Nivel3> armazenador= ftp;
            armazenador.Armazenar(new Nivel3());
            
            //Covariancia: um tipo mais específico é convertido para um tipo mais genérico
            //IRecuperador Nivel1(que é mais generico das classes) consegue receber ftp que é Nivel2(mais especifico que Nivel1) graças a keyword out na Interface IRecuperador
            IRecuperador<Nivel1> recuperador = ftp;
            Console.WriteLine(recuperador.Recuperar(0));
            Console.ReadKey();

            //Lembrando que ManipuladorFTP, IArmazenador e IRecuperador são reference-type, ou seja, estão apontando exatamente para a mesma posição de memíria, para o mesmo objeto na memória
        }
    }
}
