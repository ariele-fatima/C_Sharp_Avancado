using System;
using System.Collections.Generic;
using System.Text;

namespace CovarianciaContravariancia
{
    //Interface contravariante precisa da keyword in para ser capaz de converter tipos mais genéricos para tipos mais especificos
    interface IArmazenador<in T>
    {
        void Armazenar(T item);
    }
}
