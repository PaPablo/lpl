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


        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PacienteBusqFrm().Show();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
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

        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new ObraSocialAMFrm().NewObraSocial(new ObraSocialResultsFrm());
        }

        private void modificacionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new ObraSocialIngresoFrm().Show();
        }

        private void listadoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new ObraSocialBusqFrm().Show();
        }

        private void altaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new TurnoAMFrm().NewTurno();
        }

        private void listadoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new TurnoBusqFrm().Show();
        }

        private void altaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new EspecialidadAMFrm().NewEspecialidad();
        }

        private void modificacionToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new EspecialidadIngresoFrm().ShowDialog();
        }

        private void listadoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new EspecialidadBusqFrm().ShowDialog();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PacienteAyudaFrm().ShowDialog();
        }

        private void ayudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ProfesionalAyudaFrm().ShowDialog();
        }

        private void ayudaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new ObraSocialAyudaFrm().ShowDialog();
        }

        private void ayudaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new EspecialidadAyudaFrm().ShowDialog();
        }

        private void ayudaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new TurnosAyudaFrm().ShowDialog();
        }
    }
}
