using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class ObraSocial
    {
        public override event ValidacionIngreso Validar;
        private int _codigo;
        private string _nombre;
		
		
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value == "")
                {
                    if(this.Validar != null)
                    {
                        Validar(this, "Nombre no puede estar vacío");
                        return;
                    }
                }
                _nombre = value;
            }
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
    }
}
