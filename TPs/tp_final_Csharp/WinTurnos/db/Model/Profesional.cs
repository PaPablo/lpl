using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace LibTurnos.db
{
    public partial class Profesional
    {
        public override event ValidacionIngreso Validar;
        #region variables locales
        private int _id;
        private string _matricula;
		private string _nombres;
		private string _apellido;     
		private string _telefono;
        private DateTime _fechamatricula;
		private bool _activo;
        #endregion

        public override string ToString()
        {
            return String.Format("MATRICULA:{0}\n" +
                "NOMBRES: {1}\n" +
                "APELLIDO: {2}\n" +
                "ACTIVO?: {3}", this.Matricula, this.Nombres,
                this.Apellido,
                this.Activo == true ? "SI" : "NO");
        }

        #region propiedades publicas
        
        public int Id
        {
            get { return _id; }
            set {
                if (value < 0) {
                    if (this.Validar != null)
                    {
                        this.Validar(this, "ID inválido");
                        return;
                    }
                }
                _id = value;
            }
        }

        public string Nombres
        {
            get { return _nombres; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    if (this.Validar != null)
                    {
                        this.Validar(this, "Nombre no puede estar vacío");
                        return;
                    }
                }
                _nombres = value;
            }
        }

        public string Matricula
        {
            get { return _matricula; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    if (this.Validar != null)
                    {
                        this.Validar(this, "Matrícula no puede estar vacía");
                        return;
                    }
                }
                string pat = "[a-z]{2}[0-9]{4}";
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = r.Match(value);
                if (!m.Success)
                {
                    Validar(this, "Mátricula debe estar compuesta por dos letras y seguida de cuatro números");
                    return;
                }
                _matricula = value;
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    if (this.Validar != null)
                    {
                        this.Validar(this, "Apellido no puede estar vacío");
                        return;
                    }
                }
                _apellido = value;
            }
        }
        
       public DateTime FechaMatricula
        {
            get { return _fechamatricula; }
            set
            {
                if (value == null)
                {
                    if (this.Validar != null)
                    {
                        this.Validar(this, "Fecha de matrícula no puede estar vacío");
                        return;
                    }
                }
                _fechamatricula = value;
            }
        }
        
		
		public string Telefono
        {
            get { return _telefono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    if (this.Validar != null)
                    {
                        this.Validar(this, "Teléfono no puede estar vacío");
                        return;
                    }
                }
                _telefono = value;
            }
        }
				
		public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        #endregion

    }
}
