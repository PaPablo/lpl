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
    public partial class ObraSocialPacienteFrm : Form
    {
        public ObraSocialPacienteFrm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ObraSocialPacienteFrm_Load(object sender, EventArgs e)
        {

        }

        ObraSocial os;
        internal void ShowObrasSociales(ObraSocial os)
        {
            this.os = os;

            this.CodigoObraSocial.Text = String.Format("{0}", this.os.Codigo);
            this.NombreObraSocial.Text = this.os.Nombre;

            this.GridPacienteObraSocial.AutoGenerateColumns = false;
            List<PacienteObraSocial> listaPacienteObraSocial = ManagerDB<PacienteObraSocial>.findAll(String.Format(
                "codigoObraSocial = {0}", this.os.Codigo));

            this.GridPacienteObraSocial.DataSource = listaPacienteObraSocial;
            Cursor.Current = Cursors.Default;

            this.ShowDialog();
        }

        private void nombrePacienteLbl_Click(object sender, EventArgs e)
        {

        }

        private void GridPacienteObraSocial_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            PacienteObraSocial pos;
            foreach (DataGridViewRow row in this.GridPacienteObraSocial.Rows)
            {                
                pos = (row.DataBoundItem as PacienteObraSocial);
                row.Cells[0].Value = pos.PacienteObj.Dni;
                row.Cells[1].Value = String.Format("{0}, {1}", pos.PacienteObj.Apellido.ToUpper(),
                    pos.PacienteObj.Nombres);
            }
        }
    }
}
