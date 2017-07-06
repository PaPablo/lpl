namespace WinTurnos.Formularios
{
    partial class PacientesResultsFrm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridPacientes = new System.Windows.Forms.DataGridView();
            this.CerrarBtn = new System.Windows.Forms.Button();
            this.dni_pac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edicion = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPacientes
            // 
            this.gridPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dni_pac,
            this.NombreApellido,
            this.Domicilio,
            this.Telefono,
            this.Edicion});
            this.gridPacientes.Location = new System.Drawing.Point(2, 12);
            this.gridPacientes.Name = "gridPacientes";
            this.gridPacientes.Size = new System.Drawing.Size(645, 316);
            this.gridPacientes.TabIndex = 0;
            this.gridPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPacientes_CellContentClick);
            this.gridPacientes.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridPacientes_DataBindingComplete);
            // 
            // CerrarBtn
            // 
            this.CerrarBtn.Location = new System.Drawing.Point(498, 367);
            this.CerrarBtn.Name = "CerrarBtn";
            this.CerrarBtn.Size = new System.Drawing.Size(84, 27);
            this.CerrarBtn.TabIndex = 14;
            this.CerrarBtn.Text = "Cerrar";
            this.CerrarBtn.UseVisualStyleBackColor = true;
            this.CerrarBtn.Click += new System.EventHandler(this.CerrarBtn_Click);
            // 
            // dni_pac
            // 
            this.dni_pac.HeaderText = "DNI";
            this.dni_pac.Name = "dni_pac";
            // 
            // NombreApellido
            // 
            this.NombreApellido.HeaderText = "Nombre y Apellido";
            this.NombreApellido.Name = "NombreApellido";
            this.NombreApellido.Width = 200;
            // 
            // Domicilio
            // 
            this.Domicilio.DataPropertyName = "Domicilio";
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.Name = "Domicilio";
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "Telefono";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            // 
            // Edicion
            // 
            this.Edicion.HeaderText = "Editar";
            this.Edicion.Name = "Edicion";
            this.Edicion.Text = "Editar";
            this.Edicion.UseColumnTextForButtonValue = true;
            // 
            // PacientesResultsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 406);
            this.Controls.Add(this.CerrarBtn);
            this.Controls.Add(this.gridPacientes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PacientesResultsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Pacientes";
            this.Load += new System.EventHandler(this.PacienteFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPacientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPacientes;
        private System.Windows.Forms.Button CerrarBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni_pac;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewButtonColumn Edicion;
    }
}