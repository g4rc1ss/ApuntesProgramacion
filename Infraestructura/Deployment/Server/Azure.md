# Microsoft Azure
Azure es un servicio Serverless en el que se pueden desplegar aplicaciones en la nube, de forma que nosotros solamente tengamos que preocuparnos de la estabilidad, desarrollo y mantenimiento de nuestra aplicacion y no de los servidores.

Microsoft en este caso es el que se encarga de hacer todas las actualizaciones a nivel de software, gestionar la seguridad y encargarse de mantener el hardware de toda su granja de servidores

Para crear una cuenta, tenemos que entrar en el [portal de Azure](https://portal.azure.com) y seleccionar la opcion del free trial, donde nos dan 200$ para gastar en Azure.

Una ver registrados tenemos que empezar a crear los recursos

## App Service
Esta opcion es la base para un servicio web

Cuando le damos a crear, te da la opcion de crear un api web, una web estatica, una wordpress o una web con Database.

En este caso vamos a crear una web app, puesto que lo que vamos a deployear es un API.
<img width="1151" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/dc829a32-2ffa-4add-9505-a8039c151d2d">


<img width="1151" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/e7602404-9976-4c3c-8382-a565d8f2ac7c">

En la seccion de configuracion podemos agregar las variables de entorno y settings de la aplicacion.
<img width="1151" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/58f643c5-88a7-46c2-ac5a-fffa70c8d141">
<img width="1151" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/7947ae2e-b02c-4f80-9992-0cb83f72c737">

Luego, para poder hacer el deploy de la aplicacion, debemos de crear una pipeline automatizada con Github o Azure Pipelines y configurar el deploy como lo necesitamos.

## Mongo Database
<img width="1151" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/098aa0d2-b9d6-4d52-b3f3-7a864e759551">
