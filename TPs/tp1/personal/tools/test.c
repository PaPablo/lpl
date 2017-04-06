#include "tools.h"

int main(int argc, char *argv[]){

    int i = 0;
    do{
        printf("NUM = %d\n", i++);
    }while(confirma("Desea continuar?"));

    return 0;
}
