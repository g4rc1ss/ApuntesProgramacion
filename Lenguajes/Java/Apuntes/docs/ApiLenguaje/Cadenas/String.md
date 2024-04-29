# Creación de Strings
Puedes crear objetos `String` utilizando literales de cadena o mediante el constructor de la clase.

```java
String mensaje = "Hola, mundo"; // Creación con literal de cadena
String nombre = new String("Juan"); // Creación con constructor
```

# Concatenación de Strings
Puedes concatenar cadenas utilizando el operador `+`.

```java
String saludo = "Hola, ";
String nombre = "Juan";
String mensaje = saludo + nombre; // "Hola, Juan"
```

# Métodos de Manipulación de Strings
La clase `String` proporciona una amplia gama de métodos para manipular cadenas.

```java
String texto = "Hola, mundo";

int longitud = texto.length(); // Obtiene la longitud de la cadena
char primerCaracter = texto.charAt(0); // Obtiene el primer carácter
boolean contieneMundo = texto.contains("mundo"); // Verifica si contiene "mundo"
String mayusculas = texto.toUpperCase(); // Convierte a mayúsculas
String minusculas = texto.toLowerCase(); // Convierte a minúsculas
String reemplazado = texto.replace("Hola", "Adiós"); // Reemplaza texto
```

# Comparación de Strings
Puedes comparar cadenas utilizando los métodos `equals()` y `compareTo()`.

```java
String a = "Hola";
String b = "Hola";
boolean sonIguales = a.equals(b); // Compara el contenido
int comparacion = a.compareTo(b); // Compara lexicográficamente
```

# Substring y Split
Puedes obtener subcadenas utilizando el método `substring()` y dividir cadenas en partes utilizando `split()`.

```java
String frase = "Java es genial";
String subcadena = frase.substring(5); // "es genial"
String[] palabras = frase.split(" "); // ["Java", "es", "genial"]
```
