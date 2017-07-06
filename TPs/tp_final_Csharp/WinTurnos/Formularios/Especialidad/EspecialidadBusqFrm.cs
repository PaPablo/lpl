using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinTurnos.Formularios
{
    public partial class EspecialidadBusqFrm : Form
    {
        public EspecialidadBusqFrm()
        {
            InitializeComponent();
            this.codigoChk.Checked = true;
            this.nombreTxt.Enabled = false;
        }

        private void codigoChk_CheckedChanged(object sender, EventArgs e)
        {
            this.codigoTxt.Enabled = this.codigoChk.Checked;
            if (this.nombreChk.Checked)
            {
                this.todoChk.Checked = false;
            }
        }

        private void nombreChk_CheckedChanged(object sender, EventArgs e)
        {
            this.nombreTxt.Enabled = this.nombreChk.Checked;
            if (this.nombreChk.Checked)
            {
                this.todoChk.Checked = false;
            }

        }

        private void todoChk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.todoChk.Checked)
            {
                this.codigoChk.Checked = false;
                this.nombreChk.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = -1;
            string nombre = null;
            if (!this.todoChk.Checked && !this.codigoChk.Checked && !this.nombreChk.Checked)
            {
                MessageBox.Show("Faltan criterios de búsqueda", "ERROR");
                return;
            }

            if (!this.todoChk.Checked && this.codigoChk.Checked && !string.IsNullOrWhiteSpace(this.codigoTxt.Text))
            {
                codigo = Convert.ToInt32(this.codigoTxt.Text);
            }

            if (!this.todoChk.Checked && this.nombreChk.Checked && !string.IsNullOrWhiteSpace(this.nombreTxt.Text))
            {
                nombre = this.nombreTxt.Text;
            }
            Cursor.Current = Cursors.Default;
            this.Visible = false;
            new EspecialidadResultsFrm().ResultadosEspecialidades(codigo, nombre);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
