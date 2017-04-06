#include "tools.h"

void lowercase(char *l){
    for(int i = 0; l[i]; i++){
        l[i] = tolower(l[i]);
    }
}

int check_option(char *l, char **opt){
    
    /*opt tiene que estar terminado en NULL*/

    for(int i = 0; opt[i] != NULL; i++){
        //si l esta en opt, devuelve 1
        if (strcmp(l, opt[i]) == 0) return 1;
    }

    return 0;
}

int confirma(char *msg){
    char *options[] = {"si", "s", "no", "n", "yes", "y", NULL};
    char *positiv_options[] = {"si", "s", "yes", "y", NULL};
    char *line;

    while(1){
        printf("%s (S/N)\n", msg);
        scanf(" %m[^\n]", &line);

        /*convertimos el input a todo en minusculas
        sacado de stackoverflow, of course*/
        lowercase(line);

        printf("LOWER: %s\n", line);
        if (check_option(line,options)) break;    
    }

    return (check_option(line, positiv_options));
}
