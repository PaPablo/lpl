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
    public partial class FormTestModel : Form
    {
        public FormTestModel()
        {
            InitializeComponent();
        }

        private void CargarOSBtn_Click(object sender, EventArgs e)
        {
            this.ObraSocialCbo.DisplayMember = "Nombre";
            this.ObraSocialCbo.ValueMember = "Codigo";
            this.ObraSocialCbo.DataSource = ManagerDB<ObraSocial>.findAll();
        }

        private void ObraSocialAddBtn_Click(object sender, EventArgs e)
        {
            #region codigo Ejemplo Altas
            /*
             * Paciente  - ADD - Form - PacientesAMFrm 
             * 
             */
            /*
            // Obra Social - ADD
            ObraSocial os = new ObraSocial();
            os.Nombre = "Prueba";
            os.saveObj();
            */
            /*
            // Obra social de paciente - ADD
            PacienteObraSocial pos = new PacienteObraSocial();
            pos.DniPaciente = 2232154;
            pos.CodigoObraSocial = 10;
            pos.FechaDesde = DateTime.Now;
            pos.saveObj();
            */
            /*
            //Especialidad - ADD
            Especialidad esp = new Especialidad();
            esp.Nombre = "Psiquiatra";
            esp.saveObj();
            */
            /*
            //Profesional - ADD
            Profesional prof = new Profesional();
            prof.Apellido = "Diaz";
            prof.Nombres = "Ernesto";
            prof.Matricula = "mat-23456";
            prof.FechaMatricula= DateTime.Parse("14/05/2001");
            prof.Telefono="15487988";
            prof.saveObj();
            */
            /*
            ProfesionalEspecialidad prfesp = new ProfesionalEspecialidad();
            prfesp.CodigoEspecialidad = 93;
            prfesp.CodigoProfesional = 153;
            prfesp.Observaciones = "pro-esp";
            prfesp.FechaAlta = DateTime.Now;
            prfesp.saveObj();
            */
            /*
            Turno t = new Turno();
            t.CodigoProfesional = 93;
            t.DniPaciente = 2232154;
            t.FechaHora = DateTime.Parse("15/06/2017 15:30");
            t.Asistio = false;
            t.saveObj();*/
            #endregion
        }
        //Evento que permite gestionar la visualizacion de las tuplas de la grilla
        private void gridPacienteObraSocial_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PacienteObraSocial pos;
            foreach (DataGridViewRow row in gridPacienteObraSocial.Rows)
            {
                DataGridViewCell cell;
                pos = (row.DataBoundItem as PacienteObraSocial);
                
                cell = row.Cells[0];
                cell.Value = String.Format("{0} - {1}, {2}", pos.PacienteObj.Dni, pos.PacienteObj.Nombres, pos.PacienteObj.Apellido);

                cell = row.Cells[1];
                cell.Value = String.Format("{0}", pos.ObraSocialObj.Nombre);
            }
        }

        private void CargarGrillaBtn_Click(object sender, EventArgs e)
        {
            // Se necesita esta opcion para mantener configuracion de columnas editada en el diseño de la grilla
            this.gridPacienteObraSocial.AutoGenerateColumns = false;
            this.gridPacienteObraSocial.DataSource = ManagerDB<PacienteObraSocial>.findAll();
        }
    }
}
