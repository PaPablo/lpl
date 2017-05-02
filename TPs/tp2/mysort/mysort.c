#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_LINEAS 	100
#define MAX_CAR 	80
int comparaCadenas(const void *a, const void *b);
void limpiar(char **arreglo, int tam);
int main(int argc, char const *argv[])
{

	char **arreglo, **temp, *line;

	if ((arreglo = (char **)malloc(sizeof(char *))) == NULL){
		perror("*** MALLOC ERROR ***");
		return 1;
	}

	if ((line = (char *)malloc(MAX_CAR+1 * sizeof(char))) == NULL){
		perror("*** MALLOC ERROR ***");
		free(arreglo);
	}

	int i;

	for(i = 0; i < MAX_LINEAS; i++){

		line = fgets(line, MAX_CAR+1, stdin);
		if(line == NULL) break;
		

		if((temp = (char **)realloc(arreglo, ((i+1)*sizeof(char**)))) == NULL){
			perror("*** MALLOC ERROR ***");
			limpiar(arreglo, i);
			return 1;
		}
		
		arreglo = temp;

		if ((arreglo[i] = (char *)malloc((strlen(line) + 1) * sizeof(char))) == NULL){
			perror("*** MALLOC ERROR ***");
			limpiar(arreglo, i);
			return 1;
		}

		strcpy(arreglo[i], line);
	}

	printf("***ANTES DE ORDENAR***\n\n");
	for(int j = 0; j < i; j++){
		printf("%-5d%s\n", j, arreglo[j]);
	}

	qsort(arreglo, i, sizeof(char *), comparaCadenas);

	printf("\n\n***DESPUES DE ORDENAR***\n\n");
	for(int j = 0; j < i; j++){
		printf("%-5d%s\n", j, arreglo[j]);
	}

	limpiar(arreglo, i);
	return 0;
}


int comparaCadenas(const void *a, const void *b){
	return strcmp(*(char **)a, *(char **)b);	
}

void limpiar(char **arreglo, int tam){
	for(int i = 0; i < tam; i++){
		free(arreglo[i]);
	}
	free(arreglo);
	return;
}
