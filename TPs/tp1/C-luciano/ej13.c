#include <stdio.h>
#include <stdlib.h>
/*
#define SWAP(a, b) \
    { \
        (a) ^= (b); \
        (b) ^= (a); \
        (a) ^= (b); \
    }
*/
#define SWAP(x, y) { typeof(x) SWAP = x; x = y; y = SWAP; }

int main(int argc, char *argv[]){

	int x = 1, y = 7;
	float f = 4.5, g = 3.14;
	char a = 'r', b = 't';

	printf("INT: x = %d, y = %d\n", x, y);
	SWAP(x,y);
	printf("AFTER SWAP: x = %d, y = %d\n\n", x, y);
	
	printf("FLOAT: f = %.2f, g = %.2f\n", f, g);
	SWAP(f,g);
	printf("AFTER SWAP: f = %.2f, g = %.2f\n\n", f, g);
	
			
	printf("CHAR: a = %c, b = %c\n", a, b);	
	SWAP(a,b);
	printf("AFTER SWAP: a = %c, b = %c\n\n", a, b);	
	
	return 0;
}
