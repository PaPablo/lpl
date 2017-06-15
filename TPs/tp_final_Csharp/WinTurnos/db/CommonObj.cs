using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public class CommonObj
    {
        private bool _isNew=true;

        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
        
    }
}
