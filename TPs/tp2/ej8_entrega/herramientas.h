#ifndef HERRAMIENTAS_H
#define HERRAMIENTAS_H

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

typedef struct 
{
	char *palabra;
	int *ocurrencias;
	int cant_ocurrencias;
}t_palabra;

typedef struct 
{
	t_palabra *arreglo;
	int cant_palabras;
}t_lista;

#define SALIDA "salir"
#define MAX_CHAR 256

#define MEMORY_ERROR() perror("*** ERROR DE MEMORIA ***");
#define clear() printf("\033[H\033[J")
#define GETCHAR() getchar();getchar()

int esPalabraReservada(char *cadena);
int registrarOcurrencia(char *palabra, int linea, t_lista *lista);
void limpiar(t_lista *lista);



#endif //HERRAMIENTAS_H