
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    public class Altura : InterfazDatos
    {
        public string Formula1 = "(1/2)*{0}*pow({1},2)";//0: g, 1: t

        public decimal? Tiempo { get; set; }

        public Altura(decimal? t)
        {
            this.Tiempo = t;
            this.Calcular();
        }

        public void Calcular()
        {
            string operacion = "";

            if (this.Tiempo.HasValue)
            {
                operacion = Formula1.FormatoExpresion(Constantes.GRAVEDAD, this.Tiempo);
            }

            Resultado = operacion.EvaluarExpresion().ToDecimal();
        }

        public decimal Resultado { get; set; }

    }
}
