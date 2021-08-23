# Estructura del código

---
## Declaración de variables
```Javascript
var variableGlobal = "2";
let variableLocal = "2.5";
let booleana = true;
```
- `var` -> Se crea una variable de ambio global a todo el archivo js
- `let` -> Se cre una variable local que se elimina cuando acabe el bloque de codigo donde se almacena

---
## Convertir tipos
```Javascript
parseInt(variableGlobal);
parseFloat(variableLocal);
```

----
## Sentencias de flujo
```Javascript
if (booleana) {
    // code
} else if (booleana) {
    // code
} else {
    // code
}

switch (variableGlobal) {
    case "2":
        break;
    case "2.5":
        break;
}
```

---
## Operador ternario
````Javascript
let ternaria = booleana ? "true" : "false";
````

----
## Bucles
```Javascript
while (booleana) {
    // code
}

do {
    // code
} while (booleana);

for (let x = 0; x < 10; x++) {
    // code
}

for (let item in lista) {
    // code
}
```

---
# Cadenas

## String
Una cadena es un objeto de tipo String cuyo valor es texto. Internamente, el texto se almacena como una colección secuencial de solo lectura de objetos Char.

### Literales
| Secuencia de escape | Nombre de carácter | Codificación Unicode |
| ------------------- | ------------------ | -------------------- |
| \\' | Comilla simple | 0x0027
| \\" | Comilla doble  | 0x0022
| \\\\ | Barra diagonal inversa | 0x005C
| \\0 | Null | 0x0000
| \\a | Alerta | 0x0007
| \\b | Retroceso | 0x0008
| \\f | Avance de página | 0x000C
| \\n | Nueva línea | 0x000A
| \\r | Retorno de carro | 0x000D
| \\t | Tabulación horizontal | 0x0009
| \\U | Secuencia de escape Unicode para pares suplentes. | \\Unnnnnnnn
| \\v | Tabulación vertical | 0x000B

### Interpolacion de Cadenas
---
La interpolación de cadenas se usa para mejorar la legibilidad y el mantenimiento del código. Se obtienen los mismos resultados que con las concatenaciones, pero es mas claro y mejor.
```Javascript
let interpolacion = `Interpolando una variable: ${variable}`
```

### Métodos de string
---

```Javascript
// Devuelve una cadena en la que se reemplazan los caracteres introducidos, el primero es el valor a cambiar y el segundo parametro el nuevo valor
cadena.replace(',', '\n');

// Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-'
cadena.split('m');

// Devuelve el indice donde se encuentra el caracter indicado
cadena.indexOf('m');

// Compara el string con otro objeto, como por ejemplo, otra cadena
cadena.localeCompare("Hola, yo me llamo Ralph"); // si es true, devuelve 0

// Devuelve los caracteres entre una posicion de indice y otra, si no se indica la otra se devolvera la cadena desde el indice inicial
cadena.substring(3, 5);
```

# Colecciones
Las colecciones proporcionan una manera más flexible de trabajar con grupos de objetos. A diferencia de las matrices, el grupo de objetos con el que trabaja puede aumentar y reducirse de manera dinámica a medida que cambian las necesidades de la aplicación

---
## Arrays

Una array es un tipo de colección para almacenar objetos y poder recorrerlos mas adelante

### Métodos de array

```Javascript
let array = ["3", "ewrgf", "sfesf"];

// Agrega al ultimo elemento del array el objeto que se le pasa por parametro
array.push("me llamo Ralph");

// Devuelve la posicion del array donde se ubica el objeto a buscar
array.indexOf("Hola");

// Ordenas la array al contra
array.reverse();
```

---
## Diccionarios

Una clase de Diccionario es una estructura de datos que representa una colección de 
claves y valores de pares de datos. La clave es idéntica en un par clave-valor y puede tener como máximo un valor en el diccionario

### Métodos de diccionarios

```Javascript
let diccionario = new Map();
diccionario.set("Clave", "Valor");
diccionario.set("Clave 2", "Valor 2");
diccionario.set(3, 3);

// Devuelve una lista con las claves del diccionario
diccionario.keys();

// Devuelve una lista con los valores del diccionario
diccionario.values();

// Devuelve un bool indicando si la clave existe en el diccionario
diccionario.has("Clave");

// Elimina la Key del diccionario y por tanto, los valores asociados a la misma
diccionario.delete(3);

// Metodo para obtener el valor asociado a la clave indicada
diccionario.get("Clave");

```

