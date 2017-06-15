using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class PacienteObraSocial
    {
        public PacienteObraSocial()
        {
            
        }
        #region variables locales
        private int _dniPaciente;
        private int _codigoObraSocial;
		private DateTime _fechadesde;
        private ObraSocial _objObraSocial=null;
        private Paciente _objPaciente = null;
        #endregion
        
        #region propiedades publicas
				
		public int DniPaciente
        {
            get { return _dniPaciente; }
            set { _dniPaciente = value; }
        }
        
        public int CodigoObraSocial
        {
            get { return _codigoObraSocial; }
            set { _codigoObraSocial = value; }
        }
		
		public DateTime FechaDesde
        {
            get { return _fechadesde; }
            set { _fechadesde = value; }
        }
        #region Relacion con Obra Social
        public ObraSocial ObraSocialObj
        {
            get
            {
                if(_objObraSocial==null && this._codigoObraSocial!=0 )
                {
                    _objObraSocial = ManagerDB<ObraSocial>.findbyKey(this._codigoObraSocial);
                }
                return _objObraSocial;
            }
            set
            {
                if (value == null)
                {
                    _codigoObraSocial = 0;
                }
                else
                    _codigoObraSocial = value.Codigo;
                _objObraSocial = value;
            }
        }
        #endregion
        #region Relacion con Paciente
        public Paciente PacienteObj
        {
            get
            {
                if (_objPaciente == null && this._codigoObraSocial != 0)
                {
                    _objPaciente = ManagerDB<Paciente>.findbyKey(this._dniPaciente);
                }
                return _objPaciente;
            }
            set
            {
                if (value == null)
                {
                    _dniPaciente = 0;
                }
                else
                    _dniPaciente = value.Dni;
                _objPaciente = value;
            }
        }
        #endregion
        #endregion

    }
}
