
**Implementación básica de una caché en memoria:**

Puedes implementar una caché en memoria utilizando un objeto o un mapa en TypeScript. Aquí tienes un ejemplo básico:

```typescript
// Ejemplo de clase de caché
class MemoryCache {
  private data: { [key: string]: any } = {};

  public set(key: string, value: any): void {
    this.data[key] = value;
  }

  public get(key: string): any {
    return this.data[key];
  }

  public has(key: string): boolean {
    return key in this.data;
  }

  public delete(key: string): void {
    delete this.data[key];
  }

  public clear(): void {
    this.data = {};
  }
}

// Uso de la caché
const cache = new MemoryCache();
cache.set('clave1', 'valor1');
cache.set('clave2', 'valor2');

console.log(cache.get('clave1')); // Salida: valor1
console.log(cache.get('clave2')); // Salida: valor2
console.log(cache.has('clave1')); // Salida: true

cache.delete('clave1');
console.log(cache.has('clave1')); // Salida: false

cache.clear();
console.log(cache.get('clave2')); // Salida: undefined
```

En este ejemplo, creamos una clase `Cache` que utiliza un objeto (`data`) para almacenar los valores en la memoria caché. La clase `Cache` proporciona métodos como `set`, `get`, `has`, `delete` y `clear` para interactuar con la caché. Utilizamos estos métodos para almacenar, recuperar, verificar la existencia, eliminar y limpiar los valores en la caché.

**Cache con tiempo de expiración:**

Puedes mejorar la caché en memoria añadiendo una funcionalidad de tiempo de expiración a los valores almacenados. Aquí tienes un ejemplo:

```typescript
interface CacheItem {
  value: any;
  expiresAt: number;
}

class ExpiringCache {
  private data: Map<string, CacheItem> = new Map();

  public set(key: string, value: any, expiresInMs: number): void {
    const expiresAt = Date.now() + expiresInMs;
    this.data.set(key, { value, expiresAt });
  }

  public get(key: string): any {
    const item = this.data.get(key);
    if (item && item.expiresAt > Date.now()) {
      return item.value;
    }
    this.data.delete(key);
    return undefined;
  }

  public has(key: string): boolean {
    const item = this.data.get(key);
    return !!item && item.expiresAt > Date.now();
  }

  public delete(key: string): void {
    this.data.delete(key);
  }

  public clear(): void {
    this.data.clear();
  }
}

// Uso de la caché con tiempo de expiración
const expiringCache = new ExpiringCache();
expiringCache.set('clave1', 'valor1', 5000); // Valor expirará después de 5 segundos

console.log(expiringCache.get('clave1')); // Salida: valor1

setTimeout(() => {
  console.log(expiringCache.get('clave1')); // Salida: undefined (valor expirado)
}, 6000);
```

En este ejemplo, hemos mejorado la clase de caché añadiendo un tiempo de expiración a los valores almacenados. Utilizamos una interfaz `CacheItem` para representar cada elemento de la caché, que contiene el valor y el tiempo de expiración. La clase `ExpiringCache` utiliza un mapa (`data`) para almacenar los elementos de la caché y comprueba el tiempo de expiración antes de devolver el valor.

**Consideraciones adicionales:**

Al utilizar una memoria caché en TypeScript, ten en cuenta las siguientes consideraciones:

- Evalúa si el uso de una caché en memoria es apropiado para tu caso de uso. Una caché en memoria es útil cuando los datos se acceden con frecuencia y cambiarlos no tiene un impacto crítico en la aplicación.
- Considera el tamaño de la caché y la vida útil de los datos almacenados. Demasiados datos o una vida útil demasiado larga pueden consumir demasiada memoria y no proporcionar beneficios.
- Evalúa la estrategia de invalidación de la caché, como el tiempo de expiración, el uso de eventos o la invalidación manual.
- Utiliza estructuras de datos adecuadas para almacenar los valores en la caché, como objetos o mapas, según tus necesidades y requisitos de búsqueda y acceso.