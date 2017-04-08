#include "fechas.h"

int cantDiasMes(int mes, int anio){
	int diasMeses[12] = {31,28,31,30,31,30,31,31,30,31,30,31};
	
	if(mes == 2 && esBisiesto(anio)) return 29;

	return diasMeses[mes-1];
}

int esBisiesto(int anio){
	return ((anio % 4 == 0) && (anio % 100 != 0)) ? 1 : ((anio % 400 == 0) && (anio != 3600)); 
}

int validarAnio(int anio){
	return anio > 0 && anio <= MAX_ANIO;
}

int validarMes(int mes){
	return mes >= 1 && mes <= 12;
}

int validarDia(int dia, int mes, int anio){
	
	return ((dia > 0) && (dia <= (cantDiasMes(mes, anio)))); 
}

int esFechaValida(fecha_t fecha){

	return validarAnio(fecha.anio) && validarMes(fecha.mes) && validarDia(fecha.dia, fecha.mes, fecha.anio);
}

fecha_t nuevaFecha(){

    fecha_t fecha;
    while(1){
        printf("Ingrese anio: ");
        scanf("%d", &fecha.anio);
        printf("\nIngrese mes: ");
        scanf("%d", &fecha.mes);
        printf("\nIngrese dia: ");
        scanf("%d", &fecha.dia); 

        if(!esFechaValida(fecha))
            printf("Fecha ingresada incorrecta. Intente de nuevo\n");
        else
            break;
    }
    
    return fecha;
}
