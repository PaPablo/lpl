using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class Paciente : CommonObj, IAccessDB<Paciente>, ITable
    {
        private string[] _columns = { "dni","nombres","apellido","domicilio", "telefono"};
        public List<Paciente> findAll()
        {
            return this.findAll(null);
        }
        public List<Paciente> findAll(string criterio)
        {
            return ManagerDB<Paciente>.findAll(criterio);
        }
        public Paciente findbykey(params object[] key)
        {
            Paciente p = (Paciente)ManagerDB<Paciente>.findbyKey(key);
            this.Nombres = p.Nombres;
            this.Apellido = p.Apellido;
            this.Domicilio = p.Domicilio;
            this.Dni = p.Dni;
            this.Telefono = p.Telefono;
            this.IsNew = false;
            return this;
        }
        public bool saveObj()
        {
            return ManagerDB<Paciente>.saveObject(this);
        }

        public string TableName
        {
            get { return "pacientes"; }
        }

        public string KeyTable
        {
            get { return "dni"; }
        }

        public void initialize(System.Data.DataRow dr)
        {
            this._dni = Int32.Parse(dr[_columns[0]].ToString());
            this._nombres = dr[_columns[1]].ToString().Trim();
			this._apellido = dr[_columns[2]].ToString().Trim();
            this._domicilio = dr[_columns[3]].ToString().Trim();
            this._telefono = dr[_columns[4]].ToString().Trim();
            this.IsNew = false;
        }
        public string[] columns
        {
            get { return _columns; }
        }
        private string[] list_values()
        {
            // "dni","nombres","apellido","domicilio", "telefono"
            string[] values = { (this.IsNew?"":_columns[0] + "=")+this._dni.ToString(),
                                (this.IsNew?"":_columns[1] + "=")+String.Format("'{0}'",this._nombres), //formato cadena ''
                                (this.IsNew?"":_columns[2] + "=")+String.Format("'{0}'",this._apellido),//formato cadena ''
                                (this.IsNew?"":_columns[3] + "=")+String.Format("'{0}'",this._domicilio),//formato cadena ''
                                (this.IsNew?"":_columns[4] + "=")+String.Format("'{0}'",this._telefono),//formato cadena ''                                
                              };
            return values;
        }

        public string SqlString
        {
            get
            {
                string vvalues = String.Join(",", this.list_values());
                string sqliu = (this.IsNew ? "insert into {0} ({1}) values ({2})" : "update  {0} set {1} where {2}");
                return String.Format(sqliu, this.TableName, (this.IsNew ? String.Join(",", _columns) : vvalues), (this.IsNew ? vvalues : String.Format("dni = {0}", this.Dni)));
            }
        }

        public void setKeyValue(object valueId)
        {
            throw new NotImplementedException();
        }

        public string sqlKeyWhere(params object[] values)
        {
            return String.Format("dni = {0}", values[0]);
        }        
    }
}
