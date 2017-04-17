<<<<<<< HEAD
#include <stdio.h>
#include <stdlib.h>

/* run this program using the console pauser or add your own getch, system("pause") or input loop */

int main(int argc, char *argv[]) {
	printf("Hello World!\n");
	return 0;
}

case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
case hola mundo break for la situación\nprueba return break if final\nif termina
=======
#include <stdio.h>

typedef int (* swaping)(void *a, void*b);

int swapInt(void *a,void *b){
	
	int aux = *(int *)a;
	*(int *)a = *(int *)b;
	*(int *)b = aux;
	
	return 0;
}

int swapChar(void *a, void *b){

	char aux = *(char *)a;
	*(char *)a = *(char *)b;
	*(char *)b = aux;
	
	return 0;
}


int swap(void *a, void *b,swaping f){
	f(a,b);
	return 0;
}


int main(int argc, char const *argv[])
{
	char a = 'a', b = 'b';
	printf("a = %cs\nb = %cs\n",a,b);

	printf("\nSWAP\n\n");
	
	swap(&a,&b,swapChar);

	printf("a = %cs\nb = %cs\n",a,b);

	return 0;
}
>>>>>>> 255f99cb7d14a3e59b12376def76dc6fe776baef