# Programación Orientada a Objetos

## Class

Una clase es una estructura de datos que combina estados (campos) y acciones (métodos y otros miembros de función) en una sola unidad. 

De una clase se pueden hacer instancias de objetos para usar sus metodos, propiedades, etc. Y de esta forma, poder reutilizar codigo.

Las clases admiten herencia y polimorfismo, mecanismos por los que las clases derivadas pueden extender y especializar clases base.

```Javascript
class ClaseEjemplo {
    variable = "";

    constructor(variable) {
        this.variable = variable;
    }

    metodo() {
        // Code
    }
}
```

## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```Javascript
function funcion() {
    // Code
}

// Metodo de clase
metodo() {
    // Code
}
```

## Delegados
Un delegate es un tipo de referencia que puede utilizarse para encapsular un método con nombre o anónimo.

Imaginemos que podemos crear un método, almacenarlo en un objeto y pasarlo como parámetro de una función, pues en eso consiste.
```Javascript
let delegado = function(){
    document.write("codigoEjecutar");
};

delegado.apply();
```

---
## Herencia
La herencia significa que se pueden crear nuevas clases partiendo de clases existentes, que tendrá todas los atributos, propiedades y los métodos de su 'superclass' o 'clase padre' y además se le podrán añadir otros atributos, propiedades y métodos propios.

```Javascript
class ClasePadre {
    variable = "";

    constructor(variable) {
        this.variable = variable;
    }

    metodo() {
        // Code
    }
}

class Clasehija extends ClasePadre {    
    constructor(variable) {
        super();
    }

    metodo() {
        // Code
    }
}
```

# Conceptos Avanzados

## Liberacion de Memoria


```Javascript

```

---
## Enumerador

Una enumeración es un conjunto de constantes enteras que tienen asociado un nombre para cada valor.

El objetivo fundamental de implementar una enumeración es facilitar la legibilidad de un programa.
Supongamos que necesitamos almacenar en un juego de cartas el tipo de carta actual (oro, basto, copa o espada), podemos definir una variable entera y almacenar un 1 si es oro, un 2 si es basto y así sucesivamente.
Luego mediante if podemos analizar el valor de esa variable y proceder de acuerdo al valor existente.

```Javascript

```

---
## Indizadores
Permiten crear una clase, un struct o una interfaz con un "indice" al que se accederá a traves del objeto instanciado de la clase, no hace falta acceder a la matriz como tal.
```Javascript

```

---
## Boxing y Unboxing
Todos los tipos de C# directa o indirectamente se derivan del tipo de clase object, y object es la clase base definitiva de todos los tipos. Los valores de tipos de referencia se tratan como objetos mediante la visualización de los valores como tipo object.

Los valores de tipos de valor se tratan como objetos mediante la realización de operaciones de conversión boxing y operaciones de conversión unboxing

```Javascript

```

---
## Generics
Los genéricos introducen en .NET el concepto de parámetros de tipo, lo que le permite diseñar clases y métodos que aplazan la especificación de uno o varios tipos hasta que el código de cliente declare y cree una instancia de la clase o el método.

Para que usar los genéricos?
- Use tipos genéricos para maximizar la reutilización del código, la seguridad de tipos y el rendimiento.
- El uso más común de los genéricos es crear clases de colección.
La biblioteca de clases .NET Framework contiene varias clases de colección genéricas nuevas en el espacio de nombres System.Collections.Generic. Estas se deberían usar siempre que sea posible en lugar de clases como ArrayList en el espacio de nombres System.Collections.
- Puede crear sus propias interfaces, clases, métodos, eventos y delegados genéricos.
- Puede limitar las clases genéricas para habilitar el acceso a métodos en tipos de datos determinados.
- Puede obtener información sobre los tipos que se usan en un tipo de datos genérico en tiempo de ejecución mediante la reflexión

```Javascript

