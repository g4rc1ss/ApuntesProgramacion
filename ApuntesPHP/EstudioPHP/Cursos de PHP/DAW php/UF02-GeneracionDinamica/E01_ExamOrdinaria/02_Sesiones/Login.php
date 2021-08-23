<html>

<body>
    <form method="POST" action="Login.php">
        <input name="user" type="text" placeholder="User">
        <input name="password" type="text" placeholder="Password">
        <br>
        <button type="submit">Login</button>
    </form>
</body>

</html>

<?php
session_start();
if (count($_POST) > 0) {
    $user = $_POST["user"];
    $password = $_POST["password"];

    // Validamos el usuario y contraseña para realizar el login
    if($user == "examen" && $password == "1234") {
        $_SESSION["login_id"] = random_int(0, 10000);
        header('Location: Perfil.php');
    }
} else if (isset($_SESSION["login_id"])) {
    header("Location: Perfil.php");
}