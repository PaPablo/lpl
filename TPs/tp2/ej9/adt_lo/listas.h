//HACER LOS #includes NECESARIOS PARA UTILIZAR EL ADT
#ifndef ADTLO_H
#define ADTLO_H
#include<stdlib.h>
#include<stdio.h>
#include<string.h>

#define MALLOC_ERROR 1

typedef int     tipoClave;
typedef int     tipoInfo;       /*A MODIFICAR SEGÚN NECESIDAD*/

typedef struct t_lista tipoLista;

typedef int(*comparar)(const void*, const void*);
/*PARA IMPLEMENTAR LA FUNCION DE COMPARACION:
 *  Si la función devuelve 0, los elementos son iguales
 *  Si función devuelve menor que 0, el primer elemento es menor que el segundo
 *  Si la función devuelve mayor que 0, el segundo elemento es menor que el primero
 *
 *      return a - b;*/




int crear_lista(tipoLista, comparar);
int insertar_lista(tipoLista, tipoClave, tipoInfo);
int eliminar_lista(tipoLista, tipoClave);
int longitud_lista(tipoLista);
int recuClave_lista(tipoLista, tipoClave, tipoInfo*);
int recuAnt_lista(tipoLista, tipoClave, tipoClave*);
int recuSig_lista(tipoLista, tipoClave, tipoClave*);
int recuPrim_lista(tipoLista);
int recuUlt_lista(tipoLista, tipoClave*);
int esVacia_lista(tipoLista);
int vaciarLista_lista(tipoLista);

#endif //ADTLO_H
