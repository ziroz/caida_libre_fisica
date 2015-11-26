
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
        public string Formula2 = "pow({0},2)/(2*{1})";//0: Vf, 1: g

        public decimal? Tiempo { get; set; }
        public decimal? VelocidadFinal { get; set; }

        public Altura(decimal? t, decimal? vf)
        {
            this.Tiempo = t;
            this.VelocidadFinal = vf;
            this.Calcular();
        }

        public void Calcular()
        {
            string operacion = "";

            if (this.Tiempo.HasValue)
            {
                operacion = Formula1.FormatoExpresion(Constantes.GRAVEDAD, this.Tiempo);
                this.NumeroFormula = 1;
            }else
                if (this.VelocidadFinal.HasValue)
                {
                    operacion = Formula2.FormatoExpresion(this.VelocidadFinal, Constantes.GRAVEDAD);
                    this.NumeroFormula = 2;
                }

            Resultado = operacion.EvaluarExpresion().ToDecimal();
        }

        public decimal Resultado { get; set; }
        public int NumeroFormula { get; set; }

    }
}
