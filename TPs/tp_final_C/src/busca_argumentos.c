#include "argumentos.h"
#include "funciones_argumentos.c"
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
#define MALLOC_ERROR() {perror("*** MALLOC ERROR ***");}


argumento crear_nodo(char *nombre, int cant_hijos, t_puntero_funcion metodo){

    argumento nuevo = (argumento)malloc(sizeof(struct t_arg));

    if(nuevo == NULL){
        MALLOC_ERROR();
        printf("nuevo");
        exit(1);
    }

    if((nuevo->nombre = (char *)malloc(strlen(nombre) + 1)) == NULL){
        MALLOC_ERROR();
        printf("nombre");
        exit(1);
    }
    strcpy(nuevo->nombre, nombre);

    nuevo->hijos = cant_hijos > 0 ? (argumento *)malloc(sizeof(struct t_arg) * cant_hijos) : NULL;

    nuevo->cant_hijos = cant_hijos;
    nuevo->metodo = metodo;
}

void eliminar_nodo(argumento nodo){
    free(nodo->nombre);
    free(nodo->hijos);
    free(nodo);
    //free(nodo->);
    //free(nodo->);
}

argumento construir_arbol(void){
    argumento arbol;

    arbol = crear_nodo("-l", 5, argumento_l);

    /*una vez que tenemos creado el arbol, tenemos que ir creando los nodos hijos 
     * e ir asignandoles sus respectivos nombres e hijos*/
    //pacientes, obrasocial, profesional, turnos, custom

    //empezamos a crear hijos
    arbol->hijos[0] = crear_nodo("paciente", 0, argumento_paciente);
    arbol->hijos[1] = crear_nodo("obrasocial", 0, argumento_obrasocial);
    arbol->hijos[2] = crear_nodo("profesional", 3, argumento_profesional);
    arbol->hijos[3] = crear_nodo("turnos", 3, argumento_turnos);
    arbol->hijos[4] = crear_nodo("custom", 0, argumento_custom);

    arbol->hijos[2]->hijos[0] = crear_nodo("-esp", 0, argumento_esp);
    arbol->hijos[2]->hijos[1] = crear_nodo("-act", 0, argumento_act);
    arbol->hijos[2]->hijos[2] = crear_nodo("-inact", 0, argumento_inact);

    arbol->hijos[3]->hijos[0] = crear_nodo("-pdni", 0, argumento_pdni);
    arbol->hijos[3]->hijos[1] = crear_nodo("--prof-mat", 0, argumento_profmat);
    arbol->hijos[3]->hijos[2] = crear_nodo("--prof-id", 0, argumento_profid);

    return arbol;
}

void eliminar_arbol(argumento arbol){
    eliminar_nodo(arbol->hijos[3]->hijos[0]);
    eliminar_nodo(arbol->hijos[3]->hijos[1]);
    eliminar_nodo(arbol->hijos[3]->hijos[2]);

    eliminar_nodo(arbol->hijos[2]->hijos[0]);
    eliminar_nodo(arbol->hijos[2]->hijos[1]);
    eliminar_nodo(arbol->hijos[2]->hijos[2]);

    eliminar_nodo(arbol->hijos[0]);
    eliminar_nodo(arbol->hijos[1]);
    eliminar_nodo(arbol->hijos[2]);
    eliminar_nodo(arbol->hijos[3]);
    eliminar_nodo(arbol->hijos[4]);

    eliminar_nodo(arbol);
}

/*
argumento construir_f(void){

    argumento arbol;

    arbol = crear_nodo("-f", 0, argumento_f);

    return arbol;
}
*/

int match_arg(char *arg, argumento nodo){
    printf("DENTRO DE MATCH_ARG, arg = %s, nodo = %s, cant_hijos = %d\n", arg, nodo->nombre, nodo->cant_hijos);
    if(arg == NULL) return -1;

    for(int i = 0; i < nodo->cant_hijos; i++){
        if(strcmp(arg, nodo->hijos[i]->nombre) == 0){
            printf("el arg = %s matchea con el nombre %s del nodo %s. Devuelve %d\n", arg, nodo->hijos[i]->nombre, nodo->nombre, i);
            return i;
        }
    }

    printf("AFUERA DE MATCH_ARG\n");
    return -1;
}

//void buscar_funcion(argumento nodo, int *nivel, int argc, char* argv[], t_puntero_funcion *funcion){
t_puntero_funcion buscar_funcion(argumento nodo, int *nivel, int argc, char* argv[]){

    printf("DENTRO DE BUSCAR_FUNCION, nivel = %d\n", (*nivel));
    int pos = match_arg(argv[(*nivel)+1], nodo);
    //printf("BUSCAR_FUNCION, POS = %d\n", pos);

    //Si el nodo es hoja, o si no debemos bajar mas en el arbol, o si ninguno de los hijos matchean con el siguiente argumento
    //devolvemos el puntero a la funcion del nodo
    if(((*nivel) == (argc-1)) || (nodo->cant_hijos == 0) || (pos == -1)){
        printf("BUSCAR_FUNCION: devuelve el metodo del nodo: %s\n", nodo->nombre);
        //*funcion = nodo->metodo;
        //return;
        return nodo->metodo;
    }

    (*nivel)++;
    printf("BUSCAR_FUNCION: LLAMADA RECURSIVA CON EL NODO %s\n", nodo->hijos[pos]->nombre);
    //buscar_funcion(nodo->hijos[pos], nivel, argc, argv, funcion);
    return buscar_funcion(nodo->hijos[pos], nivel, argc, argv);
}

int verificar_f(int nivel, int argc, char *argv[]){
    return (nivel < (argc - 1)) && (!strcmp(argv[nivel], "-f"));
}

FILE *redireccionar_salida(char *nombre_archivo){

    FILE* filefd = fopen(nombre_archivo, "a");

    //close(1);
    //dup(filefd);

    return filefd;
}
