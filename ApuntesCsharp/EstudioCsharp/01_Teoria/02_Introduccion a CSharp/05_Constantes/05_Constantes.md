![](05\_Constantes.001.png)

**Evaluation Only. Created with Aspose.Words. Copyright 2003-2021 Aspose Pty Ltd.**

Las constantes son campos cuyos valores se establecen en tiempo de compilación y nunca se pueden cambiar. Use constantes para proporcionar nombres descriptivos en lugar de literales numéricos ("números mágicos") para valores especiales. 

Para definir valores constantes de tipos enteros (int, byte y así sucesivamente) use un tipo enumerado. Para más información, vea enum. 

Para definir constantes no enteras, un enfoque es agruparlas en una única clase estática denominada Constants. Esto necesitará que todas las referencias a las constantes vayan precedidas por el nombre de clase, como se muestra en el ejemplo siguiente. 

**Ejemplo** 

static class Constants 

{ 

`    `public const double Pi = 3.14159; 

`    `public const int SpeedOfLight = 300000; // km per sec. 

} 

class Program 

{ 

`    `static void Main() 

`    `{ 

`        `double radius = 5.3; 

`        `double area = Constants.Pi \* (radius \* radius); 

`        `int secsFromSun = 149476000 / Constants.SpeedOfLight; // in km     } 

} 

El uso del calificador de nombre de clase ayuda a garantizar que usted y otros usuarios que usan la constante comprenden que es una constante y que no puede modificarse. 
**Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/**
