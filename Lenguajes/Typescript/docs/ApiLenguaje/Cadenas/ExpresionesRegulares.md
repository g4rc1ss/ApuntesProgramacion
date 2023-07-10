Las expresiones regulares son patrones utilizados para buscar y manipular texto de manera flexible. Permiten realizar búsquedas, coincidencias, reemplazos y validaciones basadas en patrones definidos.

**Creación de una expresión regular:**

Las expresiones regulares se crean utilizando la sintaxis `/patrón/`. El patrón puede incluir caracteres literales y metacaracteres especiales que representan patrones más amplios. Aquí tienes un ejemplo:

```typescript
const patron = /abc/;
```

En este ejemplo, creamos una expresión regular simple que busca el patrón "abc". La expresión regular se almacena en la variable `patron`.

**Métodos de las expresiones regulares:**

Las expresiones regulares tienen métodos que te permiten realizar diferentes operaciones, como buscar coincidencias, reemplazar texto y extraer subcadenas. Aquí tienes algunos métodos comunes:

- `test(texto)`: Verifica si el texto coincide con la expresión regular y devuelve un valor booleano.
- `exec(texto)`: Busca la primera coincidencia en el texto y devuelve un objeto de coincidencia o `null`.
- `match(expresion)`: Busca todas las coincidencias en el texto y devuelve un array de coincidencias o `null`.
- `replace(expresion, reemplazo)`: Reemplaza todas las coincidencias en el texto con el texto de reemplazo y devuelve el resultado modificado.
- `split(separador)`: Divide el texto en un array de subcadenas utilizando el separador como delimitador.


```typescript
const texto = "abc def ghi abc";
const patron = /abc/;

console.log(patron.test(texto)); // Salida: true
console.log(patron.exec(texto)); // Salida: ["abc", index: 0, input: "abc def ghi abc", groups: undefined]
console.log(texto.match(patron)); // Salida: ["abc", "abc"]
console.log(texto.replace(patron, "XYZ")); // Salida: "XYZ def ghi XYZ"
console.log(texto.split(patron)); // Salida: ["", " def ghi ", ""]
```

En este ejemplo, utilizamos la expresión regular `/abc/` para buscar el patrón "abc" en el texto. Usamos el método `test()` para verificar si el texto contiene una coincidencia, el método `exec()` para obtener la primera coincidencia, el método `match()` para obtener todas las coincidencias, el método `replace()` para reemplazar todas las coincidencias y el método `split()` para dividir el texto en subcadenas.

**Metacaracteres y modificadores:**

Las expresiones regulares también admiten metacaracteres especiales y modificadores para realizar búsquedas más flexibles y avanzadas. Algunos ejemplos comunes incluyen:

- `.`: Coincide con cualquier carácter excepto nueva línea.
- `^`: Coincide con el inicio de una línea.
- `$`: Coincide con el final de una línea.
- `[]`: Define un conjunto de caracteres permitidos.
- `*`: Coincide con cero o más repeticiones del elemento anterior.
- `+`: Coincide con una o más repeticiones del elemento anterior.
- `?`: Coincide con cero o una repetición del elemento anterior.
- `|`: Coincide con cualquiera de las alternativas separadas por `|`.

Aquí tienes un ejemplo que muestra el uso de algunos metacaracteres y modificadores:

```typescript
const texto = "abc123 def456 ghi789";
const patron = /\d+/g;

console.log(texto.match(patron)); // Salida: ["123", "456", "789"]
```

En este ejemplo, utilizamos la expresión regular `/\d+/g` para buscar uno o más dígitos en el texto. Utilizamos el metacaracter `\d` para representar cualquier dígito, y el modificador `g` para buscar todas las coincidencias en lugar de solo la primera.
