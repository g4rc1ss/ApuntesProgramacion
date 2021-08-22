function GetValorCookie(nombreCookie) {
    // Si tenemos varias cookies cargamos una lista separada por ;
    // asique hacemos un split() para despues filtrar dicha lista
    let cookies = document.cookie.split(";");
    let buscar;
    //mediante un bucle for leemos la lista y buscamos la cookie que queremos
    for (i in cookies) {
        buscar = cookies[i].search(`${nombreCookie}=*`);
        if (buscar > -1) {
            // Una vez encontrada rompemos el bucle
            buscar = i;
            break;
        }
    }
    // Recogemos el valor del indice
    let buscada = cookies[buscar];
    // Filtramos para que nos de el contenido de la cadena despues del = 
    return buscada.substring(buscada.indexOf("=") + 1);
}