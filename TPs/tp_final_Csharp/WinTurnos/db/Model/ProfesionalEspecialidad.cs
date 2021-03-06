﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class ProfesionalEspecialidad
    {
        public override event ValidacionIngreso Validar;
        #region variables locales
        private int _codigoprofesional;
		private int _codigoespecialidad;
		private bool _disponible;
        private string _observaciones;
        private Profesional _objProfesional = null;
        private Especialidad _objEspecialidad = null;
        private DateTime _fechaAlta;
        #endregion

        public override string ToString()
        {
            return String.Format("PROFESIONAL: {0}\nESPECIALIDAD: {1}\nDISPONIBLE: {2}\n" +
                "FECHA ALTA: {3}\nOBSERVACIONES: {4}\n",
                this.ProfesionalObj.ToString(), this.EspecialidadObj.ToString(),
                this.Disponible ? "SI" : "NO", this.FechaAlta.ToShortDateString(),
                this.Observaciones);
        }
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
        #region relacion con especialidad

        public Especialidad EspecialidadObj
        {
            get
            {
                if(_objEspecialidad == null && this._codigoespecialidad != 0)
                {
                    _objEspecialidad = ManagerDB<Especialidad>.findbyKey(this._codigoespecialidad);
                }
                return _objEspecialidad;
            }

            set
            {
                if (value == null)
                {
                    _codigoespecialidad = 0;
                }
                else
                    _codigoespecialidad = value.Codigo;
                _objEspecialidad = value;
            }
        }

        #endregion
        #endregion



    }
}
