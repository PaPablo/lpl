namespace WinTurnos.Formularios
{
    partial class ModProfEspFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nombreEspecialidad = new System.Windows.Forms.TextBox();
            this.fechaAlta = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.estaDisponible = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textoObservaciones = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.codigoEspecialidad = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Especialidad";
            // 
            // nombreEspecialidad
            // 
            this.nombreEspecialidad.Location = new System.Drawing.Point(111, 64);
            this.nombreEspecialidad.Name = "nombreEspecialidad";
            this.nombreEspecialidad.ReadOnly = true;
            this.nombreEspecialidad.Size = new System.Drawing.Size(100, 20);
            this.nombreEspecialidad.TabIndex = 1;
            // 
            // fechaAlta
            // 
            this.fechaAlta.AutoSize = true;
            this.fechaAlta.Location = new System.Drawing.Point(33, 100);
            this.fechaAlta.Name = "fechaAlta";
            this.fechaAlta.Size = new System.Drawing.Size(72, 13);
            this.fechaAlta.TabIndex = 2;
            this.fechaAlta.Text = "Fecha de alta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 100);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // estaDisponible
            // 
            this.estaDisponible.AutoSize = true;
            this.estaDisponible.Location = new System.Drawing.Point(36, 153);
            this.estaDisponible.Name = "estaDisponible";
            this.estaDisponible.Size = new System.Drawing.Size(109, 17);
            this.estaDisponible.TabIndex = 4;
            this.estaDisponible.Text = "¿Está disponible?";
            this.estaDisponible.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Observaciones";
            // 
            // textoObservaciones
            // 
            this.textoObservaciones.Location = new System.Drawing.Point(110, 213);
            this.textoObservaciones.Name = "textoObservaciones";
            this.textoObservaciones.Size = new System.Drawing.Size(100, 20);
            this.textoObservaciones.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Código";
            // 
            // codigoEspecialidad
            // 
            this.codigoEspecialidad.Location = new System.Drawing.Point(111, 28);
            this.codigoEspecialidad.Name = "codigoEspecialidad";
            this.codigoEspecialidad.ReadOnly = true;
            this.codigoEspecialidad.Size = new System.Drawing.Size(100, 20);
            this.codigoEspecialidad.TabIndex = 10;
            // 
            // ModProfEspFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 315);
            this.Controls.Add(this.codigoEspecialidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textoObservaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.estaDisponible);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.fechaAlta);
            this.Controls.Add(this.nombreEspecialidad);
            this.Controls.Add(this.label1);
            this.Name = "ModProfEspFrm";
            this.Text = "ModProfEspFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreEspecialidad;
        private System.Windows.Forms.Label fechaAlta;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox estaDisponible;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textoObservaciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codigoEspecialidad;
    }
}