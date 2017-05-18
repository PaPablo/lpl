#include <stdio.h>
#include <stdlib.h>
#include <libpq-fe.h> 
#include <string.h>
#include <malloc.h>

#include "config.h"
#include "utils.h"
// incluir fuente de la implementacion de cada objeto del modelo
#include "orm.c"
#include "profesional.c"
#include "paciente.c"
#include "obrasocial.c"
#include "especialidad.c"
#include "pacienteobrasocial.c"
#include "profespecialidad.c"
#include "turnos.c"


PGconn *conn; //Instancia que permite manipular conexion con el servidor


/*
int comparaDNI(const void *a, const void *b){
    return (*(obj_paciente**)a)->dni - (*(obj_paciente**)b)->dni;
}
int comparaApellido(const void *a, const void *b){
    return strcmp((*(obj_paciente**)a)->apellido, (*(obj_paciente**)b)->apellido);
}
int comparaNombres(const void *a, const void *b){
    return strcmp((*(obj_paciente**)a)->nombres, (*(obj_paciente**)b)->nombres);
}
*/

//probamos hacer el un listado nosotros
void do_exit(PGconn *conn);
void listado(PGconn *conn);




int main(int argc, char *argv[])
{  
    char *port="5432",*servidor="localhost",*base="turnos", *usuario="postgres", *password="master";
    obj_profesional *prof;
    obj_obrasocial *os;
    obj_especialidad *esp;
    obj_paciente *pac;
    obj_paciente_obrasocial *ospac;
    obj_profesional_especialidad *profesp,*profesp_o;
    obj_turnos *tr;
    void *list; //para manejo generico de listado
    int i=0, size=0, j;

    connectdb(servidor,port,base,usuario,password);

     
    //busca y muestra los pacientes cuyos apellidos empiecen con T
      pac = paciente_new(); 
      size = pac->findAll(pac, &list, "apellido LIKE 'T%'");
      for(int i = 0; i < size; i++){
          pac = ((obj_paciente**)list)[i];
          printf("%-2d\t%-20s\n", i, pac->apellido);
      }


      printf("\n\n");
        obj_paciente *p = paciente_new();
     if(p->findbykey(p,38802981) != -1)
     {
         printf("Apellido y Nombre:%s – Domicilio: %s - Telefono: %s \n",p->
                 nombres, p->domicilio, p->telefono);
     }


      printf("\n\n");
      tr = turnos_new();
      //size = tr->findAll(tr, &list, NULL);

      
      //busca y muestra los turnos del 2015 que fueron asistidos, los ordena por fechahora
      if((size = tr->findAll(tr, &list, "to_char(turnos.fechahora, 'YYYY-MM-DD HH:MM:SS') LIKE '2015%' and turnos.asistio=1 order by fechahora")) == 0) 
      pac = paciente_new();

      for(i=0; i < size; i++) {
          tr = ((obj_turnos**)list)[i];
          pac_tr = (obj_paciente *) tr->get_paciente(tr);
          printf("%-2d | %-15s | %-20s | %-20s | %-10d\n", 
                  i, tr->fechahora, 
                  pac_tr->apellido,
                  pac_tr->nombres,
                  pac_tr->dni);
      }


      //tiramos nuestro listado
      //listado(conn);


      /*      
      if((size = pac->findAll(pac, &list, NULL)) == 0) 
          printf("no recupero nada bolo\n"); // se invoca sin criterio - listar todos...
      else
          printf("%s | cantidad leida: %d\n", getFechaHora(), size);

      obj_paciente *pac_tr;
      


      for(i=0; i < size; i++)
      {
          pac = ((obj_paciente**)list)[i];
          printf("%-2d\t%-10d | %-20s | %-20s | %-20s\n", i, pac->dni, pac->apellido, pac->nombres, pac->telefono);
      }
      */

      /*
   obj_profesional *profesional;
  
   prof = profesional_new();
  if(prof->findbyid(prof, 1)!=-1)
  {	  
      printf("profesional id : %d Nombre: %s  Apellido: %s - matricula: %s\n",prof->id,prof->nombres,prof->apellido, prof->matricula);	  	  
  }
  */
/*
  os = obrasocial_new();
   if(os->findbykey(os, 1)!=-1)
  {
	  printf("Obra Social codigo : %d Nombre: %s\n",os->codigo,os->nombre);	  
  }
  
  esp = especialidad_new();
   if(esp->findbykey(esp, 1)!=-1)
  {
	  printf("Especialidad codigo : %d Nombre: %s\n",esp->codigo,esp->nombre);	  
  }
  
  pac = paciente_new();
   if(pac->findbykey(pac, 225544335)!=-1)
  {
	  printf("Paciente codigo : %d RazonSocial: %s %s\n",pac->dni,pac->apellido,pac->nombres);	  
  }
  
  ospac = paciente_obrasocial_new();
   if(ospac->findbykey(ospac, 225544335,1)!=-1)
  {
	  printf("OS Paciente dni : %d RazonSocial: %s, %s\n",ospac->dnipaciente,((obj_paciente*) ospac->get_paciente(ospac))->apellido,((obj_paciente*) ospac->get_paciente(ospac))->nombres);
  }
  */
      /*
      printf("\n");
  profesp = profesional_especialidad_new();
    size = profesp->findAll(profesp,&list,NULL); // se invoca sin criterio - listar todos...
  for(i=0;i<size;++i)
  {
    profesp_o = ((obj_profesional_especialidad**)list)[i];
     
    printf("%-3d | %-30s | %-20s | %-20s\n", i,
    ((obj_profesional*) profesp_o->get_profesional(profesp_o))->apellido,
    ((obj_profesional*) profesp_o->get_profesional(profesp_o))->nombres,
    ((obj_especialidad*) profesp_o->get_especialidad(profesp_o))->nombre);
  }
  */


  /*
  tr = turnos_new();
  
   if(tr->findbyfechahhmm(tr, "2017-05-10",10,15)!=-1)
  {
	  printf("%s",tr->fechahora);
  }
  */
  disconnectdb();
  //system("PAUSE");	
  return 0;
}



