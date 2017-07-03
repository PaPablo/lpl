namespace WinTurnos.Formularios
{
    partial class TurnoAMFrm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dniPaciente = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.matriculaProfesional = new System.Windows.Forms.MaskedTextBox();
            this.asistioChk = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(63, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DNI Paciente:";
            // 
            // dniPaciente
            // 
            this.dniPaciente.Location = new System.Drawing.Point(93, 74);
            this.dniPaciente.Mask = "99999999";
            this.dniPaciente.Name = "dniPaciente";
            this.dniPaciente.Size = new System.Drawing.Size(100, 20);
            this.dniPaciente.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Matrícula del\r\nprofesional:";
            // 
            // matriculaProfesional
            // 
            this.matriculaProfesional.Location = new System.Drawing.Point(93, 123);
            this.matriculaProfesional.Mask = "LL9999";
            this.matriculaProfesional.Name = "matriculaProfesional";
            this.matriculaProfesional.Size = new System.Drawing.Size(100, 20);
            this.matriculaProfesional.TabIndex = 5;
            // 
            // asistioChk
            // 
            this.asistioChk.AutoSize = true;
            this.asistioChk.Location = new System.Drawing.Point(22, 174);
            this.asistioChk.Name = "asistioChk";
            this.asistioChk.Size = new System.Drawing.Size(68, 17);
            this.asistioChk.TabIndex = 6;
            this.asistioChk.Text = "¿Asistió?";
            this.asistioChk.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TurnoAMFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.asistioChk);
            this.Controls.Add(this.matriculaProfesional);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dniPaciente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "TurnoAMFrm";
            this.Text = "TurnoAMFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox dniPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox matriculaProfesional;
        private System.Windows.Forms.CheckBox asistioChk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}