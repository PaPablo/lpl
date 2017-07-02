namespace WinTurnos.Formularios
{
    partial class ProfesionalesResultsFrm
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
            this.gridProfesionales = new System.Windows.Forms.DataGridView();
            this.CerrarBtn = new System.Windows.Forms.Button();
            this.Mátricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edicion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // gridProfesionales
            // 
            this.gridProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProfesionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mátricula,
            this.NombreApellido,
            this.Telefono,
            this.Edicion,
            this.Activo});
            this.gridProfesionales.Location = new System.Drawing.Point(2, 12);
            this.gridProfesionales.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.gridProfesionales.Name = "gridProfesionales";
            this.gridProfesionales.Size = new System.Drawing.Size(693, 316);
            this.gridProfesionales.TabIndex = 0;
            this.gridProfesionales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProfesionales_CellContentClick);
            this.gridProfesionales.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridProfesionales_DataBindingComplete);
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
            // Mátricula
            // 
            this.Mátricula.DataPropertyName = "Mátricula";
            this.Mátricula.HeaderText = "Mátricula";
            this.Mátricula.Name = "Mátricula";
            // 
            // NombreApellido
            // 
            this.NombreApellido.HeaderText = "Nombre y Apellido";
            this.NombreApellido.Name = "NombreApellido";
            this.NombreApellido.Width = 250;
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
            // Activo
            // 
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            // 
            // ProfesionalesResultsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 406);
            this.Controls.Add(this.CerrarBtn);
            this.Controls.Add(this.gridProfesionales);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfesionalesResultsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Profesionales";
            this.Load += new System.EventHandler(this.ProfesionalFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProfesionales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridProfesionales;
        private System.Windows.Forms.Button CerrarBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mátricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewButtonColumn Edicion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activo;
    }
}