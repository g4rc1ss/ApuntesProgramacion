![](RecursosNoAdministrados.001.png)

**Evaluation Only. Created with Aspose.Words. Copyright 2003-2021 Aspose Pty Ltd.**

2\_RecursosNoAdministrados.md 1/21/2020

Recursos no Administrados:![](RecursosNoAdministrados.002.png)

Los recursos administrados son aquellos recursos que requieren del uso de .net(CORE, Framework, etc) mientras que los no administrados son recursos externos como los del sistema operativo.![](RecursosNoAdministrados.003.png)

Uso de dll externas y tratarlas como no administradas

En Csharp existe una función para poder importar .dll externas. Como estas no están escritas en un lenguaje de .Net no serán ejecutadas en el espacio de memoria administrado del CLR por tanto deberán de ser tratadas como espacio de memoria **NO** administrado.

Por ejemplo en este trozo de código se importa la librería externa user32.dll (Que gestiona interfaces de usuario de windows), y se utiliza el método MessageBox(...); de la librería importada y dentro del Main() se usa el método declarado mas arriba que a la vez usa el método de la librería importada

using System; ![](RecursosNoAdministrados.004.png)

using System.Runtime.InteropServices; 

class Example { 

`    `[DllImport("user32.dll", CharSet = CharSet.Unicode)] 

`    `public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type); 

`    `static void Main() { 

`        `// Call the MessageBox function using platform invoke. 

`        `MessageBox(new IntPtr(0), "Hello World!", "Hello Dialog", 0);     } 

} 

1 / 1
**Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/**
