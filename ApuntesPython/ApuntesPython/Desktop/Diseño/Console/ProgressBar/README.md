# Barras de progreso, hélices y contadores

## Descripción
Las barras de progreso, las hélices y los contadores son elementos que se utilizan en un programa para mostrar gráficamente el avance de un proceso.

Se usan para informar la evolución de una tarea cuando esta va a durar mas de unos pocos segundos.

Para ver en un programa este elemento visual vamos a usar los paquetes:
- Progress

### Instalación:
---------
 ```
pip install progress
pip install progressbar
 ```

 ### Uso de Progress

Crear un objeto bar e indicas el max 100(el 100%)
se crea un bucle y el rango es el recorrido de elementos
puede ser leer archivos, pues el numero de archivos, el numero de paquetes a instalar, etc.

Al usarse dentro de un bucle la ultima instrucción tiene que ser el "next()", de esta manera la actualización de la barra es mas realista

El método "next()" permite un parámetro numérico para indicar cuantos saltos tiene que hacer en la barra, para eso se hará la division: ``100/NumElementos``   y el for acabara al recorrer todos los elementos, de esta manera nos aseguramos que si en numero de elementos es mayor a 100 la barra sera mas realista al acabar cada proceso porque por ejemplo: ``100/150 = 0.67``, es menor a 1, por tanto no puede correr 1 punto la barra

----------
### Uso de los elementos de Progress

En el modulo ``progress`` hay diferentes elementos como

Barras del progreso: Se usan para ayudar a prever el final de una ejecución de un proceso
- ``Bar("", max=20)`` Por cada 1% se va añadiendo el símbolo "#"

- ``ChargingBar('Instalando:', max=100)`` Barra de puntos que se sustituyen por el símbolo █
- ``Bar('Escribiendo:', fill='·', suffix='%(percent)d%%')`` Por cada 1% se va añadiendo "."(punto)

Spinner: Se usan para mostrar que se esta ejecutando algo e indicar que no ha petado el programa, pero no ayuda a saber cuando acabará
- ``Spinner('Leyendo: ')`` Muestra una hélice que da vueltas para indicar que esta en proceso de algo

Contador: Se usa como las barras de proceso, Se muestra el numero total de elementos y tiene que bajar hasta 0 para acabar
- ``Countdown("Contador: ")`` Un contador de NumElementos a 0

