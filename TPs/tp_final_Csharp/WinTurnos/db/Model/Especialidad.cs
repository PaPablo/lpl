﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class Especialidad
    {
        public override event ValidacionIngreso Validar;

        #region variables locales
        private int _codigo;
        private string _nombre;
        #endregion

        public override string ToString()
        {
            return String.Format("NOMBRE: {0}\nCODIGO: {1}", this.Nombre, this.Codigo);
        }

        #region propiedades publicas
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
		
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        
        #endregion
        
    }
}
