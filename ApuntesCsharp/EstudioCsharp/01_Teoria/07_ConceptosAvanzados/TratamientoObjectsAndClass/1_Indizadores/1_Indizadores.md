![](1\_Indizadores.001.png)

**Evaluation Only. Created with Aspose.Words. Copyright 2003-2021 Aspose Pty Ltd.**

7\_Indizadores.md 1/21/2020

Indizadores![](1\_Indizadores.002.png)

Permiten crear una **clase**, un **struct** o una **interfaz** con un "indice" al que se accederá a traves del objeto instanciado de la clase, no hace falta acceder a la matriz como tal.

public class ClaseIndex { ![](1\_Indizadores.003.png)

`    `private float[] temps = new float[10] { 56.2F, 56.7F, 56.5F, 56.9F, 58.8F,                                             61.3F, 65.9F, 62.1F, 59.2F, 57.5F };     public float this[int index] { 

`        `get { 

`            `return temps[index]; 

`        `} 

`        `set { 

`            `temps[index] = value; 

`        `} 

`    `} 

`    `public int Contador => temps.Length; 

} 

//---------USAR EL INDEX--------\\

static void Main(){ 

`    `ClaseIndex objetoIndice = new ClaseIndex(); 

`    `objetoIndice[1] = 58.3F;     objetoIndice[5] = 98.4F; 

`    `for (int x = 0; x < objetoIndice.Contador; x++)         Console.WriteLine(objetoIndice[x]); 

} 

1 / 1
**Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/**
