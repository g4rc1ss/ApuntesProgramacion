import { useState } from 'react'
import './AñadirUsuarios.css';

function AñadirUsuarios() {
    const [dni, setdni] = useState("")

    function cambiarDni(event) {
        setdni(event.target.value);
    }

    const [nombre, setNombre] = useState("")

    function cambiarNombre(event) {
        setNombre(event.target.value);
    }

    const [apellidos, setApellidos] = useState("")

    function cambiarApellidos(event) {
        setApellidos(event.target.value);
    }
    return (
        <div class="container" className="AñadirUsuario">
            <p class="trabajador">Añada los datos del nuevo trabajador:</p>
            <label>DNI</label>
            <input type="text" value={dni} onChange={cambiarDni} />


            <label>Nombre</label>
            <input type="text" value={nombre} onChange={cambiarNombre} />


            <label>Apellidos</label>
            <input type="text" value={apellidos} onChange={cambiarApellidos} />

            <button class="btn btn-success" onClick={() => añadirUsuarioFetch(nombre, apellidos, dni)} >Añadir</button>
        </div>
    )

    async function añadirUsuarioFetch(nombreUsuario, apellidoUsuario, dniUsuario) {
        let response = await fetch(`http://localhost:55434/crearUsuario`, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ Nombre: nombreUsuario, Apellido: apellidoUsuario, DNI: dniUsuario })
        })
        let respuesta = await response.json();
        console.log(respuesta)
        //alert("Se ha añadido correctamente");
    }

}
export default AñadirUsuarios;



