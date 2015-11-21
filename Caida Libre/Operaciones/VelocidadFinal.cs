
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    public class VelocidadFinal : InterfazDatos
    {

        public string Formula1 = "{0}+{1}*{2}";//0: Vo, 1: g, 2: t
        public string Formula2 = "{0}-{1}*{2}";//0: Vo, 1: g, 2: t  -- Cuando se lanza hacia arriba
        public string Formula3 = "sqrt((2*{0}*{1})+pow({2},2))";//0: g, 1: h, 2: Vo  -- Cuando se tiene la altura 
        public string Formula4 = "sqrt((-2*{0}*{1})+pow({2},2))";//0: g, 1: h, 2: Vo  -- Cuando se tiene la altura y se lanzo hacia arriba


        public decimal VelocidadInicial { get; set; }
        public decimal? Tiempo { get; set; }
        public decimal? Altura { get; set; }

        public VelocidadFinal(decimal Vo, decimal? t):this(Vo, t, null)
        { }

        public VelocidadFinal(decimal Vo, decimal? t, decimal? h)
        {
            this.VelocidadInicial = Vo;
            this.Tiempo = t;
            this.Altura = h;

            Calcular();
        }

        public void Calcular()
        {
            //si velocidad inicial es diferente de 0 es porque se lanzo
            string operacion = "";
            if (this.Altura.HasValue)
            {
                if (this.VelocidadInicial == 0)
                {
                    operacion = Formula3.FormatoExpresion(Constantes.GRAVEDAD, this.Altura, this.VelocidadInicial);
                }
                else
                {
                    operacion = Formula4.FormatoExpresion(Constantes.GRAVEDAD, this.Altura, this.VelocidadInicial);
                }
            }
            else
                if (this.Tiempo.HasValue)
                {
                    if (this.VelocidadInicial == 0)
                    {
                        operacion = Formula1.FormatoExpresion(this.VelocidadInicial, Constantes.GRAVEDAD, this.Tiempo);
                    }
                    else
                    {
                        operacion = Formula2.FormatoExpresion(this.VelocidadInicial, Constantes.GRAVEDAD, this.Tiempo);
                    }
                }

            Resultado = operacion.EvaluarExpresion().ToDecimal();
        }
        public decimal Resultado { get; set; }
    }
}
