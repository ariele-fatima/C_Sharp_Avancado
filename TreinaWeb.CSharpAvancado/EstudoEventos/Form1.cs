using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudoEventos
{
    public partial class frmGerenciadorLatidosCachorros : Form
    {
        private GerenciadorLatidos _gerenciadorLatidos;
        public frmGerenciadorLatidosCachorros()
        {
            InitializeComponent();
            _gerenciadorLatidos = new GerenciadorLatidos();
            //Adicionando assinantes ao evento
            _gerenciadorLatidos.ExcessoDecibeisEvent += QuandoExcederDecibeis;
            _gerenciadorLatidos.ExcessoDecibeisEvent += QuandoExcederDecibeisDeNovo;
        }

        private void frmGerenciadorLatidosCachorros_Load(object sender, EventArgs e)
        {
            pgbIntensidadeLatido.Value = 0;
        }

        private void btnLatir_Click(object sender, EventArgs e)
        {
            pgbIntensidadeLatido.Value = _gerenciadorLatidos.Latir();
        }

        //a assinatura do método tem que bater com a do delegete event (retorno sempre void e recebem um object e os argumentos dos eventos
        private void QuandoExcederDecibeis(object sender, EventArgs e)
        {
            //Assim é póssivel passar informação entre a classe que executa o evento e a classe assinante do evento
            ExcessoDecibeisEventArgs eventArgs = (ExcessoDecibeisEventArgs)e;
            MessageBox.Show(string.Format("O cachorro passou dos limites, com {0} decibéis.", eventArgs.IntensidadeLatidos), "Excesso de decibéis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //a assinatura do método tem que bater com a do delegete event (retorno sempre void e recebem um object e os argumentos dos eventos
        private void QuandoExcederDecibeisDeNovo(object sender, EventArgs e)
        {
            MessageBox.Show("Você acabou de levar uma multa.", "Excesso de decibéis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            pgbIntensidadeLatido.Value = _gerenciadorLatidos.ReiniciarLatidos();
        }
    }
}
