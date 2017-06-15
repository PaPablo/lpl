using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class Profesional : CommonObj, IAccessDB<Profesional>, ITable
    {
        private string[] _columns = { "id","matricula","nombres","apellido","telefono","fechamatricula","activo"};
        public List<Profesional> findAll()
        {
            return this.findAll(null);
        }
        public List<Profesional> findAll(string criterio)
        {
            return ManagerDB<Profesional>.findAll(criterio);
        }
        public Profesional findbykey(params object[] key)
        {
            Profesional p = (Profesional)ManagerDB<Profesional>.findbyKey(key);
            this.Nombres = p.Nombres;
            this.Apellido = p.Apellido;
            this.FechaMatricula = p.FechaMatricula;
            this.Id = p.Id;
            this.Telefono = p.Telefono;
            this.Activo= p.Activo;            
            this.IsNew = false;
            return this;          
        }
        public bool saveObj()
        {
            return ManagerDB<Profesional>.saveObject(this);
        }

        public string TableName
        {
            get { return "profesionales"; }
        }

        public string KeyTable
        {
            get { return "id"; }
        }

        public void initialize(System.Data.DataRow dr)
        {
            this._id = Int32.Parse(dr[_columns[0]].ToString());
            this._matricula = dr[_columns[1]].ToString().Trim();
            this._nombres = dr[_columns[2]].ToString().Trim();
			this._apellido = dr[_columns[3]].ToString().Trim();
            this._telefono = dr[_columns[4]].ToString().Trim();
            this._fechamatricula = DateTime.Parse(dr[_columns[5]].ToString());
            this._activo = Boolean.Parse(dr[_columns[6]].ToString());
            this.IsNew = false;
        }
        public string[] columns
        {
            get { return _columns; }
        }
        private string[] list_values()
        {
            // "nombres","matricula","apellido", "telefono","activo"
            string[] values = { (this.IsNew?"":_columns[1] + "=")+String.Format("'{0}'",this._nombres), //formato cadena ''
                                (this.IsNew?"":_columns[2] + "=")+String.Format("'{0}'",this._matricula), //formato cadena ''
                                (this.IsNew?"":_columns[3] + "=")+String.Format("'{0}'",this._apellido),//formato cadena ''
                                (this.IsNew?"":_columns[4] + "=")+String.Format("'{0}'",this._telefono),//formato cadena ''
                                (this.IsNew?"":_columns[5] + "=")+String.Format("'{0}'",this._fechamatricula.ToString("yyyy-MM-dd")),//formato cadena 
                                (this.IsNew?"":_columns[6] + "=")+(this.Activo.ToString().ToLower() =="true"?1:0)
                              };
            return values;
        }

        public string SqlString
        {
            get
            {
                string vvalues = String.Join(",", this.list_values());
                string sqliu = (this.IsNew ? "insert into {0} ({1}) values ({2})" : "update  {0} set {1} where {2}");
                return String.Format(sqliu, this.TableName, (this.IsNew ? String.Join(",", _columns).Replace("id,","") : vvalues), (this.IsNew ? vvalues : String.Format("id = {0}", this.Id)));
            }
        }

        public void setKeyValue(object valueId)
        {
            throw new NotImplementedException();
        }

        public string sqlKeyWhere(params object[] values)
        {
            return String.Format("id = {0}", values[0]);
        }
    }
}
