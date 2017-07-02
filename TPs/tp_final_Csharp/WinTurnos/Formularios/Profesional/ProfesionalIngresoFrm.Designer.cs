namespace WinTurnos.Formularios
{
    partial class ProfesionalIngresoFrm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedMatricula = new System.Windows.Forms.MaskedTextBox();
            this.modificarChk = new System.Windows.Forms.CheckBox();
            this.especialidadesChk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Matrícula:";
            // 
            // maskedMatricula
            // 
            this.maskedMatricula.Location = new System.Drawing.Point(97, 45);
            this.maskedMatricula.Mask = "LL9999";
            this.maskedMatricula.Name = "maskedMatricula";
            this.maskedMatricula.Size = new System.Drawing.Size(100, 20);
            this.maskedMatricula.TabIndex = 3;
            // 
            // modificarChk
            // 
            this.modificarChk.AutoSize = true;
            this.modificarChk.Location = new System.Drawing.Point(22, 162);
            this.modificarChk.Name = "modificarChk";
            this.modificarChk.Size = new System.Drawing.Size(69, 17);
            this.modificarChk.TabIndex = 4;
            this.modificarChk.Text = "Modificar";
            this.modificarChk.UseVisualStyleBackColor = true;
            this.modificarChk.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // especialidadesChk
            // 
            this.especialidadesChk.AutoSize = true;
            this.especialidadesChk.Location = new System.Drawing.Point(157, 162);
            this.especialidadesChk.Name = "especialidadesChk";
            this.especialidadesChk.Size = new System.Drawing.Size(115, 17);
            this.especialidadesChk.TabIndex = 5;
            this.especialidadesChk.Text = "Ver especialidades";
            this.especialidadesChk.UseVisualStyleBackColor = true;
            this.especialidadesChk.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ProfesionalIngresoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.especialidadesChk);
            this.Controls.Add(this.modificarChk);
            this.Controls.Add(this.maskedMatricula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ProfesionalIngresoFrm";
            this.Text = "Ingreso de profesional";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedMatricula;
        private System.Windows.Forms.CheckBox modificarChk;
        private System.Windows.Forms.CheckBox especialidadesChk;
    }
}