#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#define MAX 10

int get_input(char **buf);
int is_numeric_string(char *str);
int empty_string(char *str);

int main(int argc, char *argv[]){

	char *line = NULL;
	int i = 0, acum = 0, n;
	
	while(i < MAX){
		printf("\nINPUT A NUMBER: ");
		get_input(&line);
	
		if (!is_numeric_string(line) || empty_string(line)) continue;
		
		n = atoi(line);
		if (!n) break;

		acum += n;
		i++;
		 
	}

	printf("AMOUNT OF INPUTTED NUMBERS: %d\n", i);
	printf("SUM: %d\n", acum);
	
	return 0;
}

int get_input(char **buf){
//inputs a line from stdin
	size_t max = 0;
	getline(buf, &max, stdin);
	return 0;
}

int is_numeric_string(char *str){
//checks if a string contains only numbers. Retuns 0 if the string str has a non-digit char, and 1 if it has only numbers.
	for(int i = 0; i < (strlen(str) - 1); i++){
		if ( (!isdigit(str[i])) && (str[i] != '-') ){
			printf("WRONG INPUT. NON-DIGIT CHARACTER\n");
			return 0;
		}

	}
	return 1;
}

int empty_string(char *str){
	
	return (*str == '\0' || *str == '\n' || *str == 0);
}
