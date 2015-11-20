using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caida_Libre
{
    public partial class Principal : Form
    {
        Dictionary<string, List<Control>> controles = new Dictionary<string, List<Control>>();

        Dictionary<string, string> incognitas = new Dictionary<string, string>()
        {
            { "h", "Altura" },
            { "t", "Tiempo" },
            { "Vf", "Velocidad Final" },
            { "Vo", "Velocidad Inicial" },
        };

        public Principal()
        {
            InitializeComponent();

            cmdIncognitas.DataSource = incognitas.Select(m => new { key = m.Key, value = m.Value }).ToList();
            cmdIncognitas.ValueMember = "key";
            cmdIncognitas.DisplayMember = "value";


            ConfigurarOpciones();
        }

        private void ConfigurarOpciones()
        {

            //Velocidad Final 
            controles.Add("Vf1", new List<Control>()
            {
                new Label(){ Text="Velocidad Inicial (Vo):" },
                new TextBox(){ Name = "txtVelocidadInicial" },
                
                new Label(){ Text="Altura (h):" },
                new TextBox(){ Name = "txtAltura" },
            });

            controles.Add("Vf2", new List<Control>()
            {
                new Label(){ Text="Velocidad Inicial (Vo):" },
                new TextBox(){ Name = "txtVelocidadInicial" },
                
                new Label(){ Text="Tiempo (t):" },
                new TextBox(){ Name = "txtTiempo" },
            });


            controles.Add("t1", new List<Control>()
            {
                new Label(){ Text="Velocidad Inicial (Vo):" },
                new TextBox(){ Name = "txtVelocidadInicial" },
                
                new Label(){ Text="Velocidad Final (Vo):" },
                new TextBox(){ Name = "txtVelocidadFinal" },
            });


            controles.Add("t2", new List<Control>()
            {
                new Label(){ Text="Velocidad Inicial (Vo):" },
                new TextBox(){ Name = "txtVelocidadInicial" },
                
                new Label(){ Text="Altura (h):" },
                new TextBox(){ Name = "txtAltura" },
            });


            controles.Add("h1", new List<Control>()
            {
                new Label(){ Text="Velocidad Inicial (Vo):" },
                new TextBox(){ Name = "txtVelocidadInicial" },
                
                new Label(){ Text="Velocidad Final (Vo):" },
                new TextBox(){ Name = "txtVelocidadFinal" },
            });


            controles.Add("Vo1", new List<Control>()
            {
                new Label(){ Text="Altura (h):" },
                new TextBox(){ Name = "txtAltura" },
            });

        }

        private void IncognitaVelocidadFinal_CheckedChanged(object sender, EventArgs e)
        {
            tblDatos.RowStyles.Clear();
            string filtro = rdVfInicialAltura.Checked ? "1" : "2";

            var campos = controles["Vf" + filtro];

            for(int i = 0; i< campos.Count; i++)
            {
                var elem = campos[i];

                if (elem.GetType() == typeof(TextBox))
                {
                    var valorActual = tblDatos.Controls.Find(elem.Name, true).FirstOrDefault();

                    if (valorActual != null)
                    {
                        elem.Text = valorActual.Text;
                    }
                }
            }
            
            tblDatos.Controls.Clear();

            foreach (var elem in campos)
            {
                tblDatos.Controls.Add(elem);
            }

        }

        private void cmdIncognitas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
