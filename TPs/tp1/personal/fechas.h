#ifndef FECHAS_H
#define FECHAS_H

#include <stdio.h>
#include <stdlib.h>

#define MAX_ANIO 9999

typedef struct{
	unsigned int dia;
	unsigned int mes;
	unsigned int anio;
}fecha_t;

int cantDiasMes(int mes, int anio);
int esBisiesto(int anio);
int esFechaValida(fecha_t fecha);
fecha_t nuevaFecha();

#endif //FECHAS_H
