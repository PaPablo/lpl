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
    public partial class ObraSocialResultsFrm : Form, IFormGridReload
    {
        public ObraSocialResultsFrm()
        {
            InitializeComponent();
        }

        public void ResultadosObraSocial(int codigo=-1, string nombre=null)
        {
            this.gridObrasSociales.AutoGenerateColumns = false;
            List<ObraSocial> lista;
            if (codigo == -1 && nombre == null)
            {
                /*
                * Se requiere este seteo para que se posibilite el mapeo de columnas que se Agregaron
                * desde el diseñador, Click con boton derecho sobre seleccion de grilla -> Edit Columns
                */            
                lista = ManagerDB<ObraSocial>.findAll();
                //lista.Sort((p1, p2) => p1.Dni.CompareTo(p2.Dni));
                lista.Sort((os1, os2) => String.Compare(os1.Nombre, os2.Nombre));
                Cursor.Current = Cursors.Default;
            }
            else if (codigo != -1 && nombre == null)
            {
                lista = ManagerDB<ObraSocial>.findAll(String.Format("codigo={0}",codigo));
            }
            else if (codigo == -1 && nombre != null)
            {
                lista = ManagerDB<ObraSocial>.findAll(String.Format("nombre like '%{0}%'", nombre));
            }
            else 
            {
                lista = ManagerDB<ObraSocial>.findAll(String.Format("codigo= {0} and nombre like '%{1}%'", codigo,nombre));
            }

            if (lista == null)
            {
                MessageBox.Show("No se encontró nada");
                return;
            }

            this.gridObrasSociales.DataSource = lista;
            this.ShowDialog();
        }

        private void ObraSocialFrm_Load(object sender, EventArgs e)
        {
           
        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void gridObraSocial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                ObraSocialAMFrm frm = new ObraSocialAMFrm();
                frm.ShowObraSocial(grid.Rows[e.RowIndex].DataBoundItem as ObraSocial,this);
            }

            if (grid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                MessageBox.Show(String.Format("pulsaste la celda {0}, {1}", e.ColumnIndex, e.RowIndex));
            }
        }

        private void gridObraSocial_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ObraSocial os;
            foreach (DataGridViewRow row in gridObrasSociales.Rows)
            {                
                DataGridViewCell cell;
                os = (row.DataBoundItem as ObraSocial);
                cell = row.Cells[1];
                cell.Value = String.Format("{0}", os.Nombre.ToUpper());
            }
        }

        private void NuevaObraSocialBtn_Click(object sender, EventArgs e)
        {
            ObraSocialAMFrm frm = new ObraSocialAMFrm();
            frm.NewObraSocial(this);
        }

        public void ReloadGrid()
        {
            this.gridObrasSociales.Refresh();
        }
    }
}
