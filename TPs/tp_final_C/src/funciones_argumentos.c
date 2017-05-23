#include <stdio.h>
#include <stdlib.h>
#include <libpq-fe.h> 
#include <string.h>
#include <malloc.h>
#include "argumentos.h"
#include "config.h"
#include "utils.h"


int argumento_l (int nivel, int argc, char *argv[], FILE* salida){

    printf("\nAYUDA -l\n\t./TurnosAtencionApp -l <paciente | obrasocial | profesional | turnos | custom>\n\n");
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

    int size;
    void *list;
    obj_turnos *tr;
    tr = turnos_new();
    
    obj_paciente *pac_tr;
    obj_profesional *prof_tr;
    if((size = tr->findAll(tr, &list, "dnipaciente > 0 order by fechahora")) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }
    fprintf(salida, "%-4s| %-10s | %-32s | %-20s | %-4s | %-8s | %-32s\n\n", "", "DNI", "Paciente", "Fecha y Hora", "ID", "Mát.", "Profesional");
    for(int i = 0; i < size; i++){
        tr = ((obj_turnos**)list)[i];
        pac_tr = (obj_paciente *)tr->get_paciente(tr);
        prof_tr = (obj_profesional *)tr->get_profesional(tr);
        fprintf(salida, "%-4d| %-10d | %-15.15s, %-15.15s | %-20s | %-4d | %-8s | %-15.15s, %-15.15s\n", i, tr->dnipaciente, pac_tr->nombres, pac_tr->apellido, tr->fechahora, tr->codigoprofesional, prof_tr->matricula, prof_tr->nombres, prof_tr->apellido);
    }

    return 0;
}


int argumento_custom (int nivel, int argc, char *argv[], FILE* salida){

    printf("argumento_custom\n");
}


int argumento_esp (int nivel, int argc, char *argv[], FILE* salida){

    int size;
    void *list;
    obj_profesional_especialidad *prof_esp = profesional_especialidad_new();
    obj_profesional *prof;
    obj_especialidad *esp;
    if((size = prof_esp->findAll(prof_esp, &list, "codigoprofesional > 0 order by codigoprofesional")) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }

    fprintf(salida, "%-3s | %-3s | %-12s | %-20s | %-24s | %-12s | %-10s | %-10s\n\n", "", "CP", "Apellido", "Nombres", "Especialidad", "Fecha alta", "Estado", "Observaciones");
    for(int i = 0; i < size; i++){
        prof_esp = ((obj_profesional_especialidad **)list)[i];
        prof = (obj_profesional *)prof_esp->get_profesional(prof_esp); 
        esp = (obj_especialidad *)prof_esp->get_especialidad(prof_esp);
        fprintf(salida, "%-3d | %-3d | %-12s | %-20s | %-25.25s | %-12s | %-10s | %-10.10s\n", i, prof_esp->codigoprofesional, prof->apellido, prof->nombres, esp->nombre, prof_esp->fechaalta, (prof_esp->disponible == 1 ? "ACTIVO" : "INACTIVO"), prof_esp->observaciones);

    }

    return 0;
}


int argumento_act (int nivel, int argc, char *argv[], FILE* salida){

    int size;
    void *list;
    obj_profesional_especialidad *prof_esp = profesional_especialidad_new();
    obj_profesional *prof;
    obj_especialidad *esp;
    if((size = prof_esp->findAll(prof_esp, &list, "codigoprofesional > 0 order by codigoprofesional")) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }

    fprintf(salida, "%-3s | %-3s | %-12s | %-20s | %-24s | %-12s | %-10s | %-10s\n\n", "", "CP", "Apellido", "Nombres", "Especialidad", "Fecha alta", "Estado", "Observaciones");
    for(int i = 0; i < size; i++){
        prof_esp = ((obj_profesional_especialidad **)list)[i];
        if(prof_esp->disponible) continue;
        prof = (obj_profesional *)prof_esp->get_profesional(prof_esp); 
        esp = (obj_especialidad *)prof_esp->get_especialidad(prof_esp);
        fprintf(salida, "%-3d | %-3d | %-12s | %-20s | %-25.25s | %-12s | %-10s | %-10.10s\n", i, prof_esp->codigoprofesional, prof->apellido, prof->nombres, esp->nombre, prof_esp->fechaalta, "ACTIVO", prof_esp->observaciones);

    }

    return 0;
}


