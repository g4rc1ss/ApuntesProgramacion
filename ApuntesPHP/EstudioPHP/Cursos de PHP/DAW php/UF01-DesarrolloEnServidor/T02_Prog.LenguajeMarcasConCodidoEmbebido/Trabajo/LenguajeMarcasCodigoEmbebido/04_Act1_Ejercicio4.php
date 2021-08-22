<html>

<body>
    <form method="POST">
        <input type="text" name="nota" placeholder="nota">
        <input type="submit" title="POST">
    </form>
    <?php
    if (count($_POST) > 0) {
        $nota = $_POST["nota"];

        if ($nota >= 0 && $nota <= 4.99) {
            echo "Suspendido!!";
        } else if ($nota >= 5 && $nota <= 6.99) {
            echo "Aprobado!!";
        } else if ($nota >= 7 && $nota <= 8.99) {
            echo "Notable!!";
        } else if ($nota >= 9 && $nota <= 9.99) {
            echo "Excelente!!";
        } else if ($nota == 10) {
            echo "MATRICULA DE HONOR!!!! :OOOO";
        }
    }
    ?>
</body>

</html>