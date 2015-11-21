using Caida_Libre.Operaciones;
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
            { "", "Seleccione" },
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
            opciones.Add("Vf", new List<Control>()
            {
                new RadioButton(){ Name = "Vf1", Text = "Vel. Inicial - Altura", Checked = true, Anchor = AnchorStyles.Left | AnchorStyles.Right },
                new RadioButton(){ Name = "Vf2", Text = "Vel. Inicial - Tiempo", Anchor = AnchorStyles.Left | AnchorStyles.Right },
            });


            opciones.Add("t", new List<Control>()
            {
                new RadioButton(){ Name = "t1", Text = "Vel. Inicial - Vel. Final", Checked = true, Anchor = AnchorStyles.Left | AnchorStyles.Right},
            });


            opciones.Add("h", new List<Control>()
            {
                new RadioButton(){ Name = "h1", Text = "Vel. Inicial - Vel. Final", Checked = true, Anchor = AnchorStyles.Left| AnchorStyles.Right },
                new RadioButton(){ Name = "h2", Text = "Vel. Inicial - Tiempo", Anchor = AnchorStyles.Left| AnchorStyles.Right },
            });

            opciones.Add("Vo", new List<Control>()
            {
                new RadioButton(){ Name = "Vo1", Text = "Altura", Checked = true, Anchor = AnchorStyles.Left | AnchorStyles.Right},
            });



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


            controles.Add("h1", new List<Control>()
            {
                new Label(){ Text="Velocidad Inicial (Vo):" },
                new TextBox(){ Name = "txtVelocidadInicial" },
                
                new Label(){ Text="Velocidad Final (Vo):" },
                new TextBox(){ Name = "txtVelocidadFinal" },
            });


            controles.Add("h2", new List<Control>()
            {
                new Label(){ Text="Velocidad Inicial (Vo):" },
                new TextBox(){ Name = "txtVelocidadInicial" },
                
                new Label(){ Text="Tiempo:" },
                new TextBox(){ Name = "txtTiempo" },
            });

            controles.Add("Vo1", new List<Control>()
            {
                new Label(){ Text="Altura (h):" },
                new TextBox(){ Name = "txtAltura" },
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
            else
            {
                tblDatos.Controls.Clear();
            }
        }

        private void cmdIncognitas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtro = sender as ComboBox;

            tblOpciones.RowStyles.Clear();
            tblOpciones.Controls.Clear();

            if (filtro.SelectedValue != null && filtro.SelectedValue.ToString() != "")
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmdIncognitas.SelectedValue != null && cmdIncognitas.SelectedValue.ToString() != "")
            {
                var incognita = cmdIncognitas.SelectedValue.ToString();
                string filtro = "";

                foreach (var control in tblOpciones.Controls)
                {
                    var elem = control as RadioButton;

                    if (elem.Checked)
                    {
                        filtro = elem.Name;
                    }
                }

                switch (incognita)
                {
                    case "t"://Tiempo
                        IncognitaTiempo(filtro);
                        break;
                    case "h"://Altura
                        IncognitaAltura(filtro);
                        break;
                    case "Vo"://Velocidad Inicial
                        IncognitaVelocidadInicial(filtro);
                        break;
                    case "Vf"://Velocidad Final
                        IncognitaVelocidadFinal(filtro);
                        break;
                }
            }
        }

        private void IncognitaTiempo(string filtro)
        {
            var txtVelocidadInicial = tblDatos.Controls.Find("txtVelocidadInicial", true).FirstOrDefault() as TextBox;
            var txtVelocidadFinal = tblDatos.Controls.Find("txtVelocidadFinal", true).FirstOrDefault() as TextBox;
            decimal velocidadInicial, velocidadFinal;

            if (!decimal.TryParse(txtVelocidadInicial.Text, out velocidadInicial)
                || !decimal.TryParse(txtVelocidadFinal.Text, out velocidadFinal))
            {

                MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var objTiempo = new Tiempo(velocidadInicial, velocidadFinal);

            lblResultado.Text = "Tiempo = " + objTiempo.Resultado;
        }

        private void IncognitaAltura(string filtro)
        {
            if (filtro == "h1")
            {
                var txtVelocidadInicial = tblDatos.Controls.Find("txtVelocidadInicial", true).FirstOrDefault() as TextBox;
                var txtVelocidadFinal = tblDatos.Controls.Find("txtVelocidadFinal", true).FirstOrDefault() as TextBox;
                decimal velocidadInicial, velocidadFinal;

                if (!decimal.TryParse(txtVelocidadInicial.Text, out velocidadInicial)
                    || !decimal.TryParse(txtVelocidadFinal.Text, out velocidadFinal))
                {
                    MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var objAltura = new Altura(velocidadInicial, null, velocidadFinal);

                lblResultado.Text = "Altura = " + objAltura.Resultado;
            }
            else
                if (filtro == "h2")
                {
                    var txtVelocidadInicial = tblDatos.Controls.Find("txtVelocidadInicial", true).FirstOrDefault() as TextBox;
                    var txtTiempo = tblDatos.Controls.Find("txtTiempo", true).FirstOrDefault() as TextBox;
                    decimal velocidadInicial, tiempo;

                    if (!decimal.TryParse(txtVelocidadInicial.Text, out velocidadInicial)
                        || !decimal.TryParse(txtTiempo.Text, out tiempo))
                    {
                        MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    var objAltura = new Altura(velocidadInicial, tiempo);
                    lblResultado.Text = "Altura = " + objAltura.Resultado;
                }
        }

        private void IncognitaVelocidadInicial(string filtro)
        {
            var txtAltura = tblDatos.Controls.Find("txtAltura", true).FirstOrDefault() as TextBox;
            decimal altura;

            if (!decimal.TryParse(txtAltura.Text, out altura))
            {
                MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var objVelInicial = new VelocidadInicial(altura);
            lblResultado.Text = "Velocidad Inicial = " + objVelInicial.Resultado;
        }

        private void IncognitaVelocidadFinal(string filtro)
        {
            if (filtro == "Vf1")
            {
                var txtVelocidadInicial = tblDatos.Controls.Find("txtVelocidadInicial", true).FirstOrDefault() as TextBox;
                var txtAltura = tblDatos.Controls.Find("txtAltura", true).FirstOrDefault() as TextBox;
                decimal altura, velocidadInicial;


                if (!decimal.TryParse(txtAltura.Text, out altura)
                    || !decimal.TryParse(txtVelocidadInicial.Text, out velocidadInicial))
                {
                    MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var objVelFinal = new VelocidadFinal(velocidadInicial, null, altura);
                lblResultado.Text = "Velocidad Final = " + objVelFinal.Resultado;
            }
            else
                if (filtro == "Vf2")
                {
                    var txtVelocidadInicial = tblDatos.Controls.Find("txtVelocidadInicial", true).FirstOrDefault() as TextBox;
                    var txtTiempo = tblDatos.Controls.Find("txtTiempo", true).FirstOrDefault() as TextBox;
                    decimal tiempo, velocidadInicial;


                    if (!decimal.TryParse(txtVelocidadInicial.Text, out velocidadInicial)
                        || !decimal.TryParse(txtTiempo.Text, out tiempo))
                    {
                        MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    var objVelFinal = new VelocidadFinal(velocidadInicial, tiempo);
                    lblResultado.Text = "Velocidad Final = " + objVelFinal.Resultado;
                }
        }
    }
}
