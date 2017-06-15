using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class ProfesionalEspecialidad
    {
        #region variables locales
        private int _codigoprofesional;
		private int _codigoespecialidad;
		private bool _disponible;
        private string _observaciones;
        private DateTime _fechaAlta;
		#endregion
        
        #region propiedades publicas
        public DateTime FechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
		
        public int CodigoProfesional
        {
            get { return _codigoprofesional; }
            set { _codigoprofesional = value; }
        }
		public int CodigoEspecialidad
        {
            get { return _codigoespecialidad; }
            set { _codigoespecialidad = value; }
        }
		public bool Disponible
        {
            get { return _disponible; }
            set { _disponible = value; }
        }
        
        #endregion
        
    }
}
