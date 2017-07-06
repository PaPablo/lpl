namespace WinTurnos.Formularios
{
    partial class ObraSocialPacienteFrm
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
            this.GridPacienteObraSocial = new System.Windows.Forms.DataGridView();
            this.DniPacienteGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombrePacienteGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CerrarBtn = new System.Windows.Forms.Button();
            this.codigoObraSocialLbl = new System.Windows.Forms.Label();
            this.NombreObraSocialLbl = new System.Windows.Forms.Label();
            this.NombreObraSocial = new System.Windows.Forms.TextBox();
            this.CodigoObraSocial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridPacienteObraSocial)).BeginInit();
            this.SuspendLayout();
            // 
            // GridPacienteObraSocial
            // 
            this.GridPacienteObraSocial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPacienteObraSocial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DniPacienteGrid,
            this.NombrePacienteGrid});
            this.GridPacienteObraSocial.Location = new System.Drawing.Point(12, 55);
            this.GridPacienteObraSocial.Name = "GridPacienteObraSocial";
            this.GridPacienteObraSocial.Size = new System.Drawing.Size(394, 209);
            this.GridPacienteObraSocial.TabIndex = 0;
            this.GridPacienteObraSocial.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GridPacienteObraSocial_DataBindingComplete);
            // 
            // DniPacienteGrid
            // 
            this.DniPacienteGrid.HeaderText = "DNI";
            this.DniPacienteGrid.Name = "DniPacienteGrid";
            // 
            // NombrePacienteGrid
            // 
            this.NombrePacienteGrid.HeaderText = "Nombre";
            this.NombrePacienteGrid.Name = "NombrePacienteGrid";
            this.NombrePacienteGrid.Width = 250;
            // 
            // CerrarBtn
            // 
            this.CerrarBtn.Location = new System.Drawing.Point(365, 300);
            this.CerrarBtn.Name = "CerrarBtn";
            this.CerrarBtn.Size = new System.Drawing.Size(83, 31);
            this.CerrarBtn.TabIndex = 1;
            this.CerrarBtn.Text = "Cerrar";
            this.CerrarBtn.UseVisualStyleBackColor = true;
            this.CerrarBtn.Click += new System.EventHandler(this.CerrarBtn_Click);
            // 
            // codigoObraSocialLbl
            // 
            this.codigoObraSocialLbl.AutoSize = true;
            this.codigoObraSocialLbl.Location = new System.Drawing.Point(57, 13);
            this.codigoObraSocialLbl.Name = "codigoObraSocialLbl";
            this.codigoObraSocialLbl.Size = new System.Drawing.Size(40, 13);
            this.codigoObraSocialLbl.TabIndex = 2;
            this.codigoObraSocialLbl.Text = "Código";
            // 
            // NombreObraSocialLbl
            // 
            this.NombreObraSocialLbl.AutoSize = true;
            this.NombreObraSocialLbl.Location = new System.Drawing.Point(278, 13);
            this.NombreObraSocialLbl.Name = "NombreObraSocialLbl";
            this.NombreObraSocialLbl.Size = new System.Drawing.Size(44, 13);
            this.NombreObraSocialLbl.TabIndex = 4;
            this.NombreObraSocialLbl.Text = "Nombre";
            this.NombreObraSocialLbl.Click += new System.EventHandler(this.nombrePacienteLbl_Click);
            // 
            // NombreObraSocial
            // 
            this.NombreObraSocial.Location = new System.Drawing.Point(328, 10);
            this.NombreObraSocial.Name = "NombreObraSocial";
            this.NombreObraSocial.ReadOnly = true;
            this.NombreObraSocial.Size = new System.Drawing.Size(120, 20);
            this.NombreObraSocial.TabIndex = 6;
            // 
            // CodigoObraSocial
            // 
            this.CodigoObraSocial.Location = new System.Drawing.Point(103, 10);
            this.CodigoObraSocial.Name = "CodigoObraSocial";
            this.CodigoObraSocial.ReadOnly = true;
            this.CodigoObraSocial.Size = new System.Drawing.Size(120, 20);
            this.CodigoObraSocial.TabIndex = 7;
            // 
            // ObraSocialPacienteFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 348);
            this.Controls.Add(this.CodigoObraSocial);
            this.Controls.Add(this.NombreObraSocial);
            this.Controls.Add(this.NombreObraSocialLbl);
            this.Controls.Add(this.codigoObraSocialLbl);
            this.Controls.Add(this.CerrarBtn);
            this.Controls.Add(this.GridPacienteObraSocial);
            this.Name = "ObraSocialPacienteFrm";
            this.Text = "Pacientes por obra social";
            this.Load += new System.EventHandler(this.ObraSocialPacienteFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridPacienteObraSocial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridPacienteObraSocial;
        private System.Windows.Forms.Button CerrarBtn;
        private System.Windows.Forms.Label codigoObraSocialLbl;
        private System.Windows.Forms.Label NombreObraSocialLbl;
        private System.Windows.Forms.TextBox NombreObraSocial;
        private System.Windows.Forms.TextBox CodigoObraSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn DniPacienteGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombrePacienteGrid;
    }
}