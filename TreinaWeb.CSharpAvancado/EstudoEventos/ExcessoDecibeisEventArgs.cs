using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoEventos
{
    public class ExcessoDecibeisEventArgs : EventArgs
    {
        //Repassando informações entre a classe onde ocorre o evente e a que assinou o evento
        public int IntensidadeLatidos { get; set; }
    }
}
