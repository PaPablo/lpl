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
    public partial class PacienteIngreso : Form
    {
        public PacienteIngreso()
        {
            InitializeComponent();
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
            PacientesAMFrm fampac = new PacientesAMFrm();
            fampac.ShowPaciente(p, new PacientesResultsFrm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
