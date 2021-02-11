# Pintar por consola

> Modulo para pintar la salida por consola de la ejecución del programa

## Instalación Colorama
> Para instalar esta herramienta se usara:
---------

``pip install colorama``


### Estilos con código ANSI
```
  Estilos*      Cod. ANSI
-------------------------
Sin efecto          0
Negrita             1
Débil               2
Cursiva             3
Subrayado           4
Inverso             5
Oculto              6
Tachado             7
```
```
Colores   Texto   Fondo
-----------------------
Negro       30      40
Rojo        31      41
Verde       32      42
Amarillo    33      43
Azul        34      44
Morado      35      45
Cían        36      46
Blanco      37      47

```
En código ANSI se pone asi:

``\033[cod_formato;cod_color_texto;cod_color_fondo``

### Formatos de Colorama
```
Estilos*    (Style)
-------------------
 Débil	      DIM
 Normal	     NORMAL
 Brillante   BRIGHT
 Reset      RESET_ALL
```
```
Colores/TextoFondo      (Fore/Black)
------------------------------------
    Negro                   BLACK
    Rojo                    RED
    Verde                   GREEN
    Amarillo                YELLOW
    Azul                    BLUE
    Morado                  MAGENTA
    Cian                    CYAN
    Blanco                  WHITE
    Reset                   RESET
```

### Cursores con Colorama

```
Cursor.POS(fila, columna):  desplaza el cursor a la fila y columna indicadas.

Cursor.UP(número):          desplaza el cursor a la línea anterior. 

Cursor.DOWN(número):        desplaza el cursor a la línea siguiente. 

Cursor.FORWARD(número):     avanza el cursor un número de caracteres en la línea actual.

Cursor.BACK(número):        retrocede el cursor un número de caracteres en la línea actual.
```