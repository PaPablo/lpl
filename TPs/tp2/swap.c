#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int swap(void *x, void *y, size_t size);
int main(int argc, char *argv[]){

    int a = 3, b = 7, a2 = 11, *pi1 = &a, *pi2 = &a2;
    char c = 'j', k = 'o', 
         *pc1 = "hola como va todo bien?", *pc2 = "chau";
    printf("***BEFORE SWAP***\n");
    printf("a = %d, b = %d\n", a, b);
    printf("c = %c, k = %c\n", c, k);
    printf("*pc1 = %s, *pc2 = %s\n", pc1, pc2);
    //printf("*pi1 = %d\n", *pi1);
    
    swap(&a, &b, sizeof(a));
    swap(&c, &k, sizeof(k));
    swap(&pc1, &pc2, sizeof(pc1));
    printf("***AFTER SWAP***\n");
    printf("a = %d, b = %d\n", a, b);
    printf("c = %c, k = %c\n", c, k);
    printf("*pc1 = %s, *pc2 = %s\n", pc1, pc2);


    return 0;
}

int swap(void *x, void *y, size_t size){
    void *aux = malloc((int)size);
    if(aux == NULL){
        perror("***MALLOC ERROR***");
        return -1;
    }

    memcpy(aux, x, size);
    memcpy(x, y, size);
    memcpy(y, aux, size);

    free(aux);
    return 0;
}
