namespace WinTurnos.Formularios
{
    partial class TurnoBusqFrm
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
            this.dniChk = new System.Windows.Forms.CheckBox();
            this.matriculaChk = new System.Windows.Forms.CheckBox();
            this.fechaChk = new System.Windows.Forms.CheckBox();
            this.todoChk = new System.Windows.Forms.CheckBox();
            this.dniPaciente = new System.Windows.Forms.MaskedTextBox();
            this.matriculaProfesional = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dniChk
            // 
            this.dniChk.AutoSize = true;
            this.dniChk.Location = new System.Drawing.Point(13, 45);
            this.dniChk.Name = "dniChk";
            this.dniChk.Size = new System.Drawing.Size(89, 17);
            this.dniChk.TabIndex = 0;
            this.dniChk.Text = "DNI paciente";
            this.dniChk.UseVisualStyleBackColor = true;
            this.dniChk.CheckedChanged += new System.EventHandler(this.dniChk_CheckedChanged);
            // 
            // matriculaChk
            // 
            this.matriculaChk.AutoSize = true;
            this.matriculaChk.Location = new System.Drawing.Point(13, 91);
            this.matriculaChk.Name = "matriculaChk";
            this.matriculaChk.Size = new System.Drawing.Size(88, 30);
            this.matriculaChk.TabIndex = 1;
            this.matriculaChk.Text = "Matrícula del\r\nprofesional\r\n";
            this.matriculaChk.UseVisualStyleBackColor = true;
            this.matriculaChk.CheckedChanged += new System.EventHandler(this.matriculaChk_CheckedChanged);
            // 
            // fechaChk
            // 
            this.fechaChk.AutoSize = true;
            this.fechaChk.Location = new System.Drawing.Point(13, 132);
            this.fechaChk.Name = "fechaChk";
            this.fechaChk.Size = new System.Drawing.Size(76, 30);
            this.fechaChk.TabIndex = 2;
            this.fechaChk.Text = "Fecha del \r\nturno";
            this.fechaChk.UseVisualStyleBackColor = true;
            this.fechaChk.CheckedChanged += new System.EventHandler(this.fechaChk_CheckedChanged);
            // 
            // todoChk
            // 
            this.todoChk.AutoSize = true;
            this.todoChk.Location = new System.Drawing.Point(13, 216);
            this.todoChk.Name = "todoChk";
            this.todoChk.Size = new System.Drawing.Size(75, 17);
            this.todoChk.TabIndex = 3;
            this.todoChk.Text = "Listar todo";
            this.todoChk.UseVisualStyleBackColor = true;
            this.todoChk.CheckedChanged += new System.EventHandler(this.todoChk_CheckedChanged);
            // 
            // dniPaciente
            // 
            this.dniPaciente.Location = new System.Drawing.Point(100, 45);
            this.dniPaciente.Mask = "99999999";
            this.dniPaciente.Name = "dniPaciente";
            this.dniPaciente.Size = new System.Drawing.Size(100, 20);
            this.dniPaciente.TabIndex = 4;
            // 
            // matriculaProfesional
            // 
            this.matriculaProfesional.Location = new System.Drawing.Point(100, 91);
            this.matriculaProfesional.Mask = "LL9999";
            this.matriculaProfesional.Name = "matriculaProfesional";
            this.matriculaProfesional.Size = new System.Drawing.Size(100, 20);
            this.matriculaProfesional.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 132);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // TurnoBusqFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 318);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.matriculaProfesional);
            this.Controls.Add(this.dniPaciente);
            this.Controls.Add(this.todoChk);
            this.Controls.Add(this.fechaChk);
            this.Controls.Add(this.matriculaChk);
            this.Controls.Add(this.dniChk);
            this.Name = "TurnoBusqFrm";
            this.Text = "TurnoBusqFrm";
            this.Load += new System.EventHandler(this.TurnoBusqFrm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox dniChk;
        private System.Windows.Forms.CheckBox matriculaChk;
        private System.Windows.Forms.CheckBox fechaChk;
        private System.Windows.Forms.CheckBox todoChk;
        private System.Windows.Forms.MaskedTextBox dniPaciente;
        private System.Windows.Forms.MaskedTextBox matriculaProfesional;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}