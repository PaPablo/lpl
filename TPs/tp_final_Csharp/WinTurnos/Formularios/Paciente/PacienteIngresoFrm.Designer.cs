﻿namespace WinTurnos.Formularios
{
    partial class PacienteIngresoFrm
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
            this.maskedDNI = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.modificarChk = new System.Windows.Forms.CheckBox();
            this.turnosChk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // maskedDNI
            // 
            this.maskedDNI.Location = new System.Drawing.Point(85, 36);
            this.maskedDNI.Mask = "99999999";
            this.maskedDNI.Name = "maskedDNI";
            this.maskedDNI.Size = new System.Drawing.Size(100, 20);
            this.maskedDNI.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // modificarChk
            // 
            this.modificarChk.AutoSize = true;
            this.modificarChk.Location = new System.Drawing.Point(44, 144);
            this.modificarChk.Name = "modificarChk";
            this.modificarChk.Size = new System.Drawing.Size(69, 17);
            this.modificarChk.TabIndex = 4;
            this.modificarChk.Text = "Modificar";
            this.modificarChk.UseVisualStyleBackColor = true;
            this.modificarChk.CheckedChanged += new System.EventHandler(this.modificarChk_CheckedChanged);
            // 
            // turnosChk
            // 
            this.turnosChk.AutoSize = true;
            this.turnosChk.Location = new System.Drawing.Point(159, 144);
            this.turnosChk.Name = "turnosChk";
            this.turnosChk.Size = new System.Drawing.Size(74, 17);
            this.turnosChk.TabIndex = 5;
            this.turnosChk.Text = "Ver turnos";
            this.turnosChk.UseVisualStyleBackColor = true;
            this.turnosChk.CheckedChanged += new System.EventHandler(this.turnosChk_CheckedChanged);
            // 
            // PacienteIngresoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 242);
            this.Controls.Add(this.turnosChk);
            this.Controls.Add(this.modificarChk);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedDNI);
            this.Name = "PacienteIngresoFrm";
            this.Text = "Ingreso de paciente";
            this.Load += new System.EventHandler(this.PacienteIngresoFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox modificarChk;
        private System.Windows.Forms.CheckBox turnosChk;
    }
}