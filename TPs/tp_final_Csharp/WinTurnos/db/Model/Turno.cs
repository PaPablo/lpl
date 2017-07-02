using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class Turno
    {
        public override event ValidacionIngreso Validar;
        private DateTime _fechahora;
        private int _dnipaciente;
		private int _codigoprofesional;
        private Profesional _objProfesional = null;
        private Paciente _objPaciente = null;
		private bool _asistio;

        public override string ToString()
        {
            return String.Format("PACIENTE: {0}\n" +
                "PROFESIONAL: {1}\n" +
                "FECHA: {2}\n" +
                "ASISTIO: {3}\n", this.PacienteObj.ToString(),
                this.ProfesionalObj.ToString(),
                this.FechaHora.ToString(),
                this.Asistio ? "SI" : "NO");
        }

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



        #region Relacion con Profesional
        public Profesional ProfesionalObj
        {
            get
            {
                if (_objProfesional == null && this._codigoprofesional != 0)
                {
                    _objProfesional = ManagerDB<Profesional>.findbyKey(this._codigoprofesional);
                }
                return _objProfesional;
            }
            set
            {
                if (value == null)
                {
                    _codigoprofesional = 0;
                }
                else
                    _codigoprofesional = value.Id;
                _objProfesional = value;
            }
        }

        #endregion
        #region relacion con paciente

        public Paciente PacienteObj
        {
            get
            {
                if(_objPaciente == null && this._dnipaciente != 0)
                {
                    _objPaciente = ManagerDB<Paciente>.findbyKey(this._dnipaciente);
                }
                return _objPaciente;
            }

            set
            {
                if (value == null)
                {
                    _dnipaciente = 0;
                }
                else
                    _dnipaciente = value.Dni;
                _objPaciente = value;
            }
        }

        #endregion
    }
}
