#include "argumentos.h"
#include "funciones_argumentos.c"
#define MALLOC_ERROR() {perror("*** MALLOC ERROR ***");}
argumento crear_nodo(char *nombre, argumento *hijos, int cant_hijos, t_puntero_funcion metodo){

    argumento nuevo = (argumento)malloc(sizeof(struct t_arg));

    if(nuevo == NULL){
        MALLOC_ERROR();
        printf("nuevo\n");
        exit(1);
    }

    if((nuevo->nombre = (char *)malloc(strlen(nombre) + 1)) == NULL){
        MALLOC_ERROR();
        exit(1);
    }
    strcpy(nuevo->nombre, nombre);

    nuevo->hijos = hijos;

    nuevo->cant_hijos = cant_hijos;
    nuevo->metodo = metodo;
}

argumento construir_arbol(){
    argumento arbol;
    arbol = (argumento)malloc(sizeof(struct t_arg));
    if(arbol == NULL){
        MALLOC_ERROR();
        printf("arbol\n");
        exit(1);
    }

    /*una vez que tenemos creado el arbol, tenemos que ir creando los nodos hijos 
     * e ir asignandoles sus respectivos nombres e hijos*/
    //pacientes, obrasocial, profesional, turnos, custom
    arbol = crear_nodo("-l", (argumento *)malloc(sizeof(struct t_arg) * 5), 5, argumento_l);
    //empezamos a crear hijos
    arbol->hijos[0] = crear_nodo("paciente", NULL, 0, argumento_paciente);
    arbol->hijos[1] = crear_nodo("obrasocial", NULL, 0, argumento_obrasocial);
    arbol->hijos[2] = crear_nodo("profesional", (argumento *)malloc(sizeof(struct t_arg) * 3), 3, argumento_profesional);
    arbol->hijos[3] = crear_nodo("turnos", (argumento *)malloc(sizeof(struct t_arg) * 2), 2, argumento_turnos);
    arbol->hijos[4] = crear_nodo("custom", NULL, 0, argumento_custom);

    arbol->hijos[2]->hijos[0] = crear_nodo("-esp", NULL, 0, argumento_esp);
    arbol->hijos[2]->hijos[1] = crear_nodo("-act", NULL, 0, argumento_act);
    arbol->hijos[2]->hijos[2] = crear_nodo("-inact", NULL, 0, argumento_inact);

    arbol->hijos[3]->hijos[0] = crear_nodo("-pdni", NULL, 0, argumento_pdni);
    arbol->hijos[3]->hijos[1] = crear_nodo("--prof-mat", NULL, 0, argumento_profmat);
    arbol->hijos[3]->hijos[2] = crear_nodo("--prof-id", NULL, 0, argumento_profid);

    return arbol;
}

int match_arg(char *arg, int argc, argumento *hijos){
    for(int i = 0; i < argc; i++){
        if(strcmp(arg, hijos[i]->nombre) == 0) return i;
    }

    return -1;
}

void buscar_funcion(argumento nodo, int *nivel, int argc, char* argv[], t_puntero_funcion *funcion){
    /*se convirtió a una función que no devuelve nada porque si era una función que devolvía el puntero,
     * nos estaba faltando el return al final para que la recursión devuelva algo.
     * Osea, iba a chillar al momento de compilar porque la función declara que devuelve algo y al final de la ejecución
     * no estaba devolviendo nada*/

    int pos;

    //Si el nodo es hoja, o si no debemos bajar mas en el arbol, o si ninguno de los hijos matchean con el siguiente argumento
    //devolvemos el puntero a la funcion del nodo
    if((nodo->hijos == NULL) || ((*nivel) == argc) || (pos = match_arg(argv[(*nivel)+1], argc, nodo->hijos)) == -1){
        *funcion = nodo->metodo;
    }

    nivel++;
    buscar_funcion(nodo->hijos[pos], nivel, argc, argv, funcion);
}
