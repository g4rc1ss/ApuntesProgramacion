// ---------------ACCIONES DE BOTONES ---------------- \\
var listaIdInputs = ["inputNick", "inputPass1", "inputPass2",
    "inputEmail", "inputDNI", "aceptarCondiciones"];

// Actividad 3, registrar una nueva aficion
function addAficion() {
    let aficion = document.getElementById("inputAficion").value;
    let opcion = document.createElement("option");
    opcion.innerHTML = aficion;
    document.getElementById("aficiones").appendChild(opcion);
}

// Actividad 4, Guardamos los datos de los input
function saveChanges() {
    for (const key in this.listaIdInputs) {
        let elementoGuardar = document.getElementById(this.listaIdInputs[key]);
        let valor;
        if (this.listaIdInputs[key] != "aceptarCondiciones") {
            valor = elementoGuardar.value;
        } else {
            valor = elementoGuardar.checked;
        }
        document.cookie = `${this.listaIdInputs[key]}=${valor}`;
    }
}


// Actividad 5, Cargamos los valores guardados en las cookies
function cargarDatos() {
    for (const key in this.listaIdInputs) {
        if (this.listaIdInputs[key] != "aceptarCondiciones") {
            document.getElementById(this.listaIdInputs[key]).value = this.GetValorCookie(this.listaIdInputs[key]);
        } else {
            document.getElementById(this.listaIdInputs[key]).checked = this.GetValorCookie(this.listaIdInputs[key]);
        }
    }
}