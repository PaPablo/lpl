#include <stdio.h>
#include <stdlib.h>

int main(int argc, char const *argv[])
{
	int *arreglo = (int *)malloc(sizeof(int)),
		*tmp,
		i = 0, num;

	while(1){
		printf("INPUT: ");
		scanf("%d", &num);
		if (num == 0) break;
		i++;
		/*Hacemos el realloc en un puntero auxiliar
		1. Casteamos el resultado al tipo de puntero con el que estemos trabajando
		2. El primer parámetro del realloc es la dirección o el puntero con el que estamos trabajando
		osea, el que queremos reallocar jeje para el que queremos agrandar el espacio
		3. le pasamos el nuevo tamaño que queremos que tenga, por eso antes del realloc
		incrementamos ese i que viene a ser un contador (el tamaño por supuesto es en bytes)*/
		tmp = (int *)realloc(arreglo, i * sizeof(int));
		

		/*Si no se pudo asignar memoria, realloc devuelve NULL
		por eso se trabaja con el auxiliar; si asignabas el realloc directamente
		a tu puntero, y llegaba a pinchar, perdías la referencia a toda la memoria
		que ya tenías asignada, se entiende?*/
		if (tmp == NULL){
			perror("*** MEMORY ERROR ***");
			break;
		}

		/*Si llegó hasta acá, viene todo bien.
		Asignamos el puntero tmp que tiene el nuevo espacio de memoria en heap asignado
		a nuestro puntero con el que estamos trabajando (arreglo)*/
		arreglo = tmp;

		/*asignamos el nuevo elemento que queremos agregar
		estoy haciendo la asignación en arreglo[i-1] porque a i ya lo incrementé antes
		si hago en arreglo[i], lo estaría asignando en una posición que no es mía*/
		arreglo[i-1] = num;

	}

	for(int j = 0; j < i; j++){
		printf("arreglo[%d] = %d\n", j, arreglo[j]);
	}

	free(arreglo);
	return 0;
}