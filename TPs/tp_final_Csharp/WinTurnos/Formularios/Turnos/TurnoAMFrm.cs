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
    public partial class TurnoAMFrm : Form
    {
        private delegate void Operacion();
        private Operacion op;
        public TurnoAMFrm()
        {
            InitializeComponent();
        }

        private void ModificarTurno() {
            Turno t = new Turno();
            t.FechaHora = this.dateTimePicker1.Value;
            t.DniPaciente = Convert.ToInt32(this.dniPaciente.Text);

            try
            {
                Profesional p = ManagerDB<Profesional>.findAll
                    (String.Format("matricula = '{}'",
                    this.matriculaProfesional))[0];
            }
            catch (NullReferenceException) {
                MessageBox.Show("Profesional no existe", "ERROR");
                return;
            }

            t.Asistio = this.asistioChk.Checked;

            if (!t.saveObj()) {
                MessageBox.Show("No se pudo modificar el turno", "ERROR");
            }

            MessageBox.Show("Turno modificado exitosamente", "Operación exitosa");
            return;

        }
        private void CrearTurno() {
            Turno t = new Turno();
            t.FechaHora = this.dateTimePicker1.Value;
            t.DniPaciente = Convert.ToInt32(this.dniPaciente.Text);

            try
            {
                Profesional p = ManagerDB<Profesional>.findAll
                    (String.Format("matricula = '{}'",
                    this.matriculaProfesional))[0];
            }
            catch (NullReferenceException) {
                MessageBox.Show("Profesional no existe", "ERROR");
                return;
            }

            t.Asistio = false;

            if (!t.saveObj()) {
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
            this.op();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }


}
