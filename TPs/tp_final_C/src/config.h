#include <stdio.h>
#include <stdlib.h>
#include <libpq-fe.h> 
#ifndef __DEFOPTS__
#define __DEFOPTS__
enum t_bool{ false=0,true=1};

#define MAX 50
#define MAX1 15
#define MAX2 30
#define MAX3 90
#define MAX4 2
#define MAX5 150
#define MAXOBS 200
#define MAX_FECHA 50
#define CANT_TABLES 7
#define MAX_SQL 800
#define MAX_WHERE_SQL 600
//enumerado de los tipos
typedef enum {
t_paciente=0, 
t_obrasocial,
t_especialidad,
t_profesional, 
t_paciente_obrasocial, 
t_profesional_especialidad,
t_turnos
}tipos;
//----------------------------------------------------
// estructura para paciente
typedef struct {
		int dni;
        char nombres[MAX];
        char apellido[MAX];
        char domicilio[MAX];
		char telefono[MAX];
        } t_data_set_paciente;
//----------------------------------------------------
// estructura para obra social
typedef struct {
		int codigo; 
        char nombre[MAX];
        } t_data_set_obrasocial;
//----------------------------------------------------		
// estructura para especialidad
typedef struct {
		int codigo; 
        char nombre[MAX];
        } t_data_set_especialidad;
//----------------------------------------------------
// estructura para profesional
typedef struct {  
          int id;   
          char matricula[MAX1];
          char nombres[MAX];
          char apellido[MAX];
          char telefono[MAX];
          char fecha_matricula[MAX_FECHA];
		  int activo;
        } t_data_set_profesional;
//----------------------------------------------------  
// estructura para relacion paciente obra social
typedef struct {  
          int dnipaciente;
		  int codigoobrasocial;
		  char fechadesde[MAX_FECHA];
        } t_data_set_paciente_obrasocial;
//----------------------------------------------------  
// estructura para relacion profesional especialidad
typedef struct {  
          int codigoprofesional;
		  int codigoespecialidad;
		  char fechaalta[MAX_FECHA];
		  int disponible;
		  char observaciones[MAXOBS];
        } t_data_set_profesional_especialidad;
//----------------------------------------------------  
// estructura para turnos
typedef struct {  
          char fechahora[MAX_FECHA];
              long dnipaciente;
		  int codigoprofesional;
		  int asistio;
        } t_data_set_turnos;
//----------------------------------------------------
//  COLECCION DE COLUMNAS DE LOS OBJETOS
const char *col_paciente[]={"dni","nombres","apellido","domicilio","telefono"};
const char *col_obrasocial[]={"codigo","nombre"};
const char *col_especialidad[]={"codigo","nombre"};
const char *col_profesional[]={"id","matricula","fechamatricula","nombres","apellido","telefono"};
const char *col_paciente_obrasocial[]={"dnipaciente","codigoobrasocial","fechadesde"};
const char *col_profesional_especialidad[]={"codigoprofesional","codigoespecialidad","fechaalta","disponible","observaciones"};
const char *col_turnos[]={"fechahora","dnipaciente","codigoprofesional","asistio"};
 
//----------------------------------------------------
// instrucciones sql para interaccionar con la base de datos
// seleccion
char *sql_select_str[CANT_TABLES]={
     "select dni,nombres,apellido,domicilio,telefono from pacientes %s;",
     "select codigo,nombre from obrasociales %s;",
	 "select codigo,nombre from especialidades %s;",
     "select id,matricula,nombres,apellido,telefono,fechamatricula,activo from profesionales %s;",
     "select dnipaciente,codigoobrasocial,fechadesde from pacienteobrasocial %s;",
     "select codigoprofesional,codigoespecialidad,fechaalta,disponible,observaciones from profesionalespecialidad %s;",
     "select dnipaciente,codigoprofesional,asistio, fechahora from turnos %s;"};
//----------------------------------------------------
// parametros de insercion
char *sql_insert_param_str[CANT_TABLES]={
     "%d,'%s','%s','%s','%s'",   // insert paciente
     "%d,'%s'",  //insert obra social
     "%d,'%s'", // insert especialidad
     "'%s','%s','%s','%s','%s'", // insert profesional
     "%d,%d,date_trunc('second', now())", // insert pacienteobrasocial -ultima columna es fecha - hora actual desde la base de datos
     "%d,%d,date_trunc('second', now()),%d,'%s'", // insert profesionalespecialidad
     "'%s',%d,%d,%d" // insert turnos
     };
