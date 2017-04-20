#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_LINEAS 	100
#define MAX_CAR 	80
int comparaCadenas(const void *a, const void *b);

int main(int argc, char const *argv[])
{
	char 	**arreglo = (char **)malloc(MAX_LINEAS * sizeof(char **)),
			*line;
	int i;
	for(i = 0; i < MAX_LINEAS; i++){

		arreglo[i] = (char *)malloc(MAX_CAR * sizeof(char *));
		line = fgets(line, MAX_CAR+1, stdin);
		if((line != NULL) || (line != EOF)) break;
		
		if ((arreglo[i] = (char *)malloc(strlen(line) + 1)) == NULL){
			perror("*** MALLOC ERROR ***");
			limpiar(arreglo);
			return 1;
		}

		strcpy(arreglo[i], line);
	}

	qsort(arreglo, i, sizeof(char *), comparaCadenas);

	for(int j = 0; j < i; j++){
		printf("%-3d\t%s\n", j, arreglo[j]);
	}

	return 0;
}


int comparaCadenas(const void *a, const void *b){
	return strcmp(*(char*)a, *(char *)b);	
}