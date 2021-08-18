class Pizza {
    // -------------------- Parte 1 --------------------
    nombre = "";
    precio = 0;
    tiempoParaHornear = 0.0;
    ingredientes;
    // Fin de la parte 1

    // -------------------- Parte 2 --------------------
    calculaTiempoParaHornear(numIngredientes) {
        return 10 + (numIngredientes * 2);
    }
    // Fin parte 2

    // -------------------- Parte 3 --------------------
    constructor(nombre, precio, ingredientesArray) {
        this.nombre = nombre;
        this.precio = precio;
        this.tiempoParaHornear = this.calculaTiempoParaHornear(ingredientesArray.length);
        this.ingredientes = ingredientesArray;
    }

    // -------------------- Parte 5 --------------------
    hornear() {
        this.tiempoParaHornear -= Math.floor((Math.random() * 10) + 1);
        if (this.tiempoParaHornear < 0)
            this.tiempoParaHornear = 0;
    }
}

// -------------------- Parte 4 --------------------
// &nbsp; es para agregar un espacio en el html
function mostrarPizzas() {
    document.getElementById("listaPizzas").innerHTML = ""
    for (let i in pizzas) {
        document.getElementById("listaPizzas")
            .appendChild(document.createElement("li"))
            .innerHTML = `${pizzas[i].nombre} </br> 
            &nbsp;&nbsp;  ${pizzas[i].precio} </br>
            &nbsp;&nbsp;  ${pizzas[i].tiempoParaHornear} </br>
            &nbsp;&nbsp;  ${pizzas[i].ingredientes} </br> </br>`;
    }
}

// -------------------- Parte 6 --------------------
function horneando() {
    window.setInterval(function () {
       for(let pizza in pizzas){
           pizzas[pizza].hornear();
       }
       mostrarPizzas();
    }, 1000);
}

// -------------------- Parte 3 --------------------
//Parte 3, array Pizzas
jamonQueso = new Pizza("jamonQueso", 5, ["Jamon", "Queso"]);
barbacoa = new Pizza("barbacoa", 8, ["carne", "SalsaBQQ", "Maiz"]);
cuatroQuesos = new Pizza("4Quesos", 10, ["mozzarella.", "queso azul", "parmesano", "queso de cabra"]);
// Array para acceder a las pizzas
var pizzas = [jamonQueso, barbacoa, cuatroQuesos];
