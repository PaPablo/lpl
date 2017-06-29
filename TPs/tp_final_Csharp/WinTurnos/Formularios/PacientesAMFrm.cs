using System;
using System.Windows.Forms;
using LibTurnos.db;

namespace WinTurnos.Formularios
{
    public enum OperacionForm
    {
        frmConsulta =0, frmAlta=1,frmModificacion=2
    }

    public partial class PacientesAMFrm : Form
    {
        OperacionForm operacion = OperacionForm.frmConsulta;
        IFormGridReload _frmGrid;
                
        Paciente p;
        public PacientesAMFrm()
        {
            InitializeComponent();
        }
        public void ShowPaciente(Paciente paciente, IFormGridReload frmGrid)
        {
            _frmGrid = frmGrid;
            this.operacion = OperacionForm.frmModificacion;
            this.Text = "Modificacion de informacion de paciente";
            p = paciente;
            this.DniMsk.Enabled = false;
            this.ApellidoTxt.Text = p.Apellido;
            this.NombresTxt.Text = p.Nombres;
            this.DniMsk.Text = p.Dni.ToString();
            this.DomicilioTxt.Text = p.Domicilio;
            this.TelefonoTxt.Text = p.Telefono;
            this.ShowDialog();
        }
        public void NewPaciente(IFormGridReload frmGrid)
        {
            _frmGrid = frmGrid;
            this.Text = "Nuevo Paciente";
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
                     p = new Paciente();
                     p.Dni = Convert.ToInt32(this.DniMsk.Text);
                 }
                 p.Apellido = this.ApellidoTxt.Text;
                 p.Nombres = this.NombresTxt.Text;
                 p.Domicilio = this.DomicilioTxt.Text;
                 p.Telefono = this.TelefonoTxt.Text;
                 if (!p.saveObj())
                 {
                     MessageBox.Show(operacion == OperacionForm.frmAlta ? 
                         "Error al intentar ingresar nuevo Paciente" : 
                         "Error al intentar editar informacion de Paciente", 
                         "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
                 MessageBox.Show(operacion == OperacionForm.frmAlta ?"Nuevo Paciente dado de alta":
                     "Actualizacion de informacion de Paciente", 
                     operacion == OperacionForm.frmAlta ? "Ingreso de paciente":
                     "Actualizacion de informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error al intentar " + (operacion == OperacionForm.frmAlta ?
                     "ingresar nuevo Paciente":"actualizar informacion") 
                     + ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }
            _frmGrid.ReloadGrid();
            this.Dispose();
        }

        private void PacientesAMFrm_Load(object sender, EventArgs e)
        {

        }

      
    }
}
