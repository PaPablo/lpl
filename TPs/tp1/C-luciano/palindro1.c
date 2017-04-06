#include <stdio.h>
#include <string.h>
/*
Segunda resolucion para determinar si una palabra es palindromo.
El algoritmo utiliza dos cadenas para comprobar si una palabra es palindromo.
y hace uso de funciones de la libreria string.h
cadenas de ingreso para probar: reconocer , neuquen, pepe
*/ 
int main()
{
   char a[100], b[100];
 
   printf("Ingrese texto para verificar si es palindromo\n");
   // obtiene la cadena desde la entrada estandar
   gets(a);
   // copia la cadena leida en otra variable
   strcpy(b,a);
   //invierte los caracteres de la variable b
   strrev(b);
   printf("\ncadena: \n%s\ncadena invertida:\n%s\ncomparacion:%d\n",a,b,strcmp(a,b));
   if( strcmp(a,b) == 0 )
      printf("Es palindromo!\n");
   else
      printf("No es palindromo!\n");
 
   system("pause");   
   return 0;
}
