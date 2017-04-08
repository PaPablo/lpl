#ifndef PERSONAL_H
#define PERSONAL_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "fechas.h"

typedef enum{
    GERENTE, 
    EMPLEADO
} tipo_t;

typedef enum{
    MAQUINISTA,
    SECRETARIO,
    OFICINISTA,
    LIMPIEZA
} empleado_t;


typedef struct{
    char *nombre_oficina;
    unsigned int cant_empleados;
} gerente_t;

typedef struct{
    char *nombre;
    fecha_t fecha_nac;
} datos_t;

typedef struct{
    tipo_t tipo_personal;
    union{
        gerente_t datos_gerente;
        empleado_t datos_empleado;
    } tipo;
} laboral_t;

typedef struct{
    datos_t datos_personales;
    laboral_t datos_laborales;
} personal_t;

//personal_t nuevoPersonal();
void listadoGerentes(personal_t *lista, int tam);
void listadoEmpleados(personal_t *lista, int tam);
void listadoCompleto(personal_t *lista, int tam);

#endif //PERSONAL_H
