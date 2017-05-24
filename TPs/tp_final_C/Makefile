CC   = gcc
RES  = 
OBJ  = obj/main.o obj/paciente.o obj/utils.o obj/obrasocial.o obj/pacienteobrasocial.o obj/orm.o obj/profespecialidad.o obj/profesional.o obj/especialidad.o obj/turnos.o obj/funciones_argumentos.o obj/argumentos.o $(RES)
LINKOBJ  = obj/main.o obj/utils.o $(RES)
LIBS =  -L"/usr/lib"
INCS =  -I"/usr/include/postgresql" 
BIN  = bin/TurnosAtencionApp

CFLAGS = $(INCS) $(LIBS) -lpq
RM = rm -f

.PHONY: all all-before all-after clean clean-custom

all: all-before bin/TurnosAtencionApp all-after

test: clean all

clean: clean-custom
	${RM} $(OBJ) $(BIN)

$(BIN): $(OBJ)
	$(CC) $(LINKOBJ) -o $(BIN) $(CFLAGS)

obj/main.o: src/main.c
	$(CC) -c src/main.c -o obj/main.o $(CFLAGS)

obj/paciente.o: src/paciente.c
	$(CC) -c src/paciente.c -o obj/paciente.o $(CFLAGS)

obj/utils.o: src/utils.c
	$(CC) -c src/utils.c -o obj/utils.o $(CFLAGS)

obj/obrasocial.o: src/obrasocial.c
	$(CC) -c src/obrasocial.c -o obj/obrasocial.o $(CFLAGS)

obj/pacienteobrasocial.o: src/pacienteobrasocial.c
	$(CC) -c src/pacienteobrasocial.c -o obj/pacienteobrasocial.o $(CFLAGS)

obj/orm.o: src/orm.c
	$(CC) -c src/orm.c -o obj/orm.o $(CFLAGS)

obj/profespecialidad.o: src/profespecialidad.c
	$(CC) -c src/profespecialidad.c -o obj/profespecialidad.o $(CFLAGS)

obj/profesional.o: src/profesional.c
	$(CC) -c src/profesional.c -o obj/profesional.o $(CFLAGS)

obj/especialidad.o: src/especialidad.c
	$(CC) -c src/especialidad.c -o obj/especialidad.o $(CFLAGS)

obj/turnos.o: src/turnos.c
	$(CC) -c src/turnos.c -o obj/turnos.o $(CFLAGS)

obj/funciones_argumentos.o: src/funciones_argumentos.c
	$(CC) -c src/funciones_argumentos.c -o obj/funciones_argumentos.o $(CFLAGS)

obj/argumentos.o: src/argumentos.c
	$(CC) -c src/argumentos.c -o obj/argumentos.o $(CFLAGS)

