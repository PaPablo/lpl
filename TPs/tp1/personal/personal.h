#ifndef PERSONAL_H
#define PERSONAL_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "fechas.h"
#include "tools/tools.h"

#define FUNCIONES_EMPLEADOS 3
#define FUNCTION_SUCCESS 0
#define FUNCTION_FAILURE 1

#define clear() printf("\033[H\033[J")
#define GET_CHAR() getchar();getchar();
#define MEM_ERROR() {perror("***NO SE PUDO RESERVAR MEMORIA.***"); exit(1);}

typedef enum {
	EMPLEADO,
	GERENTE
} t_cargo;

typedef enum {
	MAQUINISTA,
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

typedef union {
	t_datos_gerente datos_gerente;
	t_datos_empleado datos_empleado;
} t_info;

typedef struct {
	t_persona datos_personales;
	t_cargo cargo;
	t_info info_adicional;
} Personal;

void mostrarMenu(Personal arreglo[], int *tam);

#endif //PERSONAL_H
