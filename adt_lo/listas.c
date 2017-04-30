#include "listas.h"


struct nodo{
    tipoClave clave;
    tipoInfo info;
    struct nodo *sig;
};

typedef struct nodo *t_nodo;

struct t_lista{
   t_nodo lista;
   int cant;
   comparar comparador;
};

//typedef struct t_lista *tipoLista;
//ver si se puede borrar, una vez que funcione todo jeje

/*PARA IMPLEMENTAR LA FUNCION DE COMPARACION:
 *  comparar(a, b)
 *  Si la función devuelve 0, los elementos son iguales (a == b)
 *  Si función devuelve menor que 0, el primer elemento es menor que el segundo (a < b)
 *  Si la función devuelve mayor que 0, el segundo elemento es menor que el primero (a > b)
 *
 *      return a - b;*/

t_nodo nuevo_nodo(){

    t_nodo nuevo;
    
    nuevo = (t_nodo)malloc(sizeof(struct nodo));
    //si malloc falla, nuevo va a tener NULL
    return nuevo;
}

int crear_lista(tipoLista l, comparar funcion){
    if(funcion == NULL){
        printf("COMPARATOR FUNCTION NOT SPECIFIED\n");
        return 1;
    }

    if((l = (tipoLista)malloc(sizeof(struct t_lista))) == NULL) return MALLOC_ERROR;
    l->cant = 0;
    l->comparador = funcion;
    if ((l->lista = (t_nodo)malloc(sizeof(tipoClave))) == NULL){
        free(l);
        return MALLOC_ERROR;
    }
    return 0;
}

int insertar_lista(tipoLista l, tipoClave k, tipoInfo i){
    
    t_nodo aux, ant, p;
    comparar func = l->comparador;
    p = l->lista;

    while((p != NULL) && ((func(&k, &p->clave) == 1))){
        ant = p;
        p = p->sig;
    }

    if((p != NULL) && ((func(&k, &p->clave) == 0))) return CLAVE_EXISTE;

    if((aux = nuevo_nodo()) == NULL) return MALLOC_ERROR;
    aux->clave = k;
    aux->info = i;
    aux->sig = p;

    if(p != l->lista){
        ant->sig = aux;
    }else{
        l->lista = aux;
    }

    l->cant++;
    return 0;
}
