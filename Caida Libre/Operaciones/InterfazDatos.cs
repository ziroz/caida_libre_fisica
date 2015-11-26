using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    interface InterfazDatos
    {
        void Calcular();
        decimal Resultado { get; set; }
        int NumeroFormula { get; set; }
    }
}
