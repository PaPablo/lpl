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
int comparaDNI(const void *a, const void *b){
    return (*(obj_paciente**)a)->dni - (*(obj_paciente**)b)->dni;
}
int comparaApellido(const void *a, const void *b){
    return strcmp((*(obj_paciente**)a)->apellido, (*(obj_paciente**)b)->apellido);
}
int comparaNombres(const void *a, const void *b){
    return strcmp((*(obj_paciente**)a)->nombres, (*(obj_paciente**)b)->nombres);
}
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
      //obj_paciente *pac;
      //void *list;
      //int i,size=0;
      pac = paciente_new();
      //obj_paciente **ejemplo;
      //if((pac->saveObj(pac, 38147366, "David", "Serruya Aloisi", "tambien al lado", "jiji", true )) == -1) printf("no se pudo insertar\n");
      
      if((size = pac->findAll(pac, &list, NULL)) == 0) 
          printf("no recupero nada bolo\n"); // se invoca sin criterio - listar todos...
      else
          printf("%s | cantidad leida: %d\n", getFechaHora(), size);

      qsort(list, size, sizeof(obj_paciente*), comparaNombres);

      for(i=0; i < size; i++)
      {
          pac = ((obj_paciente**)list)[i];
          printf("%-2d\t%-10d|%-20s|%-20s|%-20s\n", i, pac->dni, pac->apellido, pac->nombres, pac->telefono);
      }
      

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
  
  profesp = profesional_especialidad_new();
    size = profesp->findAll(profesp,&list,NULL); // se invoca sin criterio - listar todos...
  for(i=0;i<size;++i)
  {
    profesp_o = ((obj_profesional_especialidad**)list)[i];
     
    printf("Especialidad/Profesional - Profesional: %s, %s - especialidad: %s\n",((obj_profesional*) profesp_o->get_profesional(profesp_o))->apellido,((obj_profesional*) profesp_o->get_profesional(profesp_o))->nombres,((obj_especialidad*) profesp_o->get_especialidad(profesp_o))->nombre);
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
