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
    public partial class ProfesionalIngresoFrm : Form
    {
        public ProfesionalIngresoFrm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.maskedMatricula.Text)) {
                MessageBox.Show("Se debe ingresar una matrícula válida", "ERROR");
                return;
            }
            List<Profesional> p = ManagerDB<Profesional>.findAll(String.Format("matricula = '{0}'", this.maskedMatricula.Text));
            if (p == null) {
                MessageBox.Show("No se encontró nada");
                return;
            }

            //MessageBox.Show(p[0].ToString());
            if (this.modificarChk.Checked)
            {
                new ProfesionalAMFrm().ShowProfesional(p[0], new ProfesionalesResultsFrm());
            }
            else
            {
                new ProfEspFrm().MostrarEspecialidades(p[0]);
            }
            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.especialidadesChk.Checked)
            {
                this.modificarChk.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.modificarChk.Checked)
            {
                this.especialidadesChk.Checked = false;
            }
        }
    }
}
