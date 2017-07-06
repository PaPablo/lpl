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
    public partial class EspecialidadResultsFrm : Form
    {
        public EspecialidadResultsFrm()
        {
            InitializeComponent();
        }

        public void ResultadosEspecialidades(int codigo = -1, string nombre = null)
        {
            List<Especialidad> lista;
            if (codigo == -1 && nombre == null)
            {
                lista = ManagerDB<Especialidad>.findAll();
            }
            else if (codigo != -1 && nombre == null)
            {
                lista = ManagerDB<Especialidad>.findAll(String.Format("codigo = {0}", codigo));
            }
            else if (nombre != null && codigo == -1)
            {
                lista = ManagerDB<Especialidad>.findAll(String.Format("nombre like '%{0}%'", nombre));
            }
            else
            {
                lista = ManagerDB<Especialidad>.findAll(String.Format("nombre like '%{0}%' and codigo = {1}", nombre, codigo));
            }

            if (lista == null)
            {
                MessageBox.Show("No se encontró nada", "ERROR");
                return;
            }

            lista.Sort((esp1, esp2) => (esp1.Codigo.CompareTo(esp2.Codigo)));
            this.gridEspecialidades.DataSource = lista;
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void gridEspecialidades_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            Especialidad esp;
            foreach (DataGridViewRow row in this.gridEspecialidades.Rows)
            {                
                esp = (row.DataBoundItem as Especialidad);
                row.Cells[0].Value = esp.Codigo;
                row.Cells[1].Value = esp.Nombre;
            }
        }
    }
}
