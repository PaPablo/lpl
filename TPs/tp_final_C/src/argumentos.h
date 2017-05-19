#ifndef ARG_H
#define ARG_H

typedef int (*t_puntero_funcion)(void);

struct t_arg{
    char *nombre;
    struct t_arg *hijos;
    int cant_hijos;
    t_puntero_funcion metodo;
};

typedef struct t_arg *argumento;

#endif //ARG_H
