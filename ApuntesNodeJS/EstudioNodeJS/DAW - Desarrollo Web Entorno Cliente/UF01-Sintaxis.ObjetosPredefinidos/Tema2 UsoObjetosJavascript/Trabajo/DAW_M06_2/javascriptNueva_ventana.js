//Ejercicio 6, parte A
var createTextoIndex = false;
function TextoIndexEjer1() {
    if (!createTextoIndex) {
        win = window.opener;
        win.document.body
            .appendChild(document.createElement("p"))
            .setAttribute("id", "pMostrarIndexElemento");
        createTextoIndex = true;
    }
    win.document.getElementById("pMostrarIndexElemento").innerHTML = ` Tu hija te llama </br>`;
}

//Ejercicio 6, parte B
var createNumAleatorio = false;
function NumAleatorioIndex() {
    if (!createNumAleatorio) {
        win = window.opener;
        win.document.body
            .appendChild(document.createElement("p"))
            .setAttribute("id", "pNumeroAleatorio");
        createNumAleatorio = true;
    }
    win.document.getElementById("pNumeroAleatorio").innerHTML = `${this.Math.floor((this.Math.random() * 10) + 1)} </br>`;
}

//Ejercicio 6, parte C
function CargarVentanaCookie() {
    window.location = GetValorCookie('url_usuario');
}