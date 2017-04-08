#include "personal.h"
#include "tools/tools.h"

char *tipo_empleado[] = {"MAQUINISTA", "SECRETARIO", "CADETE"};
char *tipo_cargo[] = {"EMPLEADO", "GERENTE"};
char *exit_option[] = {"salir","exit",NULL};

void print_encabezado_personal(){
	printf("NOMBRE\t\t|DIA\t|MES\t|AÑO\t|CARGO\n");
	printf("------------------------------------------------|\n");
}

void print_encabezado_empleado(){
	printf("NOMBRE\t\t|DIA\t|MES\t|AÑO\t|FUNCION\n");
	printf("--------------------------------------------------------------------\n");
}

void print_encabezado_gerente(){
	printf("NOMBRE\t\t|DIA\t|MES\t|AÑO\t|NOMBRE DE OFICINA\t|EMPLEADOS A CARGO\n");
	printf("--------------------------------------------------------------------------------\n");
}

void listado_personal(Personal personales[], int tope){
	clear();
	print_encabezado_personal();
	for(int i = 0; i < tope; i++){
		printf("%s\t\t|%d\t|%d\t|%d\t|%s\n",
			personales[i].datos_personales.nombre,
			personales[i].datos_personales.fecha_nac.dia,
			personales[i].datos_personales.fecha_nac.mes,
			personales[i].datos_personales.fecha_nac.anio,
			tipo_cargo[personales[i].cargo]);
	}
	GET_CHAR();
}

void listado_empleados(Personal personales[], int tope){
	clear();
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
	GET_CHAR();
}

void listado_gerentes(Personal personales[], int tope){
	clear();
	print_encabezado_gerente();
	for(int i = 0; i < tope; i++){
		if(personales[i].cargo==GERENTE){
			printf("%s\t\t|%d\t|%d\t|%d\t|%s\t\t\t|%d\n",
				personales[i].datos_personales.nombre,
				personales[i].datos_personales.fecha_nac.dia,
				personales[i].datos_personales.fecha_nac.mes,
				personales[i].datos_personales.fecha_nac.anio,
				personales[i].info_adicional.datos_gerente.nombre_oficina,
				personales[i].info_adicional.datos_gerente.empleados_a_cargo);
		}
	}
	GET_CHAR();
}





//ABM EMPLEADO
void display_funciones(){
	for(int i = 0; i < FUNCIONES_EMPLEADOS; i++){
		printf("%d - %s\n",i+1,tipo_empleado[i]);
	}
}

int obtener_funcion(t_funcion_empleado *funcion){
	int rt;
	do {
		display_funciones();
		printf("Ingrese funcion del empleado\n");
		scanf("%d", &rt);
		if(!(rt)) return FUNCTION_FAILURE;
		if(((rt) < 1) || ((rt) > FUNCIONES_EMPLEADOS)) continue;
		rt--;
		printf("Usted ingreso la opcion |%s|\n", tipo_empleado[rt]);
		if(!confirma("Desea ingresar otro valor?")) break;
	}while(1);
	*funcion = rt;
	return FUNCTION_SUCCESS;
}

/*
int nuevo_datos_empleado(t_datos_empleado *nuevo){
	int funcion;char *ingresarNombre()
	if(funcion = obtener_funcion()) return FUNCTION_FAILURE;
	nuevo->funcion = funcion;
	return FUNCTION_SUCCESS;
}*/
char *ingresarNombre();
/***** AGREGAR DATOS GERENTE *****/
int obtener_nombre_oficina(char **nombre_oficina){

	do {
		printf("Ingrese nombre de la oficina  (ingrese \"salir\" o \"exit\" para salir)\n");
		scanf(" %100m[^\n]", nombre_oficina);
		if(*nombre_oficina == NULL){
			//free(nombre_oficina);
			MEM_ERROR();
		}
		if(check_option(*nombre_oficina,exit_option)) return FUNCTION_FAILURE;
		printf("Usted ha ingresado: %s\n",*nombre_oficina);
		if(!confirma("Desea ingresar otro nombre de oficina?")) break;
	}while(1);
	return FUNCTION_SUCCESS;
}

