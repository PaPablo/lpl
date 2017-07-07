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
    public partial class EspecialidadProfFrm : Form
    {
        private Especialidad esp;
        public EspecialidadProfFrm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public void VerProfesionales(Especialidad esp)
        {
            this.esp = esp;
            this.nombreEsp.Text = this.esp.Nombre;
            this.codigoEsp.Text = this.esp.Codigo.ToString();
            List<ProfesionalEspecialidad> lista = ManagerDB<ProfesionalEspecialidad>.findAll(
                String.Format("codigoespecialidad = {0}", this.esp.Codigo));

            if (lista == null)
            {
                MessageBox.Show("No hay profesionales registrados con la especialidad: {0}", this.esp.Nombre);
                return;
            }

            this.gridProfesionales.DataSource = lista;
            this.ShowDialog();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ProfesionalEspecialidad pe;
            foreach (DataGridViewRow row in gridProfesionales.Rows)
            {                
                pe = (row.DataBoundItem as ProfesionalEspecialidad);
                row.Cells[0].Value = pe.CodigoProfesional;
                row.Cells[1].Value = String.Format("{0}, {1}", pe.ProfesionalObj.Apellido.ToUpper(), pe.ProfesionalObj.Nombres);
                row.Cells[2].Value = pe.FechaAlta;
                row.Cells[3].Value = pe.Disponible ? "SÍ" : "NO";
                row.Cells[4].Value = pe.Observaciones;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
