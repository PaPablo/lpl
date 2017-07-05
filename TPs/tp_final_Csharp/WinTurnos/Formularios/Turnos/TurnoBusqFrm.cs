using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibTurnos.db;

namespace WinTurnos.Formularios
{
    public partial class TurnoBusqFrm : Form
    {
        private int dni = -1;
        private string matricula = null;
        private DateTime fecha = DateTime.Today;

        public TurnoBusqFrm()
        {
            InitializeComponent();
        }


        private void dniChk_CheckedChanged(object sender, EventArgs e)
        {
            this.dniPaciente.Enabled = this.dniChk.Checked;
            this.todoChk.Checked = false;
        }

        private void matriculaChk_CheckedChanged(object sender, EventArgs e)
        {
            this.matriculaProfesional.Enabled = this.matriculaChk.Checked;
            this.todoChk.Checked = false;
        }

        private void fechaChk_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1.Enabled = this.fechaChk.Checked;
            this.todoChk.Checked = false;
        }

        private void todoChk_CheckedChanged(object sender, EventArgs e)
        {
            //this.todoChk.Checked = !this.todoChk.Checked;
            this.dniChk.Checked = false;
            this.dniPaciente.Enabled = false;
            this.matriculaChk.Checked = false;
            this.matriculaProfesional.Enabled = false;
            this.fechaChk.Checked = false;
            this.dateTimePicker1.Enabled = false;

        }

        private void TurnoBusqFrm_Load_1(object sender, EventArgs e)
        {
            this.matriculaProfesional.Enabled = false;
            this.dniPaciente.Enabled = false;
            this.dateTimePicker1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TurnoResultsFrm tfrm;
            if(!this.todoChk.Checked && !this.dniChk.Checked && ! this.matriculaChk.Checked)
            {
                MessageBox.Show("Tiene que ingresar criterio de busqueda","Faltan criterios",
                MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if (!this.todoChk.Checked && this.matriculaChk.Checked)
                matricula = this.matriculaProfesional.Text;
            if (!this.todoChk.Checked && this.dniChk.Checked)
                dni = Convert.ToInt32(this.dniPaciente.Text);
            tfrm = new TurnoResultsFrm();
            Cursor.Current = Cursors.WaitCursor;
            this.Visible = false;
            tfrm.ResultadosTurno(dni, matricula);
            this.Dispose(); 

        }
    }
}
