/**
 * Funcion que pida si del menu quiere 1-Ensalada 2-Tallarines 3-Arroz
 * y muestre la opcion seleecionada en el elemento con id "primero"
 * o que indique que no es una opcion valida
 */
function seleccionPrimero() {
    do {
        //pide mediante un prompt el numero de opcion  del menu
        var opcion = window.prompt("Qué quieres de primero?"
                + "\n 1-Ensalada" + "\n 2-Tallarines" + "\n 3-Arroz");
  
        var texto;
        switch (opcion) {
            case "1":
                texto = "Ensalada";
                break;
            case "2":
                texto = "Tallarines";
                break;
            case "3":
                texto = "Arroz";
                break;
            default:
                texto = "No has escogido una opcion valida";
        }
    } while (opcion != "1" && opcion != "2" && opcion !="3");
    document.getElementById("primero").innerHTML = texto;
}