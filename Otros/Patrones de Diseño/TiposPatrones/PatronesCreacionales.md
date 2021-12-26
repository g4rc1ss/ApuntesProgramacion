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
También llamado: **Constructor**

### Proposito

Es un patrón de diseño creacional que nos permite construir objetos complejos paso a paso. El patrón nos permite producir distintos tipos y representaciones de un objeto empleando el mismo código de construcción.

### Problema

Imaginemos una funcion que recibe muchos parametros para devolver una Query SQL formada, algo como:

```csharp
public string ResolveQuery(string select, string from, string where, string orderBy, string limit);

ResolveQuery("Id", "table", null, null, null);
ResolveQuery("Id", "table", "Id = 1", null, null);
```

Este codigo si nos fijamos es muy engorroso y nada descriptivo, porque si no necesitamos de todos los parametros, encima tenemos que enviar los datos a null.

### Solucion

Para la solución se puede crear una clase que implemente una serie de metodos para agregar las opciones, basicamente, pasar los parametros a ser funciones e ir agregandolos a variables de clase privadas y una funcion `Build()`, que se encargara de montarlo todo y devolver lo que se necesita.

```csharp
internal interface IPatronBuilder
{
    string Build();
    IPatronBuilder From(string from);
    IPatronBuilder OrderBy(string orderBy);
    IPatronBuilder Select(string select);
    IPatronBuilder Where(string where);
}

internal class PatronBuilder : IPatronBuilder
{
    private string _select;
    private string _where;
    private string _from;
    private string _orderby;

    public IPatronBuilder Select(string select)
    {
        _select = select;
        return this;
    }

    public IPatronBuilder Where(string where)
    {
        _where = where;
        return this;
    }

    public IPatronBuilder From(string from)
    {
        _from = from;
        return this;
    }

    public IPatronBuilder OrderBy(string orderBy)
    {
        _orderby = orderBy;
        return this;
    }

    public string Build()
    {
        var query = new StringBuilder();

        query.AppendLine($"SELECT {(!string.IsNullOrEmpty(_select) ? _select : "*")}");
        query.AppendLine($"FROM {_from}");

        if (!string.IsNullOrEmpty(_where))
        {
            query.AppendLine($"WHERE {_where}");
        }
        if (!string.IsNullOrEmpty(_orderby))
        {
            query.AppendLine($"ORDER BY {_orderby}");
        }

        return query.ToString();
    }
}


public static void Main(string[] args)
{
    var claseImplementaBuilder1 = new PatronBuilder();
    var claseImplementaBuilder2 = new PatronBuilder();
    var claseImplementaBuilder3 = new PatronBuilder();


    var query1 = claseImplementaBuilder1
        .Select("Id")
        .From("table")
        .Where("1 = 1")
        .OrderBy("Id")
        .Build();

    var query2 = claseImplementaBuilder2
        .From("table")
        .Build();

    var query3 = claseImplementaBuilder3
        .Select("Hola")
        .From("tableFrom")
        .Build();

    Console.WriteLine(query1);
    Console.WriteLine(query2);
    Console.WriteLine(query3);
}
```
De esta manera, la forma de crear la query es mucho mas clara por los nombres de las funciones y al poder concatenarse y usar el metodo Build() para la creacion de todo, es mucho mas claro.

### Estructura

![](../img/PatronCreacional/Builder/BuilderEstructura.jpg)

---
## Prototype
También llamado: **Metodo de fábrica**

### Proposito



### Problema



### Solucion



### Estructura

![](../img/PatronCreacional/AbstractMethod/AbstractMethod1.png)

---
## Singleton
También llamado: **Metodo de fábrica**

### Proposito



### Problema



### Solucion



### Estructura

![](../img/PatronCreacional/AbstractMethod/AbstractMethod1.png)
