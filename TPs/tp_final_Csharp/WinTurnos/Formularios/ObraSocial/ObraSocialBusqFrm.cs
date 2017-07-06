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
    public partial class ObraSocialBusqFrm : Form
    {
        public ObraSocialBusqFrm()
        {
            InitializeComponent();
            this.CodigoChk.Checked = true;
        }

        private void CodigoChk_CheckedChanged(object sender, EventArgs e)
        {
            this.CodigoTxt.Enabled = this.CodigoChk.Checked;
            if(this.CodigoChk.Checked)
            {
                this.ListarTodoChk.Checked = false;
                this.CodigoTxt.Focus();
            }
        }

        private void NombreChk_CheckedChanged(object sender, EventArgs e)
        {
            this.NombreTxt.Enabled = this.NombreChk.Checked;
            if(this.NombreChk.Checked)
            {
                this.ListarTodoChk.Checked = false;
                this.NombreTxt.Focus();
            }
        }

        private void ListarTodoChk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ListarTodoChk.Checked)
            {
                this.CodigoChk.Checked = false;
                this.NombreChk.Checked = false;
            }
        }

        private void AceptarBtn_Click(object sender, EventArgs e)
        {
            ObraSocialResultsFrm osfrm;
            int codigo = -1;
            string nombre = null;
            if(!ListarTodoChk.Checked && !this.NombreChk.Checked && ! this.CodigoChk.Checked)
            {
                MessageBox.Show("Tiene que ingresar criterio de busqueda","Faltan criterios",
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (!ListarTodoChk.Checked && this.CodigoChk.Checked && !string.IsNullOrWhiteSpace(this.CodigoTxt.Text))
                codigo = Convert.ToInt32(this.CodigoTxt.Text);
            if (!ListarTodoChk.Checked && this.NombreChk.Checked && !string.IsNullOrWhiteSpace(this.NombreTxt.Text))
                nombre = this.NombreTxt.Text;
            osfrm = new ObraSocialResultsFrm();
            Cursor.Current = Cursors.WaitCursor;
            this.Visible = false;
            osfrm.ResultadosObraSocial(codigo, nombre);
            this.Dispose(); 
        }
    }
}
