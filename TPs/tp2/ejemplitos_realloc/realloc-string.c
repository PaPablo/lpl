#include <string.h>
#include <stdio.h>
#include <stdlib.h>

#define EXIT "exit"
int main(int argc, char const *argv[])
{
	char 	**arreglo,
			**tmp,
			*line;
	int i = 0;

	arreglo = (char **)malloc(sizeof(char **));
	
	if(arreglo == NULL){
		perror("*** MEMORY ERROR ***");
		return 1;
	}

	while(1){
		printf("INPUT: ");
		scanf(" %m[^\n]", &line);
		if (strcmp(line, EXIT) == 0) break;
		i++;
		tmp = (char **)realloc(arreglo, i * sizeof(char **));
		
		if (tmp == NULL){
			perror("*** MEMORY ERROR ***");
			break;
		}

		arreglo = tmp;

		arreglo[i-1] = (char *)malloc((strlen(line) + 1));
		//acá habría que chequear si se reservar memoria correctamente
		//puede ser que arreglo[i-1] sea NULL si el malloc pinchó
		strcpy(arreglo[i-1], line);
	}

	for(int j = 0; j < i; j++){
		printf("arreglo[%d] = %s\n", j, arreglo[j]);
		free(arreglo[j]);
	}

	free(arreglo);
	return 0;
}