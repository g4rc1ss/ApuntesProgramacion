# Operadores

1. **Operadores aritméticos:**
   - `+` Suma
   - `-` Resta
   - `*` Multiplicación
   - `/` División
   - `%` Módulo (resto de la división)

    ```rust
    let suma = 5 + 3;
    let resta = 7 - 2;
    let multiplicacion = 4 * 6;
    let division = 8 / 2;
    let modulo = 9 % 4;
    ```

2. **Operadores de asignación:**
   - `=` Asignación
   - `+=` Suma y asignación
   - `-=` Resta y asignación
   - `*=` Multiplicación y asignación
   - `/=` División y asignación
   - `%=` Módulo y asignación

    ```rust
    let mut x = 10;
    x += 5; // x ahora es 15
    ```

3. **Operadores de comparación:**
   - `==` Igual a
   - `!=` No igual a
   - `<` Menor que
   - `>` Mayor que
   - `<=` Menor o igual a
   - `>=` Mayor o igual a

    ```rust
    let a = 10;
    let b = 5;

    if a > b {
        println!("a es mayor que b");
    }
    ```

4. **Operadores lógicos:**
   - `&&` AND lógico
   - `||` OR lógico
   - `!` NOT lógico

    ```rust
    let x = true;
    let y = false;

    if x && y {
        // Se ejecuta si ambas condiciones son verdaderas
    }

    if x || y {
        // Se ejecuta si al menos una condición es verdadera
    }

    if !x {
        // Se ejecuta si x es falso
    }
    ```

5. **Operadores de incremento y decremento:**
   - `+= 1`
   - `-= 1`
