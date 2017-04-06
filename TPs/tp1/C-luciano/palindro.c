#include <stdio.h>
/*
Primer resolucion para determinar si una palabra es palindromo.
El algoritmo utiliza indices que recorren la cadena en 2 sentidos y comparan caracteres.
cadenas de ingreso para probar: reconocer , neuquen, pepe
No se utiliza ninguna funcion de la libreria string.h para operar con las cadenas de caracteres
*/ 
int main()
{
   char text[100];
   int inicio, medio, fin, longitud=0;
 
   printf("Ingrese texto para verificar si es palindromo\n");
   gets(text); 
   // obtener la longitud de la cadena
   while ( text[longitud] != '\0' )
      longitud++;    
   fin = longitud - 1;
   medio = longitud/2;
 
   for( inicio = 0 ; inicio < medio ; inicio++ )
   {
      if ( text[inicio] != text[fin] )
      {
         printf("No es palindromo!\n");
         break;
      }
      fin--;
   }
   if( inicio == medio )
      printf("Es Palindromo.\n");

   system("pause");    
   return 0;
}
