
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    public class VelocidadInicial : InterfazDatos
    {

        public string Formula1 = "sqrt(2*{0}*{1})";//0: g, 1: h


        public decimal? Altura { get; set; }

        public VelocidadInicial(decimal h)
        {
            this.Altura = h;
            Calcular();
        }

        public void Calcular()
        {
            string operacion = Formula1.FormatoExpresion(Constantes.GRAVEDAD, this.Altura);
            Resultado = operacion.EvaluarExpresion().ToDecimal();
        }
        public decimal Resultado { get; set; }

    }
}
