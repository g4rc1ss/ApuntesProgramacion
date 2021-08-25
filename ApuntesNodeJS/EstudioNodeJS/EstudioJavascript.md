# Estructura del código

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

# Tratamiento de Excepciones

## Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

### Capurando las excepciones
```Javascript
try {
    // Code
} catch (err) {
    // Code
} finally {
    // Code
}
```

### Provocando una excepcion
```Javascript
throw(console.log("Excepcion"));
```

### Creando excepciones propias
```Javascript
class MiExcepcion extends Error {
    constructor(mensaje) {
        super(mensaje);
        this.name = "MiExcepcion";
    }
}

try {
    throw(new MiExcepcion("Excepciooooooooon"));
} catch (excepcionMia) {
    document.write(excepcionMia.message);
} finally {
    // Code
}
```

# Comprension de Listas


## Filter
Procesa el array aplicandole el filtro que se le indique dentro de function, si la comprobacion es `true` se agregara al array de salida el contenido correspondiente.

```Javascript
array.filter(function(numero){
    return numero > 5;
});
```

## Map
Devuelve un nuevo array con los requisitos que le indiquemos dentro de la funcion.  
Por ejemplo, se puede utililzar para devolver los objetos del array que se esta procesando con un formato especifico o insertar ciertos datos del array en una clase.
```Javascript
array.map(function(numeroFilter){
    return `Número: ${numeroFilter}`;
});
```

## Sort
Ordenamos un array que contiene objetos indicando la forma de filtrado
```Javascript
let arrayOrdenado = array.sort(function (persona, personaSiguiente) {
    if (persona.nombre > personaSiguiente.nombre) {
        return 1;
    } else if (personaSiguiente.nombre > persona.nombre) {
        return -1;
    }
    return 0;
});
```
