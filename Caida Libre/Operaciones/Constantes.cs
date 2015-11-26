using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    public class Constantes
    {
        public const decimal GRAVEDAD = 9.81M;

        public static readonly Dictionary<int, string> FORMULAS = new Dictionary<int, string>()
        {
            { 1 , Path.Combine(Directory.GetCurrentDirectory(), @"Imagenes/Formulas/Altura 1.png") },
            { 2 , Path.Combine(Directory.GetCurrentDirectory(), @"Imagenes/Formulas/Altura 2.png") },
            { 3 , Path.Combine(Directory.GetCurrentDirectory(), @"Imagenes/Formulas/Tiempo 1.png") },
            { 4 , Path.Combine(Directory.GetCurrentDirectory(), @"Imagenes/Formulas/Tiempo 2.png") },
            { 5 , Path.Combine(Directory.GetCurrentDirectory(), @"Imagenes/Formulas/Velocidad Final 1.png") },
            { 6 , Path.Combine(Directory.GetCurrentDirectory(), @"Imagenes/Formulas/Velocidad Final 2.png") },
        };
    }
}
