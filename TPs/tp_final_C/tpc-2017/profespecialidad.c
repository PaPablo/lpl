#include "config.h"
#include "utils.h"
#include <string.h>
extern PGconn *conn; //Instancia que permite manipular conexion con el servidor
//----------------------------------------------------
void fillProf_EspecialidadFromDB(void **rw , int rowi,PGresult *res)
{
    t_data_set_profesional_especialidad *dsprofesional_especialidad;
    dsprofesional_especialidad = &(( (t_data_set_profesional_especialidad *) *rw)[rowi]);
    //leer valor desde estructura obtenida de la BD
	dsprofesional_especialidad->codigoprofesional=atoi(PQgetvalue(res,rowi,0));
	dsprofesional_especialidad->codigoespecialidad=atoi(PQgetvalue(res,rowi,1));
    strcpy( dsprofesional_especialidad->fechaalta ,rtrim(PQgetvalue(res,rowi,2),' '));
    //codigoprofesional,codigoespecialidad,fechaalta,disponible,observaciones 
    dsprofesional_especialidad->disponible=atoi(PQgetvalue(res,rowi,3));
    strcpy( dsprofesional_especialidad->observaciones ,rtrim(PQgetvalue(res,rowi,4),' '));
}       
//----------------------------------------------------
void fillObjProf_Especialidad(obj_profesional_especialidad *p,  t_data_set_profesional_especialidad rwitm)
{  
      p->codigoprofesional = rwitm.codigoprofesional;
	  p->codigoespecialidad = rwitm.codigoespecialidad;
	  strcpy( p->fechaalta,rwitm.fechaalta);
	  p->disponible = rwitm.disponible;
	  strcpy( p->observaciones,rwitm.observaciones);
}
//----------------------------------------------------
void fillRowsProf_Especialidad(void **list, int size,void *data)
{
     int i;
     obj_profesional_especialidad *d;
    *list = (obj_profesional_especialidad **)malloc(sizeof(obj_profesional_especialidad*)* size);
    for(i=0;i<size;++i)
    {
      d = profesional_especialidad_new();
      fillObjProf_Especialidad(d,((t_data_set_profesional_especialidad *)data)[i]);
      ((obj_profesional_especialidad **)*list)[i] = d;
    }
 }
