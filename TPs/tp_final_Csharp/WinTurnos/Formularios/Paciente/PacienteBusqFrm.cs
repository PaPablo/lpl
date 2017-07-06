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
    public partial class PacienteBusqFrm : Form
    {
        public PacienteBusqFrm()
        {
            InitializeComponent();
        } 

        private void DniChk_CheckedChanged(object sender, EventArgs e)
        {
            this.DniMsk.Enabled = this.DniChk.Checked;
            if (this.DniChk.Checked)
            {
                this.ListTodoChk.Checked = false;
                this.DniMsk.Focus();
            }
        }

        private void ApellidoChk_CheckedChanged(object sender, EventArgs e)
        {
            this.ApellidoTxt.Enabled = this.ApellidoChk.Checked;
            if (this.ApellidoChk.Checked)
            {
                this.ListTodoChk.Checked = false;
                this.ApellidoTxt.Focus();
            }
        }

        private void BuscarBtn_Click(object sender, EventArgs e)
        {
            PacientesResultsFrm pfrm;
            int dni = -1;
            string apellido = null;
            if(!ListTodoChk.Checked && !this.ApellidoChk.Checked && ! this.DniChk.Checked)
            {
                MessageBox.Show("Tiene que ingresar criterio de busqueda","Faltan criterios",
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (!ListTodoChk.Checked && this.DniChk.Checked && !string.IsNullOrWhiteSpace(this.DniMsk.Text))
                dni = Convert.ToInt32(this.DniMsk.Text);
            if (!ListTodoChk.Checked && this.ApellidoChk.Checked && !string.IsNullOrWhiteSpace(this.ApellidoTxt.Text))
                apellido = this.ApellidoTxt.Text;
            pfrm = new PacientesResultsFrm();
            Cursor.Current = Cursors.WaitCursor;
            this.Visible = false;
            pfrm.ResultadosPaciente(dni, apellido);
            this.Dispose(); 
        }

        private void ListTodoChk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ListTodoChk.Checked)
            {
                this.ApellidoChk.Checked = false;
                this.DniChk.Checked = false;
            }
        }

        private void CancelarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