```

### Constraints
Los constraints son condiciones que deben de cumplir el parametro que se le pasa al generic para que funcione.

| Constraint | Descripción |
| ---------- | ----------- |
| | |

---
## Eventos
Un evento es un mensaje que envía un objeto cuando ocurre una acción.

Los eventos se realizan a mano en el codigo y son contenedores de un metodo Delegado que es el que se va a invocar.

Por ejemplo al interactuar con una interfaz de escritorio, se crea un objeto Button y se agrega al evento para detectar el click y se vincula a un metodo que se ha de ejecutar `Button_Click()`  
Por debajo lo que hace el codigo es detectar cuando se pulsa el boton y entonces, invoca el evento el cual tiene agregar como delegado el metodo que hemos escrito.

Para crear y controlar un evento se realiza el siguiente codigo:

```Javascript

```

---
## Codigo no Administrado
El codigo no administrado es un tipo de codigo al que no puede acceder el `Garbage Collector` para realizar el proceso de limpieza de memoria, por tanto hay que hacerlo manualmente.

### 
Es una tecnologia que permite hacer uso de librerias compiladas de forma nativa con Javascripts como `Rust`, `Cpp`, etc.  
De esta forma permite realizar interoperabilidad con librerias de los diferentes sitemas como Windows, por ejemplo se puede hacer uso de esto para ejecutar librerias como el diseño de las GUi nativas.

```rust
#[no_mangle]
pub extern fn add_numbers(number1: i32, number2: i32) -> i32 {
    println!("Hola con Rust");
    number1 + number2
}

/*
> cargo new lib
> cd lib
Creamos el archivo lib.rs
Editamos el archivo cargo.toml y agregamos:
    [lib]
    name="libreriaEjemploRust"
    crate-type = ["dylib"]
> cargo build
```

```Javascript

```

### Codigo inseguro
La mayor parte del código que se escribe es "código seguro comprobable". El código seguro comprobable significa que las herramientas del Javascript pueden comprobar que el código es seguro. En general, el código seguro no accede directamente a la memoria mediante punteros. Tampoco asigna memoria sin procesar. En su lugar, crea objetos administrados.

Este modo es un tipo de [Codigo no Administrado](#codigo-no-administrado) puesto que a este codigo no acceden las herramientas para liberar el espacio de memoria que ocupan por ejemplo.

El código no seguro tiene las propiedades siguientes:

- Los métodos, tipos y bloques de código se pueden definir como no seguros.
- En algunos casos, el código no seguro puede aumentar el rendimiento de la aplicación al eliminar las comprobaciones de límites de matriz.
- El código no seguro es necesario al llamar a funciones nativas que requieren punteros.
- El código no seguro presenta riesgos para la seguridad y la estabilidad.
- El código que contenga bloques no seguros deberá compilarse con la opción del compilador AllowUnsafeBlocks.

#### Punteros

```Javascript

```

En la tabla siguiente se muestran los operadores e instrucciones que pueden funcionar en punteros en un contexto no seguro:

| Operador/Instrucción | Usar |
| -------------------- | ---- |
| | | |

---
# Tratamiento de Excepciones

## Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

### Capurando las excepciones
```Javascript

```

### Provocando una excepcion
```Javascript

```

### Creando excepciones propias
```Javascript

```

---
# Programación Asincrona & MultiThreading

## 


```Javascript

```

---
## Paralelismo
Muchos equipos y estaciones de trabajo personales tienen varios núcleos de CPU que permiten ejecutar múltiples subprocesos simultáneamente. Para aprovecharse del hardware, se puede paralelizar el código para distribuir el trabajo entre dichos núcleos.

Por ejemplo, imaginemos que tenemos una aplicacion que requiere de realizar 3 consultas para obtener datos diferentes de una BBDD, aprovechandonos del multithreading, podemos hacer uso de la clase Parallel para realizar esas consultas de forma paralelizada y reducir los tiempos.

### Ejecucion de metodos paralelamente
Permite la ejecucion paralelizada de un array de delegados

Cuando se ejecuta la instruccion, el metodo Invoke recibe un array de delegados que ejecutaran en un hilo nuevo y esperara a que estos terminen
```Javascript

```

### Recorrer un bucle de forma paralela
Permite la ejecucion paralelizada de la lectura de una coleccion

```Javascript

```

---
# Comprension de Listas


## 

```Javascript

```
