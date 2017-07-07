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
    public partial class PacienteIngresoFrm : Form
    {
        public PacienteIngresoFrm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.maskedDNI.Text))
            {
                MessageBox.Show("Se debe ingresar un DNI válido", "ERROR");
                return;
            }
            Paciente p = (Paciente)ManagerDB<Paciente>.findbyKey(this.maskedDNI.Text);
            if (p == null)
            {
                MessageBox.Show("No se encontró nada", "ERROR");
                return;
            }

            if (this.modificarChk.Checked)
            {
                new PacientesAMFrm().ShowPaciente(p, new PacientesResultsFrm());
            }
            else {
                new PacienteTurnosFrm().ShowTurnos(p);
            }
            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void modificarChk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.modificarChk.Checked) {
                this.turnosChk.Checked = false;
            }

        }

        private void turnosChk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.turnosChk.Checked)
            {
                this.modificarChk.Checked = false;
            }

        }

        private void PacienteIngresoFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
