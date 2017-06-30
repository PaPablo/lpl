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

        #region propiedades publicas
        
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }

        public string Matricula
        {
            get { return _matricula; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Validar(this, "Mátricula no puede estar vacía");
                    return;
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
            set { _apellido = value; }
        }
        
       public DateTime FechaMatricula
        {
            get { return _fechamatricula; }
            set { _fechamatricula = value; }
        }
        
		
		public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
				
		public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        #endregion

    }
}
