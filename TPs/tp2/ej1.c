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