using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caida_Libre.Forms
{
    public partial class Resultados : Form
    {
        private decimal Altura { get; set; }
        private decimal VelocidadInicial { get; set; }

        public Resultados()
        {
            InitializeComponent();
            Altura = 50;
            CargarDibujo();
        }

        public Resultados(decimal h, decimal velInicial)
        {
            InitializeComponent();
            Altura = h;
            CargarDibujo();
        }

        private void CargarDibujo()
        {
            printPreviewControl1.Document.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 250, 250);
            printPreviewControl1.Zoom = 1.9;
            printPreviewControl1.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var lineY = new Pen(Color.Blue, 2);
            var lineX = new Pen(Color.Red, 2);
            var points = new List<PointF>();

            e.Graphics.DrawLine(lineY, new Point(40, 50), new Point(40, 230));
            e.Graphics.DrawLine(lineX, new Point(10, 200), new Point(200, 200));

            decimal displayAltura = Altura;

            e.Graphics.DrawLine(lineY, new PointF(35F, (float)Altura), new PointF(45, (float)Altura));
            e.Graphics.DrawString(displayAltura.ToString(), new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(23, (float)Altura - 5));

            if (VelocidadInicial == 0){
                float posY = 50;

                while (200 >= posY)
                {
                    points.Add(new PointF(70, posY));

                    posY += 10;
                }
            }


            var pen = new Pen(Color.Green, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            e.Graphics.DrawCurve(pen, points.ToArray());

            //var multiplicacion = 10;
            //var pen = new Pen(Color.Green, 1);

            //var points = new List<Point>();
            //int pointY = 0;
            //int i = 0;
            //while (pointY <= initY)
            //{
            //    pointY = initY - Convert.ToInt32(i * 10 - Math.Pow(i, 2));
            //    var pointX = initX + i * multiplicacion;
            //    points.Add(new Point(pointX, pointY));
            //    i++;
            //}

            //var lineY = new Pen(Color.Red, 2);
            //var lineX = new Pen(Color.Blue, 2);

            //e.Graphics.DrawLine(lineY, new Point(initX, 0), new Point(initX, 1000));
            //e.Graphics.DrawLine(lineX, new Point(0, initY), new Point(1000, initY));

            //for (int x = -10; x <= 30; x++)
            //{
            //    var pointX = initX + (x * 40);
            //    e.Graphics.DrawLine(lineX, new Point(pointX, initY - 4), new Point(pointX, initY + 4));
            //    e.Graphics.DrawString(x.ToString(), new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(pointX - 3, initY + 5));
            //}

        }
    }
}
