namespace WinTurnos.Formularios
{
    partial class EspecialidadBusqFrm
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
            this.codigoChk = new System.Windows.Forms.CheckBox();
            this.nombreChk = new System.Windows.Forms.CheckBox();
            this.todoChk = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.codigoTxt = new System.Windows.Forms.MaskedTextBox();
            this.nombreTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // codigoChk
            // 
            this.codigoChk.AutoSize = true;
            this.codigoChk.Location = new System.Drawing.Point(24, 40);
            this.codigoChk.Name = "codigoChk";
            this.codigoChk.Size = new System.Drawing.Size(59, 17);
            this.codigoChk.TabIndex = 0;
            this.codigoChk.Text = "Código";
            this.codigoChk.UseVisualStyleBackColor = true;
            this.codigoChk.CheckedChanged += new System.EventHandler(this.codigoChk_CheckedChanged);
            // 
            // nombreChk
            // 
            this.nombreChk.AutoSize = true;
            this.nombreChk.Location = new System.Drawing.Point(24, 93);
            this.nombreChk.Name = "nombreChk";
            this.nombreChk.Size = new System.Drawing.Size(63, 17);
            this.nombreChk.TabIndex = 1;
            this.nombreChk.Text = "Nombre";
            this.nombreChk.UseVisualStyleBackColor = true;
            this.nombreChk.CheckedChanged += new System.EventHandler(this.nombreChk_CheckedChanged);
            // 
            // todoChk
            // 
            this.todoChk.AutoSize = true;
            this.todoChk.Location = new System.Drawing.Point(24, 162);
            this.todoChk.Name = "todoChk";
            this.todoChk.Size = new System.Drawing.Size(75, 17);
            this.todoChk.TabIndex = 2;
            this.todoChk.Text = "Listar todo";
            this.todoChk.UseVisualStyleBackColor = true;
            this.todoChk.CheckedChanged += new System.EventHandler(this.todoChk_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // codigoTxt
            // 
            this.codigoTxt.Location = new System.Drawing.Point(132, 40);
            this.codigoTxt.Mask = "999";
            this.codigoTxt.Name = "codigoTxt";
            this.codigoTxt.Size = new System.Drawing.Size(100, 20);
            this.codigoTxt.TabIndex = 5;
            // 
            // nombreTxt
            // 
            this.nombreTxt.Location = new System.Drawing.Point(132, 93);
            this.nombreTxt.Name = "nombreTxt";
            this.nombreTxt.Size = new System.Drawing.Size(100, 20);
            this.nombreTxt.TabIndex = 6;
            // 
            // EspecialidadBusqFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.nombreTxt);
            this.Controls.Add(this.codigoTxt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.todoChk);
            this.Controls.Add(this.nombreChk);
            this.Controls.Add(this.codigoChk);
            this.Name = "EspecialidadBusqFrm";
            this.Text = "Búsqueda de una especialidad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox codigoChk;
        private System.Windows.Forms.CheckBox nombreChk;
        private System.Windows.Forms.CheckBox todoChk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox codigoTxt;
        private System.Windows.Forms.TextBox nombreTxt;
    }
}