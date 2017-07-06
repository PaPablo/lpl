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
    public partial class TurnoResultsFrm : Form
    {
        public TurnoResultsFrm()
        {
            InitializeComponent();
        }

        private void TurnoResultsFrm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                TurnoAMFrm frm = new TurnoAMFrm();
                frm.ShowTurno(grid.Rows[e.RowIndex].DataBoundItem as Turno);
            }
        }
            
        public void ResultadosTurno(int dnipaciente=-1, string matricula=null, DateTime fecha=default(DateTime))
        {
            this.turnosGrid.AutoGenerateColumns = false;
            List<Turno> lista;
            string fechaSql = fecha == DateTime.Today? "" : String.Format("and fechahora = '{0}'", 
                fecha.ToString("yyyy-MM-dd HH:mm:ss"));
            if (dnipaciente == -1 && matricula == null)
            {
                /*
                * Se requiere este seteo para que se posibilite el mapeo de columnas que se Agregaron
                * desde el diseñador, Click con boton derecho sobre seleccion de grilla -> Edit Columns
                */            
                lista = ManagerDB<Turno>.findAll();
                lista.Sort((t1, t2) => t1.DniPaciente - t2.DniPaciente);
                Cursor.Current = Cursors.Default;
            }
            else if (matricula != null && dnipaciente == -1)
            {
                List<Profesional> prof = ManagerDB<Profesional>.findAll(String.Format("matricula = '{0}'", matricula));
                lista = prof == null ? null : ManagerDB<Turno>.findAll(String.Format("codigoprofesional={0} {1}", prof[0].Id,
                fechaSql));
            }
            else if (matricula == null && dnipaciente != -1)
            {
                lista = ManagerDB<Turno>.findAll(String.Format("dnipaciente={0} {1}", dnipaciente, fechaSql));
            }
            else 
            {
                List<Profesional> prof = ManagerDB<Profesional>.findAll(String.Format("matricula = '{0}'", matricula));
                lista = prof == null ? null : ManagerDB<Turno>.findAll(String.Format("codigoprofesional={0} and dnipaciente={1} {2}", prof[0].Id, dnipaciente, fechaSql));
            }

            if (lista == null)
            {
                MessageBox.Show("No se encontró nada");
                return;
            }

            this.turnosGrid.DataSource = lista;
            this.ShowDialog();
        }

        public void ReloadGrid()
        {
            this.turnosGrid.Refresh();
        }

        private void turnosGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Turno turno;
            foreach (DataGridViewRow row in this.turnosGrid.Rows)
            {                
                turno = (row.DataBoundItem as Turno);
                row.Cells[0].Value = turno.DniPaciente;
                row.Cells[1].Value = String.Format("{0}, {1}", turno.PacienteObj.Apellido.ToUpper(),
                    turno.PacienteObj.Nombres); 
                row.Cells[2].Value = turno.ProfesionalObj.Matricula;
                row.Cells[3].Value = String.Format("{0}, {1}", turno.ProfesionalObj.Apellido.ToUpper(),
                    turno.ProfesionalObj.Nombres);
                row.Cells[4].Value = turno.FechaHora;
                row.Cells[5].Value = turno.Asistio;
                row.Cells[6].Value = "Editar";
            }
        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
