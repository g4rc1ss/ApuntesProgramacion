<html>

<body>
    <form method="POST" action="Logout.php">
        <button type="submit" name="logout">Logout</button>
    </form>
</body>

</html>

<?php

session_start();
if (!isset($_SESSION["login_id"])) {
    header("Location: Login.php");
}

if (isset($_POST["logout"])) {
    session_destroy();
}
?>