
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    public class VelocidadFinal : InterfazDatos
    {

        public string Formula1 = "{0}+{1}*{2}";//0: Vo, 1: g, 2: tlll                                                                                                                                                                                        
        public string Formula2 = "sqrt((2*{0}*{1})+pow({2},2))";//0: g, 1: h, 2: Vo  -- Cuando se tiene la altura 
        public string Formula3 = "sqrt(pow({0},2)-(2*{1}*({2}-{3})))";//0: Vo, 1: g, 2: Altura Final, 3: Altura Inicial


        public decimal VelocidadInicial { get; set; }
        public decimal? Tiempo { get; set; }
        public decimal? Altura { get; set; }
        public decimal? AlturaFinal { get; set; }
        public decimal Gravedad { get; set; }

        public VelocidadFinal(decimal Vo, decimal? t)
            : this(Vo, t, null, null)
        { }

        public VelocidadFinal(decimal Vo, decimal hInicial, decimal? hFinal)
            : this(Vo, null, hInicial, hFinal)
        { }

        public VelocidadFinal(decimal Vo, decimal? t, decimal? h, decimal? hFinal)
        {
            this.VelocidadInicial = Vo;
            this.Tiempo = t;
            this.Altura = h;
            this.AlturaFinal = hFinal;
            this.Gravedad = (Vo == 0 ? 1 : -1) * Constantes.GRAVEDAD;
            Calcular();
        }

        public void Calcular()
        {
            //si velocidad inicial es diferente de 0 es porque se lanzo
            string operacion = "";

            if (this.AlturaFinal.HasValue)
            {
                operacion = Formula3.FormatoExpresion(this.VelocidadInicial, this.Gravedad, this.AlturaFinal, this.Altura);
            }
            else
                if (this.Altura.HasValue)
                {
                    operacion = Formula2.FormatoExpresion(this.Gravedad, this.Altura, this.VelocidadInicial);
                }
                else
                    if (this.Tiempo.HasValue)
                    {
                        operacion = Formula1.FormatoExpresion(this.VelocidadInicial, this.Gravedad, this.Tiempo);
                    }

            Resultado = operacion.EvaluarExpresion().ToDecimal();
        }
        public decimal Resultado { get; set; }
    }
}
