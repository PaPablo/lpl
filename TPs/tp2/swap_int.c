#include <stdio.h>
#include <stdlib.h>

void swap_int(int *x, int *y);
int main(int argc, char *argv[]){


    int a, b;
    
    printf("Ingrese dos enteros a swapear: ");
    scanf("%d %d", &a, &b);
    printf("\nIngresó a = %d y b = %d\n", a, b);
    swap_int(&a, &b);
    printf("Después del SWAP: a = %d b = %d\n", a, b);
    

    return 0;
}


void swap_int(int *x, int *y){

    int aux = *x;
    *x = *y;
    *y = aux;
}
