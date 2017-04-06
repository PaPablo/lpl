#include <stdio.h>
/*
Tercer resolucion para determinar si una palabra es palindromo.
El algoritmo utiliza dos cadenas para comprobar si una palabra es palindromo.
y hace uso de funciones de la libreria string.h
cadenas de ingreso para probar: reconocer , neuquen, pepe
*/  
int es_palindromo(char*);
void copia_cadena(char*, char*);
void invertir_cadena(char*);
int longitud_cadena(char*);
int compara_cadena(char*, char*);
 
int main()
{
   char string[100];
   int result;
 
   printf("Ingrese texto para verificar si es palindromo\n");
   gets(string);
 
   result = es_palindromo(string);
 
   if ( result == 1 )
      printf("\"%s\" es palindromo!\n", string);
   else
      printf("\"%s\" no es palindromo!\n", string); 
 
 system("pause");
   return 0;
}
 
int es_palindromo(char *string)
{
   int check, length;
   char *reverse;
 
   length = longitud_cadena(string);    
   reverse = (char*)malloc(length+1);    
 
   copia_cadena(reverse, string);
   invertir_cadena(reverse);
 
   check = compara_cadena(string, reverse);
 
   free(reverse);
 
   if ( check == 0 )
      return 1;
   else
      return 0;
}
 
int longitud_cadena(char *string)
{
   int length = 0;  
 
   while(*string)
   {
      length++;
      string++;
   }
 
   return length;
}
 
void copia_cadena(char *target, char *source)
{
   while(*source)
   {
      *target = *source;
      source++;
      target++;
   }
   *target = '\0';
}
 
void invertir_cadena(char *string) 
{
   int length, c;
   char *begin, *end, temp;
 
   length = longitud_cadena(string);
 
   begin = string;
   end = string;
 
   for ( c = 0 ; c < ( length - 1 ) ; c++ )
       end++;
 
   for ( c = 0 ; c < length/2 ; c++ ) 
   {        
      temp = *end;
      *end = *begin;
      *begin = temp;
 
      begin++;
      end--;
   }
}
 
int compara_cadena(char *first, char *second)
{
   while(*first==*second)
   {
      if ( *first == '\0' || *second == '\0' )
         break;
 
      first++;
      second++;
   }
   if( *first == '\0' && *second == '\0' )
      return 0;
   else
      return -1;
}
