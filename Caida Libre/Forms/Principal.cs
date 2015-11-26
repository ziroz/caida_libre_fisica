using Caida_Libre.Forms;
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

        decimal? _velocidadFinal, _tiempo, _altura, _alturaFinal;

        Dictionary<string, string> incognitas = new Dictionary<string, string>()
        {
            { "", "Seleccione" },
            { "h", "Altura" },
            { "t", "Tiempo" },
            { "Vf", "Velocidad Final" }
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
                new RadioButton(){ Name = "Vf1", Text = "Altura", Checked = true, Anchor = AnchorStyles.Left | AnchorStyles.Right },
                new RadioButton(){ Name = "Vf2", Text = "Tiempo", Anchor = AnchorStyles.Left | AnchorStyles.Right },
            });


            opciones.Add("t", new List<Control>()
            {
                new RadioButton(){ Name = "t1", Text = "Vel. Final", Checked = true, Anchor = AnchorStyles.Left | AnchorStyles.Right},
                new RadioButton(){ Name = "t2", Text = "Altura", Anchor = AnchorStyles.Left | AnchorStyles.Right },
            });


            opciones.Add("h", new List<Control>()
            {
                new RadioButton(){ Name = "h1", Text = "Tiempo", Checked = true, Anchor = AnchorStyles.Left| AnchorStyles.Right },
                new RadioButton(){ Name = "h2", Text = "Vel. Final", Anchor = AnchorStyles.Left| AnchorStyles.Right,},
            });

            controles.Add("Vf1", new List<Control>()
            {
                new Label(){ Text="Altura (h):" },
                new TextBox(){ Name = "txtAltura" },
            });

            controles.Add("Vf2", new List<Control>()
            {
                new Label(){ Text="Tiempo (t):" },
                new TextBox(){ Name = "txtTiempo" },
            });
            
            controles.Add("t1", new List<Control>()
            {
                new Label(){ Text="Velocidad Final (Vo):" },
                new TextBox(){ Name = "txtVelocidadFinal" },
            });


            controles.Add("t2", new List<Control>()
            {
                new Label(){ Text="Altura (h):" },
                new TextBox(){ Name = "txtAltura" },
            });

            controles.Add("h1", new List<Control>()
            {
                new Label(){ Text="Tiempo:" },
                new TextBox(){ Name = "txtTiempo" },
            });

            controles.Add("h2", new List<Control>()
            {
                new Label(){ Text="Velocidad Final (Vo):" },
                new TextBox(){ Name = "txtVelocidadFinal" },
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

            LimpiarCampos();

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

                groupBox2.Text = filtro.Text;

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
                string filtro = "";

                foreach (var control in tblOpciones.Controls)
                {
                    var elem = control as RadioButton;

                    if (elem.Checked)
                    {
                        filtro = elem.Name;
                    }
                }

                var pregunta = cmdIncognitas.SelectedValue.ToString();
                bool informacionCorrecta = false;
                Incognitas incognita;
                switch (pregunta)
                {
                    case "t"://Tiempo
                        informacionCorrecta = IncognitaTiempo(filtro);
                        incognita = Incognitas.Tiempo;
                        break;
                    case "h"://Altura
                        informacionCorrecta = IncognitaAltura(filtro);
                        incognita = Incognitas.Altura;
                        break;
                    default:
                    case "Vf"://Velocidad Final
                        informacionCorrecta = IncognitaVelocidadFinal(filtro);
                        incognita = Incognitas.VelocidadFinal;
                        break;
                }

                if (informacionCorrecta)
                {
                    Resultados result = new Resultados(_velocidadFinal, _tiempo, _altura, incognita);
                    result.ShowDialog(this);
                }
            }
        }

        private bool IncognitaTiempo(string filtro)
        {

            if (filtro == "t1")
            {
                var txtVelocidadFinal = tblDatos.Controls.Find("txtVelocidadFinal", true).FirstOrDefault() as TextBox;
                decimal velocidadFinal;

                if (!Utilidades.TryParse(txtVelocidadFinal.Text, out velocidadFinal))
                {
                    MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                CargarInformacion(null, velocidadFinal, null);
            }else
                if (filtro == "t2")
                {
                    var txtAltura = tblDatos.Controls.Find("txtAltura", true).FirstOrDefault() as TextBox;
                    decimal altura;

                    if (!Utilidades.TryParse(txtAltura.Text, out altura))
                    {
                        MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    CargarInformacion(null, null, altura);
                }
            return true;

        }

        private bool IncognitaAltura(string filtro)
        {
                if (filtro == "h1")
                {
                    var txtTiempo = tblDatos.Controls.Find("txtTiempo", true).FirstOrDefault() as TextBox;
                    decimal tiempo;

                    if (!Utilidades.TryParse(txtTiempo.Text, out tiempo))
                    {
                        MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    CargarInformacion(tiempo, null, null);
                }
                else
                    if (filtro == "h2")
                    {
                        var txtVelocidadFinal = tblDatos.Controls.Find("txtVelocidadFinal", true).FirstOrDefault() as TextBox;
                        decimal velocidadFinal;

                        if (!Utilidades.TryParse(txtVelocidadFinal.Text, out velocidadFinal))
                        {
                            MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }

                        CargarInformacion(null, velocidadFinal, null);
                    }
                return true;
        }
        private bool IncognitaVelocidadFinal(string filtro)
        {
            if (filtro == "Vf1")
            {
                var txtAltura = tblDatos.Controls.Find("txtAltura", true).FirstOrDefault() as TextBox;
                decimal altura;


                if (!Utilidades.TryParse(txtAltura.Text, out altura))
                {
                    MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                CargarInformacion(null, null, altura);

            }
            else
                if (filtro == "Vf2")
                {
                    var txtTiempo = tblDatos.Controls.Find("txtTiempo", true).FirstOrDefault() as TextBox;
                    decimal tiempo;

                    if (!Utilidades.TryParse(txtTiempo.Text, out tiempo))
                    {
                        MessageBox.Show("Información Incorrecta, por favor verifique", "Información Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    CargarInformacion(tiempo, null, null);
                }
            return true;
        }

        private void CargarInformacion(decimal? tiempo, decimal? velocidadFinal, decimal? altura)
        {
            if (velocidadFinal.HasValue) _velocidadFinal = velocidadFinal.Value;
            if (tiempo.HasValue) _tiempo = tiempo.Value;
            if (altura.HasValue) _altura = altura.Value;
        }

        private void LimpiarCampos()
        {
            _velocidadFinal = _tiempo = _altura = null;
        }
    }
}
