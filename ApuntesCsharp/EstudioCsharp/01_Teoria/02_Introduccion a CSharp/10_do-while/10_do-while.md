![](10\_do-while.001.png)

**Evaluation Only. Created with Aspose.Words. Copyright 2003-2021 Aspose Pty Ltd.**

La instrucción do ejecuta una instrucción o un bloque de instrucciones mientras que una expresión booleana especificada se evalúa como true. Como esa expresión se evalúa después de cada ejecución del bucle, un bucle do-while se ejecuta una o varias veces. Esto es diferente del bucle while, que se ejecuta cero o varias veces. 

En cualquier punto del bloque de instrucciones do, se puede salir del bucle mediante la instrucción break. 

Puede ir directamente a la evaluación de la expresión while mediante la instrucción continue. Si la expresión se evalúa como true, la ejecución continúa en la primera instrucción del bucle. En caso contrario, la ejecución continúa en la primera instrucción después del bucle. 

También se puede salir de un bucle do-while mediante las instrucciones goto, return o throw. 

**Ejemplo** 

En el ejemplo siguiente se muestra el uso de la instrucción do.  

int n = 0; 

do  

{ 

`    `Console.WriteLine(n);     n++; 

} while (n < 5); 
**Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/**
