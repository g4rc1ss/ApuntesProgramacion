![](1\_MetodosPropiedades.001.png)

**Evaluation Only. Created with Aspose.Words. Copyright 2003-2021 Aspose Pty Ltd.**

3.2\_MetodosPropiedades.md 1/21/2020

Propiedades![](1\_MetodosPropiedades.002.png)

Las propiedades se comportan como campos cuando se obtiene acceso a ellas. Pero, a diferencia de los campos, las propiedades se implementan con descriptores de acceso que definen las instrucciones que se ejecutan cuando se tiene acceso a una propiedad o se asigna.

// Propiedad automatica![](1\_MetodosPropiedades.003.png)

public string propiedad { get; set; } = string.Empty; // Definiendo el propio almacenamiento

private string \_propiedadDos; 

public propiedadDos{ 

`    `get { return \_propiedadDos; } 

`    `set { \_propiedadDos = value; } 

} 

Métodos![](1\_MetodosPropiedades.002.png)

private void imprimir(string texto, int veces=1){ ![](1\_MetodosPropiedades.004.png)

`    `for(int x = 0; x < veces; x ++) 

`        `Console.WriteLine(texto); 

} 

var llamadaFunción = new ejemplosSintaxis().imprimir(); 

Lambda(Métodos anónimos)![](1\_MetodosPropiedades.005.png)

Una expresión lambda es una función anónima que normalmente se la utiliza para enviarla como parámetro a un método para ser evaluada en el mismo.

List<int> numeros = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}); ![](1\_MetodosPropiedades.006.png)int suma = numeros.Find(i => i % 2 == 0); //Sacamos los números pares

1 / 1
**Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/**
