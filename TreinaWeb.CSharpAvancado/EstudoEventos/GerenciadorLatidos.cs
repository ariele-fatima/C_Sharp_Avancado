using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoEventos
{
    public class GerenciadorLatidos
    {
        private int _intensidadeLatido;
        //delegates de evento são sempre void e recebem um object e os argumentos dos eventos
        //public delegate void ExcessoDecibeisHandler(object sender, EventArgs e); --1ª forma
        //criando o evento em si (uma instância de um delegate usando a keyword event)
        //por ser um event, apenas a própria classe pode chamado direto pelo ExcessoDecibeisHandler
        //public event ExcessoDecibeisHandler ExcessoDecibeisEvent; --1ª forma
        //As duas linhas acima de codigo acima podem ser substituidas por
        public event EventHandler ExcessoDecibeisEvent; //--2ª forma
        //EventHandler é uma classe do .net pronta, já que eventos são sempre void e recebem um object e o EventArgs


        public GerenciadorLatidos()
        {
            _intensidadeLatido = 0;
        }

        public int ReiniciarLatidos()
        {
            return _intensidadeLatido = 0;
        }

        public int Latir()
        {
            if(_intensidadeLatido != 100)
            {
                _intensidadeLatido += 10;
            }
            //a lógica que chama o método OnExcessoDecibeis fica aqui e não no proprio evento
            //pq a responsabilidade do método OnExcessoDecibeis é de apenas disparar o evento (S do SOLID ;) )
            if (_intensidadeLatido > 80)
            {
                ExcessoDecibeisEventArgs e = new ExcessoDecibeisEventArgs
                {
                    IntensidadeLatidos = _intensidadeLatido
                };
                //chamando o método que dispara o evento
                OnExcessoDecibeis(e);
            }
            return _intensidadeLatido;
        }
        //método que dispara o evento para poder ser usado fora dessa classe  
        //geralmento esse tipo de classe é virtual porque pode haver necessidade de modifica-lo caso a classe seja herdada
        protected virtual void OnExcessoDecibeis(EventArgs e)
        {
            //Se existem assinantes desse evento
            if(ExcessoDecibeisEvent != null)
            {
                //Como no fim apenas a própria classe é que faz o evento de fato, o object é ela mesma 
                ExcessoDecibeisEvent(this, e);
            }
        }

    }
}
