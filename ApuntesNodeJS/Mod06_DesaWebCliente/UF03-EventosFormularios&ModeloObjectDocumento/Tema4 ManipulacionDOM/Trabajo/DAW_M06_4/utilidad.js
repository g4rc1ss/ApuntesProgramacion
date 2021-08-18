// Se usa en la actividad 1
// Funcion creada para agregar elementos al array
function addArray(arrayToAdd, elementToAdd) {
    try {
        let array = new Array(arrayToAdd.length + 1);
        for (index = 0; index < array.length; index++) {
            if (index < arrayToAdd.length) {
                array[index] = arrayToAdd[index];
            } else {
                array[index] = elementToAdd;
            }
        }
        return array;
    } catch (error) { }
}

// Se usa en la actividad 3
// Funcion creada para borrar elementos mediante indice del array
function delArray(arrayToDel, indexToSearch) {
    try {
        let array = new Array(arrayToDel.length - 1);
        if (array.length >= indexToSearch) {
            let indexArrayToDel = 0;
            for (let indexNewArray = 0; indexNewArray < array.length; indexNewArray++) {
                if (indexArrayToDel != indexToSearch) {
                    array[indexNewArray] = arrayToDel[indexArrayToDel];
                } else {
                    indexNewArray--;
                }
                indexArrayToDel++;
            }
            return array;
        }
        return arrayToDel;
    } catch (error) { }
}

// Se usa en la actividad 4
function movArray(arrayToMove, ubicacionDondeEsta, ubicacionDondeVa) {
    if (ubicacionDondeVa >= arrayToMove.length) {
        let k = ubicacionDondeVa - arrayToMove.length + 1;
        while (k--) {
            arrayToMove.push(undefined);
        }
    }
    arrayToMove.splice(ubicacionDondeVa, 0, arrayToMove.splice(ubicacionDondeEsta, 1)[0]);
    return arrayToMove;
}
