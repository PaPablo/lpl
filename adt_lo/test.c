#include "listas.h"
#include <unistd.h>
#define MAX 10
int comparaEnteros(const void *num1, const void *num2){
    return *(int *)num1 - *(int *)num2;
}
void muestraEnteros(const void *clave, const void *info){
    printf("CLAVE: %-3d INFO: %-3d\n", *(int*)clave, *(int*)info);
}
int main(int argc, char* argv[]){
    srand(getpid());
    tipoLista l; 
    printf("Lista declarada\n");
    crear_lista(&l, comparaEnteros, muestraEnteros);
    printf("Lista creada\n");
    imprimir_lista(l);
    int k;
    for(int i = 0; i < MAX; i++){
        k = (rand() % MAX) + 1;
        printf("A insertar en la lista: (%d, %d)\n", k, i);
        if(insertar_lista(&l, k, i) != 0){
            printf("CLAVE EXISTE\n");
        }else{
            printf("todo bien\n");
        }
    }
    imprimir_lista(l);
    /*
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
    */

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


    int clave = 5, info = 12, anterior, siguiente, ultima;
    insertar_lista(&l, clave, info);
    info = 0;
    
    vaciar_lista(&l);

    imprimir_lista(l);
    
    if(recuPrim_lista(l, &primero) == 0){
        printf("La primer clave de la lista es %d\n", primero);
    } else{
        printf("no se pudo recuperar primera, lista vacía\n");
    }

    if(recuClave_lista(l, clave, &info)){
        printf("Clave %d no existe\n", clave);
    } else{
        printf("La clave %d tiene la info %d\n", clave, info);
    }

    if ((recuAnt_lista(l, clave, &anterior)) == 0){
        printf("La clave anterior a %d es %d\n", clave, anterior);
    }else{
        printf("La clave %d es la primera :O, no tiene anterior\n", clave);
    }

    if ((recuSig_lista(l, clave, &siguiente)) == 0){
        printf("La clave siguiente a %d es %d\n", clave, siguiente);
    }else{
        printf("La clave %d es la última D:, no tiene siguiente\n", clave);
    }

    if(recuUlt_lista(l, &ultima) == 0){
        printf("La última clave de la lista es %d\n", ultima);
    } else{
        printf("no se pudo recuperar última, lista vacía\n");
    }
    vaciar_lista(&l);
    return 0;


}
