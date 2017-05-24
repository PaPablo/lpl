#include <stdio.h>
#include <stdlib.h>
#include <libpq-fe.h> 
#include <string.h>
#include <malloc.h>
#include "argumentos.h"
#include "config.h"
#include "utils.h"


int argumento_l (char *arg, FILE* salida){

    char nombre[] = "./TurnosAtencionApp";
    printf("\nAYUDA\n\t%s <paciente> : lista todos los pacientes registrados\n \
    \t%s <obrasocial> : lista todas las obras sociales registradas\n \
    \t%s <profesional> : lista todos los profesionales registrados\n \
    \t\t[-esp] : lista los profesionales con sus especialidades\n \
    \t\t[-act] : lista los profesionales con sus especialidades activas\n \
    \t\t[-inact] : lista los profesionales con sus especialidades inactivas\n \
    \t%s <turnos> : lista todos los turnos registrados\n \
    \t\t[-pdni <DNI>] : lista los turnos del paciente con el DNI ingresado\n \
    \t\t[--prof-mat <MAT>] : lista los turnos que se le asignaron al profesional con la matrícula ingresada\n \
    \t\t[--prof-id <ID>] : lista los turnos que se le asignaron al profesional con el ID ingresado\n \
    \t\t[-anio <AÑO>] : lista todos los turnos que fueron atendidos en el año ingresado\n\n", 
    nombre, nombre, nombre, nombre); 

}



int argumento_paciente (char *arg, FILE* salida){
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


int argumento_obrasocial (char *arg, FILE* salida){

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


int argumento_profesional (char *arg, FILE* salida){

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


int argumento_turnos (char *arg, FILE* salida){

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


int argumento_anio (char *arg, FILE* salida){

    if(arg == NULL){
        printf("\nERROR: No se ingresó ningún año\n");
        return 1;
    }

    int size;
    void *list;
    obj_turnos *tr;
    tr = turnos_new();
    obj_paciente *pac_tr;
    obj_profesional *prof_tr;
    char criterio[256];
    sprintf(criterio, "to_char(turnos.fechahora, 'YYYY-MM-DD HH:MM:SS') ~ '%s.*' and turnos.asistio=1 order by fechahora;", arg);
    if((size = tr->findAll(tr, &list, criterio)) == 0){ 
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

}


int argumento_esp (char *arg, FILE* salida){

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


int argumento_act (char *arg, FILE* salida){

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


int argumento_inact (char *arg, FILE* salida){

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


int argumento_pdni (char *arg, FILE* salida){

    if(arg == NULL){
        printf("\nERROR: No se ingresó ningún DNI\n");
        return 1;
    }

    int size;
    void *list;
    obj_turnos *tr;
    tr = turnos_new();
    char criterio[50] = "dnipaciente = ";
    strcat(criterio, arg);

    obj_paciente *pac_tr;
    obj_profesional *prof_tr;
    if((size = tr->findAll(tr, &list, criterio)) == 0){ 
        printf("El paciente con DNI = %s no tiene turnos registrados\n", arg); // se invoca sin criterio - listar todos...
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
int argumento_profmat (char *arg, FILE* salida){

    if(arg == NULL){
        printf("\nERROR: No se ingresó ninguna matrícula\n");
        return 1;
    }

    int size;
    void *list;
    obj_turnos *tr;
    tr = turnos_new();
    char criterio[50];
    strcpy(criterio,arg);
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
int argumento_profid (char *arg, FILE* salida){

    if(arg == NULL){
        printf("\nERROR: No se ingresó ningún ID\n");
        return 1;
    }

    int size;
    void *list;
    obj_turnos *tr;
    tr = turnos_new();
    char criterio[50] = "codigoprofesional = ";
    strcat(criterio, arg);

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
