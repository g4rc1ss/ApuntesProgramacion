# Estructuras de Datos en Redis

## Keys
La forma principal de acceder a los datos en Redis es mediante `Clave-Valor`

Las claves en Redis tienen las siguientes caracteristicas:
- Las claves son unicas por definicion
- Las claves son Binary Safe, eso significa que puede usarse como clave cualquier objeto, como una cadena, un numero o un valor binario
- Pueden tener un tamaño de hasta 512mb

La eleccion del nombre de las claves de Redis es tomada por el desarrollador, generalmente suelen ir separadas por ':' para identificarlo, por ejemplo, si queremos almacenar los followers de un usuario en concreto, se podria usar una clave de este estilo `user:1000:followers`, de esta manera indica que se almacena los followers del user 1000

Las claves distinguen entre mayus y minus, por tanto `clave` y `Clave` son diferentes

### Listado de Keys
Para iterar sobre las Keys que existen en Redis hay 2 comandos.

| KEYS | SCAN |
| ---- | ---- |
| Bloquea Redis hasta terminal | itera mediante cursores |
| Nunca usar en produccion | retorna una referencia a esas keys |
| Utilizar solamente para depurar | Puede retornar 0 o n keys |
|  | Seguro en produccion |


Para ejecutar la consulta `KEYS` se usaria la siguiente sintaxis
> La sintaxis es `keys [MATCH pattern]`

`keys customer:1*` Esta consulta devolvera las keys existentes que empiecen por `customer:1`

Para ejecutar `SCAN`

> La sintaxis es `SCAN slot [MATCH pattern] [COUNT count]`

```redis
> scan 0 MATCH customer:1*
1) "14848"
2) (empty list or set)

> scan 14848 MATCH customer:1* COUNT 10000
1) "1229"
2) 1) "customer:1500"
   2) "customer:1000"

> scan 1229 MATCH customer:1* COUNT 10000
1) "0"
2) (empty list or set)
```

La busqueda de claves de esta manera es mucho mas tediosa, SCAN fragmenta la busqueda en varias partes, por lo que primero buscamos por el slot 0 y no nos devuelve resultados, pero nos devuelve a otra referencia, la cual buscamos y obtenemos registros y otra referencia, en la que hay que volver a buscar hasta que nos devuelva 0, que significa que no hay mas donde buscar

En este caso solo 1 slot nos ha devuelto datos, pero nos podrian haber devuelto mas registros los otros slot.


## Strings

## Lists

## Sets

## Sorted Sets

## Hashes

## Streams

## Transactions

