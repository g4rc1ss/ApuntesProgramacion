# Operadores

1. **Operadores Aritméticos**:

```typescript
let a = 10;
let b = 5;

console.log(a + b); // Output: 15
console.log(a - b); // Output: 5
console.log(a * b); // Output: 50
console.log(a / b); // Output: 2
console.log(a % b); // Output: 0

let c = 3;
console.log(c++); // Output: 3 (post-incremento)
console.log(c);   // Output: 4

let d = 5;
console.log(++d); // Output: 6 (pre-incremento)
console.log(d);   // Output: 6
```

2. **Operadores de Asignación**:

```typescript
let x = 10;

x += 5;
console.log(x); // Output: 15

x -= 3;
console.log(x); // Output: 12

x *= 2;
console.log(x); // Output: 24

x /= 4;
console.log(x); // Output: 6

x %= 3;
console.log(x); // Output: 0
```

3. **Operadores de Comparación**:

```typescript
let a = 5;
let b = 3;

console.log(a == b);  // Output: false
console.log(a != b);  // Output: true
console.log(a > b);   // Output: true
console.log(a < b);   // Output: false
console.log(a >= b);  // Output: true
console.log(a <= b);  // Output: false
```