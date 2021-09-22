import express from "express";
import { HolaController } from ".\\_01_Controllers\\holaController";

const app: any = express();
new HolaController().set(app);
const PORT = 8525;



app.get('/', (req, res) => {
    res.send('Index de la pagina');
});

app.listen(PORT, err => {
    if (err) {
        return console.error(err);
    }
    return console.log(`server is listening on ${PORT}`);
});