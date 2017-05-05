#include "config.h"
#include "utils.h"
#include <string.h>
extern PGconn *conn; //Instancia que permite manipular conexion con el servidor
//----------------------------------------------------
void fillPacienteFromDB(void **rw , int rowi,PGresult *res)
{
    t_data_set_paciente *dspaciente;
    dspaciente = &(( (t_data_set_paciente *) *rw)[rowi]);
    //leer valor desde estructura obtenida de la BD
	dspaciente->dni=atoi(PQgetvalue(res,rowi,0));
    strcpy( dspaciente->nombres ,rtrim(PQgetvalue(res,rowi,1),' '));
    strcpy( dspaciente->apellido,rtrim(PQgetvalue(res,rowi,2),' '));
    strcpy( dspaciente->domicilio ,rtrim(PQgetvalue(res,rowi,3),' '));
    strcpy( dspaciente->telefono ,rtrim(PQgetvalue(res,rowi,4),' '));
}       
//----------------------------------------------------
void fillObjPaciente(obj_paciente *p,  t_data_set_paciente rwitm)
{  
      p->dni = rwitm.dni;
      strcpy( p->apellido,rwitm.apellido);
	  strcpy( p->nombres,rwitm.nombres);
      strcpy( p->domicilio,rwitm.domicilio);
      strcpy( p->telefono,rwitm.telefono);
}
//----------------------------------------------------
void fillRowsPaciente(void **list, int size,void *data)
{
     int i;
     obj_paciente *d;
    *list = (obj_paciente **)malloc(sizeof(obj_paciente*)* size);
    for(i=0;i<size;++i)
    {
      d = paciente_new();
      fillObjPaciente(d,((t_data_set_paciente *)data)[i]);
      ((obj_paciente **)*list)[i] = d;
    }
 }
//----------------------------------------------------
int exec_get_paciente(char *sql,void **rw)
{
    return exec_get_fromDB(sql,rw,t_paciente,fillPacienteFromDB);
}
//----------------------------------------------------
void fill_dataset_paciente(data_set *ds,void *data, int sz)
{
 int i;
 ds->rows = malloc(size_st[t_paciente]* sz);
 ds->cntRows=sz;
     for(i=0;i<sz;++i)
     {
      ((t_data_set_paciente *)ds->rows)[i].dni =((t_data_set_paciente *)data)[i].dni;
	  strcpy( ((t_data_set_paciente *)ds->rows)[i].apellido,((t_data_set_paciente *)data)[i].apellido);
      strcpy( ((t_data_set_paciente *)ds->rows)[i].nombres,((t_data_set_paciente *)data)[i].nombres);
      strcpy( ((t_data_set_paciente *)ds->rows)[i].domicilio,((t_data_set_paciente *)data)[i].domicilio);
      strcpy( ((t_data_set_paciente *)ds->rows)[i].telefono,((t_data_set_paciente *)data)[i].telefono);
     }
}
//----------------------------------------------------
int findAll_pacienteImpl(void *self,void **list, char *criteria)
{
  return findAllImpl(self,list, criteria,t_paciente, ((data_set_paciente*)((obj_paciente*)self)->ds)->rows,fillPacienteFromDB,fillRowsPaciente);
}
//----------------------------------------------------
// implementacion de metodos para paciente
int find_pacienteImpl(void *self, int k)
{
  int size=0;
  void *data;  
  obj_paciente *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "dni = %d",k);
   sql =getFindSQL(t_paciente, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_paciente*)((obj_paciente*)self)->ds)->rows;
 size = exec_get_paciente(sql,&data);
 fill_dataset_paciente(((obj_paciente*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_paciente*)self;
   fillObjPaciente(p,((t_data_set_paciente *)data)[0]);
 }
 else
   size = -1;   
 return size;
}
int findById_pacienteImpl(void *self, int k)
{
	int size=0;
  void *data;  
  obj_paciente *p;
  char *where;
  char *sql, *str_where=NULL;
   where = (char*)malloc(sizeof(char)*MAX_SQL);
   sql = (char*)malloc(sizeof(char)*MAX_SQL);
   snprintf( where, MAX_SQL, "id = %d",k);
   sql =getFindSQL(t_paciente, where);
 //ejecutar consulta sql de seleccion, con criterio where
 data = ((data_set_paciente*)((obj_paciente*)self)->ds)->rows;
 size = exec_get_paciente(sql,&data);
 fill_dataset_paciente(((obj_paciente*)self)->ds,data,size);
 // setear datos a la instancia....
 if(size>0)
 {
   p = (obj_paciente*)self;
   fillObjPaciente(p,((t_data_set_paciente *)data)[0]);
 }
 else
   size = -1;   
 return size;
}	
//----------------------------------------------------
int saveObj_pacienteImpl(void *self, int dni,char *apellido,char *nombres,char *domicilio,char *telefono, int isNew)
{
  PGresult *res; 
  int code=0;
  char values[MAX_WHERE_SQL];  
  char where[MAX_WHERE_SQL];  
  char *sql;
  void *data;
  char *fecha_alta;
  obj_paciente *o;
  
  data = ((data_set_paciente*)((obj_paciente*)self)->ds)->rows;
  if(isNew)
  {// insert
    sprintf(values,sql_insert_param_str[t_paciente] , dni,apellido,nombres, domicilio, telefono);
    sql = (char*)malloc(sizeof(char)*MAX_SQL);
    snprintf( sql, MAX_SQL, sql_insert_str[t_paciente],values);    
    res = PQexec(conn, sql);
    code = PQresultStatus(res);
    PQclear(res);
    // obtener fecha actual
    fecha_alta = getFecha();    
  }
  else
  {// update
      o = (obj_paciente *)self;
      sprintf(where,"dni =%d ",dni);
      sprintf(values, sql_update_param_str[t_paciente] , apellido,nombres, domicilio, telefono);
      sql = (char*)malloc(sizeof(char)*MAX_SQL);
      snprintf( sql, MAX_SQL, sql_update_str[t_paciente],values,where);
      
      res = PQexec(conn, sql) ;
      code = PQresultStatus(res);
      PQclear(res);
  }
  if ( code != PGRES_COMMAND_OK)       
       return 0;
    else
    {
       ((obj_paciente*)self)->dni=dni;
       strcpy(((obj_paciente*)self)->apellido,apellido);
	   strcpy(((obj_paciente*)self)->nombres,nombres);
       strcpy(((obj_paciente*)self)->domicilio,domicilio);
       strcpy(((obj_paciente*)self)->telefono,telefono);
       return 1;    
    }   
}
//----------------------------------------------------
void *init_paciente(void *self, data_set *ds)
{
  obj_paciente *obj;
  obj = (obj_paciente *)self;
  obj->ds = ds;
  obj->findbykey = find_pacienteImpl;
  obj->findAll = findAll_pacienteImpl;
  obj->saveObj = saveObj_pacienteImpl;
  //obj->findbyid= findById_pacienteImpl;
  return obj;
}
//----------------------------------------------------
obj_paciente *paciente_new()
{
  return (obj_paciente *)init_obj(t_paciente, col_paciente, init_paciente);
}
