#!/bin/bash

#script para ejecutar una consulta a la base de datos "turnos" corriendo en localhost
#si se lo ejecuta sin parametros, hay que tirarle la consulta, enter, y un EOF
#tambien se le puede tirar un archivo de texto que tenga la consulta
#   ./execute_query.sh consulta.sql

SERVER="localhost"
USER="postgres"
DB="turnos"


if [ $# -eq 0 ]; then
    end_of_file=0
    SQL=""
    echo -e "\nINPUT A SQL QUERY. ENTER EOL TO END INPUT"
    while [[ $end_of_file == 0 ]]
    do
      read -r line
      # the last exit status is the 
      # flag of the end of file
      end_of_file=$?
      SQL+=" $line"
    done
    psql -h "$SERVER" -U "$USER" -d "$DB" -c "$SQL" -a
else   
    QUERY=$1
    psql -h "$SERVER" -U "$USER" -d "$DB" -f "$QUERY" -a
fi

exit 0

