# Liskov Substitution Principle
Traduccion: **Principio de sustitucion de Liskov**

Robert C. Martin lo redefinió con la siguiente frase *"subtipos deben poder ser sustituidos por sus tipos base"*.

El principio de sustitución de Liskov nos habla sobre polimorfismo.

No hay una forma general de implementar este principio y es exclusivo de nuestra aplicación y del funcionamiento de la misma. Con la excepción de la siguiente norma “El sistema no debe de romperse”. 

## Ejemplo Erroneo

```Csharp
public interface IAlmacenamiento
{
    void Guardar(string titulo, string contenido);
    string Leer(string titulo);
    FileInfo InformacionFichero(string titulo);
}
```

```Csharp
public class AlmacenamientoFichero : IAlmacenamiento
{
    readonly string path = "C:/temp";
    public void Guardar(string titulo, string contenido)
    {
        //código
    }

    public string Leer(string titulo)
    {
        //código
    }

    public FileInfo InformacionFichero(string titulo)
    {
        //código
    }
}
```

```Csharp
public class AlmacenamientoSQL : IAlmacenamiento
{
    public void Guardar(string titulo, string contenido)
    {
        //código
    }

    public string Leer(string titulo)
    {
        //código
    }

    public FileInfo InformacionFichero(string titulo)
    {
        throw new NotSupportedException();
    }
}   
```

Teniendo el codigo de arriba, si tenemos un objeto que reciba una instancia de `AlmacenamientoSQL` y ejecutamos el metodo `InformacionFichero()`, como este metodo no tiene sentido cuando hacemos uso de una Base de datos, devolvera una excepcion. Esto viola el principio, puesto que con el uso del polimorfismo no se debe de romper el sistema.

## Ejemplo correcto
Debemos de declarar en la clase o interface base, solamente las funciones que se puedan compartir y que no afecten al resto de objetos.
```Csharp
public interface IAlmacenamiento
{
    void Guardar(string titulo, string contenido);
    string Leer(string titulo);
}
```

Mi consejo para evitar este tipo de situaciones es que cuando estés desarrollando  y quieras hacer una clase, pienses en su implementación o en cómo podrías extraerlo en una interfaz en caso de que algún día quieras cambiar.  