#ifndef PERSONAL_H
#define PERSONAL_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "fechas.h"


typedef enum {
	EMPLEADO = 0,
	GERENTE
} t_cargo;

typedef enum {
	MAQUINISTA = 0,
	SECRETARIO,
	CADETE
} t_funcion_empleado;

typedef struct {
	char *nombre;
	fecha_t fecha_nac;
} t_persona;

typedef struct {
	char *nombre_oficina;
	int empleados_a_cargo;
} t_datos_gerente;

typedef struct {
	t_funcion_empleado funcion;
} t_datos_empleado;

typedef struct {
	t_persona datos_personales;
	t_cargo cargo;
	union {
		t_datos_gerente datos_gerente;
		t_datos_empleado datos_empleado;
	} info_adicional;
} Personal;

void listado_personal(Personal personales[], int tope);
void listado_empleados(Personal personales[], int tope);
void listado_gerentes(Personal personales[], int tope);

#endif //PERSONAL_H
