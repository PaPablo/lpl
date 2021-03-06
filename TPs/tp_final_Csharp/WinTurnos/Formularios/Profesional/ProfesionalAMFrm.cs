﻿using System;
using System.Windows.Forms;
using LibTurnos.db;

namespace WinTurnos.Formularios
{

    public partial class ProfesionalAMFrm : Form
    {
        // Este enum está definido en PacienteAMFrm
        OperacionForm operacion = OperacionForm.frmConsulta;
        IFormGridReload _frmGrid;
                
        Profesional p;
        public ProfesionalAMFrm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }


        public void ShowProfesional(Profesional profesional, IFormGridReload frmGrid)
        {
            _frmGrid = frmGrid;
            this.operacion = OperacionForm.frmModificacion;
            this.Text = "Modificacion de informacion de profesional";
            p = profesional;
            this.MatriculaTxt.Text = p.Matricula;
            this.FechaMatricula.Value = p.FechaMatricula;
            this.NombreTxt.Text = p.Nombres;
            this.ApellidoTxt.Text = p.Apellido;
            this.TelefonoTxt.Text = p.Telefono;
            this.EsActivo.Checked = p.Activo;
            
            this.ShowDialog();
        }
        public void NewProfesional(IFormGridReload frmGrid)
        {
            _frmGrid = frmGrid;
            this.Text = "Nuevo Profesional";
            this.operacion = OperacionForm.frmAlta;
            this.ShowDialog();
        }

        private void CancelarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AceptarBtn_Click(object sender, EventArgs e)
         {
           try
             {

                if (this.operacion == OperacionForm.frmAlta)
                {
                    p = new Profesional();
                    p.Validar += new CommonObj.ValidacionIngreso(Validar_profesional);
                    p.Matricula = this.MatriculaTxt.Text;
                }
                p.Nombres = this.NombreTxt.Text;
                p.Apellido = this.ApellidoTxt.Text;
                p.FechaMatricula = Convert.ToDateTime(this.FechaMatricula.Value);
                p.Telefono = this.TelefonoTxt.Text;
                p.Activo = this.EsActivo.Checked;


                if (!p.saveObj())
                {
                    MessageBox.Show(operacion == OperacionForm.frmAlta ? 
                        "Error al intentar ingresar nuevo Profesional " :
                        "Error al intentar editar informacion de Profesional", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(operacion == OperacionForm.frmAlta ? "Nuevo Profesional dado de alta":
                    "Actualizacion de informacion de Profesional",
                    operacion == OperacionForm.frmAlta ? "Ingreso de profesional":
                    "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             catch (Exception ex)
             {

                 MessageBox.Show("Error al intentar " +
                     (operacion == OperacionForm.frmAlta ?"ingresar nuevo Profesional":
                     "actualizar informacion") + String.Format("\n{0}", ex.Message),
                     "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }
            _frmGrid.ReloadGrid();
            this.Dispose();
        }

        private void Validar_profesional(object sender, string msg) {
            throw new Exception(msg);
        }

        private void ProfesionalAMFrm_Load(object sender, EventArgs e)
        {

           
        }
    }
}
