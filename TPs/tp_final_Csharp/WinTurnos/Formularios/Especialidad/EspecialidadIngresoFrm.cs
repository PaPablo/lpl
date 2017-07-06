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
    public partial class EspecialidadIngresoFrm : Form
    {
        public EspecialidadIngresoFrm()
        {
            InitializeComponent();
            this.modificarChk.Checked = true;
            this.profChk.Checked = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = -1;
            if (string.IsNullOrWhiteSpace(this.codigoEsp.Text))
            {
                MessageBox.Show("Faltan criterios de búsqueda", "ERROR");
                return;
            }

            codigo = Convert.ToInt32(this.codigoEsp.Text);
            Especialidad esp = new Especialidad();
            esp = (Especialidad)ManagerDB<Especialidad>.findbyKey(codigo);
            if (esp == null) {
                MessageBox.Show("Especialidad no existe", "ERROR");
                return;
            }

            if (this.modificarChk.Checked)
            {
                new EspecialidadAMFrm().ShowEspecialidad(esp);
                return;
            }

            if (this.profChk.Checked) {
                new EspecialidadProfFrm().VerProfesionales(esp);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void modificarChk_CheckedChanged(object sender, EventArgs e)
        {
            this.profChk.Checked = !this.modificarChk.Checked;
        }

        private void profChk_CheckedChanged(object sender, EventArgs e)
        {
            this.modificarChk.Checked = !this.profChk.Checked;

        }
    }
}
