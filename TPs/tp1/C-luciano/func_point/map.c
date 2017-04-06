#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include "map.h"

int incrementar(int i){
    return i+1;
}

int decrementar(int i){
    return i-1;
}

int cuadrado(int i){
    return i*i;
}

int raiz(int i){
    return pow(i, 0.5);
}

int imprimir(int i){
    printf("%d ", i);
    return i;
}

void map(int a[], tOp f, int max){
    for(int i = 0; i < max; i++){
        a[i] = f(a[i]);
    }
}

void mapAndPrint(int a[], tOp f, int max){
    map(a, f, max);
    map(a, imprimir, max);
    printf("\n");
}

/*
int main(int argc, char *argv[]){
    
    int a_int[] = {0,1,2,3,4,5,6,7,8,9};
    tOp a_tOp[] = {incrementar, decrementar, cuadrado, raiz};
     
    for(int i = 0; i < ((int)(sizeof(a_tOp)/sizeof(tOp))); i++){
        mapAndPrint(a_int, a_tOp[i], ((int)(sizeof(a_int)/sizeof(int))));
    }
    //printf("sizeof a top = %d\n", (int)(sizeof(a_tOp)/sizeof(tOp)));

    return 0;
}*/
