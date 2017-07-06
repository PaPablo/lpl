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
    public delegate void Operacion();
    public partial class TurnoAMFrm : Form
    {
        private Operacion op;
        private Turno turno;

        public TurnoAMFrm()
        {
            InitializeComponent();
            this.turno = new Turno();
            this.turno.Validar += new CommonObj.ValidacionIngreso(Validar_turno);
        }

        private void ModificarTurno() {
            Profesional prof;
            turno.FechaHora = this.dateTimePicker1.Value;
            turno.DniPaciente = Convert.ToInt32(this.dniPaciente.Text);

            try
            {
                prof = ManagerDB<Profesional>.findAll
                    (String.Format("matricula = '{0}'",
                    this.matriculaProfesional.Text))[0];
            }
            catch (NullReferenceException) {
                MessageBox.Show(String.Format("No existe profesional con matrícula {0}", this.matriculaProfesional.Text), "ERROR");
                return;
            }

            turno.Asistio = this.asistioChk.Checked;
            turno.CodigoProfesional = prof.Id;

            if (!turno.saveObj()) {
                MessageBox.Show("No se pudo modificar el turno", "ERROR");
            }

            MessageBox.Show("Turno modificado exitosamente", "Operación exitosa");
            return;
        }
        private void CrearTurno() {
            turno.FechaHora = this.dateTimePicker1.Value;
            Profesional prof;
            turno.DniPaciente = Convert.ToInt32(this.dniPaciente.Text);

            try
            {
               prof = ManagerDB<Profesional>.findAll
                    (String.Format("matricula = '{0}'",
                    this.matriculaProfesional.Text))[0];
            }
            catch (NullReferenceException) {
                MessageBox.Show("Profesional no existe", "ERROR");
                return;
            }

            turno.Asistio = false;
            turno.CodigoProfesional = prof.Id;

            if (!turno.saveObj()) {
                MessageBox.Show("No se pudo agregar el nuevo turno", "ERROR");
            }

            MessageBox.Show("Turno agregado exitosamente", "Operación exitosa");
            return;
        }

        public void NewTurno()
        {
            this.asistioChk.Enabled = false;
            this.op = CrearTurno;
            this.ShowDialog();
        }

        public void ShowTurno(Turno turno)
        {
            this.dateTimePicker1.Value = turno.FechaHora;
            this.dniPaciente.Text = turno.DniPaciente.ToString();
            this.matriculaProfesional.Text = turno.ProfesionalObj.Matricula;
            this.asistioChk.Checked = turno.Asistio;
            this.op = ModificarTurno;
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.dniPaciente.Text) || string.IsNullOrWhiteSpace(this.matriculaProfesional.Text))
            {
                MessageBox.Show("Faltan datos del turno", "ERROR");
                return;
            }
            try
            {
                this.op();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Validar_turno(object sender, string msg) {
            throw new Exception(msg);
        }

    }


}
