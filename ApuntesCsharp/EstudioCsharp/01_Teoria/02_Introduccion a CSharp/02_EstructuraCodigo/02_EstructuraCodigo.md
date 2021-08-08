![](02\_EstructuraCodigo.001.png)

**Evaluation Only. Created with Aspose.Words. Copyright 2003-2021 Aspose Pty Ltd.**

1\_EstructuraCodigo.md 1/21/2020

Estructura del código![](02\_EstructuraCodigo.002.png)

using System; ![](02\_EstructuraCodigo.003.png)

namespace sintaxis{ 

`    `public class ejemplosSintaxis{ 

`        `public static void Main(string[] args){ 

`        `}     } 

} 

- using -> Para importar librerías y módulos
- namespace -> Como los package de Java, indican donde esta el programa o mas bien, la ruta donde esta la clase o clases dentro de las llaves
  - class -> Creamos una clase, que es un modulo que se usa para declarar objetos y tratarlos añadiendo funciones.
- main(string[] args) -> el método main es el método principal de donde parte la aplicación siempre, no puede haber dos main en el mismo proyecto

Alias con using

Se puede crear un alias de la importación de using para clarificar mejor con un nombre el uso de las librerías

- namespace

El alias es Texto

using Texto = System.Text; ![](02\_EstructuraCodigo.004.png)

Si queremos acceder al espacio de nombre del using con el alias Texto por ejemplo, deberemos de usar el operador ::.

using Texto = System.Text; ![](02\_EstructuraCodigo.005.png)

\_ = Texto::Json.JsonTokenType.Comment; 

El operador . también se usa para tener acceso a los miembros de un tipo. El calificador :: garantiza que el identificador de la izquierda siempre hace referencia a un alias de espacio de nombres, aunque exista un tipo

- un espacio de nombres con el mismo nombre.

1 / 1
**Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/**
