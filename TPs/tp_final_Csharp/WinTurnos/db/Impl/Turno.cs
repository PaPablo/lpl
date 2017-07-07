using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class Turno : CommonObj, IAccessDB<Turno>, ITable
    {
        private string[] _columns = { "fechahora","dnipaciente","codigoprofesional","asistio"};
        public List<Turno> findAll()
        {
            return this.findAll(null);
        }
        public List<Turno> findAll(string criterio)
        {
            return ManagerDB<Turno>.findAll(criterio);
        }
        public Turno findbykey(params object[] key)
        {
            Turno d = (Turno)ManagerDB<Turno>.findbyKey(key);
            this.FechaHora = d.FechaHora;
            this.DniPaciente = d.DniPaciente;
			this.CodigoProfesional = d.CodigoProfesional;
            this.IsNew = false;
            return this;
        }
        public bool saveObj()
        {
            return ManagerDB<Turno>.saveObject(this);
        }

        public string TableName
        {
            get { return "turnos"; }
        }

        public string KeyTable
        {
            get { return ""; }
        }

        public void initialize(System.Data.DataRow dr)
        {
            this._fechahora = Convert.ToDateTime(dr[_columns[0]].ToString());
            this._dnipaciente =  Int32.Parse(dr[_columns[1]].ToString());
			this._codigoprofesional =  Int32.Parse(dr[_columns[2]].ToString());
			this._asistio = dr[_columns[3]].ToString() == "1" ? true : false;
			this.IsNew = false;
        }
        public string[] columns
        {
            get { return _columns; }
        }
        private string[] list_values()
        {
            // "codigo","nombre"
            string[] values = { (this.IsNew?"":_columns[0] + "=")+String.Format("'{0}'",this._fechahora.ToString("yyyy-MM-dd HH:mm")),
                                (this.IsNew?"":_columns[1] + "=")+this._dnipaciente.ToString(),
								(this.IsNew?"":_columns[2] + "=")+this._codigoprofesional.ToString(),
								(this.IsNew?"":_columns[3] + "=")+(this.Asistio.ToString().ToLower() =="true"?1:0)
                              };
            return values;
        }

        public string SqlString
        {
            get
            {
                string vvalues = String.Join(",", this.list_values());
                string sqliu = (this.IsNew ? "insert into {0} ({1}) values ({2})" : "update  {0} set {1} where {2}");
                return String.Format(sqliu, this.TableName, (this.IsNew ? String.Join(",", _columns) : vvalues), (this.IsNew ? vvalues : String.Format("fechaHora = '{0}' and dnipaciente ={1} and codigoprofesional = {2}", this._fechahora.ToString("yyyy-MM-dd HH:mm").Replace(":00", ""), this.DniPaciente, this.CodigoProfesional)));
            }
        }
        // propiedad seteada por implementar IAutoIncrement
        public void setKeyValue(object valueId)
        {
            //
        }
        
        public string sqlKeyWhere(params object[] values)
        {
            return String.Format(" to_char(fechaHora, 'YYYY-MM-DD')= = '{0}' and dnipaciente ={1} and codigoprofesional = {2}", this._fechahora, this.DniPaciente, this.CodigoProfesional);
        }
    }
}