void do_exit(PGconn *conn){
    exit(1);
}

void listado(PGconn *conn){
    
    char query[] = "SELECT E.codigo, E.nombre, PE.fechaalta, P.apellido, P.nombres, CASE WHEN PE.disponible=1 THEN 'DISPONIBLE' ELSE 'NO DISPONIBLE' END FROM profesionalespecialidad as PE JOIN especialidades as E ON PE.codigoespecialidad=E.codigo JOIN profesionales as P ON PE.codigoprofesional=P.id order by E.nombre, P.apellido;";

    PGresult *res = PQexec(conn, query);    

    if (res == NULL && PQresultStatus(res) != PGRES_TUPLES_OK) {
        printf("No data retrieved\n");        
        PQclear(res);
        do_exit(conn);
    }    

    int rows = PQntuples(res),
        cols = PQnfields(res);

    //imprimimos cabecera
    printf("%-3s", "");
    for(int i = 0; i < cols; i++){
        printf("| %-10s ", PQfname(res, i));
    }
    printf("\n");
    //printf("%s %s %s %s %s %s", PQgetvalue(res, 0, 0),PQgetvalue(res, 0, 1), PQgetvalue(res, 0, 2),PQgetvalue(res, 0, 3),PQgetvalue(res, 0, 4),PQgetvalue(res, 0, 5));

    
    for(int i=0; i<rows; i++){
        printf("%-3d", i);
        printf("| %-2s ", PQgetvalue(res, i, 0));
        printf("| %-35s ", PQgetvalue(res, i, 1));
        printf("| %-10s ", PQgetvalue(res, i, 2));
        printf("| %-10s ", PQgetvalue(res, i, 3));
        printf("| %-20s ", PQgetvalue(res, i, 4));
        printf("| %-10s ", PQgetvalue(res, i, 5));

        /*
        for(int j = 0; j < cols; j++){
            printf("%-3d");
            printf("| %s ", PQgetvalue(res, i, j));
        }
        */
        printf("\n");
    }   
    PQclear(res);

    return;
}
