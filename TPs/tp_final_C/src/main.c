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

#include "busca_argumentos.c"
PGconn *conn; //Instancia que permite manipular conexion con el servidor



int main(int argc, char *argv[])
{  
    if(argc == 1){
        printf("\nUSO: ./TurnosAplicacionApp <...>\n\n");
        return 1;
    }

    char *port="5432",*servidor="localhost",*base="turnos", *usuario="postgres", *password="master";
    connectdb(servidor,port,base,usuario,password);

    //printf("ARGC = %d\n", argc);
    argumento arbol_argumentos = construir_arbol(); 

    int nivel = 1;
    t_puntero_funcion funcion = buscar_funcion(arbol_argumentos, &nivel, argc, argv); 
 
    //printf("salimos con una funcion, nivel = %d\n", nivel);
    
    FILE *salida = stdout;

    if(verificar_f(argc, argv)){
        //printf("se debe redigirar la salida al archivo %s\n", argv[argc-1]);
        salida = redireccionar_salida(argv[argc-1]);
    }

    funcion(nivel, argc, argv, salida);
    
    if(salida != stdout)
        fclose(salida);
    //printf("cerramos salida...\n");
    eliminar_arbol(arbol_argumentos);
    //printf("eliminamos arbol...\n");
    disconnectdb();
    //system("PAUSE");	
    return 0;
}
