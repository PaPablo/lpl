#include "personal.h"

int main(int argc, char const *argv[])
{
	
	Personal p;
	Personal personales[] = {
		{{"Alejandro Perez",{18,3,1996}},GERENTE,{"Adminsitracion Aviaria",10}},
		{{"Alberto Rios",{22,4,1982}},GERENTE,{"Adminsitracion Aviaria",10}},
		{{"Carlos Garcia",{31,12,1990}},GERENTE,{"Adminsitracion Aviaria",10}},
		{{"Juan Osvaldo",{14,5,1986}},GERENTE,{"Adminsitracion Aviaria",10}},
		{{"Juan Santiago",{26,3,1992}},GERENTE,{"Adminsitracion Aviaria",10}},
		{{"Rudecindo Perez",{17,7,1984}},EMPLEADO,{CADETE}},
		{{"Celedonio Perez",{2,8,2000}},EMPLEADO,{SECRETARIO}},
		{{"Juan Perez",{1,10,1978}},EMPLEADO,{MAQUINISTA}},
		{{"Juan Perez",{12,11,1991}},EMPLEADO,{CADETE}},
		{{"Juan Perez",{9,3,1995}},EMPLEADO,{CADETE}}};

	listado_personal(personales,10);
	printf("\n\n");
	listado_empleados(personales,10);
	printf("\n\n");
	listado_gerentes(personales,10);

	//printf("Nombre: %s\nFecha de Nacimiento %d/%d/%d\nCargo: %d\nOficina a cargo: %s\nEmpleados a cargo: %d\n",
	//	p.datos_personales.nombre, p.datos_personales.fecha_nac.dia, p.datos_personales.fecha_nac.mes, p.datos_personales.fecha_nac.anio, p.cargo,p.info_adicional.datos_gerente.nombre_oficina,p.info_adicional.datos_gerente.empleados_a_cargo);

	return 0;
}