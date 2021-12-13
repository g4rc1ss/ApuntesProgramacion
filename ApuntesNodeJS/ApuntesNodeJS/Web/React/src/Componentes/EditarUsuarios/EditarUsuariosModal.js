import { useState } from 'react'
import './EditarUsuariosComponent.css';
import { useEffect } from 'react';
import { Modal, Button } from 'react-bootstrap';
import { useParams } from 'react-router';


function EditarUsuariosModal(props) {
    let params = useParams();

    const [nombre, setNombre] = useState("");
    const [apellido, setApellido] = useState("");
    const [dni, setDni] = useState("");

    const [show, setShow] = useState(props.showModal);
    const handleClose = function () {
        setShow(false);
        window.location.href = "/listaUsuarios";
    }

    function cambiarNombre(event) {
        setNombre(event.target.value)
    }
    function cambiarApellido(event) {
        setApellido(event.target.value)
    }
    function cambiarDni(event) {
        setDni(event.target.value)
    }

    useEffect(() => {
        async function fetchData() {
            let datosUsuario = await obtenerDatosUsuario(params.idUsuario);
            setNombre(datosUsuario.Nombre);
            setApellido(datosUsuario.Apellido);
            setDni(datosUsuario.DNI);
        }
        fetchData();
    }, [])


    return (
        <>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Editar Usuario</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div class="text-cente">

                        <div class="col-md-12">
                            <label class="col-md-2">Nombre: </label>
                            <input class="col-md-8" type="text" value={nombre} onChange={cambiarNombre} />
                        </div>
                        <div class="col-md-12">
                            <label class="col-md-2">Apellido: </label>
                            <input class="col-md-8" type="text" value={apellido} onChange={cambiarApellido} />
                        </div>
                        <div class="col-md-12">
                            <label class="col-md-2">DNI: </label>
                            <input class="col-md-8" type="text" value={dni} onChange={cambiarDni} />
                        </div>
                    </div>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={() => saveChanges(params.idUsuario, nombre, apellido, dni)}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
}

async function saveChanges(idUsuario, nombre, apellido, dni) {
    let response = await fetch(`http://localhost:55434/actualizarUsuario`, {
        method: 'PUT',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ Id: idUsuario, Nombre: nombre, Apellido: apellido, DNI: dni })
    })
    //alert("Se han guardado los datos correctamente");
    window.location.href = "/listaUsuarios";
}

async function obtenerDatosUsuario(idUsuario) {
    let response = await fetch(`http://localhost:55434/listaUsuarios?id=${idUsuario}`);
    let respuesta = await response.json();
    return respuesta[0];
}


export default EditarUsuariosModal;