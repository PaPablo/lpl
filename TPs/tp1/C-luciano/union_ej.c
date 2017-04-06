#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX 50

typedef  enum {
     entero,flotante,cadena
     }t_tipo;
     
typedef  struct {
          t_tipo tipo;
           union {
                 int nro;
                 float nro2;
                 char cadena[MAX];   
                 } x;
         }dynamic;

typedef  enum {
     empleado,jefe
     }t_tipoempleado;
     
typedef struct {
	char categoria[MAX];
} t_empleado_nojerarquico;

typedef struct {
	char nombre_oficina[MAX];
} t_empleado_jerarquico;

     typedef struct 
     {
     	t_tipoempleado tipo;
     	union {
     		t_empleado_nojerarquico d1;
     		t_empleado_jerarquico d2;
		 } templeado;
	 }t_empleado;
	 
int main(int argc, char *argv[])
{
  dynamic var1;
  
  
  var1.tipo=entero;
  var1.x.nro = 11;
  
  if (var1.tipo== entero ) 
       printf("Entero: %d\n",var1.x.nro);

  var1.tipo=flotante;
  var1.x.nro2=150.15;

  if (var1.tipo== flotante ) 
     printf("float: %f\n",var1.x.nro2);

  var1.tipo=cadena;   
  strcpy(var1.x.cadena,"Hola mundo "); 
  if(var1.tipo==cadena)
     printf("cadena: %s\n",var1.x.cadena);
  
 
  system("PAUSE");	
  return 0;
}


/*
#include <stdio.h>
#include <string.h>
 
union Data {
   int i;
   float f;
   char str[20];
};
 
int main( ) {

   union Data data;        

   printf( "Memory size occupied by data : %d\n", sizeof(data));

   return 0;
}



//When the above code is compiled and executed, it produces the following result −

//Memory size occupied by data : 20

*/

/*
#include <stdio.h>
#include <string.h>
 
union Data {
   int i;
   float f;
   char str[20];
};
 
int main( ) {

   union Data data;        

   data.i = 10;
   data.f = 220.5;
   strcpy( data.str, "C Programming");

   printf( "data.i : %d\n", data.i);
   printf( "data.f : %f\n", data.f);
   printf( "data.str : %s\n", data.str);

   return 0;
}


//When the above code is compiled and executed, it produces the following result −

//data.i : 1917853763
//data.f : 4122360580327794860452759994368.000000
//data.str : C Programming

//Here, we can see that the values of i and f members of union got corrupted because the final value assigned to the variable has occupied the memory location and this is the reason that the value of str member is getting printed very well.

*/

