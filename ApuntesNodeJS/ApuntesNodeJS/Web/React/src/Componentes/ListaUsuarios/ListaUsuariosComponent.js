import { useState } from 'react';
import { useEffect } from 'react';
import { Navigate } from 'react-router-dom'
import './ListaUsuariosComponent.css';

import EditarUsuariosModal from '../EditarUsuarios/EditarUsuariosModal';

// https://icons.getbootstrap.com/
import * as Icon from 'react-bootstrap-icons';


function ListaUsuariosComponent() {
    const [usuario, setUsuario] = useState([]);
    const [refresh, setRefresh] = useState({});
    const [datosModal, setDatosModal] = useState({ id: "", show: false })

    useEffect(() => {
        async function fetchData() {
            let listaUsuarios = await getListaUsuarios();
            setUsuario(listaUsuarios);
        }
        fetchData();
    }, [refresh])

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
                                    <td class="text-center">
                                        {
                                            usuario.EstaEnOficina ? <Icon.CheckCircle color="green" /> : <Icon.XCircle color="red" />
                                        }
                                    </td>
                                    <td>
                                        <button onClick={() => editarUsuario(usuario._id)} class="btn btn-primary">
                                            <Icon.PencilFill />
                                        </button>
                                        <button onClick={() => borrarUsuario(usuario._id)} class="btn btn-danger">
                                            <Icon.Trash />
                                        </button>
                                    </td>
                                </tr>
                            );
                        })
                    }
                </tbody>
            </table>
            {
                datosModal.show
                    ? <EditarUsuariosModal idUsuario={datosModal.id} showModal={true} onCloseModal={function () {
                        setRefresh({});
                        setDatosModal({ id: "", show: false })
                    }} /> : <></>
            }
        </div>
    );

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
            .then(respuesta => respuesta);
        // Insertamos en el usuario para ejecutar el UseEffect y que se actualice la tabla
        setUsuario(usuario)
        setRefresh({})
    }

    function editarUsuario(idUsuario) {
        setDatosModal({
            id: idUsuario,
            show: true
        });
    }

}
export default ListaUsuariosComponent;