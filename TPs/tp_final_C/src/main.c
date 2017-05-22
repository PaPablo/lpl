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

//#include "argumentos.h"
#include "busca_argumentos.c"
#define my_printf(...) printf(__VA_ARGS__)
PGconn *conn; //Instancia que permite manipular conexion con el servidor



int main(int argc, char *argv[])
{  
    my_printf("Hola %s va\n", "todo bien?");
    if(argc == 1){
        printf("USO: ./TurnosAplicacionApp <...>\n");
        return 1;
    }else{
        for(int i = 1; i < argc; i++){
            printf("%-2d %s\n", i, argv[i]);
        }
    }
    char *port="5432",*servidor="localhost",*base="turnos", *usuario="postgres", *password="master";
    /*
    obj_profesional *prof;
    obj_obrasocial *os;
    obj_especialidad *esp;
    apellido LIKE %T""obj_paciente *pac;
    obj_paciente_obrasocial *ospac;
    obj_profesional_especialidad *profesp,*profesp_o;
    obj_turnos *tr;
    void *list; //para manejo generico de listado
    int i=0, size=0, j;
    */
    connectdb(servidor,port,base,usuario,password);

    printf("ARGC = %d\n", argc);
    //printf("vamos a crear arbol argumentos...\n");
    argumento arbol_argumentos = construir_arbol(); 
    /*
    for(int i = 0; i < arbol_argumentos->cant_hijos; i++){
        printf("%-2d %s\n", i, arbol_argumentos->hijos[i]->nombre);
    }
    */
    //printf("arbol argumentos creado\n");
    //argumento arbol_f = construir_f();
    //printf("arbol f creado\n");

    int nivel = 1;
    t_puntero_funcion funcion;

    //printf("vamos a buscar funcion...\n");
    buscar_funcion(arbol_argumentos, &nivel, argc, argv, &funcion);
 
    printf("salimos con una funcion, nivel = %d\n", nivel);
    
    if(verificar_f(++nivel, argc, argv)){
        printf("se debe redigirar la salida al archivo %s\n", argv[nivel+1]);
        redireccionar_salida(argv[++nivel]);
    }

    funcion(nivel, argc, argv);

  disconnectdb();
  //system("PAUSE");	
  return 0;
}
