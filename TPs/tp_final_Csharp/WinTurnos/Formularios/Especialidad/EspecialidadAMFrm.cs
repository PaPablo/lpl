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
    public partial class EspecialidadAMFrm : Form
    {
        private Especialidad esp;
        private Operacion op;

        public EspecialidadAMFrm()
        {
            InitializeComponent();
            this.esp = new Especialidad();
            this.esp.Validar += new CommonObj.ValidacionIngreso(Validar_especialidad);
        }

        public void NewEspecialidad() {

            this.op = CrearEspecialidad;
            this.ShowDialog();
        }

        public void ShowEspecialidad(Especialidad esp) {

            this.esp = esp;
            this.nombreEsp.Text = esp.Nombre;
            this.op = ModificarEspecialidad;
            this.ShowDialog();
        }

        private void CrearEspecialidad() {

            this.esp.Nombre = this.nombreEsp.Text;

            if (!this.esp.saveObj())
            {
                MessageBox.Show("No se pudo agregar la nueva especialidad", "ERROR");
                return;
            }
            MessageBox.Show("Especialidad agregada con éxito", "Operación exitosa");
            return;
        }
        private void ModificarEspecialidad() {
            this.esp.Nombre = this.nombreEsp.Text;
            if (!this.esp.saveObj())
            {
                MessageBox.Show("No se pudo modificar la especialidad", "ERROR");
                return;
            }
            MessageBox.Show("Especialidad modificada con éxito", "Operación exitosa");
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.nombreEsp.Text))
            {
                MessageBox.Show("Faltan datos de la especialidad", "ERROR");
                return;
            }
            try
            {
                this.op();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Validar_especialidad(object sender, string msg) {
            throw new Exception(msg);
        }
    }
}
