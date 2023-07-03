# SET
Crea registros Clave-Valor en Redis

```redis
SET key value [NX | XX] [GET] [EX seconds | PX milliseconds |
  EXAT unix-time-seconds | PXAT unix-time-milliseconds | KEEPTTL]
```
`set clave:1 "valor"`

- `NX` Inserta el valor si la key NO existe en Redis.

- `XX` Inserta el valor si la key existe en Redis.

- `GET` Retorna el anterior valor de la key antes de ser modificada, si no existia retorna un error.

- `EX seconds` Indica una cantidad de tiempo en la que expirara el registro, en segundos

- `PX milliseconds` Indica una cantidad de tiempo en la que expirara el registro, en milisegundos

- `EXAT unix-time-seconds` Indica una cantidad de tiempo (en UNIX) en la que expirara el registro, ensegundos

- `PXAT unix-time-milliseconds` Indica una cantidad de tiempo (en UNIX) en la que expirara el registro, enmilisegundos

- `KEEPTTL` Guarda el tiempo de visa asociado a la clave

# GET
Obtiene el valor asociado a la clave que consultamos

```redis
GET key
```

# DEL
Eliminar la clave o claves y los valores asociados

```redis
DEL key [key ...]
```

# UNLINK
Desvincula la clave con el valor que tiene asociado y un proceso asincrono se encarga de la eliminacion del valor

```redis
UNLINK key [key ...]
```

