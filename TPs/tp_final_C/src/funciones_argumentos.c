#include <stdio.h>
#include <stdlib.h>
#include <libpq-fe.h> 
#include <string.h>
#include <malloc.h>
#include "argumentos.h"
#include "config.h"
#include "utils.h"

/*
int argumento_f (int nivel, int argc, char *argv[], FILE* salida){

    printf("argumento_f\n");
}
*/

int argumento_l (int nivel, int argc, char *argv[], FILE* salida){

    printf("argumento_l\n");
}
int argumento_paciente (int nivel, int argc, char *argv[], FILE* salida){
    //imprime listado de pacientes
    int size;
    void *list;
    obj_paciente *pac;
    pac = paciente_new();
    if((size = pac->findAll(pac, &list, NULL)) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }

    fprintf(salida, "%4s| %-10s | %-20s | %-20s| %-15s| %-20s\n\n", "", "DNI", "Apellido", "Nombres", "Teléfono", "Domicilio");
    for(int i = 0; i < size; i++){
        pac = ((obj_paciente**)list)[i];
        fprintf(salida, "%4d| %-10d | %-20s | %-20s| %-15s| %-20s\n", i, pac->dni,pac->apellido,pac->nombres,
                pac->telefono, pac->domicilio);
    }

    return 0;
}
int argumento_obrasocial (int nivel, int argc, char *argv[], FILE* salida){

    int size;
    void *list;
    obj_obrasocial *obs;
    obs = obrasocial_new();
    if((size = obs->findAll(obs, &list, NULL)) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }

    fprintf(salida, "%4s| %-10s | %-20s\n\n", "", "Código", "Nombre");
    for(int i = 0; i < size; i++){
        obs = ((obj_obrasocial**)list)[i];
        fprintf(salida, "%4d| %-10d | %-20s\n", i, obs->codigo,obs->nombre);
    }

    return 0;
}
int argumento_profesional (int nivel, int argc, char *argv[], FILE* salida){

    int size;
    void *list;
    obj_profesional *prof;
    prof = profesional_new();
    if((size = prof->findAll(prof, &list, NULL)) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }

    fprintf(salida, "%-4s | %-4s | %-10s | %-15s | %-15s | %-20s | %-15s | %-20s\n\n", "", "ID", "Mátricula", "Fecha Mátricula", "Apellido", "Nombre", "Teléfono", "ACTIVO/NO-ACTIVO");
    for(int i = 0; i < size; i++){
        prof = ((obj_profesional**)list)[i];
        //fprintf(salida, "%4d| %-10d | %-20s\n", i, obs->codigo,obs->nombre);
        fprintf(salida, "%-4d | %-4d | %-10s | %-15s | %-15s | %-20s | %-15s | %-20s\n", i, prof->id, prof->matricula, prof->fecha_matricula, prof->apellido, prof->nombres, prof->telefono, (prof->activo == 1 ? "ACTIVO" : "NO-ACTIVO"));
    }

    return 0;
}
int argumento_turnos (int nivel, int argc, char *argv[], FILE* salida){

    //imprime listado de pacientes
    int size;
    void *list;
    obj_turnos *tr;
    tr = turnos_new();
    obj_paciente *pac_tr = paciente_new();
    obj_profesional *prof_tr = profesional_new();
    if((size = tr->findAll(tr, &list, NULL)) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }
    else {
        fprintf(salida, "%-4s| %-15s | %-40s | %-20s | %-15s | %-10s | %-40s\n\n", 
                        "", "Dni Paciente", "Nombre y Apellido Paciente", "Fecha y Hora",
                        "ID Profesional", "Matricula", "Nombre Y Apellido Profesional");
        for(int i = 0; i < size; i++){
            tr = ((obj_turnos**)list)[i];
            pac_tr = (obj_paciente *) tr->get_paciente(tr);
            prof_tr = (obj_profesional *) tr->get_profesional(tr);
            fprintf(salida, "%4d| %-15d | %-20s%-20s | %-20s | %-15d | %-10s | %-20s%-20s\n", 
                        i, tr->dnipaciente, pac_tr->nombres, pac_tr->apellido, tr->fechahora, 
                        tr->codigoprofesional, prof_tr->matricula, prof_tr->nombres,prof_tr->apellido);
        }
    }

    return 0;
}
int argumento_custom (int nivel, int argc, char *argv[], FILE* salida){

    printf("argumento_custom\n");
}
int argumento_esp (int nivel, int argc, char *argv[], FILE* salida){

    printf("argumento_esp\n");
}
int argumento_act (int nivel, int argc, char *argv[], FILE* salida){

    printf("argumento_act\n");
}
int argumento_inact (int nivel, int argc, char *argv[], FILE* salida){

    printf("argumento_inact\n");
}
int argumento_pdni (int nivel, int argc, char *argv[], FILE* salida){

    printf("argumento_pdni\n");
}
int argumento_profmat (int nivel, int argc, char *argv[], FILE* salida){

    printf("argumento_profmat\n");
}
int argumento_profid (int nivel, int argc, char *argv[], FILE* salida){

    printf("argumento_profid\n");
}
