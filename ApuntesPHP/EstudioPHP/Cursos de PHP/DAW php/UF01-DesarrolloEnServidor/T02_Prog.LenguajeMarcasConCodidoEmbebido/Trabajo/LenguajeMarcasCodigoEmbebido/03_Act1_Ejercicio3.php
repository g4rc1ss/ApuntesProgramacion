<html>

<body>
    <form method="POST">
        <input type="text" name="number" placeholder="NUMERO">
        <input type="submit" title="POST">
    </form>
    <?php
    if (count($_POST) > 0) {
        $numero = $_POST["number"];
        if($numero % 5 == 0 && $numero % 2 == 0){
            echo "Multiplo de 2 y de 5";
        } else if ($numero % 5 == 0) {
            echo "Multiplo de 5";
        } else if ($numero % 2 == 0) {
            echo "Multiplo de 2";
        }
    }
    ?>
</body>

</html>