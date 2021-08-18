# Sintaxis Java

## Estructura del código

````Java
package sintaxis;
import System;

public class ejemplosSintaxis{
    public static void Main(string[] args){

    }
}
````
- ``import`` -> Para importar librerías y módulos

- ``package`` -> indica la ubicación del programa, debe de ir lo primero del código siempre

- ``class`` -> Creamos una clase, que es un modulo que se usa para declarar objetos y tratarlos añadiendo funciones.

- ``Main(string[] args)`` -> el método main es el método principal de donde parte la aplicación siempre, no puede haber dos main en el mismo proyecto

---
## Declaración de variables
```Java
String a = "hoa"; int b = 2; double c = 2.0; boolean d = false;
var x = "h";
System.out.printf("%s %.2f %d %n %b", a, c, b, d);
```
`var` es un "comodín" que se usa para no tener que indicar el objeto que te viene de vuelta (un string, un int, un float, un obj)
`printf`
 - Para String usamos = %s
 - Para double o float = %numEnteros.NumeroDecimalesf
 - Para integer = %d %n
 - Para boolean = %b
---
## Convertir tipos
```java
String d2 = ""+d+"";
int c2 = (int) c;
float b2 = (float)b;
System.out.printf("%s %.2f %d %n %b", a, c, b, d);
```

---
## Métodos habituales en cadenas

- ``cadena.replace(x, y)`` -> Devuelve una cadena en la que se reemplazan las letras o asi metidas en "x" por las de "y"

- ``cadena.split(x)`` -> Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-'

- ``cadena.startsWith(x)`` -> Devuelve true o false si inicia la cadena por "x", usado mucho en menus de opciones

---
## Array:

Una Array es un tipo de lista de variables ordenada en un único objeto
````java
String[] array = new String[5];
String[] array2 = {"H", "o", "l", "a"};
````

---
## Listas:

Una lista es un tipo de colección ordenada(un array)

### Métodos habituales Listas

- ``lista.add(x)`` -> Agrega al ultimo elemento de la lista "x"

- ``lista.size()`` -> Devuelve el numero de elementos que tiene la lista

- ``lista.indexOf(x)`` -> Devuelve la posición en laque se encuentra la primera x. se pueden poner los parámetros "start", "stop" que indican desde donde hasta donde del array recorrer

- ``lista.remove(X)`` -> Elimina el primer valor "x" de la lista

```java
ArrayList<String> arrayList = new ArrayList<>();
arrayList.add("");
arrayList.add(3, ""); //3 es el indice
```

---
## Diccionarios:

Un diccionario o tabla de hashes(en otros lenguajes) son colecciones que relacionan una clave y valor. osea que se asocia una especie de significado

----
### Métodos habituales de diccionario:
- ``diccionario.containsKey(k)`` -> Devuelve el valor de la key

- ``diccionario.Keys`` -> Devuelve una lista de claves

- ``diccionario.remove(k)`` -> Borra el contenido asociado a la clave k

- ``diccionario.values`` -> Devuelve una lista de los valores del diccionario

```java
 Map<Integer, String> dictionary = new HashMap<Integer, String>();
dictionary.put(0, "hola");
System.out.println(dictionary.get(0));
```

----
## Sentencias de flujo

```java
if (a == b || b == c &&  !d){
    System.out.println("pasa por verdadero");
} else if ( a != b){
    System.out.println("diferente");
} else{
    System.out.println("pues nah!");
}

switch(b) {
    case 0:
        System.out.println("es 0");
        break;
    case 1:
        System.out.println("es 1");
        break;
    case 2:
        System.out.println("es 2");
        break;
    case 3:
        System.out.println("es 3");
        break;
}
```

---
## Operador ternario
````java
String a3 = "0";
int b3 = 2;
String ternario = a3.equals("0") ? a3 : Integer.toString(b3);
````

----
## Bucles
```java
int edad = 0;
while (edad < 3) {
    edad ++;
    System.out.println(edad);
}

for(int x = 0; x < 3; x++){
    edad ++;
    System.out.printf("%d %n rango: %d %n", edad, x);
}

for (var i : arrayList)
    System.out.print(i);
```
----
## Funciones
```java
private void imprimir(String texto){
    imprimir(texto, 1);
}
private void imprimir(String texto, int veces){
    for(int x = 0; x < veces; x ++)
        System.out.println(texto);
}
new EjemploSintaxis().imprimir("hola, este es el texto");
```
En java no hay parámetros opcionales, asique se deberá de sobrecargar métodos para ello

---
## Class

Una clase es una estructura de datos que combina estados (campos) y acciones (métodos y otros miembros de función) en una sola unidad. 

De una clase se pueden hacer instancias y objetos para usar sus funciones etc y permitir la reutilizacion de código

Las clases admiten herencia y polimorfismo, mecanismos por los que las clases derivadas pueden extender y especializar clases base.

```java
//[access modifier] - [class] - [identifier]
public class Customer {
   // Fields, properties, methods and events go here...
}
```

---
## Static Class

Los `static` se usan para no tener que instanciar clases o métodos con objetos.

Todos los métodos, propiedades, variables, etc. Deberán de ser `static`

```java
public static class A {
    public static void metodo(){
    }
}
```

---
## Abstract Class

No se pueden crear instancias de una clase abstracta. 

El propósito de una clase abstracta es para el uso de herencias, tiene una funcionalidad parecida a las `interface`, te obligan a heredar métodos, propiedades, variables...

```java
public abstract class A {
    // Class members here.
}
```

---
## Enumerador

Una enumeración es un conjunto de constantes enteras que tienen asociado un nombre para cada valor.

El objetivo fundamental de implementar una enumeración es facilitar la legibilidad de un programa.
Supongamos que necesitamos almacenar en un juego de cartas el tipo de carta actual (oro, basto, copa o espada), podemos definir una variable entera y almacenar un 1 si es oro, un 2 si es basto y así sucesivamente.
Luego mediante if podemos analizar el valor de esa variable y proceder de acuerdo al valor existente.

```java
public enum EnumeradorCSharp {
    hola,
    adios
}
```

---
## Herencia
La herencia significa que se pueden crear nuevas clases partiendo de clases existentes, que tendrá todas los atributos, propiedades y los métodos de su 'superclass' o 'clase padre' y además se le podrán añadir otros atributos, propiedades y métodos propios.

```java
public class Clase extends SuperClase {

}
```

---
## Interface

Las interfaces se usan para definir atributos o métodos para herencia de una clase. Por ejemplo una `interface Ianimal` se definirá el método `int numPatas();` que retornada el numero de patas del animal, al implementar la interfaz habrá que crear un método de igual nombre que retorne el numero de patas. Es usado para definir la clase de herencia

```java
public class PruebaInterfazImplícita implements IMiInterfaz {
    public void MiMetodo() {
	    System.out.println("Hola");
    }
}
```

---
## Excepciones
Las excepciones son errores durante la ejecución del programa y lo que se hace es intentar solucionar el error o mostrar un mensaje mas claro sobre el problema al usuario, por ejemplo: se necesita ser super usuario, se esta dividiendo entre 0, no hay conexión a internet...

```java
try {
    int numero = 0;
    int resultado = 2 / numero;
} catch(ArithmeticException zero) {
    System.out.printf("Estas dividiendo entre 0 %s", zero.getMessage());
} catch(Exception ex) {
    System.out.printf("Estas haciendo algo mal %s", ex.getMessage());
} finally {
    //Aquí se suele añadir instrucciones de finalizacion del programa o cerrado de archivos
}
```
