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
        Dictionary<string, List<Control>> opciones = new Dictionary<string, List<Control>>();

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

            ConfigurarOpciones();

            cmdIncognitas.DataSource = incognitas.Select(m => new { key = m.Key, value = m.Value }).ToList();
            cmdIncognitas.ValueMember = "key";
            cmdIncognitas.DisplayMember = "value";
            cmdIncognitas.Text = "Seleccione";

            cmdIncognitas.SelectedIndexChanged += cmdIncognitas_SelectedIndexChanged;
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

            //Velocidad Final 
            opciones.Add("Vf", new List<Control>()
            {
                new RadioButton(){ Name = "Vf1", Text = "Vel. Inicial - Altura", Checked=true, Anchor = AnchorStyles.Left | AnchorStyles.Right },
                new RadioButton(){ Name = "Vf2", Text = "Vel. Inicial - Tiempo", Anchor = AnchorStyles.Left | AnchorStyles.Right },
            });


            opciones.Add("t", new List<Control>()
            {
                new RadioButton(){ Name = "t1", Text = "Vel. Inicial - Altura", Checked=true, Anchor = AnchorStyles.Left | AnchorStyles.Right},
                new RadioButton(){ Name = "t2", Text = "Vel. Inicial - Vel. Final", Anchor = AnchorStyles.Left | AnchorStyles.Right},
            });


            opciones.Add("h", new List<Control>()
            {
                new RadioButton(){ Name = "h1", Text = "Vel. Inicial - Vel. Final", Checked=true, Anchor = AnchorStyles.Left| AnchorStyles.Right },
            });

            opciones.Add("Vo", new List<Control>()
            {
                new RadioButton(){ Name = "Vo1", Text = "Altura", Checked=true, Anchor = AnchorStyles.Left | AnchorStyles.Right},
            });
        }

        private void CheckedChange(object sender, EventArgs e)
        {
            tblDatos.RowStyles.Clear();

            string filtro = "";

            foreach (var control in tblOpciones.Controls)
            {
                var elem = control as RadioButton;

                if (elem.Checked)
                {
                    filtro = elem.Name;
                }
            }

            if (!string.IsNullOrEmpty(filtro))
            {
                var campos = controles[filtro];

                for (int i = 0; i < campos.Count; i++)
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
        }

        private void cmdIncognitas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtro = sender as ComboBox;

            tblOpciones.RowStyles.Clear();
            tblOpciones.Controls.Clear();

            if (filtro.SelectedValue != null)
            {
                var campos = opciones[filtro.SelectedValue.ToString()];

                foreach (var elem in campos)
                {
                    tblOpciones.Controls.Add(elem);
                    ((RadioButton)tblOpciones.Controls.Find(elem.Name, true)[0]).CheckedChanged += CheckedChange;
                }
            }

            CheckedChange(null, null);
        }
    }
}
