using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    public class Tiempo : InterfazDatos
    {

        public string Formula1 = "{0}/{1}";//0: Vf, 1: g
        public string Formula2 = "sqrt(2*{0}/{1})";//0: h, 1: g

        public decimal? VelocidadFinal { get; set; }
        public decimal? Altura { get; set; }


        public Tiempo(decimal? Vf, decimal? h)
        {
            this.VelocidadFinal = Vf;
            this.Altura = h;
            Calcular();
        }

        public void Calcular()
        {
            string operacion = "";
            if (VelocidadFinal.HasValue)
            {
                operacion = Formula1.FormatoExpresion(this.VelocidadFinal, Constantes.GRAVEDAD);
                this.NumeroFormula = 3;
            }
            else
                if (Altura.HasValue)
                {
                    operacion = Formula2.FormatoExpresion(this.Altura, Constantes.GRAVEDAD);
                    this.NumeroFormula = 4;
                }

            Resultado = operacion.EvaluarExpresion().ToDecimal();
        }

        public decimal Resultado { get; set; }
        public int NumeroFormula { get; set; }

    }
}
