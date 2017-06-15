using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class Paciente
    {
        #region variables locales
        private int _dni;
        private string _nombres;
		private string _apellido;
        private string _domicilio;        
		private string _telefono;
        #endregion

        #region propiedades publicas
        public int Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public string Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        
        public string Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }     
		
		public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        #endregion

    }
}
