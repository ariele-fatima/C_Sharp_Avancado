using System;
using System.Collections.Generic;
using System.Text;

namespace CovarianciaContravariancia
{
    //Interface covariante precisa da keyword out para ser capaz de converter tipos mais especificos para tipos mais genéricos
    interface IRecuperador<out T>
    {
        T Recuperar(int codigo);
    }
}
