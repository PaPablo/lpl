#include "listas.h"

int compara_personas(const void *p1, const void *p2){

    return ((t_persona *)p2)->legajo - ((t_persona *)p1)->legajo;
}

void mostrar_persona(const void *k, const void *i){
    printf("DNI = %-3d Nombre = %-30s Legajo = %-3d\n", *(int *)k, ((t_persona *)i)->nombre, ((t_persona *)i)->legajo);
}

int main(int argc, char *argv[]){

    tipoLista lista;
    crear_lista(&lista, compara_personas, mostrar_persona);
    
    t_persona luciano = {"Luciano Serruya Aloisi", 32},
              pablo = {"Pablo Toledo Margalef", 67},
              marceloman = {"Marceloman", 123};

    insertar_lista(&lista, 30, luciano);
    insertar_lista(&lista, 70, pablo);
    insertar_lista(&lista, 130, marceloman);

    imprimir_lista(lista);
    
    tipoClave x;
    if(recuPrim_lista(lista, &x) == 0) printf("yey %d\n", x);
}

