#include <listas.h>

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
   mostrar display;
};

//typedef struct t_lista *tipoLista;
//ver si se puede borrar, una vez que funcione todo jeje
int listaNoExiste(tipoLista l){
    return ((l == NULL) || (l->lista == NULL));
}
void mostrar_default(const void* k, const void* i){
    printf("K = %p\tI = %p", k, i);
}

t_nodo nuevo_nodo(){

    t_nodo nuevo;
    
    nuevo = (t_nodo)malloc(sizeof(struct nodo));
    //si malloc falla, nuevo va a tener NULL
    return nuevo;

}

int crear_lista(tipoLista *l, comparar funcion, mostrar display){
    if(funcion == NULL){
        printf("FUNCIÓN DE COMPARACIÓN NO ESPECIFICADA\n");
        return 1;
    }

    if((*l = (tipoLista)malloc(sizeof(struct t_lista))) == NULL) return MALLOC_ERROR;
    (*l)->cant = 0;
    (*l)->comparador = funcion;
    (*l)->display = display != NULL? display : mostrar_default; 
    if (((*l)->lista = (t_nodo)malloc(sizeof(tipoClave))) == NULL){
        free(*l);
        return MALLOC_ERROR;
    }
    return 0;
}

int vaciar_lista(tipoLista *l){
    if (listaNoExiste(*l)) return LISTA_NOEXISTE;
    
    t_nodo ant;
    //t_nodo p = (*l)->lista;

    while((*l)->lista != NULL){
        ant = (*l)->lista;
        (*l)->lista = (*l)->lista->sig;
        free(ant);
    }

    free((*l)->lista);
    /*
    este último free capaz que da problemas eh, tenerlo en cuenta
    */
    *l = NULL;
    return 0;
}

int insertar_lista(tipoLista *l, tipoClave k, tipoInfo i){
    /*Había problemas porque en crear_lista se hacía el malloc a la lista pasada por parámetros
     * así que se le asignaba una dirección distinta a la pasada por parámetro
     * por lo tanto cuando salía de crear_lista, la lista pasada no tenía nada
     * Me parece que con que crear_lista reciba un puntero a tipoLista ya estaría,
     * no creo que todos las funciones que modifiquen la lista necesiten recibir un tipoLista* */    
    if (listaNoExiste(*l)) return LISTA_NOEXISTE;
    t_nodo aux, ant, p;
    comparar func = (*l)->comparador;
    p = (*l)->lista;

    if((*l)->cant == 0){
        if((aux = nuevo_nodo()) == NULL) return MALLOC_ERROR;
        aux->clave = k;
        aux->info = i;
        aux->sig = NULL;
        (*l)->lista = aux;
        (*l)->cant++;
        return 0;
    }

    while((p != NULL) && ((func(&k, &p->clave) > 0))){
        if((*l)->cant == 0) break;
        ant = p;
        p = p->sig;
    }
    
    if((p != NULL) && ((func(&k, &p->clave) == 0))) return CLAVE_EXISTE;
    
    if((aux = nuevo_nodo()) == NULL) return MALLOC_ERROR;
    aux->clave = k;
    aux->info = i;
    aux->sig = p;
    if(p != (*l)->lista){
        ant->sig = aux;
    }else{
        (*l)->lista = aux;
    }
    (*l)->cant++;
    return 0;
}

int eliminar_lista(tipoLista *l, tipoClave k){
    if (listaNoExiste(*l)) return LISTA_NOEXISTE;
    t_nodo ant, p;
    
    comparar func = (*l)->comparador;
    p = (*l)->lista;
    
    while ((p != NULL) && ((func(&k, &p->clave) > 0))){
        ant = p;
        p = p->sig;
    }

    if(((p != NULL) && (func(&k, &p->clave) < 0) || (p == NULL))) return CLAVE_NOEXISTE;
    
    if(p != (*l)->lista){ 
        ant->sig = p->sig;
    } else{
        (*l)->lista = p->sig;
    }

    free(p);
    (*l)->cant--;

    return 0;
}


int longitud_lista(tipoLista l){
    if (listaNoExiste(l)) return LISTA_NOEXISTE;
    return l->cant;
}

int recuPrim_lista(tipoLista l, tipoClave *prim){
    if (listaNoExiste(l)) return LISTA_NOEXISTE;
    *prim = l->lista->clave;    
    return 0;
} 

int recuUlt_lista(tipoLista l, tipoClave *ult){
    if (listaNoExiste(l)) return LISTA_NOEXISTE;

    t_nodo p = l->lista;

    while(p->sig != NULL){
        p = p->sig;
    }

    *ult = p->clave;
    return 0;
}

int recuClave_lista(tipoLista l, tipoClave k, tipoInfo *i){
    if (listaNoExiste(l)) return LISTA_NOEXISTE;

    t_nodo p = l->lista;
    comparar func = l->comparador;
    if(l->cant == 0) return CLAVE_NOEXISTE;

    while((p != NULL) && ((func(&k, &p->clave) > 0))){
        p = p->sig;
    }

    if((p != NULL) && ((func(&k, &p->clave) == 0))){
        *i = p->info;
    } else return CLAVE_NOEXISTE;

    return 0;
}

int recuAnt_lista(tipoLista l, tipoClave k, tipoClave *ant){
    if (listaNoExiste(l)) return LISTA_NOEXISTE;
    
    t_nodo aux, p = l->lista;
    comparar func = l->comparador;
    while((p != NULL) && ((func(&k, &p->clave) > 0))){
        aux = p;
        p = p->sig;
    }

    if((p != NULL) && ((func(&k, &p->clave) == 0))){
        if(p == l->lista) return CLAVE_PRIMERA;
        *ant = aux->clave;
    } else return CLAVE_NOEXISTE;
    return 0;
}

int recuSig_lista(tipoLista l, tipoClave k, tipoClave *sig){
    if (listaNoExiste(l)) return LISTA_NOEXISTE;
    
    t_nodo p = l->lista;
    comparar func = l->comparador;
    while((p != NULL) && ((func(&k, &p->clave) > 0))){
        p = p->sig;
    }

    if((p != NULL) && ((func(&k, &p->clave) == 0))){
        if(p->sig == NULL) return CLAVE_ULTIMA;
        *sig = p->sig->clave;
    } else return CLAVE_NOEXISTE;

    return 0;
}

int esVacia_lista(tipoLista l){
    if (listaNoExiste(l)) return LISTA_NOEXISTE;
    return (!l->cant);
}

void imprimir_lista(tipoLista l){
    if (listaNoExiste(l)) return;
    
   if(l->cant == 0){
        printf("***LISTA VACÍA***\n");
        return;
   }
   t_nodo p = l->lista;
   int i = 1;
   printf("Cantidad de nodos: %d\n", l->cant);
   while(p != NULL){
       printf("NODO %d ", i++);
       l->display(&p->clave, &p->info);
       p = p->sig;
   }

}
