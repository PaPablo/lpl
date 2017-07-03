namespace WinTurnos.Formularios
{
    partial class ProfEspFrm
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
            this.gridEspecialidades = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.codigoEspecialidad = new System.Windows.Forms.CheckBox();
            this.nombreEspecialidad = new System.Windows.Forms.CheckBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.estaDisponible = new System.Windows.Forms.CheckBox();
            this.textObservaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.maskedCodigo = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nombreProfesional = new System.Windows.Forms.TextBox();
            this.matriculaProfesional = new System.Windows.Forms.TextBox();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edicion = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridEspecialidades)).BeginInit();
            this.SuspendLayout();
            // 
            // gridEspecialidades
            // 
            this.gridEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEspecialidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Especialidad,
            this.FechaAlta,
            this.Disponible,
            this.Observaciones,
            this.Edicion});
            this.gridEspecialidades.Location = new System.Drawing.Point(12, 57);
            this.gridEspecialidades.Name = "gridEspecialidades";
            this.gridEspecialidades.Size = new System.Drawing.Size(606, 312);
            this.gridEspecialidades.TabIndex = 0;
            this.gridEspecialidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEspecialidades_CellContentClick);
            this.gridEspecialidades.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agregar nueva especialidad";
            // 
            // codigoEspecialidad
            // 
            this.codigoEspecialidad.AutoSize = true;
            this.codigoEspecialidad.Location = new System.Drawing.Point(648, 80);
            this.codigoEspecialidad.Name = "codigoEspecialidad";
            this.codigoEspecialidad.Size = new System.Drawing.Size(136, 17);
            this.codigoEspecialidad.TabIndex = 2;
            this.codigoEspecialidad.Text = "Código de especialidad";
            this.codigoEspecialidad.UseVisualStyleBackColor = true;
            this.codigoEspecialidad.CheckedChanged += new System.EventHandler(this.codigoEspecialidad_CheckedChanged);
            // 
            // nombreEspecialidad
            // 
            this.nombreEspecialidad.AutoSize = true;
            this.nombreEspecialidad.Location = new System.Drawing.Point(648, 145);
            this.nombreEspecialidad.Name = "nombreEspecialidad";
            this.nombreEspecialidad.Size = new System.Drawing.Size(140, 17);
            this.nombreEspecialidad.TabIndex = 4;
            this.nombreEspecialidad.Text = "Nombre de especialidad";
            this.nombreEspecialidad.UseVisualStyleBackColor = true;
            this.nombreEspecialidad.CheckedChanged += new System.EventHandler(this.nombreEspecialidad_CheckedChanged);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(789, 145);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(100, 20);
            this.textNombre.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(690, 221);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(751, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha de alta";
            // 
            // estaDisponible
            // 
            this.estaDisponible.AutoSize = true;
            this.estaDisponible.Location = new System.Drawing.Point(655, 257);
            this.estaDisponible.Name = "estaDisponible";
            this.estaDisponible.Size = new System.Drawing.Size(109, 17);
            this.estaDisponible.TabIndex = 8;
            this.estaDisponible.Text = "¿Está disponible?";
            this.estaDisponible.UseVisualStyleBackColor = true;
            // 
            // textObservaciones
            // 
            this.textObservaciones.Location = new System.Drawing.Point(754, 292);
            this.textObservaciones.Name = "textObservaciones";
            this.textObservaciones.Size = new System.Drawing.Size(167, 20);
            this.textObservaciones.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(664, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Observaciones";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(664, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(846, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // maskedCodigo
            // 
            this.maskedCodigo.Location = new System.Drawing.Point(790, 80);
            this.maskedCodigo.Mask = "999";
            this.maskedCodigo.Name = "maskedCodigo";
            this.maskedCodigo.Size = new System.Drawing.Size(100, 20);
            this.maskedCodigo.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Profesional:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Matrícula:";
            this.label5.UseMnemonic = false;
            // 
            // nombreProfesional
            // 
            this.nombreProfesional.Location = new System.Drawing.Point(81, 20);
            this.nombreProfesional.Name = "nombreProfesional";
            this.nombreProfesional.ReadOnly = true;
            this.nombreProfesional.Size = new System.Drawing.Size(100, 20);
            this.nombreProfesional.TabIndex = 16;
            // 
            // matriculaProfesional
            // 
            this.matriculaProfesional.Location = new System.Drawing.Point(400, 20);
            this.matriculaProfesional.Name = "matriculaProfesional";
            this.matriculaProfesional.ReadOnly = true;
            this.matriculaProfesional.Size = new System.Drawing.Size(100, 20);
            this.matriculaProfesional.TabIndex = 17;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 50;
            // 
            // Especialidad
            // 
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.Name = "Especialidad";
            this.Especialidad.ReadOnly = true;
            // 
            // FechaAlta
            // 
            this.FechaAlta.HeaderText = "Fecha alta";
            this.FechaAlta.Name = "FechaAlta";
            this.FechaAlta.Width = 80;
            // 
            // Disponible
            // 
            this.Disponible.HeaderText = "Disponible";
            this.Disponible.Name = "Disponible";
            this.Disponible.Width = 60;
            // 
            // Observaciones
            // 
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Width = 170;
            // 
            // Edicion
            // 
            this.Edicion.DataPropertyName = "Editar";
            this.Edicion.HeaderText = "Editar";
            this.Edicion.Name = "Edicion";
            this.Edicion.Text = "Eda";
            this.Edicion.ToolTipText = "Editar";
            // 
            // ProfEspFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 393);
            this.Controls.Add(this.matriculaProfesional);
            this.Controls.Add(this.nombreProfesional);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maskedCodigo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textObservaciones);
            this.Controls.Add(this.estaDisponible);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.nombreEspecialidad);
            this.Controls.Add(this.codigoEspecialidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridEspecialidades);
            this.Name = "ProfEspFrm";
            this.Text = "ProfEspFrm";
            ((System.ComponentModel.ISupportInitialize)(this.gridEspecialidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridEspecialidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox codigoEspecialidad;
        private System.Windows.Forms.CheckBox nombreEspecialidad;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox estaDisponible;
        private System.Windows.Forms.TextBox textObservaciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox maskedCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nombreProfesional;
        private System.Windows.Forms.TextBox matriculaProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAlta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewButtonColumn Edicion;
    }
}