-- ver turnos que fueron asistidos con los datos de los pacientes

SELECT fechahora, P.apellido, P.nombres, dnipaciente, asistio from turnos as T JOIN pacientes as P ON T.dnipacientes=P.dni where T.asistio=1 order by fechahora;

-- ahora esta consulta muestra las fechas de los turnos que se hicieron en el 2015

SELECT fechahora FROM turnos WHERE to_char(fechahora, 'YYYY-MM-DD HH:MM:SS') LIKE '2015%';

--muestra la fecha completa y datos de los pacientes que sacaron turno en 2015
SELECT T.fechahora, P.apellido, P.nombres, p.dni FROM turnos as T JOIN pacientes as P ON T.dnipaciente=P.dni WHERE to_char(T.fechahora, 'YYYY-MM-DD HH:MM:SS') LIKE '2015%' order by fechahora;

--fecha completa y datos de pacientes que se atendieron (sacaron turno y asistieron) durante 2015
SELECT T.fechahora, P.apellido, P.nombres, p.dni FROM turnos as T JOIN pacientes as P ON T.dnipaciente=P.dni WHERE to_char(T.fechahora, 'YYYY-MM-DD HH:MM:SS') LIKE '2015%' and T.asistio=1 order by fechahora;

--fecha completa y datos de pacientes que se atendieron (sacaron turno y asistieron) durante 2015 (con expresion regular)
SELECT T.fechahora, P.apellido, P.nombres, p.dni FROM turnos as T JOIN pacientes as P ON T.dnipaciente=P.dni WHERE to_char(T.fechahora, 'YYYY-MM-DD HH:MM:SS') ~ '2015.*' and T.asistio=1 order by fechahora;

--pacientes asociados a obras sociales
SELECT O.dnipaciente, S.nombre, O.fechadesde, P.apellido, P.nombres from pacienteobrasocial as O JOIN pacientes as P ON O.dnipaciente=P.dni JOIN obrasociales as S ON O.codigoobrasocial=S.codigo order by S.nombre, O.dnipaciente;

--profesionales asociados cada especialidad
SELECT E.codigo, E.nombre, PE.fechaalta, PE.disponible, P.apellido, P.nombres from profesionalespecialidad as PE JOIN especialidades as E ON PE.codigoespecialidad=E.codigo JOIN profesionales as P ON PE.codigoprofesional=P.id order by E.nombre, P.apellido;

--ahi quedo mas cheta
SELECT E.codigo, E.nombre, PE.fechaalta, P.apellido, P.nombres, CASE WHEN PE.disponible=1 THEN 'DISPONIBLE' ELSE 'NO DISPONIBLE' END FROM profesionalespecialidad as PE JOIN especialidades as E ON PE.codigoespecialidad=E.codigo JOIN profesionales as P ON PE.codigoprofesional=P.id order by E.nombre, P.apellido;

--profesionales que ejercen cada especialidad (estan disponibles)
SELECT E.codigo, E.nombre, PE.fechaalta, P.apellido, P.nombres from profesionalespecialidad as PE JOIN especialidades as E ON PE.codigoespecialidad=E.codigo JOIN profesionales as P ON PE.codigoprofesional=P.id where PE.disponible=1 order by E.nombre, P.apellido;

--consulta con salida tipo CSV
SELECT dni||','apellido "DNI y apellido de los pacientes registrados" from pacientes order by apellido;


