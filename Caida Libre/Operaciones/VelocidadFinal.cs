
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    public class VelocidadFinal : InterfazDatos
    {

        public string Formula1 = "{0}*{1}";//0: Vo, 1: g, 2: t                                                                                                                                                                                       
        public string Formula2 = "sqrt((2*{0}*{1}))";//0: g, 1: h -- Cuando se tiene la altura 


        public decimal? Tiempo { get; set; }
        public decimal? Altura { get; set; }

        public VelocidadFinal(decimal? t)
            : this(t, null)
        { }

        public VelocidadFinal(decimal? t, decimal? h)
        {
            this.Tiempo = t;
            this.Altura = h;
            Calcular();
        }

        public void Calcular()
        {
            //si velocidad inicial es diferente de 0 es porque se lanzo
            string operacion = "";

            if (this.Tiempo.HasValue)
            {
                operacion = Formula1.FormatoExpresion(Constantes.GRAVEDAD, this.Tiempo);
                this.NumeroFormula = 5;
            }
            else
                if (this.Altura.HasValue)
                {
                    operacion = Formula2.FormatoExpresion(Constantes.GRAVEDAD, this.Altura);
                    this.NumeroFormula = 6;
                }

            Resultado = operacion.EvaluarExpresion().ToDecimal();
        }
        public decimal Resultado { get; set; }
        public int NumeroFormula { get; set; }
    }
}