int argumento_inact (int nivel, int argc, char *argv[], FILE* salida){

    int size;
    void *list;
    obj_profesional_especialidad *prof_esp = profesional_especialidad_new();
    obj_profesional *prof;
    obj_especialidad *esp;
    if((size = prof_esp->findAll(prof_esp, &list, "codigoprofesional > 0 order by codigoprofesional")) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }

    fprintf(salida, "%-3s | %-3s | %-12s | %-20s | %-24s | %-12s | %-10s | %-10s\n\n", "", "CP", "Apellido", "Nombres", "Especialidad", "Fecha alta", "Estado", "Observaciones");
    for(int i = 0; i < size; i++){
        prof_esp = ((obj_profesional_especialidad **)list)[i];
        if(!(prof_esp->disponible)) continue;
        prof = (obj_profesional *)prof_esp->get_profesional(prof_esp); 
        esp = (obj_especialidad *)prof_esp->get_especialidad(prof_esp);
        fprintf(salida, "%-3d | %-3d | %-12s | %-20s | %-25.25s | %-12s | %-10s | %-10.10s\n", i, prof_esp->codigoprofesional, prof->apellido, prof->nombres, esp->nombre, prof_esp->fechaalta, "INACTIVO", prof_esp->observaciones);

    }

    return 0;
}


int argumento_pdni (int nivel, int argc, char *argv[], FILE* salida){

    //imprime listado de pacientes
    int size;
    void *list;
    obj_turnos *tr;
    tr = turnos_new();
    char criterio[50] = "dnipaciente = ";
    strcat(criterio, argv[nivel+1]);

    obj_paciente *pac_tr;
    obj_profesional *prof_tr;
    if((size = tr->findAll(tr, &list, criterio)) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }
    fprintf(salida, "%-4s| %-10s | %-32s | %-20s | %-4s | %-8s | %-30s\n\n", 
                    "", "DNI", "Paciente", "Fecha y Hora",
                    "ID", "Mát.", "Profesional");
    for(int i = 0; i < size; i++){
        tr = ((obj_turnos**)list)[i];
        pac_tr = (obj_paciente *) tr->get_paciente(tr);
        prof_tr = (obj_profesional *) tr->get_profesional(tr);
        fprintf(salida, "%4d| %-10d | %-15.15s, %-15s | %-20s | %-4d | %-8s | %-15.15s, %-15s\n", 
                    i, tr->dnipaciente, pac_tr->nombres, pac_tr->apellido, tr->fechahora, 
                    tr->codigoprofesional, prof_tr->matricula, prof_tr->nombres,prof_tr->apellido);
    }

    return 0;
}
int argumento_profmat (int nivel, int argc, char *argv[], FILE* salida){

    //imprime listado de pacientes
    int size;
    void *list;
    obj_turnos *tr;
    tr = turnos_new();
    char criterio[50];
    strcpy(criterio,argv[nivel+1]);
    obj_paciente *pac_tr;
    obj_profesional *prof_tr;
    if((size = tr->findAll(tr, &list, NULL)) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }
    fprintf(salida, "%-4s| %-10s | %-32s | %-20s | %-4s | %-8s | %-30s\n\n", 
                    "", "DNI", "Paciente", "Fecha y Hora",
                    "ID", "Mát.", "Profesional");
    for(int i = 0; i < size; i++){
        tr = ((obj_turnos**)list)[i];
        pac_tr = (obj_paciente *) tr->get_paciente(tr);
        prof_tr = (obj_profesional *) tr->get_profesional(tr);
        if(strcmp(prof_tr->matricula,criterio)) continue; 
        fprintf(salida, "%4d| %-10d | %-15.15s, %-15s | %-20s | %-4d | %-8s | %-15.15s, %-15s\n", 
                    i, tr->dnipaciente, pac_tr->nombres, pac_tr->apellido, tr->fechahora, 
                    tr->codigoprofesional, prof_tr->matricula, prof_tr->nombres,prof_tr->apellido);
    }

    return 0;
}
int argumento_profid (int nivel, int argc, char *argv[], FILE* salida){

    //imprime listado de pacientes
    int size;
    void *list;
    obj_turnos *tr;
    tr = turnos_new();
    char criterio[50] = "codigoprofesional = ";
    strcat(criterio, argv[nivel+1]);

    obj_paciente *pac_tr;
    obj_profesional *prof_tr;
    if((size = tr->findAll(tr, &list, criterio)) == 0){ 
        printf("No recuperó nada\n"); // se invoca sin criterio - listar todos...
        return 1;
    }
    fprintf(salida, "%-4s| %-10s | %-32s | %-20s | %-4s | %-8s | %-30s\n\n", 
                    "", "DNI", "Paciente", "Fecha y Hora",
                    "ID", "Mát.", "Profesional");
    for(int i = 0; i < size; i++){
        tr = ((obj_turnos**)list)[i];
        pac_tr = (obj_paciente *) tr->get_paciente(tr);
        prof_tr = (obj_profesional *) tr->get_profesional(tr);
        fprintf(salida, "%4d| %-10d | %-15.15s, %-15s | %-20s | %-4d | %-8s | %-15.15s, %-15s\n", 
                    i, tr->dnipaciente, pac_tr->nombres, pac_tr->apellido, tr->fechahora, 
                    tr->codigoprofesional, prof_tr->matricula, prof_tr->nombres,prof_tr->apellido);
    }

    return 0;
}
