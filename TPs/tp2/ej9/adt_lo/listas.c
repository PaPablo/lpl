#include "listas.h"

struct nodo{
    tipoClave clave;
    tipoInfo info;
    struct nodo *sig;
};

typedef struct nodo t_nodo;

typedef struct {
   t_nodo *lista;
   int cant;
   comparar comparador;
} t_lista;

int crear_lista(tipoLista l, comparar funcion){

    if((l = (tipoLista)malloc(sizeof(t_lista))) == NULL) return MALLOC_ERROR;
    l.cant = 0;
    l->comparar = funcion;
    if ((l->lista = (tipoClave *)malloc(sizeof(tipoClave))) == NULL){
        free(l);
        return MALLOC_ERROR;
    }
    return 0;
}

int insertar_lista(tipoLista l, tipoClave k, tipoInfo i){


    return 0;
}
