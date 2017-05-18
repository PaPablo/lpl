#include "config.h"
#include "utils.h"
#include <string.h>
extern PGconn *conn; //Instancia que permite manipular conexion con el servidor
//----------------------------------------------------
void fillTurnosFromDB(void **rw , int rowi,PGresult *res)
{
    t_data_set_turnos *dsturnos;
    dsturnos = &(( (t_data_set_turnos *) *rw)[rowi]);
    //leer valor desde estructura obtenida de la BD
	dsturnos->dnipaciente=atol(PQgetvalue(res,rowi,0));
	dsturnos->codigoprofesional=atoi(PQgetvalue(res,rowi,1));
	dsturnos->asistio=atoi(PQgetvalue(res,rowi,2));
	strcpy( dsturnos->fechahora ,rtrim(PQgetvalue(res,rowi,3),' '));
}       
//----------------------------------------------------
void fillObjTurnos(obj_turnos *p,  t_data_set_turnos rwitm)
{  
      p->dnipaciente = rwitm.dnipaciente;
	  p->codigoprofesional = rwitm.codigoprofesional;
	  strcpy( p->fechahora,rwitm.fechahora);
	  p->asistio = rwitm.asistio;
}
//----------------------------------------------------
void fillRowsTurnos(void **list, int size,void *data)
{
     int i;
     obj_turnos *d;
    *list = (obj_turnos **)malloc(sizeof(obj_turnos*)* size);
    for(i=0;i<size;++i)
    {
      d = turnos_new();
      fillObjTurnos(d,((t_data_set_turnos *)data)[i]);
      ((obj_turnos **)*list)[i] = d;
    }
 }
