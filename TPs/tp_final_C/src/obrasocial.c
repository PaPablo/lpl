#include "config.h"
#include "utils.h"
#include <string.h>
extern PGconn *conn; //Instancia que permite manipular conexion con el servidor
//----------------------------------------------------
void fillObraSocialFromDB(void **rw , int rowi,PGresult *res)
{
    t_data_set_obrasocial *dsobrasocial;
    dsobrasocial = &(( (t_data_set_obrasocial *) *rw)[rowi]);
    //leer valor desde estructura obtenida de la BD
	dsobrasocial->codigo=atoi(PQgetvalue(res,rowi,0));
    strcpy( dsobrasocial->nombre ,rtrim(PQgetvalue(res,rowi,1),' '));
}       
//----------------------------------------------------
void fillObjObraSocial(obj_obrasocial *p,  t_data_set_obrasocial rwitm)
{  
      p->codigo = rwitm.codigo;
	  strcpy( p->nombre,rwitm.nombre);
}
//----------------------------------------------------
void fillRowsObraSocial(void **list, int size,void *data)
{
     int i;
     obj_obrasocial *d;
    *list = (obj_obrasocial **)malloc(sizeof(obj_obrasocial*)* size);
    for(i=0;i<size;++i)
    {
      d = obrasocial_new();
      fillObjObraSocial(d,((t_data_set_obrasocial *)data)[i]);
      ((obj_obrasocial **)*list)[i] = d;
    }
 }
//----------------------------------------------------
int exec_get_obrasocial(char *sql,void **rw)
{
    return exec_get_fromDB(sql,rw,t_obrasocial,fillObraSocialFromDB);
}
//----------------------------------------------------
void fill_dataset_obrasocial(data_set *ds,void *data, int sz)
{
 int i;
 ds->rows = malloc(size_st[t_obrasocial]* sz);
 ds->cntRows=sz;
     for(i=0;i<sz;++i)
     {
      ((t_data_set_obrasocial *)ds->rows)[i].codigo =((t_data_set_obrasocial *)data)[i].codigo;
      strcpy( ((t_data_set_obrasocial *)ds->rows)[i].nombre,((t_data_set_obrasocial *)data)[i].nombre);
     }
}
//----------------------------------------------------
int findAll_obrasocialImpl(void *self,void **list, char *criteria)
{
  return findAllImpl(self,list, criteria,t_obrasocial, ((data_set_obrasocial*)((obj_obrasocial*)self)->ds)->rows,fillObraSocialFromDB,fillRowsObraSocial);
}
//----------------------------------------------------
// implementacion de metodos para obrasocial
int find_obrasocialImpl(void *self, int k)
{
  int size=0;
  void *data;  
  obj_obrasocial *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "codigo = %d",k);
   sql =getFindSQL(t_obrasocial, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_obrasocial*)((obj_obrasocial*)self)->ds)->rows;
 size = exec_get_obrasocial(sql,&data);
 fill_dataset_obrasocial(((obj_obrasocial*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_obrasocial*)self;
   fillObjObraSocial(p,((t_data_set_obrasocial *)data)[0]);
 }
 else
   size = -1;   
 return size;
}
//----------------------------------------------------
int saveObj_obrasocialImpl(void *self, int codigo,char *nombre, int isNew)
{
  PGresult *res; 
  int code=0;
  char values[MAX_WHERE_SQL];  
  char where[MAX_WHERE_SQL];  
  char *sql;
  void *data;
  obj_obrasocial *o;
  
  data = ((data_set_obrasocial*)((obj_obrasocial*)self)->ds)->rows;
  if(isNew)
  {// insert
     // obtener ultimo codigo autogenerado
    res = PQexec(conn, "select max(codigo) codigo from obrasociales;");
    codigo = atoi(PQgetvalue(res,0,0));
    PQclear(res);

    sprintf(values,sql_insert_param_str[t_obrasocial] , ++codigo, nombre);
    sql = (char*)malloc(sizeof(char)*MAX_SQL);
    snprintf( sql, MAX_SQL, sql_insert_str[t_obrasocial],values);    
    res = PQexec(conn, sql);
    code = PQresultStatus(res);
    PQclear(res);
  }
  else
  {// update
      o = (obj_obrasocial *)self;
      sprintf(where,"codigo =%d ",codigo);
      sprintf(values, sql_update_param_str[t_obrasocial] , codigo,nombre);
      sql = (char*)malloc(sizeof(char)*MAX_SQL);
      snprintf( sql, MAX_SQL, sql_update_str[t_obrasocial],values,where);
      
      res = PQexec(conn, sql) ;
      code = PQresultStatus(res);
      PQclear(res);
  }
  if ( code != PGRES_COMMAND_OK)       
       return 0;
    else
    {
       ((obj_obrasocial*)self)->codigo=codigo;
	   strcpy(((obj_obrasocial*)self)->nombre,nombre);
       return 1;    
    }   
}
//----------------------------------------------------
void *init_obrasocial(void *self, data_set *ds)
{
  obj_obrasocial *obj;
  obj = (obj_obrasocial *)self;
  obj->ds = ds;
  obj->findbykey = find_obrasocialImpl;
  obj->findAll = findAll_obrasocialImpl;
  obj->saveObj = saveObj_obrasocialImpl;
  return obj;
}
//----------------------------------------------------
obj_obrasocial *obrasocial_new()
{
  return (obj_obrasocial *)init_obj(t_obrasocial, col_obrasocial, init_obrasocial);
}
