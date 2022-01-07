import './NavBarComponent.css';
import { Link } from 'react-router-dom';

function NavBarComponent() {

  return (
    <nav class="navbar navbar-center navbar-expand-lg navbar-light bg-light">
      <div class="container-fluid">
        <Link to="/" className="navbar-brand">PROYECTO3</Link>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <Link to="/" className="nav-link active">Inicio</Link>
            </li>
            <li class="nav-item">
              <Link to="/crearUsuarios" className="nav-link">Añadir</Link>
            </li>
            <li class="nav-item">
              <Link to="/listaUsuarios" className="nav-link">Lista Trabajadores</Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}


export default NavBarComponent;