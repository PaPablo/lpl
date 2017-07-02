using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class Paciente
    {
        public override event ValidacionIngreso Validar;
        #region variables locales
        private int _dni;
        private string _nombres;
		private string _apellido;
        private string _domicilio;        
		private string _telefono;
        #endregion

        public override string ToString()
        {
            return String.Format("NOMBRE: {0}\n" +
                "APELLIDO: {1}\n" +
                "DNI: {2}\n",
                this.Nombres, this.Apellido, this.Dni.ToString());
        }
        #region propiedades publicas
        public int Dni
        {
            get { return _dni; }
            set {
                if (value == 0) {
                    if (this.Validar != null)
                    {
                        Validar(this, "DNI no puede ser 0");
                        return;
                    }
                }
                _dni = value;
            }
        }

        public string Nombres
        {
            get { return _nombres; }
            set {
                if(string.IsNullOrWhiteSpace(value))
                {
                    if (this.Validar != null)
                    {
                        Validar(this, "Nombres no pueden estar vacíos");
                        return;
                    }
                }
                _nombres = value;
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set {
                if(string.IsNullOrWhiteSpace(value))
                {
                    if (this.Validar != null)
                    {
                        Validar(this, "Apellido no puede estar vacío");
                        return;
                    }
                }
                _apellido = value;
            }
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
