using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibTurnos.db
{
    public partial class PacienteObraSocial : CommonObj, IAccessDB<PacienteObraSocial>, ITable
    {
        private string[] _columns = { "dnipaciente","codigoobrasocial","fechadesde" };
        public List<PacienteObraSocial> findAll()
        {
            return this.findAll(null);
        }
        public List<PacienteObraSocial> findAll(string criterio)
        {
            return ManagerDB<PacienteObraSocial>.findAll(criterio);
        }
        public PacienteObraSocial findbykey(params object[] key)
        {
            PacienteObraSocial pc =(PacienteObraSocial)ManagerDB<PacienteObraSocial>.findbyKey(key);
            this.DniPaciente = pc.DniPaciente;
            this.CodigoObraSocial = pc.CodigoObraSocial;
            this.FechaDesde = pc.FechaDesde;
            this.IsNew = false;
            return this;
        }
        public bool saveObj()
        {
            return ManagerDB<PacienteObraSocial>.saveObject(this);
        }

        public string TableName
        {
            get { return "pacienteobrasocial"; }
        }

        public string KeyTable
        {
            get { return "dniPaciente"; }
        }

        public void initialize(System.Data.DataRow dr)
        {
			// "dnipaciente","codigoobrasocial","fechadesde"
            this._dniPaciente = Int32.Parse(dr[_columns[0]].ToString());
			this._codigoObraSocial = Int32.Parse(dr[_columns[1]].ToString());
            this._fechadesde = DateTime.Parse(dr[_columns[2]].ToString());
            this.IsNew = false;
        }
        public string[] columns
        {
            get { return _columns; }
        }
        private string[] list_values()
        {
            // "dnipaciente","codigoobrasocial","fechadesde"
            string[] values = { (this.IsNew?"":_columns[0] + "=")+this._dniPaciente.ToString(),
								(this.IsNew?"":_columns[1] + "=")+this._codigoObraSocial.ToString(),
                                  (this.IsNew?"":_columns[2] + "=")+String.Format("'{0}'",this._fechadesde.ToString("yyyy-MM-dd"))//formato cadena '								
                              };
            return values;
        }

        public string SqlString
        {
            get
            {
                string vvalues = String.Join(",", this.list_values());
                string sqliu = (this.IsNew ? "insert into {0} ({1}) values ({2})" : "update  {0} set {1} where {2}");
                return String.Format(sqliu, this.TableName, (this.IsNew ? String.Join(",", _columns) : vvalues), (this.IsNew ? vvalues : String.Format("dnipaciente = {0} and  codigoobrasocial = {1} and to_char(fecha, 'YYYY-MM-DD')= '{2}'", this.DniPaciente, this.CodigoObraSocial, this.FechaDesde)));
            }
        }

        public void setKeyValue(object valueId)
        {
            throw new NotImplementedException();
        }

        public string sqlKeyWhere(params object[] values)
        {
            return String.Format("dnipaciente = {0} and  codigoobrasocial = {1} and to_char(fecha, 'YYYY-MM-DD')= '{2}'", this.DniPaciente, this.CodigoObraSocial, this.FechaDesde);
        }
    }
}
