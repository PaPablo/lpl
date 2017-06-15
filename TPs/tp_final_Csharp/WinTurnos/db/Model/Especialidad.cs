using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class Especialidad
    {
        #region variables locales
        private int _codigo;
        private string _nombre;
		#endregion
        
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
