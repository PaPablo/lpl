#include "config.h"
#include "utils.h"
#include <string.h>
extern PGconn *conn; //Instancia que permite manipular conexion con el servidor
//----------------------------------------------------
void fillEspecialidadFromDB(void **rw , int rowi,PGresult *res)
{
    t_data_set_especialidad *dsespecialidad;
    dsespecialidad = &(( (t_data_set_especialidad *) *rw)[rowi]);
    //leer valor desde estructura obtenida de la BD
	dsespecialidad->codigo=atoi(PQgetvalue(res,rowi,0));
    strcpy( dsespecialidad->nombre ,rtrim(PQgetvalue(res,rowi,1),' '));
}       
//----------------------------------------------------
void fillObjEspecialidad(obj_especialidad *p,  t_data_set_especialidad rwitm)
{  
      p->codigo = rwitm.codigo;
	  strcpy( p->nombre,rwitm.nombre);
}
//----------------------------------------------------
void fillRowsEspecialidad(void **list, int size,void *data)
{
     int i;
     obj_especialidad *d;
    *list = (obj_especialidad **)malloc(sizeof(obj_especialidad*)* size);
    for(i=0;i<size;++i)
    {
      d = especialidad_new();
      fillObjEspecialidad(d,((t_data_set_especialidad *)data)[i]);
      ((obj_especialidad **)*list)[i] = d;
    }
 }
//----------------------------------------------------
int exec_get_especialidad(char *sql,void **rw)
{
    return exec_get_fromDB(sql,rw,t_especialidad,fillEspecialidadFromDB);
}
//----------------------------------------------------
void fill_dataset_especialidad(data_set *ds,void *data, int sz)
{
 int i;
 ds->rows = malloc(size_st[t_especialidad]* sz);
 ds->cntRows=sz;
     for(i=0;i<sz;++i)
     {
      ((t_data_set_especialidad *)ds->rows)[i].codigo =((t_data_set_especialidad *)data)[i].codigo;
      strcpy( ((t_data_set_especialidad *)ds->rows)[i].nombre,((t_data_set_especialidad *)data)[i].nombre);
     }
}
//----------------------------------------------------
int findAll_especialidadImpl(void *self,void **list, char *criteria)
{
  return findAllImpl(self,list, criteria,t_especialidad, ((data_set_especialidad*)((obj_especialidad*)self)->ds)->rows,fillEspecialidadFromDB,fillRowsEspecialidad);
}
//----------------------------------------------------
// implementacion de metodos para especialidad
int find_especialidadImpl(void *self, int k)
{
  int size=0;
  void *data;  
  obj_especialidad *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "codigo = %d",k);
   sql =getFindSQL(t_especialidad, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_especialidad*)((obj_especialidad*)self)->ds)->rows;
 size = exec_get_especialidad(sql,&data);
 fill_dataset_especialidad(((obj_especialidad*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_especialidad*)self;
   fillObjEspecialidad(p,((t_data_set_especialidad *)data)[0]);
 }
 else
   size = -1;   
 return size;
}
//----------------------------------------------------
int saveObj_especialidadImpl(void *self, int codigo,char *nombre, int isNew)
{
  PGresult *res; 
  int code=0;
  char values[MAX_WHERE_SQL];  
  char where[MAX_WHERE_SQL];  
  char *sql;
  void *data;
  obj_especialidad *o;
  
  data = ((data_set_especialidad*)((obj_especialidad*)self)->ds)->rows;
  if(isNew)
  {// insert
	/*
	sprintf(values,sql_insert_param_str[t_dieta] , nombre);
    sql = (char*)malloc(sizeof(char)*MAX_SQL);
    snprintf( sql, MAX_SQL, sql_insert_str[t_dieta],values);    
    res = PQexec(conn, sql);
    code = PQresultStatus(res);
    PQclear(res);
	*/
     // obtener ultimo codigo autogenerado
    res = PQexec(conn, "select max(codigo) codigo from especialidades;");
    codigo = atoi(PQgetvalue(res,0,0));
    PQclear(res);

    sprintf(values,sql_insert_param_str[t_especialidad] , ++codigo, nombre);
    sql = (char*)malloc(sizeof(char)*MAX_SQL);
    snprintf( sql, MAX_SQL, sql_insert_str[t_especialidad],values);    
    res = PQexec(conn, sql);
    code = PQresultStatus(res);
    PQclear(res);
  }
  else
  {// update
      o = (obj_especialidad *)self;
      sprintf(where,"codigo =%d ",codigo);
      sprintf(values, sql_update_param_str[t_especialidad] ,nombre);
      sql = (char*)malloc(sizeof(char)*MAX_SQL);
      snprintf( sql, MAX_SQL, sql_update_str[t_especialidad],values,where);
      
      res = PQexec(conn, sql) ;
      code = PQresultStatus(res);
      PQclear(res);
  }
  if ( code != PGRES_COMMAND_OK)       
       return 0;
    else
    {
       ((obj_especialidad*)self)->codigo=codigo;
       strcpy(((obj_especialidad*)self)->nombre,nombre);
       return 1;    
    }   
}
//----------------------------------------------------
void *init_especialidad(void *self, data_set *ds)
{
  obj_especialidad *obj;
  obj = (obj_especialidad *)self;
  obj->ds = ds;
  obj->findbykey = find_especialidadImpl;
  obj->findAll = findAll_especialidadImpl;
  obj->saveObj = saveObj_especialidadImpl;
  //obj->findbyid= findById_especialidadImpl;
  return obj;
}
//----------------------------------------------------
obj_especialidad *especialidad_new()
{
  return (obj_especialidad *)init_obj(t_especialidad, col_especialidad, init_especialidad);
}
