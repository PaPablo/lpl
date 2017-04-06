#include "fechas.h"

/*
	Programa de prueba para las estructuras de fechas (fechas.h)
*/
int main(int argc, char *argv[]){

    fecha_t fecha = nuevaFecha();

    printf("\nAnio: %d\nMes: %d\nDia: %d\n", fecha.anio, fecha.mes, fecha.dia);
	return 0;
}
