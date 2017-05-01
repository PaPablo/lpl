//HACER LOS #includes NECESARIOS PARA UTILIZAR EL ADT
#ifndef ADTLO_H
#define ADTLO_H

#include<stdlib.h>
#include<stdio.h>
#include<string.h>

#include <persona.h>



#define MALLOC_ERROR    1
#define CLAVE_EXISTE    2
#define CLAVE_NOEXISTE  3
#define CLAVE_PRIMERA   4
#define CLAVE_ULTIMA    5
#define LISTA_VACIA     6
#define LISTA_NOEXISTE  7




typedef     int    tipoClave;       //A MODIFICAR SEGÚN NECESIDAD
typedef     t_persona    tipoInfo;        //A MODIFICAR SEGÚN NECESIDAD

typedef int(*comparar)(const void*, const void*);
/*PARA IMPLEMENTAR LA FUNCION DE COMPARACION:
 *  Si la función devuelve 0, los elementos son iguales
 *  Si función devuelve menor que 0, el primer elemento es menor que el segundo
 *  Si la función devuelve mayor que 0, el segundo elemento es menor que el primero
 *
 *      return a - b;*/

typedef void(*mostrar)(const void*, const void*);
/*PARA IMPLEMENTAR LA FUNCIÓN DE MOSTRAR
 * poner el printf con el formato deseado 
 * para que se muestren los datos de un elemento de la lista
 * por ejemplo:
 *      printf("clave = %d\tinfo = %d\n", clave, info);
 *
 * el listado genérico no incorpora salto de línea, así que no olvidárselo si se lo desea
 * */




typedef struct t_lista *tipoLista;
//API del ADT
int crear_lista(tipoLista*, comparar, mostrar);
int insertar_lista(tipoLista*, tipoClave, tipoInfo);
int eliminar_lista(tipoLista*, tipoClave);
int longitud_lista(tipoLista);
int recuClave_lista(tipoLista, tipoClave, tipoInfo*);
int recuAnt_lista(tipoLista, tipoClave, tipoClave*);
int recuSig_lista(tipoLista, tipoClave, tipoClave*);
int recuPrim_lista(tipoLista, tipoClave*);
int recuUlt_lista(tipoLista, tipoClave*);
int esVacia_lista(tipoLista);
int vaciar_lista(tipoLista*);
void imprimir_lista(tipoLista);

#endif //ADTLO_H
