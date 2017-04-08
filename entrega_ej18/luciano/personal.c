#include "personal.h"

/*personal_t nuevoPersonal(){

    personal_t nuevo;

}*/
char *tipos_empleados[] = {"MAQUINISTA", "SECRETARIO", "OFICINISTA", "LIMPIEZA"};

void mostrarDatosPersonales(datos_t datos){
	printf("\nNombre: %s\nFecha de nacimiento: %d/%d/%d\n",
			datos.nombre, datos.fecha_nac.dia, datos.fecha_nac.mes, datos.fecha_nac.anio);
}

void mostrarDatosGerente(gerente_t datos){

	printf("Nombre oficina: %s\nCantidad de empleados a cargo: %d\n",
			datos.nombre_oficina, datos.cant_empleados);
}

void mostrarDatosEmpleado(empleado_t datos){
	printf("Tipo de empleado: %s\n", tipos_empleados[datos]);
}

void listadoGerentes(personal_t *lista, int tam){
	
	printf("\n\n***LISTADO DE GERENTES***\n");
    
    for(int i = 0; i < tam; i++){

    	if(lista[i].datos_laborales.tipo_personal != GERENTE) continue;

    	mostrarDatosPersonales(lista[i].datos_personales);
    	mostrarDatosGerente(lista[i].datos_laborales.tipo.datos_gerente);
    }
}
    
void listadoEmpleados(personal_t *lista, int tam){
	
	printf("\n\n***LISTADO DE EMPLEADOS***\n");
	for(int i = 0; i < tam; i++){

		if(lista[i].datos_laborales.tipo_personal != EMPLEADO) continue;

		mostrarDatosPersonales(lista[i].datos_personales);
		mostrarDatosEmpleado(lista[i].datos_laborales.tipo.datos_empleado);
	}

}

void listadoCompleto(personal_t *lista, int tam){

	printf("\n\n***LISTADO COMPLETO***\n");
	for(int i = 0; i < tam; i++){
		mostrarDatosPersonales(lista[i].datos_personales);
		if(lista[i].datos_laborales.tipo_personal == EMPLEADO)
			mostrarDatosEmpleado(lista[i].datos_laborales.tipo.datos_empleado);
		else
			mostrarDatosGerente(lista[i].datos_laborales.tipo.datos_gerente);
	}

}
