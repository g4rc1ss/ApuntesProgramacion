La interfaz `Iterator` para crear un iterador personalizado que proporcione elementos uno por uno cuando se solicite.


```java
import java.util.Iterator;

class GeneradorNumeros implements Iterable<Integer> {
    private final int limite;

    public GeneradorNumeros(int limite) {
        this.limite = limite;
    }

    @Override
    public Iterator<Integer> iterator() {
        return new Iterator<Integer>() {
            private int numero = 0;

            @Override
            public boolean hasNext() {
                return numero < limite;
            }

            @Override
            public Integer next() {
                return numero++;
            }
        };
    }
}

public class Main {
    public static void main(String[] args) {
        GeneradorNumeros generador = new GeneradorNumeros(5);
        for (int numero : generador) {
            System.out.println(numero);
        }
    }
}
```
