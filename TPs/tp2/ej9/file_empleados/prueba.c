#include <stdio.h>
#include <stdlib.h>
#include "file_emp.h"

struct st{

    int a;
    int b;

};
int main(int argc, char *argv[]){

    FILE *file;
    file = fopen("arc.dat","w+");
    
    struct st *structura = malloc(sizeof(struct st));
    
    fprintf(file,"%d %d ", 1,2);
    fprintf(file,"%d %d ", 4,3);

    // Regresa el puntero de lectura al principio del archivo
    rewind(file);

    fscanf(file, "%d %d",&(structura->a),&(structura->b));
    printf("%d %d\n",structura->a,structura->b);
    
    fscanf(file, "%d %d",&(structura->a),&(structura->b));
    printf("%d %d\n",structura->a,structura->b);
    return 0;

}
