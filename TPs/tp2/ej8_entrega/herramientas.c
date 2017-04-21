#include "herramientas.h"

char *palabras_reservadas[] = 	{"break","case","default","do",
								"else","for","if","return","switch",
								"void","while","exit","static","extern"};

int cantPalabras(){
	return (int)(sizeof(palabras_reservadas) / sizeof(char *));
}

int esPalabraReservada(char *cadena){

	for(int i = 0; i < cantPalabras(); i++){
		if(!strcmp(cadena, palabras_reservadas[i]))
			return i;	
	}

	return -1;
}

int yaRegistrada(char *p, t_lista *lista){
    /*chequeamos si la palabra reservada ya tiene un nodo en la lista*/
    for(int i = 0; i < lista->cant_palabras; i++){
    	if (strcmp(p, lista->arreglo[i].palabra) == 0){
    		return i;
    	}
    }

    return -1;
}

int nuevaPalabra(t_palabra *nodo, char *palabra){
	if ((nodo->palabra = (char *)malloc(strlen(palabra) + 1)) == NULL) return -1;
	strcpy(nodo->palabra, palabra);

	if ((nodo->ocurrencias = (int *)malloc(sizeof(int))) == NULL) return -1;

	nodo->cant_ocurrencias = 0;
	
	return 0;
}
int registrarOcurrencia(char *palabra, int linea, t_lista *lista){
	/*Si la palabra ya está registrada, incrementamos su contador de ocurrencias
	y almacenamos la línea en la que se registró
	Si no está registrada, tenemos que crearle un nodo nuevo, inicializar su contador a 0
	y almacenar la línea en la que se registró (crear también el arreglo de entero para almacenar las líneas)*/
	int pos;
	if((pos = yaRegistrada(palabra, lista)) == -1){
		//se registra una nueva palabra, se incrementa el contador
		lista->cant_palabras++;

		t_palabra nuevo;
		//se inicializa el nodo
		if((nuevaPalabra(&nuevo, palabra)) == -1){
			MEMORY_ERROR();
			return -1;
		}

		//se reserva espacio para el nuevo nodo
		t_palabra *tmp = (t_palabra *)realloc(lista->arreglo, lista->cant_palabras * sizeof(t_palabra));
		if (tmp == NULL){
			MEMORY_ERROR();
			return -1;
		}

		//se almacena el nuevo nodo
		lista->arreglo = tmp;
		pos = (lista->cant_palabras) - 1;
		lista->arreglo[pos] = nuevo;
	}

	//se incrementa la cantidad de veces que apareció la palabra
	//pos tiene la posicion del nodo en el arreglo de la palabra deseada
	lista->arreglo[pos].cant_ocurrencias++;
	//se reserva espacio para almacenar la línea en la que apareció
	int *tmp = (int *)realloc(lista->arreglo[pos].ocurrencias, lista->arreglo[pos].cant_ocurrencias * sizeof(int));
	
	if (tmp == NULL){
		MEMORY_ERROR();
		return -1;
	}

	//se almacena la línea en la que apareció
	lista->arreglo[pos].ocurrencias = tmp;
	lista->arreglo[pos].ocurrencias[(lista->arreglo[pos].cant_ocurrencias) - 1] = linea+1;


	return 0;
}

void limpiar(t_lista *lista){
	for(int i = 0; i < lista->cant_palabras; i++){
		free(lista->arreglo[i].ocurrencias);
		free(lista->arreglo[i].palabra);
	}
    free(lista->arreglo);
}
