#include "herramientas.h"

//herramientas.c
extern char *palabras_reservadas[];

int main(int argc, char const *argv[])
{
	
	t_lista lista_ocurrencias;
	lista_ocurrencias.cant_palabras = 0;
	FILE *archivo;

	char 	*buff,
			*token,
			*nombre,
			delim[] = " \t(){};\n!=";

	//reservamos espacio para MAX_CHAR caracteres más el '\0'
	if((buff = (char *)malloc((MAX_CHAR + 1) * sizeof(char))) == NULL){
		MEMORY_ERROR();
		fclose(archivo);
	}

	while(1){
		clear();
		printf("Ingrese el nombre del archivo (ingrese \"salir\" para salir): ");
		scanf(" %m[^\n]", &nombre);
		
		if(strcmp(nombre, SALIDA) == 0) 
			return 0;

		archivo = fopen(nombre,"r");

		if(archivo == NULL){
			printf("*** NO SE PUDO ABRIR EL ARCHIVO \"%s\"***\n", nombre);
            GETCHAR();
		}else 
			break;
	}



	int lineas = 0;
	int pos_reservada;
	if(archivo == NULL)
		exit(EXIT_FAILURE);


	while((fgets(buff, MAX_CHAR + 1, archivo)) != NULL){
		token = strtok(buff, delim);

		while(token != NULL){

			if((pos_reservada = esPalabraReservada(token)) != -1){
				if ((registrarOcurrencia(palabras_reservadas[pos_reservada], lineas, &lista_ocurrencias)) == -1){
					limpiar(&lista_ocurrencias);
					return 1;
				}
			}
			
			token = strtok(NULL, delim);

		}
		lineas++;

	}

	clear();

	printf("Cantidad de líneas leídas: %d\n\n", lineas);
	if(lista_ocurrencias.cant_palabras <= 0){
        printf("No se encontraron palabras reservadas en el archivo \"%s\"\n\n", nombre);
    }else{
        printf("Palabras reservadas encontradas en el archivo \"%s\":\n", nombre);

	    for(int i = 0; i < lista_ocurrencias.cant_palabras; i++){
		    printf("%-10s: ", lista_ocurrencias.arreglo[i].palabra);
		    for(int j = 0; j < lista_ocurrencias.arreglo[i].cant_ocurrencias; j++){
			    printf("%-3d", lista_ocurrencias.arreglo[i].ocurrencias[j]);
		    }
		    printf("\n");
	    }
    }

    fclose(archivo);
    free(buff);
	limpiar(&lista_ocurrencias);

	return 0;
}
