# Interface Segregation Principle
Traduccion: **Principio de segregación de interfaces**

Este nos indica que *"Los clientes no deben ser forzados a depender de métodos que no utilizan"*.

Por ejemplo nuestra clase cliente utiliza una interfaz, esta interfaz es una dependencia. Lo que quiere decir que si nuestra clase cliente no necesita un método en concreto la interfaz no debe indicarlo. 
Una interfaz debe ser definida por el cliente que consume la interfaz, y no por la clase que la implementa.

## Implementacion Erronea
Esta interface **rompe** este principio completamente, puesto que un almacenamiento no siempre tiene por que ser en un fichero. Si implementamos esta interface para realizar el almacenamiento enviando los datos a un API o a una Base de datos, ¿Que hacemos con el metodo `InformacionFichero`?
```Csharp
public interface IAlmacenamiento
{
    void Guardar(string titulo, string contenido);
    string Leer(string titulo);
    FileInfo InformacionFichero(string titulo);
}
```

## Implementacion correcta
Para solucionarlo declaramos una interface lo mas generica posible, en este caso solamente con los metodos `Leer` y `Guardar`.
```Csharp
public interface IAlmacenamiento
{
    void Guardar(string titulo, string contenido);
    string Leer(string titulo);
}
```

Declaramos una interface orientada a un tipo de almacenamiento, en este caso, ficheros. De esta forma los metodos que contiene, estaran exclusivamente orientados a ello y cuando toque implementar otra clase diferente, no hará falta usar esta
```Csharp
public interface IFicheroInformacion
{
    FileInfo GetInformacion(string titulo);
}
```

Cuando querammos crear una clase que guarde en ficheros, implementamos ambas interfaces, la generica que implementara `Leer` y `Guardar` y la interface que nos permitira obtener informacion del fichero.
```Csharp
public class AlmacenamientoFichero : IAlmacenamiento, IFicheroInformacion
{
    public void Guardar(string titulo, string contenido)
    {
        // codigo
    }

    public string Leer(string titulo)
    {
        // codigo
    }
    
    public FileInfo GetInformacion(string titulo)
    {
        // codigo
    }
}
```

La forma correcta es agrupar las interfaces por funcionalidades, de esta manera, para hacer x funcionalidad, deberias de tener siempre x metodos que la resuelvan.