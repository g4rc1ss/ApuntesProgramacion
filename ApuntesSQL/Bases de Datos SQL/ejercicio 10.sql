
--obtener por cada hotel el nombre y el codigo de categoria--

SELECT nombre, cod_categoria

FROM hoteles

--OBTENER POR CADA CATEGORIA EL NUMERO DE HOTELES

	SELECT cod_categoria, COUNT(*)

	FROM HOTELES

	GROUP BY cod_categoria

/* OBTENER POR CADA HOTEL LA INFORMACION DE TODAS SUS HABITACIONES

nombreDEL HOTEL
CODIGO PLANTA
NUMERO HABITACIO
codigo tipo HABITACIONES
temporada
precio

*/

	SELECT nombrehotel, cod_planta, num_hab, cod_tipo_hab, temporada, precio

	FROM Hotel h, HABITACION hab, precio p

	WHERE h.cod_hotel = hab.cod_hotel AND p.cod_tipo_hab = hab.cod_tipo_hab

--eliminar la tabla de hoteles

DROP TABLE HOTELES

ALTER TABLE HOTELES ADD( direccion varchar2(50) DEFAULT "iturribide" NOT NULL )

--nombre de los hoteles 

-- nombre mas antiguo de 5 estrellas(cod-categoria) 

SELECT nombrehotel 

FROM HOTEL

WHERE cod_categoria ="S" AND MIN ( FECHA-CONST )

--nombre de los hoteles de 5 estrellas construidos el 1/1/1900 

SELECT  NOMBRE

FROM hotel

WHERE fecha_hotel = "1/1/1900" AND cod_categoria = "5"

--obtener de cada hotel el codigo del hotel, nombre-hotel y categoria que tengan mas de 100 empleados

SELECT H.cod_hotel, H.NOM, H.CATEGORIA

FROM HOTEL H, EMPLEADOS E

WHERE H.cod_hotel = E.cod_hotel

GROUP BY H.COD_HOTEL, H.NOM, H.CATEGORIA

HAVING COUNT( * ) > 100

--empleados que sean camareros y que empiece el nombre por N

SELECT NOMBRE

FROM EMPLEADOS

WHERE PUESTO = "CAMARERO" AND NOMBRE LIKE "N%"

--EN LA TABLA DE HOTELES PUEDE HABER CATEGORIAS QUE NO ESTEN EN LA TABLA CATEGORIAS  Y AL REVES, OBTENER TODOS LOS CODIGOS DE CATEGORIAS EXISTENTES EN LA BASE DE DATOS

(SELECT cod_categoria FROM HOTEL) UNION (SELECT cod_categoria FROM CATEGORIA)

--UN GERENTE PUEDE SERLO COMO MAXIMO DE DOS HOTELES, NOMBRE DE LOS DOS HOTELES QUE TIENE EL MISMO GERENTE JUNTO AL DNI DEL GERENTE