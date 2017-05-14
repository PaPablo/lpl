#!/bin/bash

#script para conectarse a la bd de turnos via cli, sin el pgadmin3
#no creo que haya drama por conectarse con el usuario "postgres"
#de ultima cambiar el usuario segun el que corresponda, por lo pronto funciona

psql -U postgres -h localhost -d turnos
