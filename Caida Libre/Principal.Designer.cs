﻿namespace Caida_Libre
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdIncognitas = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdVfInicalTiempo = new System.Windows.Forms.RadioButton();
            this.rdVfInicialAltura = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tblDatos = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdIncognitas
            // 
            this.cmdIncognitas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdIncognitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdIncognitas.FormattingEnabled = true;
            this.cmdIncognitas.Items.AddRange(new object[] {
            "Altura",
            "Altura Máxima",
            "Tiempo",
            "Velocidad Final",
            "Velocidad Inicial"});
            this.cmdIncognitas.Location = new System.Drawing.Point(76, 32);
            this.cmdIncognitas.Name = "cmdIncognitas";
            this.cmdIncognitas.Size = new System.Drawing.Size(153, 21);
            this.cmdIncognitas.TabIndex = 0;
            this.cmdIncognitas.SelectedIndexChanged += new System.EventHandler(this.cmdIncognitas_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmdIncognitas);
            this.groupBox1.Location = new System.Drawing.Point(59, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 77);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incognita";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rdVfInicalTiempo);
            this.groupBox2.Controls.Add(this.rdVfInicialAltura);
            this.groupBox2.Location = new System.Drawing.Point(59, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 71);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Velocidad Final";
            // 
            // rdVfInicalTiempo
            // 
            this.rdVfInicalTiempo.AutoSize = true;
            this.rdVfInicalTiempo.Location = new System.Drawing.Point(198, 33);
            this.rdVfInicalTiempo.Name = "rdVfInicalTiempo";
            this.rdVfInicalTiempo.Size = new System.Drawing.Size(117, 17);
            this.rdVfInicalTiempo.TabIndex = 1;
            this.rdVfInicalTiempo.TabStop = true;
            this.rdVfInicalTiempo.Text = "Vel. Inicial - Tiempo";
            this.rdVfInicalTiempo.UseVisualStyleBackColor = true;
            // 
            // rdVfInicialAltura
            // 
            this.rdVfInicialAltura.AutoSize = true;
            this.rdVfInicialAltura.Location = new System.Drawing.Point(36, 33);
            this.rdVfInicialAltura.Name = "rdVfInicialAltura";
            this.rdVfInicialAltura.Size = new System.Drawing.Size(109, 17);
            this.rdVfInicialAltura.TabIndex = 0;
            this.rdVfInicialAltura.TabStop = true;
            this.rdVfInicialAltura.Text = "Vel. Inicial - Altura";
            this.rdVfInicialAltura.UseVisualStyleBackColor = true;
            this.rdVfInicialAltura.CheckedChanged += new System.EventHandler(this.IncognitaVelocidadFinal_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tblDatos);
            this.groupBox3.Location = new System.Drawing.Point(59, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 194);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos";
            // 
            // tblDatos
            // 
            this.tblDatos.ColumnCount = 2;
            this.tblDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDatos.Location = new System.Drawing.Point(18, 32);
            this.tblDatos.Name = "tblDatos";
            this.tblDatos.RowCount = 1;
            this.tblDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tblDatos.Size = new System.Drawing.Size(289, 137);
            this.tblDatos.TabIndex = 0;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 531);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.Text = "Datos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmdIncognitas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdVfInicalTiempo;
        private System.Windows.Forms.RadioButton rdVfInicialAltura;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tblDatos;
    }
}
