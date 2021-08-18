var nombresLabelVerification = ["labelInputUsuario", "labelPass",
    "labelPassVerification", "labelEmail", "labelDNI", "labelCheckBox", "labelAficiones"];

var listaAficiones = new Array();

// Cuando se pulsa el boton de validacion, se ejecutan las validaciones
// Y se comprueban que todas esten en verde
function validationForm() {
    usuarioValidation(document.getElementById("inputNick"));
    passwordValidation(document.getElementById("inputPass1"));
    passwordEqualsVerification(document.getElementById("inputPass2"));
    emailValidation(document.getElementById("inputEmail"));
    DNI_Validation(document.getElementById("inputDNI"));
    comboBoxValidation();
    checkBoxValidation();
    for (const key in nombresLabelVerification) {
        let comprobacion = document.getElementById(nombresLabelVerification[key]);
        if (comprobacion.style.backgroundColor != "green") {
            return false;
        }
    }
    return true;
}

// cada vez que un input cambie se llama a este metodo
function changeInput(tipoInput) {
    let elemento = document.getElementById(tipoInput);

    comboBoxValidation();
    checkBoxValidation();
    switch (tipoInput) {
        case "inputNick":
            usuarioValidation(elemento);
            break;
        case "inputPass1":
            passwordValidation(elemento);
            break;
        case "inputPass2":
            passwordEqualsVerification(elemento);
            break;
        case "inputEmail":
            emailValidation(elemento);
            break;
        case "inputDNI":
            DNI_Validation(elemento);
            break;
        default:
            break;
    }
}

// Cada vez que se seleccione una de las opciones se llamara a este metodo
function changeSelect() {
    let elementoSelect = document.getElementById("aficiones");
    listaAficiones.push(elementoSelect.value);
}