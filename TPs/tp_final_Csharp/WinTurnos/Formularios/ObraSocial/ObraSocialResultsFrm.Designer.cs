namespace WinTurnos.Formularios
{
    partial class ObraSocialResultsFrm
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
            this.gridObrasSociales = new System.Windows.Forms.DataGridView();
            this.CerrarBtn = new System.Windows.Forms.Button();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridObrasSociales)).BeginInit();
            this.SuspendLayout();
            // 
            // gridObrasSociales
            // 
            this.gridObrasSociales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridObrasSociales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre});
            this.gridObrasSociales.Location = new System.Drawing.Point(2, 12);
            this.gridObrasSociales.Name = "gridObrasSociales";
            this.gridObrasSociales.Size = new System.Drawing.Size(625, 316);
            this.gridObrasSociales.TabIndex = 0;
            this.gridObrasSociales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridObraSocial_CellContentClick);
            this.gridObrasSociales.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridObraSocial_DataBindingComplete);
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
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 150;
            // 
            // ObraSocialResultsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 406);
            this.Controls.Add(this.CerrarBtn);
            this.Controls.Add(this.gridObrasSociales);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObraSocialResultsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":w";
            this.Load += new System.EventHandler(this.ObraSocialFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridObrasSociales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridObrasSociales;
        private System.Windows.Forms.Button CerrarBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}