namespace WinTurnos.Formularios
{
    partial class TurnoResultsFrm
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
            this.CerrarBtn = new System.Windows.Forms.Button();
            this.turnosGrid = new System.Windows.Forms.DataGridView();
            this.dniPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matriculaProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asistioChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.editarTurno = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.turnosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CerrarBtn
            // 
            this.CerrarBtn.Location = new System.Drawing.Point(573, 308);
            this.CerrarBtn.Name = "CerrarBtn";
            this.CerrarBtn.Size = new System.Drawing.Size(83, 31);
            this.CerrarBtn.TabIndex = 0;
            this.CerrarBtn.Text = "Cerrar";
            this.CerrarBtn.UseVisualStyleBackColor = true;
            // 
            // turnosGrid
            // 
            this.turnosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.turnosGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dniPaciente,
            this.nombrePaciente,
            this.matriculaProfesional,
            this.nombreProf,
            this.asistioChk,
            this.editarTurno});
            this.turnosGrid.Location = new System.Drawing.Point(12, 12);
            this.turnosGrid.Name = "turnosGrid";
            this.turnosGrid.Size = new System.Drawing.Size(644, 275);
            this.turnosGrid.TabIndex = 1;
            this.turnosGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dniPaciente
            // 
            this.dniPaciente.DataPropertyName = "dniPaciente";
            this.dniPaciente.HeaderText = "DNI Paciente";
            this.dniPaciente.Name = "dniPaciente";
            this.dniPaciente.ReadOnly = true;
            // 
            // nombrePaciente
            // 
            this.nombrePaciente.DataPropertyName = "nombrePaciente";
            this.nombrePaciente.HeaderText = "Nombre del Paciente";
            this.nombrePaciente.Name = "nombrePaciente";
            this.nombrePaciente.ReadOnly = true;
            // 
            // matriculaProfesional
            // 
            this.matriculaProfesional.DataPropertyName = "matriculaProfesional";
            this.matriculaProfesional.HeaderText = "Matricula";
            this.matriculaProfesional.Name = "matriculaProfesional";
            this.matriculaProfesional.ReadOnly = true;
            // 
            // nombreProf
            // 
            this.nombreProf.DataPropertyName = "nombreProf";
            this.nombreProf.HeaderText = "Nombre del Profesional";
            this.nombreProf.Name = "nombreProf";
            this.nombreProf.ReadOnly = true;
            // 
            // asistioChk
            // 
            this.asistioChk.DataPropertyName = "asistioChk";
            this.asistioChk.HeaderText = "¿Asistió?";
            this.asistioChk.Name = "asistioChk";
            this.asistioChk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.asistioChk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // editarTurno
            // 
            this.editarTurno.DataPropertyName = "editarTurno";
            this.editarTurno.HeaderText = "Editar";
            this.editarTurno.Name = "editarTurno";
            this.editarTurno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editarTurno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TurnoResultsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 361);
            this.Controls.Add(this.turnosGrid);
            this.Controls.Add(this.CerrarBtn);
            this.Name = "TurnoResultsFrm";
            this.Text = "TurnoResultsFrm";
            this.Load += new System.EventHandler(this.TurnoResultsFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.turnosGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CerrarBtn;
        private System.Windows.Forms.DataGridView turnosGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dniPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn matriculaProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProf;
        private System.Windows.Forms.DataGridViewCheckBoxColumn asistioChk;
        private System.Windows.Forms.DataGridViewButtonColumn editarTurno;
    }
}