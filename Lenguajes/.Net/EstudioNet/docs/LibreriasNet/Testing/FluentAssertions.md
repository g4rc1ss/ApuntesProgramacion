# Fluent Assertions
La ventaja de esta libreria es en cuanto a legibilidad, puesto que se encarga de que las Asserts sean utilizadas de forma más natural a como lo haríamos en el lenguaje humano.

Contiene un conjunto de metodos de extension de `T`, por tanto puede ser usada en todo tipo de objetos.

Cuando realizamos test no solo necesitamos ejecutar una funcionalidad, sino que necesitamos comprobar que la respuesta es la esperada, para ello podemos hacer uso de `Fluent Assertions`.

Por lo general, cuando realizamos una comprobacion con esta libreria, empezamos con el metodo `Should()`, seguido de la comprobacion.

```Csharp
.Should().NotBeNull();
.Should().HaveCountGreaterThan(0);
.Should().Be("Expected");
.Should().StartWith("AB");
```
Algunos ejemplos podrian ser los de arriba, comprobar que no sea null, que tenga mas de 0 elementos, o que tenga que devolver si o si x valor.

Para poder comprobar si se tiene que ejecutar una Excepcion:
```Csharp
.Invoking(x =>
{
    // Codigo que ejecuta la excepcion
}).Should()
.Throw<Exception>()
.WithMessage("Mensaje de la excepcion esperado");
```

Podemos extender de la dependencia el metodo `Invoking` que recibe un `Action` donde indicaremos el Metodo o el codigo que puede tener la excepcion e indicaremos el tipo de excepcion que esperamos.