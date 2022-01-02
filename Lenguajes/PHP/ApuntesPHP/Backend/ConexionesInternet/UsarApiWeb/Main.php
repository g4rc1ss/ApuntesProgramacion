<?php

$curl = curl_init();

$response = file_get_contents("https://ipinfo.io/json");

?>

<!DOCTYPE html>
<html>

<head>

</head>

<body>
    <?php echo $response; ?>
</body>

</html>