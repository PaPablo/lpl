#include <listas.h>

int compara_personas(const void *p1, const void *p2){

    return *(int *)p1 - *(int *)p2;
}

void mostrar_persona(const void *k, const void *i){
    printf("DNI = %-3d Nombre = %-30s Legajo = %-3d\n", *(int *)k, ((t_persona *)i)->nombre, ((t_persona *)i)->legajo);
}

int main(int argc, char *argv[]){

    tipoLista lista;
    crear_lista(&lista, compara_personas, NULL);
    
    t_persona luciano = {"Luciano Serruya Aloisi", 32},
              pablo = {"Pablo Toledo Margalef", 67},
              marceloman = {"Marceloman", 123};

    insertar_lista(&lista, 30, luciano);
    insertar_lista(&lista, 70, pablo);
    insertar_lista(&lista, 130, marceloman);
    
    imprimir_lista(lista);
    
    tipoClave k, sig;
    int rta;
    recuPrim_lista(lista, &k);
    printf("la primer clave es %d\n", k);
    rta = recuSig_lista(lista, k, &k);

    if(rta == 0)
        printf("la segunda clave es %d\n", k);
    else if(rta == CLAVE_NOEXISTE)
        printf("CLAVE_NOEXISTE\n");
    else
        printf("LISTA_NOEXISTE\n");

    tipoInfo i;
    recuClave_lista(lista, k, &i);
    printf("la info del segundo nodo es %s\n", i.nombre);
    
    char *cadena = "holuuu";
    luciano.nombre = (char *)malloc(strlen(cadena)+1);
    strcpy(luciano.nombre, cadena);
    printf("luciano.nombre = %s\n", luciano.nombre);

    imprimir_lista(lista);
}


