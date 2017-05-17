#include "config.h"
#include "utils.h"
#include <string.h>
extern PGconn *conn; //Instancia que permite manipular conexion con el servidor
//----------------------------------------------------
void fillPacienteObSocFromDB(void **rw , int rowi,PGresult *res)
{
    t_data_set_paciente_obrasocial *dspaciente_obrasocial;
    dspaciente_obrasocial = &(( (t_data_set_paciente_obrasocial *) *rw)[rowi]);
    //leer valor desde estructura obtenida de la BD
	dspaciente_obrasocial->dnipaciente=atoi(PQgetvalue(res,rowi,0));
	dspaciente_obrasocial->codigoobrasocial=atoi(PQgetvalue(res,rowi,1));
    strcpy( dspaciente_obrasocial->fechadesde ,rtrim(PQgetvalue(res,rowi,2),' '));
}       
//----------------------------------------------------
void fillObjPacienteObSoc(obj_paciente_obrasocial *p,  t_data_set_paciente_obrasocial rwitm)
{  
      p->dnipaciente = rwitm.dnipaciente;
	  p->codigoobrasocial = rwitm.codigoobrasocial;
	  strcpy( p->fechadesde,rwitm.fechadesde);
}
//----------------------------------------------------
void fillRowsPacienteObSoc(void **list, int size,void *data)
{
     int i;
     obj_paciente_obrasocial *d;
    *list = (obj_paciente_obrasocial **)malloc(sizeof(obj_paciente_obrasocial*)* size);
    for(i=0;i<size;++i)
    {
      d = paciente_obrasocial_new();
      fillObjPacienteObSoc(d,((t_data_set_paciente_obrasocial *)data)[i]);
      ((obj_paciente_obrasocial **)*list)[i] = d;
    }
 }
//----------------------------------------------------
int exec_get_paciente_obrasocial(char *sql,void **rw)
{
    return exec_get_fromDB(sql,rw,t_paciente_obrasocial,fillPacienteObSocFromDB);
}
//----------------------------------------------------
void fill_dataset_paciente_obrasocial(data_set *ds,void *data, int sz)
{
 int i;
 ds->rows = malloc(size_st[t_paciente_obrasocial]* sz);
 ds->cntRows=sz;
     for(i=0;i<sz;++i)
     {
      ((t_data_set_paciente_obrasocial *)ds->rows)[i].dnipaciente =((t_data_set_paciente_obrasocial *)data)[i].dnipaciente;
	  ((t_data_set_paciente_obrasocial *)ds->rows)[i].codigoobrasocial =((t_data_set_paciente_obrasocial *)data)[i].codigoobrasocial;
      strcpy( ((t_data_set_paciente_obrasocial *)ds->rows)[i].fechadesde,((t_data_set_paciente_obrasocial *)data)[i].fechadesde);
     }
}
//----------------------------------------------------
int findAll_paciente_obrasocialImpl(void *self,void **list, char *criteria)
{
  return findAllImpl(self,list, criteria,t_paciente_obrasocial, ((data_set_paciente_obrasocial*)((obj_paciente_obrasocial*)self)->ds)->rows,fillPacienteObSocFromDB,fillRowsPacienteObSoc);
}
//----------------------------------------------------
// implementacion de metodos para paciente_obrasocial
int find_paciente_obrasocialImpl(void *self, int k,int k2)
{
  int size=0;
  void *data;  
  obj_paciente_obrasocial *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "dnipaciente = %d and codigoobrasocial=%d",k,k2);
   sql =getFindSQL(t_paciente_obrasocial, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_paciente_obrasocial*)((obj_paciente_obrasocial*)self)->ds)->rows;
 size = exec_get_paciente_obrasocial(sql,&data);
 fill_dataset_paciente_obrasocial(((obj_paciente_obrasocial*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_paciente_obrasocial*)self;
   fillObjPacienteObSoc(p,((t_data_set_paciente_obrasocial *)data)[0]);
 }
 else
   size = -1;   
 return size;
}
//----------------------------------------------------
int saveObj_paciente_obrasocialImpl(void *self, int dnipaciente,int codigoobrasocial,char *fechadesde, int isNew)
{
  PGresult *res; 
  int code=0;
  char values[MAX_WHERE_SQL];  
  char where[MAX_WHERE_SQL];  
  char *sql;
  void *data;
  obj_paciente_obrasocial *o;
  
  data = ((data_set_paciente_obrasocial*)((obj_paciente_obrasocial*)self)->ds)->rows;
  if(isNew)
  {// insert
	sprintf(values,sql_insert_param_str[t_paciente_obrasocial] , dnipaciente, codigoobrasocial);
    sql = (char*)malloc(sizeof(char)*MAX_SQL);
    snprintf( sql, MAX_SQL, sql_insert_str[t_paciente_obrasocial],values);    
    res = PQexec(conn, sql);
    code = PQresultStatus(res);
    PQclear(res);
  }
  else
  {// update
      o = (obj_paciente_obrasocial *)self;
      sprintf(where,"dnipaciente =%d and codigoobrasocial= %d",dnipaciente,codigoobrasocial);
      sprintf(values, sql_update_param_str[t_paciente_obrasocial] ,fechadesde);
      sql = (char*)malloc(sizeof(char)*MAX_SQL);
      snprintf( sql, MAX_SQL, sql_update_str[t_paciente_obrasocial],values,where);
      
      res = PQexec(conn, sql) ;
      code = PQresultStatus(res);
      PQclear(res);
  }
  if ( code != PGRES_COMMAND_OK)       
       return 0;
    else
    {
       ((obj_paciente_obrasocial*)self)->dnipaciente=dnipaciente;
	   ((obj_paciente_obrasocial*)self)->codigoobrasocial=codigoobrasocial;
       strcpy(((obj_paciente_obrasocial*)self)->fechadesde,fechadesde);
       return 1;    
    }   
}
//----------------------------------------------------
void *getPaciente_Paciente_ObraSocialImpl(void *self)
{
   obj_paciente_obrasocial* o;
   obj_paciente *p;
   o = (obj_paciente_obrasocial*) self;   
   p = paciente_new();
   p->findbykey(p,o->dnipaciente);     
   return p;
}
//implementación de getObraSocial_Paciente_ObraSocial
//
void *getObraSocial_Paciente_ObraSocialImpl(void *self){
    
    obj_paciente_obrasocial* o;
    obj_obrasocial *os;
    o = (obj_paciente_obrasocial*) self;
    os = obrasocial_new();
    os->findbykey(os,o->codigoobrasocial);
    return os;
}
//----------------------------------------------------
void *init_paciente_obrasocial(void *self, data_set *ds)
{
  obj_paciente_obrasocial *obj;
  obj = (obj_paciente_obrasocial *)self;
  obj->ds = ds;
  obj->findbykey = find_paciente_obrasocialImpl;
  obj->findAll = findAll_paciente_obrasocialImpl;
  obj->saveObj = saveObj_paciente_obrasocialImpl;
  obj->get_paciente = getPaciente_Paciente_ObraSocialImpl;
  //obj->findbyid= findById_paciente_obrasocialImpl;
  return obj;
}
//----------------------------------------------------
obj_paciente_obrasocial *paciente_obrasocial_new()
{
  return (obj_paciente_obrasocial *)init_obj(t_paciente_obrasocial, col_paciente_obrasocial, init_paciente_obrasocial);
}
