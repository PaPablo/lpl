#include <stdio.h>
#include "../personal.h"
#include "../tools/tools.h"
#include "../adt_lo/listas.h"
#include "file_emp.h"

levantar_empleados(FILE *empleados, t_lista *lista){
    //file descriptor del archivo
    FILE *empleados;


    //Acá va lo que sacamos del archivo
    Personal *p = (Personal *)malloc(siseof(Personal));

    empleados = fopen("../empleados.dat","r");
    char *formato = ""; //Ver qué formato usamos para los datos    
    //&(p.)
    while(fscanf(empleados,formato,&(p.)))
        // Mientras no se haya llegado al fin de archivo
        // leer en la variable de buffer e ir tirando a
        // la lista

}


