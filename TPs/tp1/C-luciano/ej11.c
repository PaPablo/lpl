#include <stdio.h>
#include <stdlib.h>

#define MAX(a,b,c) (((a) > (b) && (a) > (c)) ? a : (b > c ? b : c))


int main(int argc, char *argv[]){

	if(argc < 4){
		printf("***ERROR. MISSING ARGUMENTS***\n");
		exit(1);
	}	
	int 	x=atoi(argv[1]), 
		y=atoi(argv[2]), 
		z=atoi(argv[3]);

	printf("The greatest between %d, %d, and %d is: %d\n", x, y, z, MAX(x,y,z));

	return 0;
}
