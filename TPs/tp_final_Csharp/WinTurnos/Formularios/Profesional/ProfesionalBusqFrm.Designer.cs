namespace WinTurnos.Formularios
{
    partial class ProfesionalBusqFrm
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
            this.MatriculaChk = new System.Windows.Forms.CheckBox();
            this.DniMsk = new System.Windows.Forms.MaskedTextBox();
            this.BuscarBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ListTodoChk = new System.Windows.Forms.CheckBox();
            this.ApellidoTxt = new System.Windows.Forms.TextBox();
            this.ApellidoChk = new System.Windows.Forms.CheckBox();
            this.CancelarBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MatriculaChk
            // 
            this.MatriculaChk.AutoSize = true;
            this.MatriculaChk.Location = new System.Drawing.Point(26, 29);
            this.MatriculaChk.Name = "MatriculaChk";
            this.MatriculaChk.Size = new System.Drawing.Size(74, 17);
            this.MatriculaChk.TabIndex = 0;
            this.MatriculaChk.Text = "Matrícula:";
            this.MatriculaChk.UseVisualStyleBackColor = true;
            this.MatriculaChk.CheckedChanged += new System.EventHandler(this.DniChk_CheckedChanged);
            // 
            // DniMsk
            // 
            this.DniMsk.Enabled = false;
            this.DniMsk.Location = new System.Drawing.Point(106, 26);
            this.DniMsk.Mask = "LL0000";
            this.DniMsk.Name = "DniMsk";
            this.DniMsk.Size = new System.Drawing.Size(75, 20);
            this.DniMsk.TabIndex = 1;
            // 
            // BuscarBtn
            // 
            this.BuscarBtn.Location = new System.Drawing.Point(211, 153);
            this.BuscarBtn.Name = "BuscarBtn";
            this.BuscarBtn.Size = new System.Drawing.Size(83, 29);
            this.BuscarBtn.TabIndex = 2;
            this.BuscarBtn.Text = "Buscar";
            this.BuscarBtn.UseVisualStyleBackColor = true;
            this.BuscarBtn.Click += new System.EventHandler(this.BuscarBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListTodoChk);
            this.groupBox1.Controls.Add(this.ApellidoTxt);
            this.groupBox1.Controls.Add(this.ApellidoChk);
            this.groupBox1.Controls.Add(this.MatriculaChk);
            this.groupBox1.Controls.Add(this.DniMsk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 125);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios";
            // 
            // ListTodoChk
            // 
            this.ListTodoChk.AutoSize = true;
            this.ListTodoChk.Location = new System.Drawing.Point(26, 102);
            this.ListTodoChk.Name = "ListTodoChk";
            this.ListTodoChk.Size = new System.Drawing.Size(75, 17);
            this.ListTodoChk.TabIndex = 4;
            this.ListTodoChk.Text = "Listar todo";
            this.ListTodoChk.UseVisualStyleBackColor = true;
            this.ListTodoChk.CheckedChanged += new System.EventHandler(this.ListTodoChk_CheckedChanged);
            // 
            // ApellidoTxt
            // 
            this.ApellidoTxt.Enabled = false;
            this.ApellidoTxt.Location = new System.Drawing.Point(106, 58);
            this.ApellidoTxt.Name = "ApellidoTxt";
            this.ApellidoTxt.Size = new System.Drawing.Size(189, 20);
            this.ApellidoTxt.TabIndex = 3;
            // 
            // ApellidoChk
            // 
            this.ApellidoChk.AutoSize = true;
            this.ApellidoChk.Location = new System.Drawing.Point(26, 61);
            this.ApellidoChk.Name = "ApellidoChk";
            this.ApellidoChk.Size = new System.Drawing.Size(66, 17);
            this.ApellidoChk.TabIndex = 2;
            this.ApellidoChk.Text = "Apellido:";
            this.ApellidoChk.UseVisualStyleBackColor = true;
            this.ApellidoChk.CheckedChanged += new System.EventHandler(this.ApellidoChk_CheckedChanged);
            // 
            // CancelarBtn
            // 
            this.CancelarBtn.Location = new System.Drawing.Point(356, 154);
            this.CancelarBtn.Name = "CancelarBtn";
            this.CancelarBtn.Size = new System.Drawing.Size(80, 28);
            this.CancelarBtn.TabIndex = 4;
            this.CancelarBtn.Text = "Cerrar";
            this.CancelarBtn.UseVisualStyleBackColor = true;
            this.CancelarBtn.Click += new System.EventHandler(this.CancelarBtn_Click);
            // 
            // ProfesionalBusqFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 204);
            this.Controls.Add(this.CancelarBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BuscarBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfesionalBusqFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de paciente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox MatriculaChk;
        private System.Windows.Forms.MaskedTextBox DniMsk;
        private System.Windows.Forms.Button BuscarBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ApellidoTxt;
        private System.Windows.Forms.CheckBox ApellidoChk;
        private System.Windows.Forms.Button CancelarBtn;
        private System.Windows.Forms.CheckBox ListTodoChk;
    }
}