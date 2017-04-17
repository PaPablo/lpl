#include "herramientas.h"

char *palabras_reservadas[] = 	{"break","case","default","do",
								"else","for","if","return","switch",
								"void","while","exit","static","extern"};

int cantPalabras(){
	return (int)(sizeof(palabras_reservadas) / sizeof(char *));
}

int inicializar_arreglo(int *arreglo, int tope){
	for(int i = 0; i < tope;i++){
		arreglo[i] = 0; 
	}
	return 0;
}

int esPalabraReservada(char *cadena){
	for(int i = 0; i < cantPalabras(); i++){
		if(!strcmp(cadena, palabras_reservadas[i]))
			return i;	
	}

	return -1;
}

int yaRegistrada(char *l, t_lista lista){
    /*chequeamos si la palabra reservada ya tiene un nodo en la lista*/
    for(int i = 0; i < lista.cant_palabras; i++){

    }

    return 0;
}

int registrarOcurrencia(char *palabra, t_lista lista){
	/*Si la palabra ya está registrada, incrementamos su contador de ocurrencias
	y almacenamos la línea en la que se registró
	Si no está registrada, tenemos que crearle un nodo nuevo, inicializar su contador a 1
	y almacenar la línea en la que se registró (crear también el arreglo de entero para almacenar las líneas)*/
	//if(yaRegistrada(palabra, lista))

	return 0;
}

void limpiar(t_lista lista){

}