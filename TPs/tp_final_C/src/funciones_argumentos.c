#include <stdio.h>
#include <stdlib.h>
#include <libpq-fe.h> 
#include <string.h>
#include <malloc.h>
#include "argumentos.h"
#include "config.h"
#include "utils.h"

int argumento_f (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_f\n");
}


int argumento_l (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_l\n");
}
int argumento_paciente (int nivel, int argc, char *argv[], FILE *out){
    //imprime listado de pacientes
    int size;
    void *list;
    obj_paciente *pac;
    pac = paciente_new();
    if((size = pac->findAll(pac, &list, NULL)) == 0) 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
    else{
        for(int i = 0; i < size; i++){
            pac = ((obj_paciente**)list)[i];
            fprintf(out, "%4d|%-10d|%-20s|%-20s\n", i, pac->dni,pac->apellido,pac->nombres);
        }
    }

    return 0;
}
int argumento_obrasocial (int nivel, int argc, char *argv[], FILE *out){

    //imprime listado de pacientes
    int size;
    void *list;
    obj_obrasocial *obs;
    obs = obrasocial_new();
    if((size = obs->findAll(obs, &list, NULL)) == 0) 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
    else{
        for(int i = 0; i < size; i++){
            obs = ((obj_obrasocial**)list)[i];
            fprintf(out, "%4d|%-10d|%-20s\n", i, obs->codigo,obs->nombre);
        }
    }

    return 0;
}
int argumento_profesional (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_profesional\n");
}
int argumento_turnos (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_turnos\n");
}
int argumento_custom (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_custom\n");
}
int argumento_esp (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_esp\n");
}
int argumento_act (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_act\n");
}
int argumento_inact (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_inact\n");
}
int argumento_pdni (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_pdni\n");
}
int argumento_profmat (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_profmat\n");
}
int argumento_profid (int nivel, int argc, char *argv[], FILE *out){

    printf("argumento_profid\n");
}
