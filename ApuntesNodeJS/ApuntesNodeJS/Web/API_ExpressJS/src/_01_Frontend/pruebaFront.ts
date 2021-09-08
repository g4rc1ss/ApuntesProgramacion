import { PruebaBack } from "..\\_02_Backend\\pruebaBack";

export class PruebaFront {
    constructor(parameters) {

    }

    saludar() {
        let back: PruebaBack = new PruebaBack("");

        back.saludo();
    }
}
