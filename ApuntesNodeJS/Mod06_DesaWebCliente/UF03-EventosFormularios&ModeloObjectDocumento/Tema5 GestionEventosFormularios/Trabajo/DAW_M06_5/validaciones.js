// ------------------------ VALIDACIONES DEL EJERCICIO 1 -------------------- \\

// La logica que siguen estas funciones es bastante similar,
// Primero se comprueba si existe el label correspondiente en el que se va a 
// mostrar el mensaje de validacion, si no existe se creara y despues
// se comprueba la validacion correspondiente, dependiendo de si es valido o no
// El mensaje y el color se cambiaran para mostrar el valor y se asignaran al valor del label

// Validacion del input de usuario
function usuarioValidation(element) {
    if (!document.getElementById("labelInputUsuario")) {
        let elementoCrear = document.createElement("label");
        element.insertAdjacentElement('afterend', elementoCrear);
        elementoCrear.id = "labelInputUsuario";
    }
    let mensaje; let color;
    let labelMensaje = document.getElementById("labelInputUsuario");
    if (element.value.length < 2) {
        mensaje = "Menos de 2 caracteres";
        color = "red";
    } else if (element.value.length > 25) {
        mensaje = "Mas de 25 caracteres";
        color = "red";
    } else {
        mensaje = "Campo de Usuario verificado";
        color = "green";
    }
    labelMensaje.style.backgroundColor = color;
    labelMensaje.innerHTML = mensaje;
}

// Validacion del input password
function passwordValidation(element) {
    var expresionRegular = new RegExp("[A-Za-z0-9]{4,9}");
    if (!document.getElementById("labelPass")) {
        let elementoCrear = document.createElement("label");
        element.insertAdjacentElement('afterend', elementoCrear);
        elementoCrear.id = "labelPass";
    }
    let mensaje; let color;
    
    let labelMensaje = document.getElementById("labelPass");
    if (expresionRegular.test(element.value)) {
        mensaje = "Password valido";
        color = "green";
    } else {
        mensaje = "La pass debe de contener entre 4 y 9 letras o numeros";
        color = "red";
    }
    labelMensaje.style.backgroundColor = color;
    labelMensaje.innerHTML = mensaje;
}

// Validacion del input de confirmar contraseña
function passwordEqualsVerification(element) {
    if (!document.getElementById("labelPassVerification")) {
        let elementoCrear = document.createElement("label");
        element.insertAdjacentElement('afterend', elementoCrear);
        elementoCrear.id = "labelPassVerification";
    }
    
    let mensaje; let color;
    
    let labelMensaje = document.getElementById("labelPassVerification");
    if (document.getElementById("inputPass1").value == element.value) {
        mensaje = "Las password son iguales";
        color = "green";
    } else {
        mensaje = "Las password son diferentes";
        color = "red";
    }
    labelMensaje.style.backgroundColor = color;
    labelMensaje.innerHTML = mensaje;
}

// Validacion del input del email
function emailValidation(element) {
    let expresionRegular = new RegExp("[A-Za-z]@[A-Za-z].[A-Za-z]");
    if (!document.getElementById("labelEmail")) {
        let elementoCrear = document.createElement("label");
        element.insertAdjacentElement('afterend', elementoCrear);
        elementoCrear.id = "labelEmail";
    }
    
    let mensaje; let color;
    
    let labelMensaje = document.getElementById("labelEmail");
    if (expresionRegular.test(element.value)) {
        mensaje = "Email valido";
        color = "green";
    } else {
        mensaje = "El Email debe contener un @, un punto y no numeros";
        color = "red";
    }
    labelMensaje.style.backgroundColor = color;
    labelMensaje.innerHTML = mensaje;
    return false;
}

// Validacion del input del DNI
function DNI_Validation(element) {
    let expresionRegular = new RegExp("[0-9]{8,8}[A-Za-z]{1,1}");

    if (!document.getElementById("labelDNI")) {
        let elementoCrear = document.createElement("label");
        element.insertAdjacentElement('afterend', elementoCrear);
        elementoCrear.id = "labelDNI";
    }
    
    let mensaje; let color;

    let labelMensaje = document.getElementById("labelDNI");
    if (expresionRegular.test(element.value)) {
        mensaje = "DNI valido";
        color = "green";
    } else {
        mensaje = "El DNI debe de contener 8 numeros y 1 letra";
        color = "red";
    }
    labelMensaje.style.backgroundColor = color;
    labelMensaje.innerHTML = mensaje;
}

// Comprobar que haya minimo 2 aficiones seleccionadas
function comboBoxValidation() {
    let element = document.getElementById("aficiones");
    if (!document.getElementById("labelAficiones")) {
        let elementoCrear = document.createElement("label");
        element.insertAdjacentElement('afterend', elementoCrear);
        elementoCrear.id = "labelAficiones";
    }
    
    let mensaje; let color;

    let labelMensaje = document.getElementById("labelAficiones");
    if (listaAficiones.length >= 2) {
        mensaje = "combo de aficiones valido";
        color = "green";
    } else {
        mensaje = "Hay que seleccionar 2 aficiones";
        color = "red";
    }
    labelMensaje.style.backgroundColor = color;
    labelMensaje.innerHTML = mensaje;
}

// Comprobar que este marcado el checkbox de aceptar condiciones
function checkBoxValidation() {
    let condiciones = document.getElementById("aceptarCondiciones");
    if (!document.getElementById("labelCheckBox")) {
        let elementoCrear = document.createElement("label");
        condiciones.insertAdjacentElement('afterend', elementoCrear);
        elementoCrear.id = "labelCheckBox";
    }
    let mensaje; let color;
    let labelMensaje = document.getElementById("labelCheckBox");
    if (condiciones.checked) {
        mensaje = "Condiciones aceptadas";
        color = "green";
    } else {
        mensaje = "No se han aceptado las condiciones";
        color = "red";
    }
    labelMensaje.style.backgroundColor = color;
    labelMensaje.innerHTML = mensaje;
}