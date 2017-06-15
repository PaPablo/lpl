using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class Turno
    {
        private DateTime _fechahora;
        private int _dnipaciente;
		private int _codigoprofesional;
		private bool _asistio;
		
		
        public int DniPaciente
        {
            get { return _dnipaciente; }
            set { _dnipaciente = value; }
        }

			
        public int CodigoProfesional
        {
            get { return _codigoprofesional; }
            set { _codigoprofesional = value; }
        }
		
		public bool Asistio
        {
            get { return _asistio; }
            set { _asistio = value; }
        }
		
        public DateTime FechaHora
        {
            get { return _fechahora; }
            set { _fechahora = value; }
        }
    }
}
