#include "fechas.h"
#include "personal.h"
#define MAX 10

int main(int argc, char *argv[]){
    personal_t cast[MAX];
    
    fecha_t fecha = {6, 11, 1996}, 
    fecha2 = {18, 3, 1996},
    fecha3 = {5, 5, 1974};

    personal_t e1, e2, e3;
    e1.datos_personales.nombre = "Luciano Serruya Aloisi";
    e1.datos_personales.fecha_nac = fecha; 
    e1.datos_laborales.tipo_personal = EMPLEADO;
    e1.datos_laborales.tipo.datos_empleado = MAQUINISTA;
    
    e2.datos_personales.nombre = "Pablo Toledo Margalef";
    e2.datos_personales.fecha_nac = fecha2; 
    e2.datos_laborales.tipo_personal = GERENTE;
    e2.datos_laborales.tipo.datos_gerente.nombre_oficina = "La oficina re piola";
    e2.datos_laborales.tipo.datos_gerente.cant_empleados = 32;
    
    e3.datos_personales.nombre = "Elwatij Ahtomaldi";
    e3.datos_personales.fecha_nac = fecha3; 
    e3.datos_laborales.tipo_personal = EMPLEADO;
    e3.datos_laborales.tipo.datos_empleado = LIMPIEZA;

    int i = 0;
    cast[i++] = e1;
    cast[i++] = e2;
    cast[i++] = e3;

    listadoGerentes(cast, i);
    listadoEmpleados(cast, i);
    listadoCompleto(cast, i);
    //printf("holu y chau, again\n");
    return 0;
}
