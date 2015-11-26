using Caida_Libre.Operaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caida_Libre.Forms
{
    public partial class Resultados : Form
    {
        private decimal? Altura { get; set; }
        private decimal? VelocidadFinal { get; set; }
        private decimal? Tiempo { get; set; }
        private Incognitas Incognita { get; set; }

        public Resultados(decimal? velocidadFinal, decimal? tiempo, decimal? altura, Incognitas incognita)
        {
            InitializeComponent();

            this.Altura = altura;
            this.VelocidadFinal = velocidadFinal;
            this.Tiempo = tiempo;
            this.Incognita = incognita;

            CargarVariables();
            CargarDibujo();
        }

        private void CargarDibujo()
        {
            printPreviewControl1.Document.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 250, Altura > (450) ? Convert.ToInt32(Altura * 250/450) : 250);
            printPreviewControl1.Zoom = 1.9;
            printPreviewControl1.Document.DefaultPageSettings.Landscape = false;
            printPreviewControl1.Document.PrinterSettings.PrinterName = "Microsoft XPS Document Writer";
            
            printPreviewControl1.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            var lineY = new Pen(Color.Blue, 2);
            var lineX = new Pen(Color.Red, 2);
            var points = new List<PointF>();
            int inicio = 20;

            //e.Graphics.DrawLine(lineX, new Point(10, 200), new Point(200, 200));

            decimal displayAltura = this.Altura.Value;

            if (this.Altura < 30)
            {
                this.Altura *= 10;
            }else
                if (this.Altura > 150)
                {
                    this.Altura /= 2;
                }

            e.Graphics.DrawLine(lineY, new PointF(60, inicio), new PointF(60, (float)Altura + inicio));

            e.Graphics.DrawLine(lineY, new PointF(56F, inicio), new PointF(64F, inicio));
            e.Graphics.DrawLine(lineY, new PointF(56F, (float)Altura+inicio), new PointF(64, (float)Altura+inicio));
            var font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Pixel);
            var stringFormat = new StringFormat(StringFormatFlags.DirectionVertical);
            string textoH = string.Format("h = {0} m", displayAltura);
            var tamano = e.Graphics.MeasureString(textoH, font);
            float ubicacionAltura = (float)((Altura + inicio) / 2);

            if (tamano.Width < ubicacionAltura && (ubicacionAltura - tamano.Width) > 50)
            {
                ubicacionAltura -= (tamano.Width/2);
            }

            e.Graphics.DrawString(textoH, font, new SolidBrush(Color.Black), new PointF(40, ubicacionAltura), stringFormat);

            var pen = new Pen(Color.Green, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            
            e.Graphics.DrawLine(pen, new PointF(100F, inicio), new PointF(100F, (float)Altura + inicio));

            e.Graphics.FillEllipse(new SolidBrush(Color.Green), 100 - 4, inicio - 4, 8, 8);
            e.Graphics.DrawString("Vo = 0 m/s       t = 0 s", font, new SolidBrush(Color.Black), new PointF(120, inicio-5));

            e.Graphics.DrawString(string.Format("Vf = {0} m/s       tf = {1} s", VelocidadFinal, Tiempo), font, new SolidBrush(Color.Black), new PointF(120, (float)Altura + inicio - 5));

        }

        private void CargarVariables()
        {
            tblVariables.Controls.Add(new Label()
            {
                Text = "Datos:",
                Anchor = AnchorStyles.Left,
                Font = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold)
            });

            tblVariables.Controls.Add(new Label()
            {
                Text = string.Format("Vo = {0} m/s", 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            });

            tblVariables.Controls.Add(new Label()
                    {
                        Text = string.Format("g = {0} m/s²", Constantes.GRAVEDAD),
                        Anchor = AnchorStyles.Left | AnchorStyles.Right
                    });

            if (this.VelocidadFinal.HasValue)
            {
                tblVariables.Controls.Add(new Label()
                {
                    Text = string.Format("Vf = {0} m/s", this.VelocidadFinal.Value),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right
                });
            }

            if (this.Tiempo.HasValue)
            {
                tblVariables.Controls.Add(new Label()
                {
                    Text = string.Format("t = {0} s", this.Tiempo.Value),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right
                });
            }

            if (this.Altura.HasValue)
            {
                tblVariables.Controls.Add(new Label()
                {
                    Text = string.Format("h = {0} m", this.Altura.Value),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right
                });
            }

            PictureBox image = new PictureBox();
            Label resultado = new Label();
            resultado.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            switch (Incognita)
            {

                case Incognitas.VelocidadFinal:
                    tblVariables.Controls.Add(new Label()
                    {
                        Text = "Vf = ?",
                        Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    });

                    var objVelocidadFinal = new VelocidadFinal(Tiempo, Altura);
                    image.Image = Image.FromFile(Constantes.FORMULAS[objVelocidadFinal.NumeroFormula]);
                    resultado.Text = string.Format("Velocidad Final = {0} m/s", objVelocidadFinal.Resultado);
                    this.VelocidadFinal = objVelocidadFinal.Resultado;

                    break;
                case Incognitas.Tiempo:
                    tblVariables.Controls.Add(new Label()
                    {
                        Text = "t = ?",
                        Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    });

                    var objTiempo = new Tiempo(VelocidadFinal, Altura);
                    image.Image = Image.FromFile(Constantes.FORMULAS[objTiempo.NumeroFormula]);
                    this.Tiempo = objTiempo.Resultado;
                    resultado.Text = string.Format("Tiempo = {0} s", objTiempo.Resultado);
                    break;
                case Incognitas.Altura:
                    tblVariables.Controls.Add(new Label()
                    {
                        Text = "h = ?",
                        Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    });

                    var objAltura = new Altura(Tiempo, VelocidadFinal);
                    image.Image = Image.FromFile(Constantes.FORMULAS[objAltura.NumeroFormula]);
                    resultado.Text = string.Format("Altura = {0} m", objAltura.Resultado);
                    this.Altura = objAltura.Resultado;
                    break;

            }

            image.Size = new System.Drawing.Size(image.Image.Width, image.Image.Height);


            tblVariables.Controls.Add(new Label()
            {
                Text = "Fórmulas:",
                Anchor = AnchorStyles.Left,
                Font = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold)
            });

            tblVariables.Controls.Add(image);


            tblVariables.Controls.Add(new Label()
            {
                Text = "Solución:",
                Anchor = AnchorStyles.Left,
                Font = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold)
            });

            tblVariables.Controls.Add(resultado);

            if (!Altura.HasValue)
            {
                Altura = new Altura(Tiempo, VelocidadFinal).Resultado;
            }

            if (!VelocidadFinal.HasValue)
            {
                VelocidadFinal = new VelocidadFinal(Tiempo, Altura).Resultado;
            }

            if (!Tiempo.HasValue)
            {
                Tiempo = new Tiempo(VelocidadFinal, Altura).Resultado;
            }
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X + 25, this.Location.Y + 35, 0, 0, s);
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = button1.Visible = false;
            CaptureScreen();
            button2.Visible = button1.Visible = true;
            printDocument2.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", this.Width, this.Height - 20);
            printDocument2.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
