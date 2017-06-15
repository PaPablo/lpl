namespace WinTurnos.Formularios
{
    partial class FormTestModel
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
            this.ObraSocialCbo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CargarOSBtn = new System.Windows.Forms.Button();
            this.ObraSocialAddBtn = new System.Windows.Forms.Button();
            this.gridPacienteObraSocial = new System.Windows.Forms.DataGridView();
            this.CargarGrillaBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridPacienteObraSocial)).BeginInit();
            this.SuspendLayout();
            // 
            // ObraSocialCbo
            // 
            this.ObraSocialCbo.FormattingEnabled = true;
            this.ObraSocialCbo.Location = new System.Drawing.Point(98, 14);
            this.ObraSocialCbo.Name = "ObraSocialCbo";
            this.ObraSocialCbo.Size = new System.Drawing.Size(159, 21);
            this.ObraSocialCbo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Obras Sociales:";
            // 
            // CargarOSBtn
            // 
            this.CargarOSBtn.Location = new System.Drawing.Point(263, 12);
            this.CargarOSBtn.Name = "CargarOSBtn";
            this.CargarOSBtn.Size = new System.Drawing.Size(73, 24);
            this.CargarOSBtn.TabIndex = 2;
            this.CargarOSBtn.Text = "Cargar";
            this.CargarOSBtn.UseVisualStyleBackColor = true;
            this.CargarOSBtn.Click += new System.EventHandler(this.CargarOSBtn_Click);
            // 
            // ObraSocialAddBtn
            // 
            this.ObraSocialAddBtn.Location = new System.Drawing.Point(12, 73);
            this.ObraSocialAddBtn.Name = "ObraSocialAddBtn";
            this.ObraSocialAddBtn.Size = new System.Drawing.Size(111, 39);
            this.ObraSocialAddBtn.TabIndex = 3;
            this.ObraSocialAddBtn.Text = "Prueba de Ingreso de Obj";
            this.ObraSocialAddBtn.UseVisualStyleBackColor = true;
            this.ObraSocialAddBtn.Click += new System.EventHandler(this.ObraSocialAddBtn_Click);
            // 
            // gridPacienteObraSocial
            // 
            this.gridPacienteObraSocial.AllowUserToAddRows = false;
            this.gridPacienteObraSocial.AllowUserToDeleteRows = false;
            this.gridPacienteObraSocial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPacienteObraSocial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Paciente,
            this.ObraSocial});
            this.gridPacienteObraSocial.Location = new System.Drawing.Point(309, 104);
            this.gridPacienteObraSocial.Name = "gridPacienteObraSocial";
            this.gridPacienteObraSocial.Size = new System.Drawing.Size(473, 126);
            this.gridPacienteObraSocial.TabIndex = 4;
            this.gridPacienteObraSocial.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridPacienteObraSocial_DataBindingComplete);
            // 
            // CargarGrillaBtn
            // 
            this.CargarGrillaBtn.Location = new System.Drawing.Point(495, 61);
            this.CargarGrillaBtn.Name = "CargarGrillaBtn";
            this.CargarGrillaBtn.Size = new System.Drawing.Size(120, 37);
            this.CargarGrillaBtn.TabIndex = 5;
            this.CargarGrillaBtn.Text = "Cargar";
            this.CargarGrillaBtn.UseVisualStyleBackColor = true;
            this.CargarGrillaBtn.Click += new System.EventHandler(this.CargarGrillaBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Grilla de Obra Sociales de Pacientes";
            // 
            // Paciente
            // 
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.Width = 250;
            // 
            // ObraSocial
            // 
            this.ObraSocial.HeaderText = "ObraSocial";
            this.ObraSocial.Name = "ObraSocial";
            this.ObraSocial.Width = 150;
            // 
            // FormTestModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 464);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CargarGrillaBtn);
            this.Controls.Add(this.gridPacienteObraSocial);
            this.Controls.Add(this.ObraSocialAddBtn);
            this.Controls.Add(this.CargarOSBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ObraSocialCbo);
            this.Name = "FormTestModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTestModel";
            ((System.ComponentModel.ISupportInitialize)(this.gridPacienteObraSocial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ObraSocialCbo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CargarOSBtn;
        private System.Windows.Forms.Button ObraSocialAddBtn;
        private System.Windows.Forms.DataGridView gridPacienteObraSocial;
        private System.Windows.Forms.Button CargarGrillaBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObraSocial;
    }
}