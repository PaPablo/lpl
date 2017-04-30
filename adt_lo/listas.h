//HACER LOS #includes NECESARIOS PARA UTILIZAR EL ADT
#ifndef ADTLO_H
#define ADTLO_H

#include<stdlib.h>
#include<stdio.h>
#include<string.h>

#define MALLOC_ERROR 1
#define CLAVE_EXISTE 2
#define LISTA_VACIA  3




typedef     int    tipoClave;       //A MODIFICAR SEGÚN NECESIDAD
typedef     int    tipoInfo;        //A MODIFICAR SEGÚN NECESIDAD

typedef int(*comparar)(const void*, const void*);
/*PARA IMPLEMENTAR LA FUNCION DE COMPARACION:
 *  Si la función devuelve 0, los elementos son iguales
 *  Si función devuelve menor que 0, el primer elemento es menor que el segundo
 *  Si la función devuelve mayor que 0, el segundo elemento es menor que el primero
 *
 *      return a - b;*/






typedef struct t_lista *tipoLista;
//API del ADT
extern int crear_lista(tipoLista, comparar);
extern int insertar_lista(tipoLista, tipoClave, tipoInfo);
extern int eliminar_lista(tipoLista, tipoClave);
extern int longitud_lista(tipoLista);
extern int recuClave_lista(tipoLista, tipoClave, tipoInfo*);
extern int recuAnt_lista(tipoLista, tipoClave, tipoClave*);
extern int recuSig_lista(tipoLista, tipoClave, tipoClave*);
extern int recuPrim_lista(tipoLista);
extern int recuUlt_lista(tipoLista, tipoClave*);
extern int esVacia_lista(tipoLista);
extern int vaciar_lista(tipoLista);


#endif //ADTLO_H
