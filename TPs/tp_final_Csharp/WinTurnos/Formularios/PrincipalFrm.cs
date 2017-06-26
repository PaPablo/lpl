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
            PacientesResultsFrm frm = new PacientesResultsFrm();
            frm.ShowDialog();
        }

        private void ListadosBtn_Click(object sender, EventArgs e)
        {
            
        }     
                
        private void SearchDniBtn_Click(object sender, EventArgs e)
        {/*
            Paciente p = new Paciente();
            p.findbykey(this.DniSearchTxt.Text);
            PacientesAMFrm fampac = new PacientesAMFrm();
            fampac.ShowPaciente(p);*/
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dgresult = MessageBox.Show("Desea salir del sistema?", "salir....", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dgresult == System.Windows.Forms.DialogResult.Yes)
                this.Dispose();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PacientesAMFrm frmPacAlta = new PacientesAMFrm();
            frmPacAlta.NewPaciente(null);
        }

        private void modificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PacienteBusqFrm pbusq = new PacienteBusqFrm();
            pbusq.Show();
        }

        private void FormTestBtn_Click(object sender, EventArgs e)
        {
            FormTestModel frm = new  FormTestModel();
            frm.Show();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProfesionalAMFrm profalta = new ProfesionalAMFrm();
            profalta.NewProfesional(null);
            profalta.Show();
        }
    }
}
