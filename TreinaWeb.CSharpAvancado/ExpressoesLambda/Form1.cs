using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressoesLambda
{
    public partial class frmLambda : Form
    {
        public frmLambda()
        {
            InitializeComponent();
        }

        private void btnConcatenar_Click(object sender, EventArgs e)
        {
            //Com expressões lambda o código fica menos verboso

            //Depois de criar um delegate do tipo Func ou Action, ao invés de criar uma instância de um objeto que aponta 
            //para um método (como foi feito em DelegatesFuncEAction), você fazer direto usando expressão lambda


            //A Func precisa de duas strings e retornar uma string, então ela é igual a s1 e s2 (= (s1, s2))
            //Expressão lambda (=>) e o retorno entre chaves ( { return s1 + " " + s2; }; )
            //Depois é só passar para o delegate Func concatenador as duas strings de paramentros

            //Para usar apenas a Func, comente as outras linhas de código abaixo
            Func<string, string, string> concatena = (s1, s2) => { return s1 + " " + s2; };
            txbResultado.Text = concatena(txbTexto1.Text, txbTexto2.Text); 


            //A Action é void e precisa de apenas uma string, então ela é igual a s1 ( = (s1) )
            //Expressão lambda (=>) e ela vai atribuir a string passada ao textbox de Resultado ( { txbResultado.Text = s1; }; )
            //Depois o delegate Action escritor usa como parametro o delegate Func concatenador (já que ele retorna uma string)

            //Para usar apenas a Func com a Action, comente as linhas de código acima
            Func<string, string, string> concatenador = (s1, s2) => { return s1 + " " + s2; };
            Action<string> escritor = (s1) => { txbResultado.Text = s1; };
            escritor(concatenador(txbTexto1.Text, txbTexto2.Text));

        }
    }
}
