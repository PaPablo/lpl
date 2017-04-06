#ifndef MAP_H
#define MAP_H

#include <stdio.h>
#include <stdlib.h>

typedef int (*tOp)(int i);

int incrementar(int i);
int decrementar(int i);
int cuadrado(int i);
int raiz(int i);
int imprimir(int i);
void map(int a[], tOp f, int max);
void mapAndPrint(int a[], tOp f, int max);

#endif //MAP_H
