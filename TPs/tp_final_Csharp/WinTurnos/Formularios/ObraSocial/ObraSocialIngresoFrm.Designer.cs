namespace WinTurnos.Formularios
{
    partial class ObraSocialIngresoFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.CodigoTxt = new System.Windows.Forms.TextBox();
            this.PacientesChk = new System.Windows.Forms.CheckBox();
            this.ModificarChk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AceptarBtn
            // 
            this.AceptarBtn.Location = new System.Drawing.Point(28, 122);
            this.AceptarBtn.Name = "AceptarBtn";
            this.AceptarBtn.Size = new System.Drawing.Size(83, 31);
            this.AceptarBtn.TabIndex = 0;
            this.AceptarBtn.Text = "Aceptar";
            this.AceptarBtn.UseVisualStyleBackColor = true;
            this.AceptarBtn.Click += new System.EventHandler(this.AceptarBtn_Click);
            // 
            // CancelarBtn
            // 
            this.CancelarBtn.Location = new System.Drawing.Point(150, 122);
            this.CancelarBtn.Name = "CancelarBtn";
            this.CancelarBtn.Size = new System.Drawing.Size(83, 31);
            this.CancelarBtn.TabIndex = 1;
            this.CancelarBtn.Text = "Cancelar";
            this.CancelarBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código";
            // 
            // CodigoTxt
            // 
            this.CodigoTxt.Location = new System.Drawing.Point(106, 22);
            this.CodigoTxt.Name = "CodigoTxt";
            this.CodigoTxt.Size = new System.Drawing.Size(100, 20);
            this.CodigoTxt.TabIndex = 3;
            // 
            // PacientesChk
            // 
            this.PacientesChk.AutoSize = true;
            this.PacientesChk.Location = new System.Drawing.Point(150, 70);
            this.PacientesChk.Name = "PacientesChk";
            this.PacientesChk.Size = new System.Drawing.Size(73, 17);
            this.PacientesChk.TabIndex = 4;
            this.PacientesChk.Text = "Pacientes";
            this.PacientesChk.UseVisualStyleBackColor = true;
            this.PacientesChk.CheckedChanged += new System.EventHandler(this.PacientesChk_CheckedChanged);
            // 
            // ModificarChk
            // 
            this.ModificarChk.AutoSize = true;
            this.ModificarChk.Location = new System.Drawing.Point(28, 70);
            this.ModificarChk.Name = "ModificarChk";
            this.ModificarChk.Size = new System.Drawing.Size(69, 17);
            this.ModificarChk.TabIndex = 5;
            this.ModificarChk.Text = "Modificar";
            this.ModificarChk.UseVisualStyleBackColor = true;
            this.ModificarChk.CheckedChanged += new System.EventHandler(this.ModificarChk_CheckedChanged);
            // 
            // ObraSocialIngresoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 185);
            this.Controls.Add(this.ModificarChk);
            this.Controls.Add(this.PacientesChk);
            this.Controls.Add(this.CodigoTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelarBtn);
            this.Controls.Add(this.AceptarBtn);
            this.Name = "ObraSocialIngresoFrm";
            this.Text = "ObraSocialIngresoFrm";
            this.Load += new System.EventHandler(this.ObraSocialIngresoFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AceptarBtn;
        private System.Windows.Forms.Button CancelarBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CodigoTxt;
        private System.Windows.Forms.CheckBox PacientesChk;
        private System.Windows.Forms.CheckBox ModificarChk;
    }
}