import './NavBarComponent.css';

function NavBarComponent() {

  return (
    <nav class="navbar navbar-center navbar-expand-lg navbar-light bg-light">
      <div class="container-fluid">
        <a class="navbar-brand" href="/">PROYECTO3</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <a class="nav-link active" aria-current="page" href="/">Inicio</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/crearUsuarios">Añadir</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/listaUsuarios">Lista Trabajadores</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}


export default NavBarComponent;