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
    public partial class PacienteTurnosFrm : Form
    {
        public PacienteTurnosFrm()
        {
            InitializeComponent();
        }

        private Paciente pac;

        public void ShowTurnos(Paciente p)
        {
            this.pac = p;
            this.nombrePaciente.Text = String.Format("{0}, {1}", this.pac.Apellido.ToUpper(), this.pac.Nombres);
            this.dniPaciente.Text = this.pac.Dni.ToString();

            this.gridTurnos.AutoGenerateColumns = false;
            List<Turno> listaTurnos = ManagerDB<Turno>.findAll(String.Format(
                "dnipaciente = {0}", this.pac.Dni));

            this.gridTurnos.DataSource = listaTurnos;
            Cursor.Current = Cursors.Default;

            this.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Turno turno;
            foreach (DataGridViewRow row in this.gridTurnos.Rows)
            {                
                turno = (row.DataBoundItem as Turno);
                row.Cells[0].Value = turno.FechaHora;
                row.Cells[1].Value = String.Format("{0}, {1}", turno.ProfesionalObj.Apellido.ToUpper(),
                    turno.ProfesionalObj.Nombres);
                row.Cells[2].Value = turno.ProfesionalObj.Matricula;
                row.Cells[3].Value = turno.Asistio ? "SÍ" : "NO";
            }
        }
    }
}
