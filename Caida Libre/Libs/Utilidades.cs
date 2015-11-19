using Microsoft.JScript;
using Microsoft.JScript.Vsa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caida_Libre.Operaciones
{
    public static class Utilidades
    {
        public static double EvaluarExpresion(this string expresion){

            expresion = expresion.OrganizarExpresion();
            VsaEngine engine = VsaEngine.CreateEngine();
            try
            {
                object o = Eval.JScriptEvaluate(expresion, engine);
                return Math.Round(System.Convert.ToDouble(o), 2);
            }
            catch
            {
                throw new Exception("No se puede hacer la operacion");
            }
        }

        private static string OrganizarExpresion(this string expresion)
        {
            expresion = expresion.Replace("pow", "Math.pow");
            expresion = expresion.Replace("sqrt", "Math.sqrt");
            return expresion;
        }

        public static string FormatoExpresion(this string expresion, params object[] parametros)
        {
            for (int i = 0; i < parametros.Count(); i++ )
            {
                parametros[i] = parametros[i] != null ? parametros[i].ToString().Replace(",", ".") : null;
            }

            return string.Format(expresion, parametros);
        }

        public static decimal ToDecimal(this double valor)
        {
            return System.Convert.ToDecimal(valor);
        }
    }
}
