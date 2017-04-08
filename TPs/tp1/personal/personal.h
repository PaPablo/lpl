#ifndef PERSONAL_H
#define PERSONAL_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "fechas.h"
#include "tools/tools.h"


#define FUNCIONES_EMPLEADOS 4
#define FUNCTION_SUCCESS 0
#define FUNCTION_FAILURE 0

#define MEM_ERROR() {perror("***NO SE PUDO RESERVAR MEMORIA.***"); exit(1);}

typedef enum {
	EMPLEADO = 1,
	GERENTE
} t_cargo;

typedef enum {
	MAQUINISTA = 1,
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

//ABM EMPLEADO
int crear_datos_empleado(t_datos_empleado *nuevo);
void modificar_datos_empleado(t_datos_empleado *empleado);
int obtener_funcion(int *funcion);
void display_funciones();
int nuevo_datos_empleado(t_datos_empleado *nuevo);

//ABM GERENTE
int nuevo_datos_gerente(t_datos_gerente *nuevo);
int obtener_personas_a_cargo(int *personas_a_cargo);
int obtener_nombre_oficina(char *nombre_oficina);

int nuevaPersona(t_persona *nuevo);

void mostrarMenu();

int nuevoPersonal(Personal arreglo[], int *tam);
void mostrarMenu(Personal arreglo[], int *tam);

#endif //PERSONAL_H
