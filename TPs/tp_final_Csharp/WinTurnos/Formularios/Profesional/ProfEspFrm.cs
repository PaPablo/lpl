using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibTurnos.db;

namespace WinTurnos.Formularios { 

    public partial class ProfEspFrm : Form
    {
        private Profesional prof;
        public ProfEspFrm()
        {
            InitializeComponent();
        }

        public void MostrarEspecialidades(Profesional p) {

            this.prof = p;

            this.nombreProfesional.Text = String.Format("{0}, {1}", this.prof.Apellido.ToUpper(), this.prof.Nombres);
            this.matriculaProfesional.Text = this.prof.Matricula;
            this.codigoEspecialidad.Enabled = true;
            this.codigoEspecialidad.Checked = true;
            this.textNombre.Enabled = false;
            this.nombreEspecialidad.Checked = false;

            this.Actualizar_Grid(p);

            this.ShowDialog();

        }


        public void Actualizar_Grid(Profesional p) {
            this.gridEspecialidades.AutoGenerateColumns = false;
            List<ProfesionalEspecialidad> listaProfEsp = ManagerDB<ProfesionalEspecialidad>.findAll(
                String.Format("codigoprofesional = {0}", p.Id));

            if (listaProfEsp == null) {
                return;
            }
            listaProfEsp.Sort((pe1, pe2) => pe1.CodigoEspecialidad.CompareTo(pe2.CodigoEspecialidad));
            this.gridEspecialidades.DataSource = listaProfEsp;

            Cursor.Current = Cursors.Default;
        }


        private void ProfEsp_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ProfesionalEspecialidad pe;
            foreach (DataGridViewRow row in this.gridEspecialidades.Rows)
            {                
                pe = (row.DataBoundItem as ProfesionalEspecialidad);
                row.Cells[0].Value = pe.EspecialidadObj.Codigo;
                row.Cells[1].Value = pe.EspecialidadObj.Nombre;
                row.Cells[2].Value = pe.FechaAlta.ToShortDateString();
                row.Cells[3].Value = pe.Disponible ? "SÍ" : "NO";
                row.Cells[4].Value = pe.Observaciones;
                row.Cells[5].Value = "Editar";
            }
        }

        private void codigoEspecialidad_CheckedChanged(object sender, EventArgs e)
        {
            this.maskedCodigo.Enabled = this.codigoEspecialidad.Checked;
            if (this.codigoEspecialidad.Checked) {
                this.nombreEspecialidad.Checked = false;
                this.maskedCodigo.Focus();
            }
        }

        private void nombreEspecialidad_CheckedChanged(object sender, EventArgs e)
        {
            this.textNombre.Enabled = this.nombreEspecialidad.Checked;
            if (this.nombreEspecialidad.Checked) {
                this.codigoEspecialidad.Checked = false;
                this.textNombre.Focus();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(!this.codigoEspecialidad.Checked && !this.nombreEspecialidad.Checked)
            {
                MessageBox.Show("Falta ingresar la especialidad", "Faltan criterios");
                return;
            }

            ProfesionalEspecialidad pe = new ProfesionalEspecialidad()
            {
                ProfesionalObj = this.prof,
                CodigoProfesional = this.prof.Id
            };

            if (this.codigoEspecialidad.Checked)
            {
                try
                {
                    pe.EspecialidadObj = (Especialidad)ManagerDB<Especialidad>.findbyKey(
                    Convert.ToInt32(this.maskedCodigo.Text));
                }
                catch (System.FormatException) {
                    pe.EspecialidadObj = null;
                }
            }
            else
            {
                try
                {
                    pe.EspecialidadObj = ManagerDB<Especialidad>.findAll(
                        String.Format("nombre like '{0}'", this.textNombre.Text))[0];
                }
                catch(Exception)
                {
                    pe.EspecialidadObj = null;
                }
            }

            if (pe.EspecialidadObj == null) {
                MessageBox.Show("Especialidad incorreta", "ERROR");
                return;
            }

            pe.FechaAlta = this.dateTimePicker1.Value;
            pe.Disponible = this.estaDisponible.Checked;
            pe.Observaciones = this.textObservaciones.Text;

            if (!pe.saveObj())
            {
                MessageBox.Show("Error al ingresar nueva especialidad en el profesional", "ERROR");
                return;
            }
            MessageBox.Show(String.Format("Nueva especialidad cargada en el/la profesional {0}",
                pe.ProfesionalObj.Apellido.ToUpper()), "Operación exitosa");


            this.Actualizar_Grid(this.prof);
        }

        private void gridEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var grid = (DataGridView)sender;
            ProfesionalEspecialidad pe;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                pe = (ProfesionalEspecialidad)grid.Rows[e.RowIndex].DataBoundItem;
                new ModProfEspFrm().ShowEspecialidad(pe);
                this.Actualizar_Grid(this.prof);
            }

        }
    }
    }
