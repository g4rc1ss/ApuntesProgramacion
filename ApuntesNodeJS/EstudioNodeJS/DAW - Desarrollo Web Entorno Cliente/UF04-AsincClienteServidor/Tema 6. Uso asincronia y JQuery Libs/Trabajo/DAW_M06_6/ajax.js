function generarPalabra() {
    let xmlHttp = new XMLHttpRequest();
    xmlHttp.open("POST", "/Servidor/src/xmlHttpRequest_GenerarPalabra.php", true);
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
            let respuestaJson = xmlHttp.responseText;
            let respuesta = JSON.parse(respuestaJson).longitud;
            let letrasKey = "";

            for (let x = 0; x < respuesta; x++) {
                letrasKey += "_ ";
            }
            document.getElementById("palabra").innerHTML = letrasKey;
        }
    }
    xmlHttp.send();
}


function checkLetra() {
    let configuracionFetch = {
        method: "GET",
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
    };

    let resp = fetch(`/Servidor/src/ApiFetch_CheckearPalabra.php?letra=${document.getElementById("letraToCheck").value}`, configuracionFetch);
    resp.then(function (respuesta) {
        if (!respuesta.status == 200){
            return;
        }
        respuesta.text().then(
            function (respuestaText) {
                let indices = respuestaText.split(' ');
                let palabraToRellenar = document.getElementById('palabra').innerHTML.split(' ');
                for (let index = 0; index < indices.length; index++) {
                    palabraToRellenar[indices[index]] = document.getElementById('letraToCheck').value[0];
                }
                let letrasToAdd = "";
                for (let index = 0; index < palabraToRellenar.length; index++) {
                    letrasToAdd += palabraToRellenar[index] + " ";
                }

                document.getElementById('palabra').innerHTML = letrasToAdd;
                document.getElementById('letraToCheck').value = "";
            }
        );
    });
}