//----------------------------------------------------
// parametros de actualizacion
char *sql_update_param_str[CANT_TABLES]={
     "nombres = '%s', apellido ='%s', domicilio='%s', telefono='%s'", // campos actualizables de paciente
     "nombre = '%s'",// campos actualizables de obra social
     "nombre = '%s'", // campos actualizables de especialidad
     "matricula ='%s', fechamatricula='%s',nombres ='%s', apellido ='%s', telefono='%s'", // campos actualizables de profesional
     "", // campos actualizables de paciente obrasocial
     "disponible=%d,observaciones='%s'", // campos actualizables de profesionales especialidad
     "asistio=%d|"}; // campos actualizables de  turnos
//----------------------------------------------------
// insercion
char *sql_insert_str[CANT_TABLES]={
     "insert into pacientes(dni,nombres,apellido,domicilio,telefono)values(%s);",
     "insert into obrasociales(codigo,nombre)values(%s);",
     "insert into especialidades(codigo,nombre)values(%s);",
     "insert into profesionales(matricula,fechamatricula,nombres,apellido,telefono,activo)values(%s);",
     "insert into pacienteobrasocial(dnipaciente,codigoobrasocial,fechadesde)values(%s);",
     "insert into profesionalespecialidad(codigoprofesional,codigoespecialidad,fecha_alta,disponible,observaciones)values(%s);",
     "insert into turnos(fechahora,dnipaciente,codigoprofesional,asistio)values(%s);"};
//----------------------------------------------------
// actualizacion
char *sql_update_str[CANT_TABLES]={
     "update paciente set %s where %s;",
     "update obrasociales set %s where %s;",
     "update especialidades set %s where %s;",
     "update profesionales set %s where %s;",
     "update pacienteobrasocial set %s where %s;",
     "update profesionalespecialidad set %s where %s;",
     "update turnos set %s where %s;"};
//----------------------------------------------------
//t_paciente=0, t_obrasocial, t_especialidad, t_profesional, t_paciente_obrasocial, t_profesional_especialidad, t_turno
// definicion de tamaños para comparaciones asignacion de memoria dinamica.
int size_st[CANT_TABLES]={
	sizeof(t_data_set_paciente),
	sizeof(t_data_set_obrasocial),
	sizeof(t_data_set_especialidad),
	sizeof(t_data_set_profesional),
	sizeof(t_data_set_paciente_obrasocial), 
	sizeof(t_data_set_profesional_especialidad), 
	sizeof(t_data_set_turnos)};
int size_col[CANT_TABLES]={
	sizeof(col_paciente),
	sizeof(col_obrasocial),
	sizeof(col_especialidad),
	sizeof(col_profesional),
	sizeof(col_paciente_obrasocial), 
	sizeof(col_profesional_especialidad), 
	sizeof(col_turnos)};
