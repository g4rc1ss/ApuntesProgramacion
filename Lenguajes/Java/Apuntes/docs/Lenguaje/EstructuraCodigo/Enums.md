# Definición de Enumeradores
Un enumerador es una lista fija de valores constantes con nombre. Puedes crear tu propio enumerador utilizando la palabra clave `enum`.

```java
enum DiaSemana {
    LUNES, MARTES, MIERCOLES, JUEVES, VIERNES, SABADO, DOMINGO
}
```

# Acceso a los Valores del Enumerador
Puedes acceder a los valores del enumerador utilizando el nombre del enumerador seguido de un valor constante.

```java
DiaSemana dia = DiaSemana.MARTES;
System.out.println("Hoy es " + dia);
```

# Usando Enumeradores en Switch
Los enumeradores son útiles en estructuras de control como `switch`, donde puedes manejar diferentes casos basados en los valores del enumerador.

```java
DiaSemana dia = DiaSemana.MIERCOLES;
switch (dia) {
    case LUNES:
    case MARTES:
    case MIERCOLES:
    case JUEVES:
    case VIERNES:
        System.out.println("Es un día laboral");
        break;
    case SABADO:
    case DOMINGO:
        System.out.println("Es fin de semana");
        break;
}
```

# Atributos y Métodos en Enumeradores
Puedes agregar atributos y métodos a los enumeradores, similar a las clases. Cada valor del enumerador puede tener sus propios atributos y comportamientos.

```java
enum EstadoCivil {
    SOLTERO("Soltero/a"), CASADO("Casado/a"), DIVORCIADO("Divorciado/a");

    private String descripcion;

    private EstadoCivil(String descripcion) {
        this.descripcion = descripcion;
    }

    public String getDescripcion() {
        return descripcion;
    }
}

EstadoCivil estado = EstadoCivil.CASADO;
System.out.println("Estado civil: " + estado.getDescripcion());
```

# Iteración a través de los Valores del Enumerador
Puedes iterar a través de todos los valores del enumerador utilizando el método `values()`.

```java
for (DiaSemana dia : DiaSemana.values()) {
    System.out.println("Día de la semana: " + dia);
}
```

Los enumeradores en Java ofrecen una manera organizada y legible de representar conjuntos de constantes relacionadas. Son especialmente útiles cuando deseas limitar las opciones posibles para una variable a un conjunto predefinido de valores.