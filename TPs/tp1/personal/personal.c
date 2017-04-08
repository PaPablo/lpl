#include "personal.h"

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

char *ingresarNombre(){
	char *line;
	scanf(" %50m[^\n]", &line);
	return line;
}

int nuevaPersona(t_persona *nuevo){
	
	do{
		if((nuevo->nombre = ingresarNombre()) == NULL){
			MEM_ERROR()
		}
		if(check_option(nuevo->nombre, exit_option)){
			return FUNCTION_FAILURE;
		}
		printf("Ingresó el nombre %s\n", nuevo->nombre);
	}while(!confirma("Desea continuar?"));

	do{
		nuevo->fecha_nac = nuevaFecha();

		if(nuevo->fecha_nac.dia == 0 
			|| nuevo->fecha_nac.mes == 0
			|| nuevo->fecha_nac.anio == 0) return FUNCTION_FAILURE;

		printf("Ingresó la fecha %d/%d/d\n", 
			nuevo->fecha_nac.dia, 
			nuevo->fecha_nac.mes, 
			nuevo->fecha_nac.anio);
	}while(!confirma("Desea continuar?"));

	return FUNCTION_SUCCESS;
}


int nuevoPersonal(Personal arreglo[], int *tam){

	Personal nuevo;
	if(nuevaPersona(&nuevo.datos_personales) == FUNCTION_SUCCESS 
		&& ingresarCargo(&nuevo.cargo) == FUNCTION_SUCCESS
		&& ingresarInfoCargo(&nuevo.cargo, &nuevo.info_adicional) == FUNCTION_SUCCESS){
		arreglo[(*tam)++] = nuevo;
	}

	return FUNCTION_SUCCESS;
}

void mostrarMenu(Personal arreglo[], int *tam){

	int rta = 0;
	do{
		printf("1. Ingresar nuevo personal\n");
		printf("2. Mostrar listado completo\n");
		printf("3. Mostrar listado de empleados\n");
		printf("4. Mostrar listado de gerentes\n");

		scanf("%d", &rta);

		switch(rta){
			case 1:
				nuevoPersonal(arreglo, tam);
				break;
			case 2:
				listado_personal(arreglo, tam);
				break;
			case 3:
				listado_empleados(arreglo, tam);
				break;
			case 4:
				listado_gerentes(arreglo, tam);
			default: break;
		}
	while(rta != 0);

	return 0;
}