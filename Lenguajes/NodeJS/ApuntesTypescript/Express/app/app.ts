import express = require('express')
import cors = require('cors')

const port: number = 3000;
const app: express.Application = express();

app.use(express.json)
app.use(cors());

app.listen(port, function () {
    console.log(`Corriendo en el puerto ${port}`);
})

app.get('/', function (request, response) {
    response.send('Holaaaaaaaa, prueba con Typescrit');
})
