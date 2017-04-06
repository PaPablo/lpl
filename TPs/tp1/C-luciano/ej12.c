#include <stdio.h>
#include <stdlib.h>

#define PRODUCTO(x,y) ((x)*(y))

int main(int argc, char *argv[]){
	

	if(argc < 3){
		printf("no way\n");
		exit(1);
	}

	int 	x = atoi(argv[1]),
		y = atoi(argv[2]);
	
	x = PRODUCTO(x + 2, y);


	printf("%d\n", x);
	//printf("%d x %d = %d\n", x, y, PRODUCTO(x,y));

	return 0;
}
