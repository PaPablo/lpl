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
            set {
                try
                {
                    if ((Paciente)ManagerDB<Paciente>.findbyKey(value) == null)
                    {
                        if (this.Validar != null)
                        {
                            this.Validar(this, String.Format("No existe el paciente con DNI: {0}", value.ToString()));
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    this.Validar(this, String.Format("Error al asignar el paciente ({0}) al turno", value.ToString()));
                    return;
                }
                _dnipaciente = value;
            }
        }

			
        public int CodigoProfesional
        {
            get { return _codigoprofesional; }
            set {
                try
                {
                    Profesional prof = (Profesional)ManagerDB<Profesional>.findbyKey(value);
                    if (prof == null)
                    {
                        if (this.Validar != null)
                        {
                            this.Validar(this, String.Format("No existe el profesional con id: {0}", value.ToString()));
                            return;
                        }
                    }
                    if (!prof.Activo)
                    {
                        this.Validar(this, String.Format("El profesional ({0}) no está activo", value));
                        return;
                    }
                }
                catch (Exception)
                {
                    this.Validar(this, String.Format("Error al asignar el profesional ({0}) al turno", value.ToString()));
                    return;
                }
                _codigoprofesional = value;
            }
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
