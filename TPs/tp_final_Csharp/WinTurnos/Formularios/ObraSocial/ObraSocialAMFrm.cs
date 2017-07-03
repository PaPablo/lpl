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
    public partial class ObraSocialAMFrm : Form
    {

        ObraSocial os;

        OperacionForm operacion = OperacionForm.frmConsulta;
        IFormGridReload _frmGrid;

        public ObraSocialAMFrm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void ShowObraSocial(ObraSocial obraSocial, IFormGridReload frmGrid)
        {
            _frmGrid = frmGrid;
            this.operacion = OperacionForm.frmModificacion;
            this.Text = "Modificación de información de paciente";
            os = obraSocial;
            this.txtNombre.Text = os.Nombre;
            this.ShowDialog();
        }

        public void NewObraSocial(IFormGridReload frmGrid)
        {
            _frmGrid = frmGrid;
            this.Text = "Nueva Obra Social";
            this.operacion = OperacionForm.frmAlta;
            this.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {

           try
             {
                 if (this.operacion == OperacionForm.frmAlta)
                 {
                    os = new ObraSocial();
                    os.Validar += new CommonObj.ValidacionIngreso(Validar_obra_social);
                 }
                os.Nombre = this.txtNombre.Text;

                 if (!os.saveObj())
                 {
                     MessageBox.Show(operacion == OperacionForm.frmAlta ? 
                         "Error al intentar ingresar una nueva Obra Social" : 
                         "Error al intentar editar información de Obra Social", 
                         "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
                 MessageBox.Show(operacion == OperacionForm.frmAlta ?"Nueva Obra Social dada de alta":
                     "Actualización de información de Obra Social", 
                     operacion == OperacionForm.frmAlta ? "Ingreso de obra social":
                     "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error al intentar " + (operacion == OperacionForm.frmAlta ?
                     "ingresar nueva Obra Social":"actualizar información") 
                     + String.Format("\n{0}",ex.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }
            _frmGrid.ReloadGrid();
            this.Dispose();
        }
    private void Validar_obra_social(object sender, string msg)
    {
        throw new Exception(msg);
    }

        private void ObraSocialAMFrm_Load(object sender, EventArgs e)
        {

        }
    }

}
