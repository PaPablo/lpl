#ifndef TOOLS_H
#define TOOLS_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

void lowercase(char *l);

//opt tiene que estar terminado en NULL
int check_option(char *l, char **opt);

int confirma(char *msg);

#endif //TOOLS_H
