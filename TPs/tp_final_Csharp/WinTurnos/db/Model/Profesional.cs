using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class Profesional
    {
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
            set { _matricula = value; }
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
