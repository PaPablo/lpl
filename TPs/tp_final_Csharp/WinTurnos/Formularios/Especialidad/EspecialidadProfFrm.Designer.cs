namespace WinTurnos.Formularios
{
    partial class EspecialidadProfFrm
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
            this.gridProfesionales = new System.Windows.Forms.DataGridView();
            this.CodigoProf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obsevaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreEsp = new System.Windows.Forms.TextBox();
            this.codigoEsp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // gridProfesionales
            // 
            this.gridProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProfesionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoProf,
            this.NombreProf,
            this.FechaAlta,
            this.Disponible,
            this.Obsevaciones});
            this.gridProfesionales.Location = new System.Drawing.Point(12, 85);
            this.gridProfesionales.Name = "gridProfesionales";
            this.gridProfesionales.Size = new System.Drawing.Size(795, 313);
            this.gridProfesionales.TabIndex = 0;
            this.gridProfesionales.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // CodigoProf
            // 
            this.CodigoProf.HeaderText = "Código";
            this.CodigoProf.Name = "CodigoProf";
            // 
            // NombreProf
            // 
            this.NombreProf.HeaderText = "Nombre";
            this.NombreProf.Name = "NombreProf";
            this.NombreProf.Width = 200;
            // 
            // FechaAlta
            // 
            this.FechaAlta.HeaderText = "Fecha de alta";
            this.FechaAlta.Name = "FechaAlta";
            this.FechaAlta.Width = 150;
            // 
            // Disponible
            // 
            this.Disponible.HeaderText = "¿Disponible?";
            this.Disponible.Name = "Disponible";
            // 
            // Obsevaciones
            // 
            this.Obsevaciones.HeaderText = "Observaciones";
            this.Obsevaciones.Name = "Obsevaciones";
            this.Obsevaciones.Width = 200;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(732, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Código";
            // 
            // nombreEsp
            // 
            this.nombreEsp.Location = new System.Drawing.Point(98, 26);
            this.nombreEsp.Name = "nombreEsp";
            this.nombreEsp.ReadOnly = true;
            this.nombreEsp.Size = new System.Drawing.Size(100, 20);
            this.nombreEsp.TabIndex = 4;
            // 
            // codigoEsp
            // 
            this.codigoEsp.Location = new System.Drawing.Point(571, 26);
            this.codigoEsp.Name = "codigoEsp";
            this.codigoEsp.ReadOnly = true;
            this.codigoEsp.Size = new System.Drawing.Size(100, 20);
            this.codigoEsp.TabIndex = 5;
            // 
            // EspecialidadProfFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 456);
            this.Controls.Add(this.codigoEsp);
            this.Controls.Add(this.nombreEsp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridProfesionales);
            this.Name = "EspecialidadProfFrm";
            this.Text = "Profesionales de una especialidad";
            ((System.ComponentModel.ISupportInitialize)(this.gridProfesionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridProfesionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProf;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProf;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAlta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obsevaciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreEsp;
        private System.Windows.Forms.TextBox codigoEsp;
    }
}