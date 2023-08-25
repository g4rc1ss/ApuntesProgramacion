# Clases Estáticas
Puedes utilizar la palabra clave `static` para definir miembros estáticos en una clase, los cuales pertenecen a la clase en sí misma en lugar de las instancias individuales. Ejemplo:
```typescript
class MathUtils {
    static PI: number = 3.1416;

    static calcularAreaCirculo(radio: number): number {
        return MathUtils.PI * radio * radio;
    }
}

console.log(MathUtils.calcularAreaCirculo(5)); // Output: 78.54
```