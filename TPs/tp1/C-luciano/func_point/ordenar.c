#include <stdio.h>
#include <stdlib.h>
#include "map.h"

#define SIZE_INT_ARRAY(a) (sizeof(a)/sizeof(int))
int compEnteros (const void* a, const void* b){
    return (*(int*)a - *(int*)b);
}

int main(){

    int arreglo[] = {3,5,2,8};
    printf("BEFORE SORT: ");
    map(arreglo, imprimir, SIZE_INT_ARRAY(arreglo));
    qsort(arreglo, SIZE_INT_ARRAY(arreglo), sizeof(int), compEnteros);
    printf("\nAFTER SORT: ");
    map(arreglo, imprimir, SIZE_INT_ARRAY(arreglo));
    printf("\n");
    return 0;
}