//----------------------------------------------------
int exec_get_turnos(char *sql,void **rw)
{
    return exec_get_fromDB(sql,rw,t_turnos,fillTurnosFromDB);
}
//----------------------------------------------------
void fill_dataset_turnos(data_set *ds,void *data, int sz)
{
 int i;
 ds->rows = malloc(size_st[t_turnos]* sz);
 ds->cntRows=sz;
     for(i=0;i<sz;++i)
     {
      ((t_data_set_turnos *)ds->rows)[i].dnipaciente =((t_data_set_turnos *)data)[i].dnipaciente;
	  ((t_data_set_turnos *)ds->rows)[i].codigoprofesional =((t_data_set_turnos *)data)[i].codigoprofesional;
      strcpy( ((t_data_set_turnos *)ds->rows)[i].fechahora,((t_data_set_turnos *)data)[i].fechahora);
      ((t_data_set_turnos *)ds->rows)[i].asistio =((t_data_set_turnos *)data)[i].asistio;
     }
}
//----------------------------------------------------
int findAll_turnosImpl(void *self,void **list, char *criteria)
{
  return findAllImpl(self,list, criteria,t_turnos, ((data_set_turnos*)((obj_turnos*)self)->ds)->rows,fillTurnosFromDB,fillRowsTurnos);
}
//----------------------------------------------------
int find_turnosFechaHHMMImpl(void *self,char *fecha,int hh,int mm)
{
  int size=0;
  void *data;  
  obj_turnos *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "fechahora::date = '%s' and date_trunc('minute',fechahora)::time ='%02d:%02d:00'",fecha,hh,mm);   
   sql =getFindSQL(t_turnos, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_turnos*)((obj_turnos*)self)->ds)->rows;
 size = exec_get_turnos(sql,&data);
 fill_dataset_turnos(((obj_turnos*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_turnos*)self;
   fillObjTurnos(p,((t_data_set_turnos *)data)[0]);
 }
 else
   size = -1;   
 return size;
}
int find_turnosFechaImpl(void *self,char *fecha)
{
  int size=0;
  void *data;  
  obj_turnos *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "fechahora::date = '%s'",fecha);
   sql =getFindSQL(t_turnos, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_turnos*)((obj_turnos*)self)->ds)->rows;
 size = exec_get_turnos(sql,&data);
 fill_dataset_turnos(((obj_turnos*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_turnos*)self;
   fillObjTurnos(p,((t_data_set_turnos *)data)[0]);
 }
 else
   size = -1;   
 return size;
}
//----------------------------------------------------
// implementacion de metodos para turnos
int find_turnosImpl(void *self,char *jk, int k,int k2)
{
  int size=0;
  void *data;  
  obj_turnos *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "fechahora = '%s' and dnipaciente = %d and codigoprofesional=%d",jk,k,k2);
   sql =getFindSQL(t_turnos, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_turnos*)((obj_turnos*)self)->ds)->rows;
 size = exec_get_turnos(sql,&data);
 fill_dataset_turnos(((obj_turnos*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_turnos*)self;
   fillObjTurnos(p,((t_data_set_turnos *)data)[0]);
 }
 else
   size = -1;   
 return size;
}
//----------------------------------------------------
int saveObj_turnosImpl(void *self, int dnipaciente, int codigoprofesional, int asistio,int isNew)
{
  PGresult *res; 
  int code=0;
  char values[MAX_WHERE_SQL];  
  char where[MAX_WHERE_SQL];  
  char *sql;
  void *data;
  obj_turnos *o;
  
  data = ((data_set_turnos*)((obj_turnos*)self)->ds)->rows;
  if(isNew)
  {// insert
	sprintf(values,sql_insert_param_str[t_turnos] , dnipaciente, codigoprofesional);
    sql = (char*)malloc(sizeof(char)*MAX_SQL);
    snprintf( sql, MAX_SQL, sql_insert_str[t_turnos],values);    
    res = PQexec(conn, sql);
    code = PQresultStatus(res);
    PQclear(res);
  }
  else
  {// update
      o = (obj_turnos *)self;
      sprintf(where,"dnipaciente =%d and codigoprofesional= %d",dnipaciente,codigoprofesional);
      sprintf(values, sql_update_param_str[t_turnos] ,asistio);
      sql = (char*)malloc(sizeof(char)*MAX_SQL);
      snprintf( sql, MAX_SQL, sql_update_str[t_turnos],values,where);
      
      res = PQexec(conn, sql) ;
      code = PQresultStatus(res);
      PQclear(res);
  }
  if ( code != PGRES_COMMAND_OK)       
       return 0;
    else
    {
       ((obj_turnos*)self)->dnipaciente=dnipaciente;
	   ((obj_turnos*)self)->codigoprofesional=codigoprofesional;
       ((obj_turnos*)self)->asistio=asistio;
       return 1;    
    }   
}
//----------------------------------------------------
void *getPaciente_TurnosImpl(void *self)
{
   obj_turnos* o;
   obj_paciente *p;
   o = (obj_turnos*) self;   
   p = paciente_new();
   p->findbykey(p, o->dnipaciente);
   return p;
}
//----------------------------------------------------
void *getProfesional_TurnosImpl(void *self)
{
   obj_turnos* o;
   obj_profesional *p;
   o = (obj_turnos*) self;   
   p = profesional_new();
   p->findbyid(p,o->codigoprofesional);     
   return p;
}
//----------------------------------------------------
void *init_turnos(void *self, data_set *ds)
{
  obj_turnos *obj;
  obj = (obj_turnos *)self;
  obj->ds = ds;
  obj->findbykey = find_turnosImpl;  
  obj->findAll = findAll_turnosImpl;
  obj->saveObj = saveObj_turnosImpl;
  //busca el primero con una fecha dada
  obj->findbyfecha = find_turnosFechaImpl;
  //busca el primero con una fecha / hora/ min dada
  obj->findbyfechahhmm = find_turnosFechaHHMMImpl;  
  obj->get_paciente = getPaciente_TurnosImpl;
  obj->get_profesional = getProfesional_TurnosImpl;
  //obj->findbyid= findById_turnosImpl;
  return obj;
}
//----------------------------------------------------
obj_turnos *turnos_new()
{
  return (obj_turnos *)init_obj(t_turnos, col_turnos, init_turnos);
}
