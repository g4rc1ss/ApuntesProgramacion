<?php
require_once("database.php");
$db = new Database();
$tipo = $_POST['tipo'];
$db->query("select * from locales where tipo = '".$tipo."'");
$resultado = $db->rows();
?>

<!DOCTYPE html>
<html>
  <head>
    <title>Simple Map</title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <style>
      html, body, #map-canvas {
        height: 100%;
        margin: 0px;
        padding: 0px
      }
    </style>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp"></script>
    <script>
		var map;
		var geocoder;
		function initialize() {
			geocoder = new google.maps.Geocoder();
			var myLatlng = new google.maps.LatLng(41.22, 2.1);
			var mapOptions = {
				zoom: 13,
				center: myLatlng
			};
			map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
			  
			  
			  
			<?php
			foreach($resultado as $marca){
				echo "var address = \"".$marca['direccion']."\";";
			?>
				geocoder.geocode( { 'address': address}, function(results, status) {
				if (status == google.maps.GeocoderStatus.OK) {
					map.setCenter(results[0].geometry.location);
					var marker = new google.maps.Marker({
					  map: map,
					  position: results[0].geometry.location,
					  animation: google.maps.Animation.DROP,
					  title: <?php echo "'".$marca['nombre']."'";?>
					});
				  
					var contentString = <?php echo "'".$marca['nombre']."'";?>;
					var infowindow = new google.maps.InfoWindow({
					  content: contentString
					});
					google.maps.event.addListener(marker, 'click', function() {
						infowindow.open(map,marker);
					}); 
				} else {
					alert('Geocode was not successful for the following reason: ' + status);
				}
			  });
			  <?php
				}
			  ?>
		}

		google.maps.event.addDomListener(window, 'load', initialize);

    </script>
  </head>
  <body>
    <div id="map-canvas" style="height: 50%; width: 50%"></div>
  </body>
</html>