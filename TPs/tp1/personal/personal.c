#include "personal.h"
#include "tools/tools.h"

char *tipo_empleado[] = {"MAQUINISTA", "SECRETARIO", "CADETE"};

void print_encabezado_personal(){
	printf("NOMBRE\t\t\t|DIA\t|MES\t|AÑO\t|\n");
	printf("------------------------------------------------|\n");
}

void print_encabezado_empleado(){
	printf("NOMBRE\t\t\t|DIA\t|MES\t|AÑO\t|FUNCION\n");
	printf("--------------------------------------------------------------------\n");
}

void print_encabezado_gerente(){
	printf("NOMBRE\t\t\t|DIA\t|MES\t|AÑO\t|NOMBRE DE OFICINA\t|EMPLEADOS A CARGO\n");
	printf("--------------------------------------------------------------------------------\n");
}

void listado_personal(Personal personales[], int tope){
	print_encabezado_personal();
	for(int i = 0; i < tope; i++){
		printf("%s\t\t|%d\t|%d\t|%d\t|\n",
			personales[i].datos_personales.nombre,
			personales[i].datos_personales.fecha_nac.dia,
			personales[i].datos_personales.fecha_nac.mes,
			personales[i].datos_personales.fecha_nac.anio);
	}
}

void listado_empleados(Personal personales[], int tope){
	print_encabezado_empleado();
	for(int i = 0; i < tope; i++){
		if(personales[i].cargo==EMPLEADO){
			printf("%s\t\t|%d\t|%d\t|%d\t|%s\n",
				personales[i].datos_personales.nombre,
				personales[i].datos_personales.fecha_nac.dia,
				personales[i].datos_personales.fecha_nac.mes,
				personales[i].datos_personales.fecha_nac.anio,
				tipo_empleado[personales[i].info_adicional.datos_empleado.funcion]);
		}
	}
}

void listado_gerentes(Personal personales[], int tope){
	print_encabezado_gerente();
	for(int i = 0; i < tope; i++){
		if(personales[i].cargo==GERENTE){
			printf("%s\t\t|%d\t|%d\t|%d\t|%s\t|%d\n",
				personales[i].datos_personales.nombre,
				personales[i].datos_personales.fecha_nac.dia,
				personales[i].datos_personales.fecha_nac.mes,
				personales[i].datos_personales.fecha_nac.anio,
				personales[i].info_adicional.datos_gerente.nombre_oficina,
				personales[i].info_adicional.datos_gerente.empleados_a_cargo);
		}
	}
}

//ABM EMPLEADO
void display_funciones(){
	for(int i = 0; i < FUNCIONES_EMPLEADOS ;i++){
		printf("%d - %s\n",i,tipos_empleados[i]);
	}
}

int crear_datos_empleado(t_datos_empleado *nuevo){
	int funcion;
	do {
		printf("Ingrese funcion del empleado\n");
		display_funciones();
		scanf("%d",&funcion);
		if(!funcion) return 1;
		printf("Usted ingreso la opcion %d, correspondiente a %s\n",funcion,((funcion>(FUNCIONES_EMPLEADOS-1)||(funcion<0))?"ninguna función":tipos_empleados[funcion]));
	}while(confirma("Desea continuar?"));
	nuevo->funcion = funcion;
	return 0;
}

char *nuevoNombre(){
	char *line;
	scanf(" %50m[^\n]", &line);
	return line;
}

int nuevaPersona(t_persona *nuevo){

	do{
		if((nuevo->nombre = nuevoNombre()) == NULL){
			MEM_ERROR()
		}
		if(check_option(nuevo->nombre, exit_option)) return FUNCTION_FAILURE;
		printf("Ingresó el nombre %s\n", nuevo->nombre);
	}while(!confirma("Desea continuar?"));

	do{
		nuevo->fecha_nac = nuevaFecha();
		printf("Ingresó la fecha %d/%d/d\n",
			nuevo->fecha_nac.dia,
			nuevo->fecha_nac.mes,
			nuevo->fecha_nac.anio);
	}while(!confirma("Desea continuar?"));

	return FUNCTION_SUCCESS;
}


void mostrarMenu(){

	int rta = 0;
	do{
		printf("1. Ingresar nuevo personal\n");
		printf("2. Mostrar listado completo\n");
		printf("3. Mostrar listado de empleados\n");
		printf("4. Mostrar listado de gerentes\n");
	while(rta != 0);

	return 0;
}
