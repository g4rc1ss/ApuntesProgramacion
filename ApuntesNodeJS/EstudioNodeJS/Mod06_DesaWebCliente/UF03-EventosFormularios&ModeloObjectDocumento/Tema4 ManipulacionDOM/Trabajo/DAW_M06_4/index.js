let listaParticipantes = [];
let colorParticipantes = [];
var cargarEstructura = document.getElementById("estructura");
// Actividad 1
function addParticipantes() {
    try {
        if (listaParticipantes != null || listaParticipantes != undefined) {
            let nodosHijos = cargarEstructura.children;
            for (let index = 0; index < nodosHijos.length; index++) {
                if (nodosHijos[index].id == "nombre") {
                    listaParticipantes = addArray(listaParticipantes, nodosHijos[index].value);
                }
                else if (nodosHijos[index].id == "color") {
                    colorParticipantes = addArray(colorParticipantes,
                        nodosHijos[index].value == "" ? "black" : nodosHijos[index].value);
                    break;
                }
            }
            updateListParticipantes();
        } else {
            listaParticipantes = new Array();
            if (colorParticipantes == null || listaParticipantes == undefined) {
                colorParticipantes = new Array();
            }
            addParticipantes();
        }
    } catch (error) { }
}

// Actividad 2
function finalizarCompeticion() {
    try {
        if (listaParticipantes.length > 0) {
            colorParticipantes[0] = "green";
            if (listaParticipantes.length == 2) {
                colorParticipantes[1] = "red";
            }
            else if (listaParticipantes.length == 3) {
                colorParticipantes[1] = "blue";
                colorParticipantes[2] = "red";
            }
            else if (listaParticipantes.length >= 4) {
                colorParticipantes[1] = "blue";
                colorParticipantes[2] = "orange";
                colorParticipantes[3] = "red";
            }
        }
    } catch{
        console.error("Se ha registrado un error en la funcion finalizarCompeticion");
    }
    updateListParticipantes();
}

// Actividad 3
function borrarParticipante() {
    try {
        let nodosHijos = cargarEstructura.children;
        for (let index = 0; index < nodosHijos.length; index++) {
            if (nodosHijos[index].id == "posicion") {
                listaParticipantes = delArray(listaParticipantes, (nodosHijos[index].value) - 1);
                colorParticipantes = delArray(colorParticipantes, (nodosHijos[index].value) - 1);
                break;
            }
        }
        updateListParticipantes();
    } catch (error) { }
}

//Actividad 4
function mueveParticipante() {
    try {
        let nodosHijos = cargarEstructura.children;
        let indexPosicion;
        let indexPosicionFinal;
        for (let index = 0; index < nodosHijos.length; index++) {
            if (nodosHijos[index].id == "posicion") {
                indexPosicion = nodosHijos[index].value - 1;
            } else if (nodosHijos[index].id == "posicionFinal") {
                indexPosicionFinal = nodosHijos[index].value - 1;
                break;
            }
        }
        listaParticipantes = movArray(listaParticipantes, indexPosicion, indexPosicionFinal);
        colorParticipantes = movArray(colorParticipantes, indexPosicion, indexPosicionFinal);
        updateListParticipantes();
    } catch (error) { }
}

//Actividad 5
function modificaParticipante() {
    try {
        let nodosHijos = cargarEstructura.children;
        let nuevoDato;
        let indiceDondeModificar;
        for (let index = 0; index < nodosHijos.length; index++) {
            if (nodosHijos[index].id == "nombre") {
                nuevoDato = nodosHijos[index].value;
            } else if (nodosHijos[index].id == "posicion") {
                indiceDondeModificar = nodosHijos[index].value - 1
                break;
            }
        }
        listaParticipantes[indiceDondeModificar] = nuevoDato;
        updateListParticipantes();
    } catch (error) { }
}

// funcion para updatear la lista de elementos cuando se agregan, borrar, modifican...
function updateListParticipantes() {
    try {
        let contenedorLista = document.getElementById("contenedorParticipantes");
        if (contenedorLista.firstElementChild != null) {
            let nodoOl = contenedorLista.firstChild;
            contenedorLista.removeChild(nodoOl);
        }
        let ol = contenedorLista.appendChild(document.createElement("ol"));
        for (let index = 0; index < listaParticipantes.length; index++) {
            ol.innerHTML += `<li style="color:${colorParticipantes[index]};"> ${listaParticipantes[index]} </li>`;
        }
    } catch (error) { }
}
