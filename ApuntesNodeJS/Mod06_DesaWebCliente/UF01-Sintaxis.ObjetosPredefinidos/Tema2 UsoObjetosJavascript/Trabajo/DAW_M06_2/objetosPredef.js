// Ejercicio 2
function Ejecicio2ListaPropiedades() {
    let propiedadesArray = [
        `Lengua predefinida en el navegador: ${navigator.languages.length > 1 ? navigator.languages : navigator.language}`,
        `URL de la página web : ${document.URL}`,
        `Puerto de la URL: ${document.URL.split(":")[2].split('/')[0]}`,
        `Título de la página web: ${document.title}`,
        `Un valor aleatorio entre 0 y 100 (utiliza el objeto Math): ${this.Math.floor((this.Math.random() * 100) + 1)}`,
        `La fecha actual es: ${new this.Date().getDate()}-${new this.Date().getMonth()+1}-${new this.Date().getFullYear()}`,
        `La hora actual es: ${new this.Date().getHours()}:${new this.Date().getMinutes()}:${new this.Date().getSeconds()}`,
        `Valor máximo que puede tener un número en JavaScript : ${Number.MAX_VALUE}`,
        `Valor mínimo que puede tener un número en JavaScript : ${Number.MIN_VALUE}`,
        `Anchura total de la pantalla: ${screen.width}`
    ];
    document.getElementById("listaPropiedades")
        .appendChild(document.createElement("ol"))
        .setAttribute("id", "olListaPropiedades");

    for (let i in propiedadesArray) {
        document.getElementById("listaPropiedades")
            .appendChild(document.createElement("li"))
            .innerHTML = `${propiedadesArray[i]} </br>`;
    }
}


// Ejercicio 3 - guardamos el valor de la cookie
function ClickDivUrl() {
    document.cookie = `url_usuario=${document.getElementById("url").value}`
}


// Ejercicio 4 - cargamos el valor de la cookie 
function CargamosCookie() {
    this.document.getElementById("url").value = GetValorCookie("url_usuario")
}

// Ejercicio 5 Boton que al clicar se abra una ventana que se cierre en 7 segundos
function nuevaVentanaAbrir() {
    let width = 400; let height = 400;
    let top = (screen.height - height) / 2;
    let left = (screen.width - width) / 2;
    let ventanaAbierta = window.open(
        "nueva_ventana.html",
        "nueva_ventana.html",
        `width=${width}, height=${height}, top=${top}, left=${left} menubar=no`
    );
    window.setInterval(function () {
        if (!ventanaAbierta.closed)
            ventanaAbierta.close();
    }, 7000);
}

// Lanzamos los onload
window.onload = function () {
    Ejecicio2ListaPropiedades();
    CargamosCookie();
}