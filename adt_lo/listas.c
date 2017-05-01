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

typedef struct t_lista *tipoLista;
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

int crear_lista(tipoLista *l, comparar funcion){
    if(funcion == NULL){
        printf("FUNCIÓN DE COMPARACIÓN NO ESPECIFICADA\n");
        return 1;
    }

    if((*l = (tipoLista)malloc(sizeof(struct t_lista))) == NULL) return MALLOC_ERROR;
    (*l)->cant = 0;
    (*l)->comparador = funcion;
    if (((*l)->lista = (t_nodo)malloc(sizeof(tipoClave))) == NULL){
        free(*l);
        return MALLOC_ERROR;
    }
    return 0;
}

int vaciar_lista(tipoLista l){
    if(l == NULL) return LISTA_VACIA;

    t_nodo p, ant;
    p = l->lista;

    while(p != NULL){
        ant = p;
        p = p->sig;
        free(ant);
    }
    free(p);
    /*
    este último free capaz que da problemas eh, tenerlo en cuenta
    */


    l->cant = 0;

    return 0;
}

int insertar_lista(tipoLista l, tipoClave k, tipoInfo i){
    /*Había problemas porque en crear_lista se hacía el malloc a la lista pasada por parámetros
     * así que se le asignaba una dirección distinta a la pasada por parámetro
     * por lo tanto cuando salía de crear_lista, la lista pasada no tenía nada
     * Me parece que con que crear_lista reciba un puntero a tipoLista ya estaría,
     * no creo que todos las funciones que modifiquen la lista necesiten recibir un tipoLista* */    
    printf("INSERTAR LISTA: COMIENZO\n");
    t_nodo aux, ant, p;
    printf("INSERTAR LISTA: DESPUES DE DECLARAR VARIABLES\n");
    comparar func = l->comparador;
    printf("INSERTAR LISTA: FUNCION DE COMPARACION ASIGNADA\n");
    p = l->lista;
    printf("INSERTAR LISTA: LISTA RESCATADA\n");

    printf("INSERTAR LISTA: ANTES DE WHILE \n");
    while((p != NULL) && ((func(&k, &p->clave) > 0))){
        ant = p;
        p = p->sig;
        printf("INSERTAR LISTA: DENTRO DE WHILE\n");
    }
    
    printf("INSERTAR LISTA: DESPUES DE WHILE\n");
    if((p != NULL) && ((func(&k, &p->clave) == 0))) return CLAVE_EXISTE;

    printf("INSERTAR LISTA: DESPUES DE PREGUNTAR POR CLAVE EXISTE\n");
    if((aux = nuevo_nodo()) == NULL) return MALLOC_ERROR;
    aux->clave = k;
    aux->info = i;
    aux->sig = p;

    printf("INSERTAR LISTA: NODO INSERTADO\n");
    if(p != l->lista){
        ant->sig = aux;
    }else{
        l->lista = aux;
    }

    printf("INSERTAR LISTA: YA EN EL FINAL\n");
    l->cant++;
    return 0;
}