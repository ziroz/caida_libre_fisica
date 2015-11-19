using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.JScript.Vsa;
using Microsoft.JScript;
using Caida_Libre.Operaciones;

namespace Caida_Libre
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            decimal velocidadInicial = 30;
            decimal velocidadFinal = 0;
            decimal tiempo1 = 2;
            decimal tiempo2 = 5;

            var tiempoMaximo = new Tiempo(velocidadInicial, velocidadFinal);

            Console.WriteLine("Tiempo Altura Máxima: " + tiempoMaximo.Resultado);

            var alturaMaxima = new Altura(velocidadInicial, null, velocidadFinal);

            Console.WriteLine("Altura Máxima: " + alturaMaxima.Resultado);

            var velocidadFinal1 = new VelocidadFinal(velocidadInicial, tiempo1, null);

            Console.WriteLine("Velocidad 2 seg: " + velocidadFinal1.Resultado);


            var velocidadFinal2 = new VelocidadFinal(velocidadInicial, tiempo2, null);

            Console.WriteLine("Velocidad 5 seg: " + velocidadFinal2.Resultado);


            var altura2seg = new Altura(velocidadInicial, tiempo1, velocidadFinal1.Resultado);

            Console.WriteLine("Altura 2 seg: " + altura2seg.Resultado);


            var altura5seg = new Altura(velocidadInicial, tiempo2, velocidadFinal2.Resultado);

            Console.WriteLine("Altura 5 seg: " + altura5seg.Resultado);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }

    }
}
