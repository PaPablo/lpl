#include "listas.h"
#include <unistd.h>
#define MAX 10
int comparaEnteros(const void *num1, const void *num2){
    return *(int *)num1 - *(int *)num2;
}
int main(int argc, char* argv[]){

    tipoLista l; 
    printf("Lista declarada\n");
    crear_lista(&l, comparaEnteros);
    printf("Lista creada\n");
    imprimir_lista(l);
    int k;
    for(int i = 0; i < MAX; i++){
        k = rand() % 5;
        printf("A insertar en la lista: (%d, %d)\n", k, i);
        if(insertar_lista(&l, k, i) != 0){
            printf("CLAVE EXISTE\n");
        }else{
            printf("todo bien\n");
        }
    }

    insertar_lista(&l, 2, 3);
    printf("Insertado en la lista: (2, 3)\n");
    imprimir_lista(l);
    insertar_lista(&l, 4, 3);
    printf("Insertado en la lista: (4, 3)\n");
    imprimir_lista(l);
    insertar_lista(&l, 1, 3);
    printf("Insertado en la lista: (1, 3)\n");
    imprimir_lista(l);
    if((insertar_lista(&l, 1, 3) != 0)){
        printf("eh que ortiva loco, clave existe\n");
    }else{
        printf("Insertado en la lista: (1, 3)\n");
    }
    imprimir_lista(l);

    printf("Probamos eliminar el nodo: (4, 3)\n");
    if(eliminar_lista(&l, 4) == 0){
        printf("TODO BIEN con el nodo k = 4\n");
    } else printf("todo mal bldo\n");

    printf("Probamos eliminar el nodo: (4, 3)\n");
    if(eliminar_lista(&l, 4) == 0){
        printf("TODO BIEN con el nodo k = 4\n");
    } else printf("todo mal bldo\n");
    imprimir_lista(l);


    int primero;

    if(recuPrim_lista(l, &primero) == 0){
        printf("recuperamos la clave %d\n", primero);
    } else{
        printf("no se pudo recuperar primera\n");
    }
    return 0;
}
