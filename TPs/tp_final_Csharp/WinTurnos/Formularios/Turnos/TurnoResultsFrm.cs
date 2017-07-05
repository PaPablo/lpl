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

            if (grid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                MessageBox.Show(String.Format("pulsaste la celda {0}, {1}", e.ColumnIndex, e.RowIndex));
            }
        }
            
        public void ResultadosTurno(int dnipaciente=-1, string matricula=null)
        {
            this.turnosGrid.AutoGenerateColumns = false;
            List<Turno> lista;
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
                Profesional prof = ManagerDB<Profesional>.findbyKey(matricula);
                lista = ManagerDB<Turno>.findAll(String.Format("codigoprofesional={0}", prof.Id));
            }
            else if (matricula == null && dnipaciente != -1)
            {
                lista = ManagerDB<Turno>.findAll(String.Format("dnipaciente={0}", dnipaciente));
            }
            else 
            {
                Profesional prof = ManagerDB<Profesional>.findbyKey(matricula);
                lista = ManagerDB<Turno>.findAll(String.Format
                    ("codigoprofesional={0} and dnipaciente={1}", matricula, dnipaciente));
            }

            if (lista == null)
            {
                MessageBox.Show("No se encontró nada");
                return;
            }

            this.turnosGrid.DataSource = lista;
            this.ShowDialog();
        }
        private void gridProfesionales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Turno t;
            Paciente pac;
            Profesional prof;
            foreach (DataGridViewRow row in turnosGrid.Rows)
            {                
                t = (row.DataBoundItem as Turno);
                row.Cells[0].Value = t.DniPaciente;
                pac = ManagerDB<Paciente>.findbyKey(t.DniPaciente);
                row.Cells[10].Value = String.Format("{0}, {1}", pac.Apellido.ToUpper(), pac.Nombres);
                prof = ManagerDB<Profesional>.findbyKey(t.CodigoProfesional);
                row.Cells[2].Value = String.Format("{0}", prof.Matricula);
                row.Cells[3].Value = String.Format("{0}, {1}", prof.Apellido.ToUpper(), prof.Nombres);
                row.Cells[4].Value = t.Asistio;
            }
        }

        public void ReloadGrid()
        {
            this.turnosGrid.Refresh();
        }
        
    }
}
