
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    public class Altura : InterfazDatos
    {

        public string Formula1 = "({0}*{1})+(1/2)*{2}*pow({1},2)";//0: Vo, 1: t, 2: g

        public string Formula2 = "(pow({0},2)-pow({1},2))/(-2*({2}))";//0: Vf, 1: Vo, 2: g   -- Cuando se lanza hacia arriba


        public decimal VelocidadInicial { get; set; }
        public decimal VelocidadFinal { get; set; }

        public decimal? Tiempo { get; set; }
        public decimal Gravedad { get; set; }

        public Altura(decimal Vo, decimal? t)
            : this(Vo, t, 0)
        {
        }

        public Altura(decimal Vo, decimal? t, decimal Vf)
        {
            this.VelocidadFinal = Vf;
            this.VelocidadInicial = Vo;
            this.Tiempo = t;
            this.Gravedad = Constantes.GRAVEDAD;

            this.Calcular();
        }

        public void Calcular()
        {
            //si velocidad inicial es diferente de 0 es porque se lanzo
            string operacion ="";
            if (this.VelocidadInicial == 0)
            {
                operacion = Formula1.FormatoExpresion(this.VelocidadInicial, this.Tiempo, this.Gravedad);
            }
            else
            {
                operacion = Formula2.FormatoExpresion(this.VelocidadFinal, this.VelocidadInicial, this.Gravedad);
            }

            Resultado  = operacion.EvaluarExpresion().ToDecimal();
        }

        public decimal Resultado { get; set; }

    }
}