int cnt_cols[CANT_TABLES]={5,2,2,7,3,5,4};
//----------------------------------------------------
// dataset generico
typedef struct { char **columns;int cntCol;int cntRows; void *rows;} data_set;
// dataset tipado- especifico
typedef struct { char **columns;int cntCol;int cntRows; t_data_set_paciente *rows;  } data_set_paciente;
typedef struct { char **columns;int cntCol;int cntRows; t_data_set_obrasocial *rows;  } data_set_obrasocial;
typedef struct { char **columns;int cntCol;int cntRows; t_data_set_especialidad *rows;  } data_set_especialidad;
typedef struct { char **columns;int cntCol;int cntRows; t_data_set_profesional *rows;  } data_set_profesional;
typedef struct { char **columns;int cntCol;int cntRows; t_data_set_paciente_obrasocial *rows;  } data_set_paciente_obrasocial;
typedef struct { char **columns;int cntCol;int cntRows; t_data_set_profesional_especialidad *rows;  } data_set_profesional_especialidad;
typedef struct { char **columns;int cntCol;int cntRows; t_data_set_turnos *rows;  } data_set_turnos;
//----------------------------------------------------
// IMPLEMENTACION DE LOS OBJETOS EN STRUCT CON "METODOS"
//----------------------------------------------------
typedef struct
{
 data_set *ds;
 int (*findAll)(void *self, void **list,char *criteria); 
 int (*findbykey)(void *self,int dni);
 int (*saveObj)(void *self,int dni,char *nombres,char *apellido,char *domicilio,char *telefono,int isNew); 
/*implementacion de relaciones*/
	int dni;
	char nombres[MAX];
	char apellido[MAX];
	char domicilio[MAX];
	char telefono[MAX];
}obj_paciente;
//----------------------------------------------------
typedef struct
{
 data_set *ds;
 int (*findAll)(void *self, void **list,char *criteria); 
 int (*findbykey)(void *self,int codigo);
 int (*saveObj)(void *self, int codigo,char *nombre,int isNew); 
	int codigo; 
    char nombre[MAX];
}obj_obrasocial;
//----------------------------------------------------
typedef struct
{
 data_set *ds;
 int (*findAll)(void *self, void **list,char *criteria); 
 int (*findbykey)(void *self,int codigo);
 int (*saveObj)(void *self, int codigo,char *nombre,int isNew); 
	int codigo; 
	char nombre[MAX];
}obj_especialidad;
//----------------------------------------------------
typedef struct
{
 data_set *ds;
 int (*findAll)(void *self, void **list,char *criteria); 
 int (*findbykey)(void *self,char *matricula);
 int (*findbyid)(void *self,int id);
 int (*saveObj)(void *self, int id,char *matricula, char *fechamatricula,char *nombres,char *apellido,char *telefono, int activo, int isNew); 
/*implementacion de relaciones*/
	int id;   
	char matricula[MAX1];
	char nombres[MAX];
	char apellido[MAX];
	char telefono[MAX];
	char fecha_matricula[MAX_FECHA];
	int activo;
}obj_profesional;
//----------------------------------------------------
typedef struct
{
 data_set *ds;
 int (*findAll)(void *self, void **list,char *criteria); 
 int (*findbykey)(void *self,int dnipaciente,int codigoobrasocial);
 int (*saveObj)(void *self,	int dnipaciente, int codigoobrasocial,char *fechadesde,int isNew); 
 void *(*get_paciente)(void *self);
/*implementacion de relaciones*/
    int dnipaciente;
	int codigoobrasocial;
	char fechadesde[MAX_FECHA];
}obj_paciente_obrasocial;
//----------------------------------------------------
typedef struct
{
 data_set *ds;
 int (*findAll)(void *self, void **list,char *criteria); 
 int (*findbykey)(void *self,int codigoprof,int codigoespecialidad);
 int (*saveObj)(void *self, int codigoprofesional, int codigoespecialidad, int disponible, char *observaciones,int isNew); 
 void *(*get_profesional)(void *self); 
 void *(*get_especialidad)(void *self); 
	int codigoprofesional;
	int codigoespecialidad;
	char fechaalta[MAX_FECHA];
	int disponible;
	char observaciones[MAXOBS];
}obj_profesional_especialidad;
//----------------------------------------------------
typedef struct
{
 data_set *ds;
 int (*findAll)(void *self, void **list,char *criteria); 
 int (*findbykey)(void *self,char *fechahora,int dnipaciente, int codigoprofesional);
 int (*saveObj)(void *self,	int dnipaciente, int codigoprofesional, int asistio, int isNew); 
 int (*findbyfecha)(void *self,char *fecha);
 int (*findbyfechahhmm)(void *self,char *fecha, int hora,int minuto);
 
/*implementacion de relaciones*/
  void *(*get_profesional)(void *self); 
  void *(*get_paciente)(void *self); 
  char fechahora[MAX_FECHA];
  int dnipaciente;
  int codigoprofesional;
  int asistio;
}obj_turnos;
//----------------------------------------------------
typedef struct 
{ 
 data_set *ds;
 int (*findAll)(void *self, void **list,char *criteria);
   
}t_object;
//----------------------------------------------------
// constructores
obj_paciente *paciente_new();
obj_obrasocial *obrasocial_new();
obj_especialidad *especialidad_new();
obj_profesional *profesional_new();
obj_paciente_obrasocial *paciente_obrasocial_new();
obj_profesional_especialidad *profesional_especialidad_new();
obj_turnos *turnos_new();

// IMPLEMENTACION PARA DAR SOPORTE A COMPORTAMIENTO GENERICO - ABSTRACT.
// Implementacion en  "orm.c"
extern int exec_get_fromDB(char *sql,void **rw, tipos t, void(*fcFill)(void **,int ri,PGresult *r));
extern int findAllImpl(void *self,void **list, char *criteria,tipos t, void *data,void(*fcFill)(void **,int ri,PGresult *r),void(*fillRows)(void **list,int size,void *data));
extern char *getFindSQL(tipos t, char *where);
extern void *init_obj(tipos t, const char *col[], void*(*init)(void *o,data_set *ds));
// Implementacion en "utils.c"
extern char *getFecha();
extern char *getFechaHora();
#endif
