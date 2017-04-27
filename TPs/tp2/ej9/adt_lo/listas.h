#include "../personal.h"


typedef tipoClave   int;
typedef tipoInfo    int;       /*A MODIFICAR SEGÚN NECESIDAD*/

typedef tipoLista *t_lista;
typedef int(*comparar)(const void*, const void*);

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

