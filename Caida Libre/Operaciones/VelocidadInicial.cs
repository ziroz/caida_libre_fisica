
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
        public string Formula2 = "{0}-({1}*{2})";//0: Vf, 1: h, 2: t
        public string Formula3 = "sqrt(pow({0},2)+(2*{1}*({2}-{3})))";//0: Vf, 1: g, 2: Altura Final, 3: Altura Inicial


        public decimal? Altura { get; set; }
        public decimal? AlturaFinal { get; set; }
        public decimal? VelocidadFinal { get; set; }
        public decimal? Tiempo { get; set; }

        public VelocidadInicial(decimal? h)
            : this(null, null, h, null)
        {
        }
        public VelocidadInicial(decimal? Vf, decimal? h, decimal? hFinal)
            : this(Vf, null, h, hFinal)
        {
        }

        public VelocidadInicial(decimal? Vf, decimal? t, decimal? h, decimal? hFinal)
        {
            this.VelocidadFinal = Vf;
            this.Tiempo = t;
            this.Altura = h;
            this.AlturaFinal = hFinal;
            Calcular();
        }

        public void Calcular()
        {
            string operacion = "";

            if (this.AlturaFinal.HasValue)
            {
                operacion = Formula3.FormatoExpresion(this.VelocidadFinal, Constantes.GRAVEDAD, this.AlturaFinal, this.Altura);
            }
            else
                if (this.Altura.HasValue)
                {
                    operacion = Formula1.FormatoExpresion(Constantes.GRAVEDAD, this.Altura);
                }
                else
                    if (this.Tiempo.HasValue)
                    {
                        operacion = Formula2.FormatoExpresion(this.VelocidadFinal, Constantes.GRAVEDAD, this.Tiempo);
                    }

            Resultado = operacion.EvaluarExpresion().ToDecimal();
        }
        public decimal Resultado { get; set; }

    }
}
