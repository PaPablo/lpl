CC   = gcc
RES  = 
OBJ  = main.o paciente.o utils.o obrasocial.o pacienteobrasocial.o orm.o profespecialidad.o profesional.o especialidad.o turnos.o $(RES)
LINKOBJ  = main.o utils.o $(RES)
LIBS =  -L"/usr/lib"
INCS =  -I"/usr/include/postgresql" 
BIN  = tpfinalc

CFLAGS = $(INCS) $(LIBS)  -lpq
RM = rm -f

.PHONY: all all-before all-after clean clean-custom

all: all-before tpfinalc all-after


clean: clean-custom
	${RM} $(OBJ) $(BIN)

$(BIN): $(OBJ)
	$(CC) $(LINKOBJ) -o tpfinalc $(CFLAGS)

main.o: main.c
	$(CC) -c main.c -o main.o $(CFLAGS)

paciente.o: paciente.c
	$(CC) -c paciente.c -o paciente.o $(CFLAGS)

utils.o: utils.c
	$(CC) -c utils.c -o utils.o $(CFLAGS)

obrasocial.o: obrasocial.c
	$(CC) -c obrasocial.c -o obrasocial.o $(CFLAGS)

pacienteobrasocial.o: pacienteobrasocial.c
	$(CC) -c pacienteobrasocial.c -o pacienteobrasocial.o $(CFLAGS)

orm.o: orm.c
	$(CC) -c orm.c -o orm.o $(CFLAGS)

profespecialidad.o: profespecialidad.c
	$(CC) -c profespecialidad.c -o profespecialidad.o $(CFLAGS)

profesional.o: profesional.c
	$(CC) -c profesional.c -o profesional.o $(CFLAGS)

especialidad.o: especialidad.c
	$(CC) -c especialidad.c -o especialidad.o $(CFLAGS)

turnos.o: turnos.c
	$(CC) -c turnos.c -o turnos.o $(CFLAGS)
