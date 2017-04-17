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

int cantPalabras();
int inicializar_arreglo(int *arreglo, int tope);
int esPalabraReservada(char *cadena);
int registrarOcurrencia(char *palabra, t_lista lista);
void limpiar(t_lista lista);



#endif //HERRAMIENTAS_H