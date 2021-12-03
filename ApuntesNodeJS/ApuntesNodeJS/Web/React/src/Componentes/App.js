import React from "react";
import './App.css';
import {
    BrowserRouter as Router,
    Routes,
    Route
} from "react-router-dom";
import RegistroEntradaSalidaComponent from './RegistroEntradaSalida/RegistrarEntradaSalidaComponent';
import ListaUsuariosComponent from './ListaUsuarios/ListaUsuariosComponent';
import AñadirUsuarios from './AñadirUsuarios/AñadirUsuarios';
import EditarUsuariosModal from "./EditarUsuarios/EditarUsuariosModal";

function App() {
    return (
        <div className="App">
            <Router>
                <Routes>
                    <Route path="/" element={<RegistroEntradaSalidaComponent />} />
                    <Route path="/listaUsuarios" element={<ListaUsuariosComponent />} />
                    <Route path="/crearUsuarios" element={<AñadirUsuarios />} />
                    <Route path="/editarUsuarios/:idUsuario" element={<EditarUsuariosModal showModal={true} />} />
                </Routes>
            </Router>
        </div>

    );
}

export default App;