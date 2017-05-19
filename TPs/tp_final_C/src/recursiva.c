argumento construir_arbol(){
    argumento arbol;
    arbol = malloc(sizeof(struct t_arg));
    if(arbol == NULL){
        MALLOC_ERROR();
        exit(1);
    }
    /*una vez que tenemos creado el arbol, tenemos que ir creando los nodos hijos 
     * e ir asignandoles sus respectivos nombres e hijos*/
    arbol.nombre = malloc(strlen("-l") + 1);
    strcpy(arbol.nombre, "-l");

    //pacientes, obrasocial, profesional, turnos, custom
    arbol.arreglo = malloc(sizeof(struct t_arg) * 5);
    arbol.cant_hijos = 5;
    arbol.metodo = argumento_l;

    //empezamos a crear hijos
    arbol.arreglo[0] = crear_hijo("paciente", NULL, 0, argumento_paciente);
    arbol.arreglo[1] = crear_hijo("obrasocial", NULL, 0, argumento_obrasocial);
    arbol.arreglo[2] = crear_hijo("profesional", NULL, 0, argumento_profesional);
    arbol.arreglo[3] = crear_hijo("turnos", NULL, 0, argumento_turnos);
    arbol.arreglo[4] = crear_hijo("custom", NULL, 0, argumento_custom);

    //ahora tenemos que ir bajando y creando los hijos de profesional y turnos

    /*
    argumento raiz = arbol;

    //nos vamos a "profesional"
    arbol = arbol.arreglo[2];
    
    arbol.nombre = malloc(strlen("profesional") + 1);
    strcpy(arbol.nombre, "profesional");
    arbol.arreglo = malloc(sizeof(struct t_arg));
    arbol.cant_hijos = 1;
    arbol.metodo = argumento_profesional;

    //nos vamos a "-esp"
    */

}

int match_arg(char *arg, int argc, argumento *arreglo){
    for(int i = 0; i < argc; i++){
        if(strcmp(arg, arreglo[i]->nombre) == 0) return i;
    }

    return -1;
}

t_puntero_funcion buscar_funcion(argumento nodo, int *(*nivel), int argc, char* argv[]){

    int pos;

    //Si el nodo es hoja, o si no debemos bajar mas en el arbol, o si ninguno de los hijos matchean con el siguiente argumento
    //devolvemos el puntero a la funcion del nodo
    if((nodo.arreglo == NULL) || ((*nivel) == argc) || (pos = match_arg(argv[(*nivel)+1], argc, nodo->arreglo)) == -1){
        return nodo->metodo;
    }

    check_arg(nodo->arreglo[pos], ++(*nivel), argc, argv);
}
