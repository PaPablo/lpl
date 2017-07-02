namespace WinTurnos.Formularios
{
    partial class PacienteTurnosFrm
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
            this.gridTurnos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.nombrePaciente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dniPaciente = new System.Windows.Forms.TextBox();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asistio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTurnos
            // 
            this.gridTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Profesional,
            this.Matricula,
            this.Asistio});
            this.gridTurnos.Location = new System.Drawing.Point(3, 64);
            this.gridTurnos.Name = "gridTurnos";
            this.gridTurnos.Size = new System.Drawing.Size(656, 357);
            this.gridTurnos.TabIndex = 0;
            this.gridTurnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.gridTurnos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre y apellido:";
            // 
            // nombrePaciente
            // 
            this.nombrePaciente.Location = new System.Drawing.Point(113, 10);
            this.nombrePaciente.Name = "nombrePaciente";
            this.nombrePaciente.ReadOnly = true;
            this.nombrePaciente.Size = new System.Drawing.Size(224, 20);
            this.nombrePaciente.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "DNI:";
            // 
            // dniPaciente
            // 
            this.dniPaciente.Location = new System.Drawing.Point(414, 12);
            this.dniPaciente.Name = "dniPaciente";
            this.dniPaciente.ReadOnly = true;
            this.dniPaciente.Size = new System.Drawing.Size(120, 20);
            this.dniPaciente.TabIndex = 4;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 160;
            // 
            // Profesional
            // 
            this.Profesional.HeaderText = "Profesional";
            this.Profesional.Name = "Profesional";
            this.Profesional.Width = 250;
            // 
            // Matricula
            // 
            this.Matricula.HeaderText = "Matrícula";
            this.Matricula.Name = "Matricula";
            // 
            // Asistio
            // 
            this.Asistio.HeaderText = "¿Asistió?";
            this.Asistio.Name = "Asistio";
            // 
            // PacienteTurnosFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 433);
            this.Controls.Add(this.dniPaciente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombrePaciente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridTurnos);
            this.Name = "PacienteTurnosFrm";
            this.Text = "PacienteTurnosFrm";
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTurnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombrePaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dniPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asistio;
    }
}