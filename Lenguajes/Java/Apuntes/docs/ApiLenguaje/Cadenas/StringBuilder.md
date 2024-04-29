# Creación de StringBuilder
Puedes crear un objeto `StringBuilder` utilizando su constructor predeterminado o proporcionándole una cadena inicial.

```java
StringBuilder sb1 = new StringBuilder();  // Constructor predeterminado
StringBuilder sb2 = new StringBuilder("Hola");  // Constructor con cadena inicial
```

# Métodos para Manipulación
`StringBuilder` proporciona una serie de métodos para agregar, insertar, reemplazar y eliminar contenido.

```java
StringBuilder sb = new StringBuilder("Hola");

sb.append(", mundo!");  // Agrega al final
sb.insert(5, " a");     // Inserta en la posición 5
sb.replace(0, 4, "Adiós");  // Reemplaza parte de la cadena
sb.delete(5, 9);         // Elimina desde la posición 5 hasta 8
```

# Capacidad y Longitud
`StringBuilder` tiene una capacidad inicial y un tamaño (longitud). La capacidad es la cantidad total de caracteres que puede contener, mientras que la longitud es la cantidad actual de caracteres.

```java
int capacidad = sb.capacity();
int longitud = sb.length();
```

# Convertir a String
Puedes convertir un `StringBuilder` a una cadena utilizando el método `toString()`.

```java
String cadena = sb.toString();
```

# Ventajas de StringBuilder
La principal ventaja de `StringBuilder` es su eficiencia en la manipulación de cadenas, especialmente en bucles. A medida que concatenas o modificas una cadena, el mismo objeto `StringBuilder` se modifica en lugar de crear nuevos objetos en cada operación, lo que ahorra memoria y tiempo de ejecución.

```java
StringBuilder sb = new StringBuilder();
for (int i = 0; i < 1000; i++) {
    sb.append(i);
}
String resultado = sb.toString();
```
