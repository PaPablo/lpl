#include "herramientas.h"


//herramientas.c
extern char *palabras_reservadas[];

int main(int argc, char const *argv[])
{
	
	//int ocurrencias[MAX_PALABRAS_RESERVADAS];
	//inicializar_arreglo(ocurrencias,MAX_PALABRAS_RESERVADAS);
	t_lista lista_ocurrencias;
	lista_ocurrencias.cant_palabras = 0;
	FILE *archivo;
	size_t len = 0;

	char *buff = NULL,
		*token,
		delim[] = " \t(){};\n!=";

	char *nombre = "ejemplo.c";
	archivo = fopen(nombre,"r");

	if(archivo == NULL){
		printf("*** NO SE PUDO ABRIR EL ARCHIVO %s***", nombre);
		return 1;
	}

	int lineas = 0;
	int pos_reservada;
	if(archivo == NULL)
		exit(EXIT_FAILURE);

	while((getline(&buff, &len, archivo)) != -1){
		token = strtok(buff, delim);

		while(token != NULL){

			if((pos_reservada = esPalabraReservada(token)) != -1){
				if ((registrarOcurrencia(palabras_reservadas[pos_reservada], lineas, &lista_ocurrencias)) == -1){
					limpiar(lista_ocurrencias);
					return 1;
				}
			}
			
			token = strtok(NULL, delim);

		}
		lineas++;

	}

	printf("\nCantidad de líneas leídas: %d\n\n", lineas);
	printf("Palabras reservadas encontradas:\n");

	
	for(int i = 0; i < lista_ocurrencias.cant_palabras; i++){
		printf("%s\t: ", lista_ocurrencias.arreglo[i].palabra);
		for(int j = 0; j < lista_ocurrencias.arreglo[i].cant_ocurrencias; j++){
			printf("%d ", lista_ocurrencias.arreglo[i].ocurrencias[j]);
		}
		printf("\n");
	}

	limpiar(lista_ocurrencias);
	return 0;
}
