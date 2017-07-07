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
    public partial class ModProfEspFrm : Form
    {
        public ModProfEspFrm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private ProfesionalEspecialidad profesp;
        public void ShowEspecialidad(ProfesionalEspecialidad pe) {

            this.profesp = pe;

            this.codigoEspecialidad.Text = pe.CodigoEspecialidad.ToString();
            this.nombreEspecialidad.Text = pe.EspecialidadObj.Nombre;
            this.dateTimePicker1.Value = pe.FechaAlta;
            this.estaDisponible.Checked = pe.Disponible;
            this.textoObservaciones.Text = pe.Observaciones;
            this.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.profesp.FechaAlta = this.dateTimePicker1.Value;
            this.profesp.Disponible = this.estaDisponible.Checked;
            this.profesp.Observaciones = this.textoObservaciones.Text;


            this.profesp.IsNew = false;

            if (!this.profesp.saveObj())
            {
                MessageBox.Show("No se pudo realizar la actualización", "ERROR");
                MessageBox.Show("Seguro que pincha siempre porque cambia la matrícula por el nombre", "ERROR");
                return;
            }
            MessageBox.Show("La actualización se realizó correctamente", "Operación exitosa");
            this.Dispose();
        }

    }
}
