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
            this.gridPacientes.AutoGenerateColumns = false;
            List<Paciente> lista;
            if (dni == -1 && apellido == null)
            {
                /*
                * Se requiere este seteo para que se posibilite el mapeo de columnas que se Agregaron
                * desde el diseñador, Click con boton derecho sobre seleccion de grilla -> Edit Columns
                */            
                lista = ManagerDB<Paciente>.findAll();
                //lista.Sort((p1, p2) => p1.Dni.CompareTo(p2.Dni));
                lista.Sort((p1, p2) => String.Compare(p1.Apellido, p2.Apellido));
                Cursor.Current = Cursors.Default;
            }
            else if (dni != -1 && apellido == null)
            {
                lista = ManagerDB<Paciente>.findAll(String.Format("dni={0}",dni));
            }
            else if (dni == -1 && apellido != null)
            {
                lista = ManagerDB<Paciente>.findAll(String.Format("apellido like '%{0}%'", apellido));
            }
            else 
            {
                lista = ManagerDB<Paciente>.findAll(String.Format("dni= {0} and apellido like '%{1}%'", dni,apellido));
            }

            if (lista == null)
            {
                MessageBox.Show("No se encontró nada");
                return;
            }

            lista.Sort((p1, p2) => p1.Apellido.CompareTo(p2.Apellido));
            this.gridPacientes.DataSource = lista;
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
                PacientesAMFrm frm = new PacientesAMFrm();
                frm.ShowPaciente(grid.Rows[e.RowIndex].DataBoundItem as Paciente,this);
            }

        }

        private void gridPacientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Paciente p;
            foreach (DataGridViewRow row in gridPacientes.Rows)
            {                
                p = (row.DataBoundItem as Paciente);
                row.Cells[0].Value = p.Dni;
                row.Cells[1].Value = String.Format("{0}, {1}", p.Apellido.ToUpper(), p.Nombres);
                row.Cells[2].Value = p.Domicilio;
                row.Cells[3].Value = p.Telefono;
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
