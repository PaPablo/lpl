using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class ObraSocial : CommonObj, IAccessDB<ObraSocial>, ITable, IAutoIncrement
    {
        private string[] _columns = { "codigo","nombre"};
        public List<ObraSocial> findAll()
        {
            return this.findAll(null);
        }
        public List<ObraSocial> findAll(string criterio)
        {
            return ManagerDB<ObraSocial>.findAll(criterio);
        }
        public ObraSocial findbykey(params object[] key)
        {
            ObraSocial i = (ObraSocial)ManagerDB<ObraSocial>.findbyKey(key);
            this.Codigo = i.Codigo;
            this.Nombre = i.Nombre;
            this.IsNew = false;
            return this;
        }
        public bool saveObj()
        {
            return ManagerDB<ObraSocial>.saveObject(this);
        }

        public string TableName
        {
            get { return "obrasociales"; }
        }

        public string KeyTable
        {
            get { return "codigo"; }
        }

        public void initialize(System.Data.DataRow dr)
        {
            this._codigo = Int32.Parse(dr[_columns[0]].ToString());
            this._nombre = dr[_columns[1]].ToString().Trim();
            this.IsNew = false;
        }
        public string[] columns
        {
            get { return _columns; }
        }
        private string[] list_values()
        {
            string[] values = { (this.IsNew?"":_columns[0] + "=")+this._codigo.ToString(),                                
                                (this.IsNew?"":_columns[1] + "=")+String.Format("'{0}'",this._nombre)
                              };
            return values;
        }

        public string SqlString
        {
            get
            {
                string vvalues = String.Join(",", this.list_values());
                string sqliu = (this.IsNew ? "insert into {0} ({1}) values ({2})" : "update  {0} set {1} where {2}");
                return String.Format(sqliu, this.TableName, (this.IsNew ? String.Join(",", _columns) : vvalues), (this.IsNew ? vvalues : String.Format("codigo = {0}", this.Codigo)));
            }
        }

        // propiedad seteada por implementar IAutoIncrement
        public void setKeyValue(object valueId)
        {
            this._codigo = Convert.ToInt32(valueId);
        }

        public string sqlKeyWhere(params object[] values)
        {
            return String.Format("codigo={0}", values[0]);
        }
    }
}
