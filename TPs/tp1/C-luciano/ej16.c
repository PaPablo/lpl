#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>

#define MAX_DAYS 7
#define MAX_MONTHS 12

char *input_check(char *a[], int max);

int main(int argc, char *argv[]){
	
	char *cad = NULL;
	//printf("%d %s\n\n", argc, argv[1]);
	
	if((argc == 2) && (strcmp(argv[1], "-m") == 0 || strcmp(argv[1], "--month") == 0)){
		char *months[] = 	{"","Enero", "Febrero", "Marzo", "Abril", "Mayo",
						 "Junio", "Julio", "Agosto", "Septiembre",
						 "Octubre", "Noviembre", "Diciembre"};
		cad = input_check(months, MAX_MONTHS);
	}else{
		char *days[] = {"","Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"};
		cad = input_check(days, MAX_DAYS);	
	}
	
	if(cad){
		printf("El número ingresado se corresponde con: %s\n", cad);	
	}else
		printf("Entrada incorrecta\n");
	return 0;
}

char *input_check(char *a[], int max){

	printf("Ingrese un número entre 1 y %d: ", max);
	int input;
	scanf("%d", &input);
	
	if(input >= 1 && input <= max){
		return a[input];
	}

	return NULL;
}
