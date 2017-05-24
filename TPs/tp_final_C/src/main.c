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

#include "argumentos.c" 
PGconn *conn; //Instancia que permite manipular conexion con el servidor 

int main(int argc, char *argv[])
{  
    if(argc == 1){
        printf("\nUSO: ./TurnosAplicacionApp -l <...>\n\n");
        return 1;
    }

    char *port="5432",*servidor="localhost",*base="turnos", *usuario="postgres", *password="master";
    connectdb(servidor,port,base,usuario,password);

    argumento arbol_argumentos = construir_arbol(); 

    int nivel = 1;
    t_puntero_funcion funcion = buscar_funcion(arbol_argumentos, &nivel, argc, argv); 
 
    
    FILE *salida = stdout;

    if(verificar_f(argc, argv)){
        salida = redireccionar_salida(argv[argc-1]);
    }

    funcion(argv[nivel+1], salida);
    
    if(salida != stdout)
        fclose(salida);

    eliminar_arbol(arbol_argumentos);
    disconnectdb();
    //system("PAUSE");	
    return 0;
}
