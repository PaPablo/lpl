using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql; // Libreria para conectar con PostgreSQL
using LibTurnos.db; // incluir espacio de nombre para poder acceder a los objetos de negocios.

namespace WinTurnos.Formularios
{
    public partial class PrincipalFrm : Form
    {
        public PrincipalFrm()
        {            
            InitializeComponent();
        }

        private void PrincipalFrm_Load(object sender, EventArgs e)
        {
               
        }     
               

        private void PacienteBtn_Click(object sender, EventArgs e)
        {
            new PacientesResultsFrm().ShowDialog();
        }

        private void ListadosBtn_Click(object sender, EventArgs e)
        {
            
        }     
                
        private void SearchDniBtn_Click(object sender, EventArgs e)
        {
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dgresult = MessageBox.Show("¿Desea salir del sistema?", "SALIR",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dgresult == System.Windows.Forms.DialogResult.Yes)
                this.Dispose();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PacientesAMFrm().NewPaciente(new PacientesResultsFrm());
        }

        private void modificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PacienteIngresoFrm().Show();
        }

        private void FormTestBtn_Click(object sender, EventArgs e)
        {
            FormTestModel frm = new  FormTestModel();
            frm.Show();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PacienteBusqFrm().Show();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //List<Turno> lista = ManagerDB<Turno>.findAll();
            //List<ObraSocial> listaOS = ManagerDB<ObraSocial>.findAll();
            //List<PacienteObraSocial> listaPOS = ManagerDB<PacienteObraSocial>.findAll();

            new ProfesionalAMFrm().NewProfesional(new ProfesionalesResultsFrm());

        }
        private void listadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ProfesionalBusqFrm().Show();
        }

        private void modificacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ProfesionalIngresoFrm().Show();

        }
    }
}
