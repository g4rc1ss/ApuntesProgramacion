import { useState } from 'react';
import { useEffect } from 'react';
import './ListaUsuariosComponent.css';
import EditarUsuariosModal from '../EditarUsuarios/EditarUsuariosModal';

function ListaUsuariosComponent() {
    const [usuario, setUsuario] = useState([]);
    //const [isOpen, setIsOpen] = useState(false);

    useEffect(() => {
        async function fetchData() {
            let listaUsuarios = await getListaUsuarios();
            setUsuario(listaUsuarios);
        }
        fetchData();
    }, [])

    return (
        <div>
            <table class="table">
                <thead class="table1">
                    <tr>
                        <th class="text-center" scope="col">DNI</th>
                        <th class="text-center" scope="col">Nombre</th>
                        <th class="text-center" scope="col">Apellido</th>
                        <th class="text-center" scope="col">Última fecha entrada</th>
                        <th class="text-center" scope="col">Última fecha salida</th>
                        <th class="text-center" scope="col">Está en oficina</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        usuario.map(function (usuario) {
                            return (
                                <tr >
                                    <th class="text-center" scope="row">{usuario.DNI}</th>
                                    <td class="text-center">{usuario.Nombre}</td>
                                    <td class="text-center">{usuario.Apellido}</td>
                                    <td class="text-center">{usuario.FechaUltimaEntrada}</td>
                                    <td class="text-center">{usuario.FechaUltimaSalida}</td>
                                    <td class="text-center">{usuario.EstaEnOficina.toString()}</td>
                                    <td>
                                        <button onClick={() => editarUsuario(usuario._id)} class="btn btn-primary">Editar</button>
                                        <button onClick={() => borrarUsuario(usuario._id)} class="btn btn-danger">Eliminar</button>
                                    </td>
                                </tr>
                            );
                        })
                    }
                </tbody>
            </table>
        </div>
    );
}

function getListaUsuarios() {
    let response = fetch(`http://localhost:55434/listaUsuarios`)
        .then(response => response.json())
        .then(respuesta => respuesta)
    return response;
}

function borrarUsuario(idUsuario) {
    fetch(`http://localhost:55434/borrarUsuario`, {
        method: 'DELETE',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ Id: idUsuario })
    })
        .then(response => response.json())
        .then(respuesta => respuesta)

        alert("Se ha eliminado el trabajador correctamente");
    //recargamos la pagina
    window.location.href = "/listaUsuarios";
}

function editarUsuario(dni) {
    window.location.href = `/editarUsuarios/${dni}`;
}

export default ListaUsuariosComponent;