#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define MAX 256
/*  se cuenta ocurrencia de los caracteres ascii  */


int main(int argc, char *argv[]) {
	int tabla_ascii[MAX];
	int i;
	//char *cadena="prueba cadena 1133 4  0392 4rRSWA FFWd";
	char *cadena = (argc > 1) ? argv[1] : NULL;

	if(cadena == NULL){
		//printf("***ERROR. WRONG AMOUNT OF PARAMETERS***\n");
		perror("***ERROR. WRONG AMOUNT OF PARAMETERS***\n");
		exit(1);
	}
	//inicializar
	for(i=0;i<MAX;++i)
	{
		tabla_ascii[i]=0;
	}
	//procesar cadena y contar ocurrencias
	for(i=0;i<strlen(cadena);++i)
	{
		tabla_ascii[cadena[i]]++;
	}
	//mostrar donde se conto.
	for(i=0;i<MAX;++i)
	{
		if(tabla_ascii[i])
		  printf("%c: %d\n",i,tabla_ascii[i]);
	}
	//system("pause");
	return 0;
}
