![](2\_Constructores.001.png)

**Evaluation Only. Created with Aspose.Words. Copyright 2003-2021 Aspose Pty Ltd.**

**Constructores** 

Cada vez que se crea una clase o struct, se llama a su constructor. Una clase o struct puede tener varios constructores que toman argumentos diferentes. Los constructores permiten al programador establecer valores predeterminados, limitar la creación de instancias y escribir código flexible y fácil de leer 

**Constructores predeterminados** 

Si no proporciona un constructor para la clase, C# creará uno de manera predeterminada que cree instancias del objeto y establezca las variables miembro en los valores predeterminados que se indican en Tabla de valores predeterminados. Si no proporciona un constructor para su struct, C# se basa en un constructor predeterminado implícito para inicializar automáticamente cada campo de un tipo de valor en su valor predeterminado. 

**Sintaxis del constructor** 

Un constructor es un método cuyo nombre es igual que el nombre de su tipo. Su firma del método incluye solo el nombre del método y su lista de parámetros; no incluye un tipo de valor devuelto. En el ejemplo siguiente se muestra el constructor de una clase denominada Person. 

public class Person 

{ 

`   `private string last;    private string first; 

`   `public Person(string lastName, string firstName)    { 

`      `last = lastName; 

`      `first = firstName; 

`   `} 

`   `// Remaining implementation of Person class. } 

Si un constructor puede implementarse como una instrucción única, puede usar una definición del cuerpo de expresión. En el ejemplo siguiente se define una clase Location cuyo constructor tiene un único parámetro de cadena denominado name. La definición del cuerpo de expresión asigna el argumento al campo locationName. 

public class Location 

{ 

`   `private string locationName; 

public Location(string name) => Name = name; 

`   `public string Name 

`   `{ 

`      `get => locationName; 

`      `set => locationName = value;    }  

} 

**Constructores estáticos** 

En los ejemplos anteriores se han mostrado constructores de instancia, que crean un objeto nuevo. Una clase o struct también puede tener un constructor estático, que inicializa los miembros estáticos del tipo. Los constructores estáticos no tienen parámetros. Si no proporciona un constructor estático para inicializar los campos estáticos, el compilador de C# proporcionará un constructor estático predeterminado que inicializa los campos estáticos en su valor predeterminado como se muestra en la Tabla de valores predeterminados. 

En el ejemplo siguiente se usa un constructor estático para inicializar un campo estático. 

public class Adult : Person 

{ 

`   `private static int minimumAge; 

`   `public Adult(string lastName, string firstName) : base(lastName, firstName) 

`   `{ } 

`   `static Adult() 

`   `{ 

`      `minimumAge = 18;    } 

`   `// Remaining implementation of Adult class. } 

También puede definir un constructor estático con una definición de cuerpo de expresión, como se muestra en el ejemplo siguiente. 

public class Child : Person { 

private static int maximumAge; 

`   `public Child(string lastName, string firstName) : base(lastName, firstName) 

`   `{ } 

static Child() => maximumAge = 18; 

`   `// Remaining implementation of Child class. } 
**Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/**
