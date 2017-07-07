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
    public partial class ProfesionalBusqFrm : Form
    {
        public ProfesionalBusqFrm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void DniChk_CheckedChanged(object sender, EventArgs e)
        {
            this.MatriculaMsk.Enabled = this.MatriculaChk.Checked;
            if (this.MatriculaChk.Checked)
            {
                this.ListTodoChk.Checked = false;
                this.MatriculaMsk.Focus();
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
            ProfesionalesResultsFrm pfrm;
            string matricula = null;
            string apellido = null;
            if(!ListTodoChk.Checked && !this.ApellidoChk.Checked && ! this.MatriculaChk.Checked)
            {
                MessageBox.Show("Tiene que ingresar criterio de busqueda","Faltan criterios",
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (!ListTodoChk.Checked && this.MatriculaChk.Checked && !string.IsNullOrWhiteSpace(this.MatriculaMsk.Text))
                matricula = this.MatriculaMsk.Text;
            if (!ListTodoChk.Checked && this.ApellidoChk.Checked && !string.IsNullOrWhiteSpace(this.ApellidoTxt.Text))
                apellido = this.ApellidoTxt.Text;
            pfrm = new ProfesionalesResultsFrm();
            Cursor.Current = Cursors.WaitCursor;
            this.Visible = false;
            pfrm.ResultadosProfesional(matricula, apellido);
            this.Dispose(); 
        }

        private void ListTodoChk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ListTodoChk.Checked)
            {
                this.ApellidoChk.Checked = false;
                this.MatriculaChk.Checked = false;
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
