#include "config.h"
#include "utils.h"
#include <string.h>
extern PGconn *conn; //Instancia que permite manipular conexion con el servidor
//----------------------------------------------------
void fillProfesionalFromDB(void **rw , int rowi,PGresult *res)
{
    t_data_set_profesional *dsprofesional;
    dsprofesional = &(( (t_data_set_profesional *) *rw)[rowi]);
    //leer valor desde estructura obtenida de la BD
	dsprofesional->id=atoi(PQgetvalue(res,rowi,0));
    strcpy( dsprofesional->matricula ,rtrim(PQgetvalue(res,rowi,1),' '));
    strcpy( dsprofesional->nombres,rtrim(PQgetvalue(res,rowi,2),' '));
    strcpy( dsprofesional->apellido ,rtrim(PQgetvalue(res,rowi,3),' '));
    strcpy( dsprofesional->telefono ,rtrim(PQgetvalue(res,rowi,4),' '));
	strcpy( dsprofesional->fecha_matricula ,rtrim(PQgetvalue(res,rowi,5),' '));
    dsprofesional->activo=atoi(PQgetvalue(res,rowi,6));
}       
//----------------------------------------------------
void fillObjProfesional(obj_profesional *p,  t_data_set_profesional rwitm)
{  
      p->id = rwitm.id;
      strcpy( p->matricula,rwitm.matricula);
	  strcpy( p->nombres,rwitm.nombres);
      strcpy( p->apellido,rwitm.apellido);
      strcpy( p->telefono,rwitm.telefono);
	  strcpy( p->fecha_matricula,rwitm.fecha_matricula);
      strcpy( p->telefono,rwitm.telefono);
      p->activo = rwitm.activo;
}
//----------------------------------------------------
void fillRowsProfesional(void **list, int size,void *data)
{
     int i;
     obj_profesional *d;
    *list = (obj_profesional **)malloc(sizeof(obj_profesional*)* size);
    for(i=0;i<size;++i)
    {
      d = profesional_new();
      fillObjProfesional(d,((t_data_set_profesional *)data)[i]);
      ((obj_profesional **)*list)[i] = d;
    }
 }
//----------------------------------------------------
int exec_get_profesional(char *sql,void **rw)
{
    return exec_get_fromDB(sql,rw,t_profesional,fillProfesionalFromDB);
}
//----------------------------------------------------
void fill_dataset_profesional(data_set *ds,void *data, int sz)
{
 int i;
 ds->rows = malloc(size_st[t_profesional]* sz);
 ds->cntRows=sz;
     for(i=0;i<sz;++i)
     { 
      ((t_data_set_profesional *)ds->rows)[i].id =((t_data_set_profesional *)data)[i].id;
	  strcpy( ((t_data_set_profesional *)ds->rows)[i].matricula,((t_data_set_profesional *)data)[i].matricula);
      strcpy( ((t_data_set_profesional *)ds->rows)[i].nombres,((t_data_set_profesional *)data)[i].nombres);
      strcpy( ((t_data_set_profesional *)ds->rows)[i].apellido,((t_data_set_profesional *)data)[i].apellido);
      strcpy( ((t_data_set_profesional *)ds->rows)[i].telefono,((t_data_set_profesional *)data)[i].telefono);
	  strcpy( ((t_data_set_profesional *)ds->rows)[i].fecha_matricula,((t_data_set_profesional *)data)[i].fecha_matricula);
      ((t_data_set_profesional *)ds->rows)[i].activo =((t_data_set_profesional *)data)[i].activo;
     }
}
//----------------------------------------------------
int findAll_profesionalImpl(void *self,void **list, char *criteria)
{
  return findAllImpl(self,list, criteria,t_profesional, ((data_set_profesional*)((obj_profesional*)self)->ds)->rows,fillProfesionalFromDB,fillRowsProfesional);
}
//----------------------------------------------------
// implementacion de metodos para profesional
int find_profesionalImpl(void *self, char *k)
{
  int size=0;
  void *data;  
  obj_profesional *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "matricula = '%s'",k);
   sql =getFindSQL(t_profesional, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_profesional*)((obj_profesional*)self)->ds)->rows;
 size = exec_get_profesional(sql,&data);
 fill_dataset_profesional(((obj_profesional*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_profesional*)self;
   fillObjProfesional(p,((t_data_set_profesional *)data)[0]);
 }
 else
   size = -1;   
 return size;
}
int findById_profesionalImpl(void *self, int k)
{
	int size=0;
  void *data;  
  obj_profesional *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "id = %d",k);
   sql =getFindSQL(t_profesional, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_profesional*)((obj_profesional*)self)->ds)->rows;
 size = exec_get_profesional(sql,&data);
 fill_dataset_profesional(((obj_profesional*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_profesional*)self;
   fillObjProfesional(p,((t_data_set_profesional *)data)[0]);
 }
 else
   size = -1;   
 return size;
}
//----------------------------------------------------
int saveObj_profesionalImpl(void *self, int id,char *matricula, char *fechamatricula,char *nombres,char *apellido,char *telefono, int activo, int isNew)
{
  PGresult *res; 
  int code=0;
  char values[MAX_WHERE_SQL];  
  char where[MAX_WHERE_SQL];  
  char *sql;
  void *data;
  char *fecha_alta;
  obj_profesional *o;
  
  data = ((data_set_profesional*)((obj_profesional*)self)->ds)->rows;
  if(isNew)
  {// insert
    sprintf(values,sql_insert_param_str[t_profesional] , matricula,fechamatricula,nombres, apellido, telefono, activo);
    sql = (char*)malloc(sizeof(char)*MAX_SQL);
    snprintf( sql, MAX_SQL, sql_insert_str[t_profesional],values);    
    res = PQexec(conn, sql);
    code = PQresultStatus(res);
    PQclear(res);
    // obtener fecha actual
    fecha_alta = getFecha();    
  }
  else
  {// update
      o = (obj_profesional *)self;
      strcpy(fechamatricula,o->fecha_matricula);
      sprintf(where,"id =%d ",id);
      sprintf(values, sql_update_param_str[t_profesional] , matricula,fechamatricula,nombres, apellido, telefono, activo);
      sql = (char*)malloc(sizeof(char)*MAX_SQL);
      snprintf( sql, MAX_SQL, sql_update_str[t_profesional],values,where);
      
      res = PQexec(conn, sql) ;
      code = PQresultStatus(res);
      PQclear(res);
  }
  if ( code != PGRES_COMMAND_OK)       
       return 0;
    else
    {
       strcpy(((obj_profesional*)self)->matricula,matricula);
       strcpy(((obj_profesional*)self)->fecha_matricula,fechamatricula);
	   strcpy(((obj_profesional*)self)->nombres,nombres);
       strcpy(((obj_profesional*)self)->apellido,apellido);
       strcpy(((obj_profesional*)self)->telefono,telefono);
       ((obj_profesional*)self)->activo= activo;
       return 1;    
    }   
}
//----------------------------------------------------
void *init_profesional(void *self, data_set *ds)
{
  obj_profesional *obj;
  obj = (obj_profesional *)self;
  obj->ds = ds;
  obj->findbykey = find_profesionalImpl;
  obj->findAll = findAll_profesionalImpl;
  obj->saveObj = saveObj_profesionalImpl;
  obj->findbyid= findById_profesionalImpl;
  return obj;
}
//----------------------------------------------------
obj_profesional *profesional_new()
{
  return (obj_profesional *)init_obj(t_profesional, col_profesional, init_profesional);
}
