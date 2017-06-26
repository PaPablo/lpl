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
    public partial class PacientesResultsFrm : Form, IFormGridReload
    {
        public PacientesResultsFrm()
        {
            InitializeComponent();
        }

        public void ResultadosPaciente(int dni=-1, string apellido=null)
        {
            if (dni == -1 && apellido == null)
            {
                /*
                * Se requiere este seteo para que se posibilite el mapeo de columnas que se Agregaron
                * desde el diseñador, Click con boton derecho sobre seleccion de grilla -> Edit Columns
                */            
                this.gridPacientes.AutoGenerateColumns = false;
                List<Paciente> lista = ManagerDB<Paciente>.findAll();
                //lista.Sort((p1, p2) => p1.Dni.CompareTo(p2.Dni));
                lista.Sort((p1, p2) => String.Compare(p1.Apellido, p2.Apellido));
                this.gridPacientes.DataSource = lista;
                Cursor.Current = Cursors.Default;
            }
            if (dni != -1 && apellido == null)
            {
                this.gridPacientes.AutoGenerateColumns = false;
                List<Paciente> lista = ManagerDB<Paciente>.findAll(String.Format("dni={0}",dni));
                this.gridPacientes.DataSource = lista;
            }
            if (dni == -1 && apellido != null)
            {
                this.gridPacientes.AutoGenerateColumns = false;
                List<Paciente> lista = ManagerDB<Paciente>.findAll(String.Format("apellido like '%{0}%'", apellido));
                this.gridPacientes.DataSource = lista;
            }
            if (dni != -1 && apellido != null)
            {
                this.gridPacientes.AutoGenerateColumns = false;
                List<Paciente> lista = ManagerDB<Paciente>.findAll(String.Format("dni= {0} and apellido like '%{1}%'", dni,apellido));
                this.gridPacientes.DataSource = lista;
            }
            this.ShowDialog();
        }
        private void PacienteFrm_Load(object sender, EventArgs e)
        {
           
        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void gridPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                MessageBox.Show("Dot Net Perls is awesome.");
                PacientesAMFrm frm = new PacientesAMFrm();
                frm.ShowPaciente(grid.Rows[e.RowIndex].DataBoundItem as Paciente,this);
            }
        }

        private void gridPacientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Paciente p;
            foreach (DataGridViewRow row in gridPacientes.Rows)
            {                
                DataGridViewCell cell;
                p = (row.DataBoundItem as Paciente);
                cell = row.Cells[1];
                cell.Value = String.Format("{0}, {1}", p.Apellido.ToUpper(), p.Nombres);
            }
        }

        private void NuevoPacienteBtn_Click(object sender, EventArgs e)
        {
            PacientesAMFrm frm = new PacientesAMFrm();
            frm.NewPaciente(this);
        }

        public void ReloadGrid()
        {
            this.gridPacientes.Refresh();
        }
    }
}
