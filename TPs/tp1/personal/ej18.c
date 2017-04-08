#include "personal.h"

#define MAX_PERSONAL 10

int main(int argc, char const *argv[])
{
	
	Personal p[MAX_PERSONAL];
	int indice_personal = 0;

	mostrarMenu(p, &indice_personal);
	return EXIT_SUCCESS;
}