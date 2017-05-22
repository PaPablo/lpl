#ifndef ARG_H
#define ARG_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef int (*t_puntero_funcion)(int nivel, int argc, char*argv[], FILE *out);

struct t_arg{
    char *nombre;
    struct t_arg **hijos;
    int cant_hijos;
    t_puntero_funcion metodo;
};

typedef struct t_arg *argumento;

//void buscar_funcion(argumento nodo, int *nivel, int argc, char* argv[], t_puntero_funcion *funcion);
//argumento construir_arbol(void);
//argumento construir_f(void);

#endif //ARG_H
