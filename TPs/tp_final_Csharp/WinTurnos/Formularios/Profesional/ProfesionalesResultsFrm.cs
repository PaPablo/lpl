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
    public partial class ProfesionalesResultsFrm : Form, IFormGridReload
    {
        public ProfesionalesResultsFrm()
        {
            InitializeComponent();
        }

        public void ResultadosProfesional(string matricula=null, string apellido=null)
        {
            this.gridProfesionales.AutoGenerateColumns = false;
            List<Profesional> lista;
            if (matricula == null && apellido == null)
            {
                /*
                * Se requiere este seteo para que se posibilite el mapeo de columnas que se Agregaron
                * desde el diseñador, Click con boton derecho sobre seleccion de grilla -> Edit Columns
                */            
                lista = ManagerDB<Profesional>.findAll();
                lista.Sort((p1, p2) => String.Compare(p1.Apellido, p2.Apellido));
                Cursor.Current = Cursors.Default;
            }
            else if (matricula != null && apellido == null)
            {
                lista = ManagerDB<Profesional>.findAll(String.Format("matricula = '{0}'", matricula));
            }
            else if (matricula == null && apellido != null)
            {
                lista = ManagerDB<Profesional>.findAll(String.Format("apellido like '%{0}%'", apellido));
            }
            else 
            {
                lista = ManagerDB<Profesional>.findAll(String.Format
                    ("matricula = '{0}' and apellido like '%{1}%'", matricula, apellido));
            }

            if (lista == null)
            {
                MessageBox.Show("No se encontró nada");
                return;
            }

            this.gridProfesionales.DataSource = lista;
            this.ShowDialog();
        }

        private void ProfesionalFrm_Load(object sender, EventArgs e)
        {
           
        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void gridProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                ProfesionalAMFrm frm = new ProfesionalAMFrm();
                frm.ShowProfesional(grid.Rows[e.RowIndex].DataBoundItem as Profesional,this);
            }

            if (grid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                MessageBox.Show(String.Format("pulsaste la celda {0}, {1}", e.ColumnIndex, e.RowIndex));
            }
        }

        private void gridProfesionales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Profesional p;
            foreach (DataGridViewRow row in gridProfesionales.Rows)
            {                
                p = (row.DataBoundItem as Profesional);
                row.Cells[0].Value = p.Matricula;
                row.Cells[1].Value = String.Format("{0}, {1}", p.Apellido.ToUpper(), p.Nombres);
                row.Cells[4].Value = p.Activo;
            }
        }

        private void NuevoProfesionalBtn_Click(object sender, EventArgs e)
        {
            ProfesionalAMFrm frm = new ProfesionalAMFrm();
            frm.NewProfesional(this);
        }

        public void ReloadGrid()
        {
            this.gridProfesionales.Refresh();
        }
    }
}