int obtener_personas_a_cargo(int *personas_a_cargo){
	do {
		printf("Ingrese cantidad de personas a cargo:\n");
		scanf("%d",personas_a_cargo);
		if(!(*personas_a_cargo)) return FUNCTION_FAILURE;
		if(*personas_a_cargo < 1) continue;
		printf("Usted ha ingresado %d\n", *personas_a_cargo);
		if(!confirma("Desea ingresar el valor nuevamente?")) break;
	}while(1);
	return FUNCTION_SUCCESS;
}


int nuevo_datos_gerente(t_datos_gerente *nuevo){
	char *nombre_oficina;
	if(obtener_nombre_oficina(&nombre_oficina)) return FUNCTION_FAILURE;
	
	nuevo->nombre_oficina = malloc(strlen(nombre_oficina)+1);
	strcpy(nuevo->nombre_oficina, nombre_oficina);
	
	int personas_a_cargo;
	
	if(obtener_personas_a_cargo(&personas_a_cargo)) return FUNCTION_FAILURE;
	nuevo->empleados_a_cargo = personas_a_cargo;
	return FUNCTION_SUCCESS;
}

/***** AGREGAR CARGO *****/

void display_cargos(){
	for(int i = 0; i < 2; i++){
		printf("%d - %s\n", i+1, tipo_cargo[i]);
	}
}

int ingresarCargo(t_cargo *cargo){
	int rt;
	do{
		display_cargos();
		printf("Ingrese cargo: ");
		scanf("%d", &rt);
		if(!rt) return FUNCTION_FAILURE;
		if ((rt < 1) || (rt > 2)) continue;
		rt--;
		printf("Ingresó el cargo |%s|\n", tipo_cargo[rt]);
		if(confirma("Desea continuar?")) break;
	}while(1);

	*cargo = rt;
	return FUNCTION_SUCCESS;
}

int ingresarInfoCargo(t_cargo cargo, t_info *info){

	if(cargo == EMPLEADO){
		return obtener_funcion(&(info->datos_empleado.funcion));
	}

	//si no es empleado, es gerente

	return nuevo_datos_gerente(&(info->datos_gerente));
}

/***** AGREGAR DATOS PERSONALES *****/

char *ingresarNombre(){
	char *line;
	printf("Ingrese un nombre (ingrese \"salir\" o \"exit\" para salir): ");
	scanf(" %50m[^\n]", &line);
	return line;
}

int nuevaPersona(t_persona *nuevo){

	do{
		if((nuevo->nombre = ingresarNombre()) == NULL){
			MEM_ERROR()
		}
		if(check_option(nuevo->nombre, exit_option)){
			//free(nuevo->nombre)
			return FUNCTION_FAILURE;
		}
		printf("Ingresó el nombre %s\n", nuevo->nombre);
		if(confirma("Desea continuar?")) break;
	}while(1);

	do{
		nuevo->fecha_nac = nuevaFecha();

		printf("Ingresó la fecha %d/%d/%d\n",
			nuevo->fecha_nac.dia,
			nuevo->fecha_nac.mes,
			nuevo->fecha_nac.anio);
	}while(confirma("Desea reintentar?"));

	return FUNCTION_SUCCESS;
}

/***** CARGAR NUEVO PERSONAL*****/

int nuevoPersonal(Personal arreglo[], int *tam){

	Personal nuevo;
	if(nuevaPersona(&nuevo.datos_personales) == FUNCTION_SUCCESS
		&& ingresarCargo(&nuevo.cargo) == FUNCTION_SUCCESS
		&& ingresarInfoCargo(nuevo.cargo, &nuevo.info_adicional) == FUNCTION_SUCCESS){
		arreglo[(*tam)++] = nuevo;
	}

	return FUNCTION_SUCCESS;
}

void mostrarMenu(Personal arreglo[], int *tam){

	int rta = 0;
	do{
		clear();
		printf("1. Ingresar nuevo personal\n");
		printf("2. Mostrar listado completo\n");
		printf("3. Mostrar listado de empleados\n");
		printf("4. Mostrar listado de gerentes\n");
		printf("---------------------------------\n");
		printf("0. Salir\n");

		scanf("%d", &rta);

		switch(rta){
			case 1:
				nuevoPersonal(arreglo, tam);
				break;
			case 2:
				listado_personal(arreglo, *tam);
				break;
			case 3:
				listado_empleados(arreglo, *tam);
				break;
			case 4:
				listado_gerentes(arreglo, *tam);
			default: break;
		}
	}while(rta != 0);
}
