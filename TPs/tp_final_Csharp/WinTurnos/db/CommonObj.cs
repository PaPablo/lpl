using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public abstract class CommonObj
    {
        #region definicion de delegado para el evento de validacion
        public delegate void ValidacionIngreso(object sender, string msg);
        #endregion

        #region definicion del evento de validacion
        public abstract event ValidacionIngreso Validar;
        #endregion

        private bool _isNew=true;

        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
        
    }
}
