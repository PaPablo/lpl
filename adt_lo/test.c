#include "listas.h"

int comparaEnteros(const void *num1, const void *num2){
    return *(int *)num1 - *(int *)num2;
}
int main(int argc, char* argv[]){

    tipoLista l; 
    printf("Lista declarada\n");
    crear_lista(&l, comparaEnteros);
    printf("Lista creada\n");
    insertar_lista(l, 2, 3);
    printf("Insertado en la lista: (2, 3)\n");
    vaciar_lista(l);
    printf("Lista eliminada\n");
    return 0;
}
