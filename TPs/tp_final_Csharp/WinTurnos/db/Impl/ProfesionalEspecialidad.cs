using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class ProfesionalEspecialidad : CommonObj, IAccessDB<ProfesionalEspecialidad>, ITable
    {
        private string[] _columns = { "codigoprofesional", "codigoEspecialidad", "fechaalta", "disponible", "observaciones" };
        public List<ProfesionalEspecialidad> findAll()
        {
            return this.findAll(null);
        }
        public List<ProfesionalEspecialidad> findAll(string criterio)
        {
            return ManagerDB<ProfesionalEspecialidad>.findAll(criterio);
        }
        public ProfesionalEspecialidad findbykey(params object[] key)
        {
            ProfesionalEspecialidad d = (ProfesionalEspecialidad)ManagerDB<ProfesionalEspecialidad>.findbyKey(key);
            this.CodigoProfesional = d.CodigoProfesional;
            this.Observaciones = d.Observaciones;
            this.IsNew = false;
            return this;
        }
        public bool saveObj()
        {
            return ManagerDB<ProfesionalEspecialidad>.saveObject(this);
        }

        public string TableName
        {
            get { return "profesionalespecialidad"; }
        }

        public string KeyTable
        {
            get { return ""; }
        }

        public void initialize(System.Data.DataRow dr)
        {
            this._codigoprofesional = Int32.Parse(dr[_columns[0]].ToString());
            this._codigoespecialidad = Int32.Parse(dr[_columns[1]].ToString());
            this._fechaAlta = Convert.ToDateTime(dr[_columns[2]].ToString());
            this._disponible = dr[_columns[3]].ToString() == "1" ? true : false;
            this._observaciones = dr[_columns[4]].ToString().Trim();
			this.IsNew = false;
        }
        public string[] columns
        {
            get { return _columns; }
        }
        private string[] list_values()
        {
            // "codigo","Observaciones"
            string[] values = { (this.IsNew?"":_columns[0] + "=")+this._codigoprofesional.ToString(),
                                (this.IsNew?"":_columns[1] + "=")+this._codigoespecialidad.ToString(),
                                (this.IsNew?"":_columns[2] + "=")+String.Format("'{0}'",this._fechaAlta.ToString("yyyy-MM-dd")),
                                (this.IsNew?"":_columns[3] + "=")+(this.Disponible.ToString().ToLower() =="true"?1:0),
                                (this.IsNew?"":_columns[4] + "=")+String.Format("'{0}'",this._observaciones),
                              };
            return values;
        }

        public string SqlString
        {
            get
            {
                string vvalues = String.Join(",", this.list_values());
                string sqliu = (this.IsNew ? "insert into {0} ({1}) values ({2})" : "update  {0} set {1} where {2}");
                return String.Format(sqliu, this.TableName, (this.IsNew ? String.Join(",", _columns) : vvalues), 
                    (this.IsNew ? vvalues : String.Format("codigoprofesional = {0} and codigoespecialidad = {1}" +
                    " and fechaalta = {2}", this.CodigoProfesional, this.CodigoEspecialidad,
                    String.Format("'{0}'",this._fechaAlta.ToString("yyyy-MM-dd")))));
            }
        }
        // propiedad seteada por implementar IAutoIncrement
        public void setKeyValue(object valueId)
        {
            //
        }
        
        public string sqlKeyWhere(params object[] values)
        {
            return String.Format("codigo={0}", values[0]);
        }
    }
}