//----------------------------------------------------
int exec_get_profesional_especialidad(char *sql,void **rw)
{
    return exec_get_fromDB(sql,rw,t_profesional_especialidad,fillProf_EspecialidadFromDB);
}
//----------------------------------------------------
void fill_dataset_profesional_especialidad(data_set *ds,void *data, int sz)
{
 int i;
 ds->rows = malloc(size_st[t_profesional_especialidad]* sz);
 ds->cntRows=sz;
     for(i=0;i<sz;++i)
     {
      ((t_data_set_profesional_especialidad *)ds->rows)[i].codigoprofesional =((t_data_set_profesional_especialidad *)data)[i].codigoprofesional;
	  ((t_data_set_profesional_especialidad *)ds->rows)[i].codigoespecialidad =((t_data_set_profesional_especialidad *)data)[i].codigoespecialidad;
      strcpy( ((t_data_set_profesional_especialidad *)ds->rows)[i].fechaalta,((t_data_set_profesional_especialidad *)data)[i].fechaalta);
      ((t_data_set_profesional_especialidad *)ds->rows)[i].disponible =((t_data_set_profesional_especialidad *)data)[i].disponible;
      strcpy( ((t_data_set_profesional_especialidad *)ds->rows)[i].observaciones,((t_data_set_profesional_especialidad *)data)[i].observaciones);
     }
}
//----------------------------------------------------
int findAll_profesional_especialidadImpl(void *self,void **list, char *criteria)
{
  return findAllImpl(self,list, criteria,t_profesional_especialidad, ((data_set_profesional_especialidad*)((obj_profesional_especialidad*)self)->ds)->rows,fillProf_EspecialidadFromDB,fillRowsProf_Especialidad);
}
//----------------------------------------------------
// implementacion de metodos para profesional_especialidad
int find_profesional_especialidadImpl(void *self, int k,int k2)
{
  int size=0;
  void *data;  
  obj_profesional_especialidad *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "codigoprofesional = %d and codigoespecialidad=%d",k,k2);
   sql =getFindSQL(t_profesional_especialidad, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_profesional_especialidad*)((obj_profesional_especialidad*)self)->ds)->rows;
 size = exec_get_profesional_especialidad(sql,&data);
 fill_dataset_profesional_especialidad(((obj_profesional_especialidad*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_profesional_especialidad*)self;
   fillObjProf_Especialidad(p,((t_data_set_profesional_especialidad *)data)[0]);
 }
 else
   size = -1;   
 return size;
}
//----------------------------------------------------
int saveObj_profesional_especialidadImpl(void *self, int codigoprofesional, int codigoespecialidad, int disponible, char *observaciones,int isNew)
{
  PGresult *res; 
  int code=0;
  char values[MAX_WHERE_SQL];  
  char where[MAX_WHERE_SQL];  
  char *sql;
  void *data;
  obj_profesional_especialidad *o;
  
  data = ((data_set_profesional_especialidad*)((obj_profesional_especialidad*)self)->ds)->rows;
  if(isNew)
  {// insert
	sprintf(values,sql_insert_param_str[t_profesional_especialidad] , codigoprofesional, codigoespecialidad);
    sql = (char*)malloc(sizeof(char)*MAX_SQL);
    snprintf( sql, MAX_SQL, sql_insert_str[t_profesional_especialidad],values);    
    res = PQexec(conn, sql);
    code = PQresultStatus(res);
    PQclear(res);
  }
  else
  {// update
      o = (obj_profesional_especialidad *)self;
      sprintf(where,"codigoprofesional =%d and codigoespecialidad= %d",codigoprofesional,codigoespecialidad);
      sprintf(values, sql_update_param_str[t_profesional_especialidad] ,disponible,observaciones);
      sql = (char*)malloc(sizeof(char)*MAX_SQL);
      snprintf( sql, MAX_SQL, sql_update_str[t_profesional_especialidad],values,where);
      
      res = PQexec(conn, sql) ;
      code = PQresultStatus(res);
      PQclear(res);
  }
  if ( code != PGRES_COMMAND_OK)       
       return 0;
    else
    {
       ((obj_profesional_especialidad*)self)->codigoprofesional=codigoprofesional;
	   ((obj_profesional_especialidad*)self)->codigoespecialidad=codigoespecialidad;
       strcpy(((obj_profesional_especialidad*)self)->observaciones,observaciones);
       ((obj_profesional_especialidad*)self)->disponible=disponible;
       return 1;    
    }   
}
//----------------------------------------------------
void *getProfesional_Profesional_EspecialidadImpl(void *self)
{
   obj_profesional_especialidad* o;
   obj_profesional *p;
   o = (obj_profesional_especialidad*) self;   
   p = profesional_new();
   p->findbyid(p,o->codigoprofesional);     
   return p;
}
//----------------------------------------------------
void *getEspecialidad_Profesional_EspecialidadImpl(void *self)
{
   obj_profesional_especialidad* o;
   obj_especialidad *e;
   o = (obj_profesional_especialidad*) self;   
   e = especialidad_new();
   e->findbykey(e,o->codigoespecialidad);     
   return e;
}
//----------------------------------------------------
void *init_profesional_especialidad(void *self, data_set *ds)
{
  obj_profesional_especialidad *obj;
  obj = (obj_profesional_especialidad *)self;
  obj->ds = ds;
  obj->findbykey = find_profesional_especialidadImpl;
  obj->findAll = findAll_profesional_especialidadImpl;
  obj->saveObj = saveObj_profesional_especialidadImpl;
  obj->get_profesional = getProfesional_Profesional_EspecialidadImpl;
  obj->get_especialidad = getEspecialidad_Profesional_EspecialidadImpl;
  //obj->findbyid= findById_profesional_especialidadImpl;
  return obj;
}
//----------------------------------------------------
obj_profesional_especialidad *profesional_especialidad_new()
{
  return (obj_profesional_especialidad *)init_obj(t_profesional_especialidad, col_profesional_especialidad, init_profesional_especialidad);
}
