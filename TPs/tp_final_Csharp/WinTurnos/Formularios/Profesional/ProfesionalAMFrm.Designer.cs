namespace WinTurnos.Formularios
{
    partial class ProfesionalAMFrm
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
            this.AceptarBtn = new System.Windows.Forms.Button();
            this.CancelarBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.NombreTxt = new System.Windows.Forms.TextBox();
            this.EsActivo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ApellidoTxt = new System.Windows.Forms.TextBox();
            this.TelefonoTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FechaMatricula = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.MatriculaTxt = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // AceptarBtn
            // 
            this.AceptarBtn.Location = new System.Drawing.Point(54, 234);
            this.AceptarBtn.Name = "AceptarBtn";
            this.AceptarBtn.Size = new System.Drawing.Size(83, 31);
            this.AceptarBtn.TabIndex = 16;
            this.AceptarBtn.Text = "Aceptar";
            this.AceptarBtn.UseVisualStyleBackColor = true;
            this.AceptarBtn.Click += new System.EventHandler(this.AceptarBtn_Click);
            // 
            // CancelarBtn
            // 
            this.CancelarBtn.Location = new System.Drawing.Point(195, 234);
            this.CancelarBtn.Name = "CancelarBtn";
            this.CancelarBtn.Size = new System.Drawing.Size(83, 31);
            this.CancelarBtn.TabIndex = 17;
            this.CancelarBtn.Text = "Cancelar";
            this.CancelarBtn.UseVisualStyleBackColor = true;
            this.CancelarBtn.Click += new System.EventHandler(this.CancelarBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nombre:";
            // 
            // NombreTxt
            // 
            this.NombreTxt.Location = new System.Drawing.Point(118, 78);
            this.NombreTxt.Name = "NombreTxt";
            this.NombreTxt.Size = new System.Drawing.Size(200, 20);
            this.NombreTxt.TabIndex = 9;
            // 
            // EsActivo
            // 
            this.EsActivo.AutoSize = true;
            this.EsActivo.BackColor = System.Drawing.SystemColors.Control;
            this.EsActivo.Location = new System.Drawing.Point(60, 190);
            this.EsActivo.Name = "EsActivo";
            this.EsActivo.Size = new System.Drawing.Size(56, 17);
            this.EsActivo.TabIndex = 20;
            this.EsActivo.Text = "Activo";
            this.EsActivo.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Matrícula:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Apellido:";
            // 
            // ApellidoTxt
            // 
            this.ApellidoTxt.Location = new System.Drawing.Point(118, 104);
            this.ApellidoTxt.Name = "ApellidoTxt";
            this.ApellidoTxt.Size = new System.Drawing.Size(200, 20);
            this.ApellidoTxt.TabIndex = 23;
            // 
            // TelefonoTxt
            // 
            this.TelefonoTxt.Location = new System.Drawing.Point(118, 131);
            this.TelefonoTxt.Name = "TelefonoTxt";
            this.TelefonoTxt.Size = new System.Drawing.Size(200, 20);
            this.TelefonoTxt.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Teléfono:";
            // 
            // FechaMatricula
            // 
            this.FechaMatricula.Location = new System.Drawing.Point(118, 158);
            this.FechaMatricula.Name = "FechaMatricula";
            this.FechaMatricula.Size = new System.Drawing.Size(200, 20);
            this.FechaMatricula.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Fecha Matrícula:";
            // 
            // MatriculaTxt
            // 
            this.MatriculaTxt.Location = new System.Drawing.Point(118, 48);
            this.MatriculaTxt.Mask = "LL9999";
            this.MatriculaTxt.Name = "MatriculaTxt";
            this.MatriculaTxt.Size = new System.Drawing.Size(200, 20);
            this.MatriculaTxt.TabIndex = 29;
            // 
            // ProfesionalAMFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 300);
            this.Controls.Add(this.MatriculaTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FechaMatricula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TelefonoTxt);
            this.Controls.Add(this.ApellidoTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EsActivo);
            this.Controls.Add(this.CancelarBtn);
            this.Controls.Add(this.AceptarBtn);
            this.Controls.Add(this.NombreTxt);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfesionalAMFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Profesional";
            this.Load += new System.EventHandler(this.ProfesionalAMFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AceptarBtn;
        private System.Windows.Forms.Button CancelarBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NombreTxt;
        private System.Windows.Forms.CheckBox EsActivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ApellidoTxt;
        private System.Windows.Forms.TextBox TelefonoTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FechaMatricula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox MatriculaTxt;
    }
}