import { PruebaBack } from "../_02_Core/pruebaBack";

export class HolaController {
    constructor() {
    }

    set(app) {
        app.get('/hola', (req, res) => {
            res.send("Holaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        });
    }
}
