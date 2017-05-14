#!/bin/bash
#
# This program reads lines from a file.
#

SERVER="localhost"
USER="postgres"
DB="turnos"
echo $#
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
    echo "chau"
fi

exit 0

