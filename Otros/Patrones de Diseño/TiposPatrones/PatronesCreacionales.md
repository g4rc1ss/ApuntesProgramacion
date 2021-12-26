# Patrones Creacionales

Los patrones creacionales proporcionan formas de creacion de objetos y permiten la reutilización de codigo existente.


## Factory Method
También llamado: **Metodo de fábrica**

### Proposito

Consiste en la creacion de instancias de una superclase o interface y poder devolverlas en instancias de la subclase

El patrón Factory Method sugiere que, en lugar de llamar al operador new para construir objetos directamente, se invoque a un método fábrica especial

### Problema

Suponiendo una aplicacion de control de logistica, en la primera versión del codigo, lo realizas pensando en que el metodo de transporte es, por ejemplo, `camion`, pero mas adelante tienes las necesidades de agregar mas metodos como maritimo, aereo, etc.

Al final te ves obligado a repetir codigo o tener que agregar condicionales extras, etc.


### Solucion

La solución es implementar un nivel de abstraccion creando una `interface Transporte`, las clases de transporte `Camion`, `Barco`, `Avion` por ejemplo y estas deberan de implementar la interface `Transporte`.

![transporte](../img/PatronCreacional/FactoryMethod/FactoryMethod1.png)

Una clase abstracta o interface `MedioTransporte` y tendra un metodo para crear un transporte y creamos subclases que sean referentes a `Tierra`, `Agua`, `Aire`. 

En el medio de transporte por tierra se pueden usar Camiones, trenes, etc.  
Entonces lo que se hace es crear un metodo de factoria que devuelva un `Transporte`(clase abstracta o interface) y ahi es donde se realizara la logica de devolver una instancia de la clase `Camion` o `Tren` o la correspondiente.

![transporte](../img/PatronCreacional/FactoryMethod/FactoryMethod2.png)


### Estructura

![transporte](../img/PatronCreacional/FactoryMethod/FactoryMethod3.png)


---
## Abstract Method
También llamado: **Fábrica Abstracta**

### Proposito

Permite producir familias de objetos relacionados sin especificar sus clases concretas.

El patrón Abstract Factory está aconsejado cuando se prevé la inclusión de nuevas familias de productos, pero puede resultar contraproducente cuando se añaden nuevos productos o cambian los existentes, puesto que afectaría a todas las familias creadas.

### Problema

Debemos crear diferentes objetos, todos pertenecientes a la misma familia. Por ejemplo: las bibliotecas para crear interfaces gráficas suelen utilizar este patrón y cada familia sería un sistema operativo distinto. Así pues, el usuario declara un Botón, pero de forma más interna lo que está creando es un BotónWindows o un BotónLinux, por ejemplo.

El problema que intenta solucionar este patrón es el de crear diferentes familias de objetos.

### Solucion

Para mostrar el concepto del Abstract Factory vamos a hacer un sencillo reloj que nos muestra la hora actual. Como sabemos, la hora puede ser desplegada en formato de 24Hrs o puede ser desplegada en formato AM/PM.

```Java
public abstract class Reloj {
 
    abstract String dameLaHora();
}

public class RelojAmPm extends Reloj{
 
    public RelojAmPm(){
 
    }
 
    public String dameLaHora() {
        Date d = new Date();
        int hora = d.getHours();
        int minutos = d.getMinutes();
        int segundos = d.getSeconds();
        String tr;
        if (hora&lt;=12){
            tr="Son las "+hora+":"+minutos+":"+segundos+" AM";
        } else {
            tr="Son las "+(hora-12)+":"+minutos+":"+segundos+" PM";
        }
 
        return tr;
    }
 
}

public class Reloj24Hrs extends Reloj {
 
    public String dameLaHora() {
        Date d = new Date();
        int hora = d.getHours();
        int minutos = d.getMinutes();
        int segundos = d.getSeconds();
        String tr;
        tr = "Son las " + hora + ":" + minutos + ":" + segundos + " ";
 
        return tr;
    }
}

public class RelojFactory {
    public static final int RELOJ_AM_PM=0;
    public static final int RELOJ_24_HRS=1;
 
    public RelojFactory(){
 
    }
 
    public static Reloj createReloj(int tipoDeReloj){
        if (tipoDeReloj==RelojFactory.RELOJ_24_HRS){
            return new Reloj24Hrs();
        }
        if (tipoDeReloj==RelojFactory.RELOJ_AM_PM){
            return new RelojAmPm();
        }
 
        return null;
    }
 
}

public class MainClient {
 
    public static void main(String[] args) {
        Reloj r = RelojFactory.createReloj(RelojFactory.RELOJ_24_HRS);
        System.out.println(r.dameLaHora());
    }
}
```

### Estructura

![](../img/PatronCreacional/AbstractMethod/AbstractMethod1.png)

---
## Builder
También llamado: **Metodo de fábrica**

### Proposito



### Problema



### Solucion



### Estructura

---
## Prototype
También llamado: **Metodo de fábrica**

### Proposito



### Problema



### Solucion



### Estructura

---
## Singleton
También llamado: **Metodo de fábrica**

### Proposito



### Problema



### Solucion



### Estructura