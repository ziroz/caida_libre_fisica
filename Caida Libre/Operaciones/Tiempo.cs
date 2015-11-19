using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    public class Tiempo : InterfazDatos
    {

        public string Formula1 = "({0}-{1})/{2}";//0: Vf, 1: Vo, 2: g

        public decimal VelocidadInicial { get; set; }
        public decimal VelocidadFinal { get; set; }
        public decimal gravedad { get; set; }


        public Tiempo(decimal Vo, decimal Vf)
        {
            this.VelocidadInicial = Vo;
            this.VelocidadFinal = Vf;

            this.gravedad = (this.VelocidadInicial != 0 ? -1 : 1) * Constantes.GRAVEDAD;
            Calcular();
        }

        public void Calcular()
        {
            string operacion = Formula1.FormatoExpresion(this.VelocidadFinal, this.VelocidadInicial, this.gravedad);

            Resultado = operacion.EvaluarExpresion().ToDecimal();
        }
        public decimal Resultado { get; set; }

    }
}
