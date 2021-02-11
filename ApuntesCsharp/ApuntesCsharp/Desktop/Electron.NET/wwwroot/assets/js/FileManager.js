const removeFileIdsInput = document.getElementById("RemoveFileIds");
const dt = new DataTransfer();

function fillRemoveDBFileIdsInput(id) {
    if (removeFileIdsInput.value === "") {
        removeFileIdsInput.value = id;
    } else {
        removeFileIdsInput.value += "," + id;
    }
}

function removeFileFromInput(inputId, fileName) {
    dt.clearData();

    var inputFile = document.getElementById(inputId);

    for (var i = 0; i < inputFile.files.length; i++) {
        if (inputFile.files[i].name !== fileName) {
            dt.items.add(inputFile.files[i]);
        }
    }

    updateInputFiles(inputFile);
}

function addFileDetailsToList(file, inputId) {
    var ul = document.getElementById(inputId + 'DZFileNames');

    var fileName = file.name;
    var fileSize = bytesToSize(file.size);
    var fileType = file.name.split('.').slice(-1)[0];

    ul.innerHTML += ('<li class="name">' + '<span class="badge badge-pill">' + fileType + '</span> ' + '<a class="filename">' + fileName + '</a>' + '<span class="filesize">(' + fileSize + ')</span> <button class="btn remove" type="button" onclick="removeFileFromInput(' + "'" + inputId + "','" + fileName + "'" + ')"><i class="fas fa-times"></i></button>' + '</li>');

}

function bytesToSize(bytes) {
    var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
    if (bytes == 0) return '0 Byte';
    var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
    return Math.round(bytes / Math.pow(1024, i), 2) + ' ' + sizes[i];
}

function addFileToInptut(input, ctrlId) {

    for (let file of input.files) {
        dt.items.add(file);
        addFileDetailsToList(file, ctrlId);
    }

    updateInputFiles(input);
}

function onClickFile(input) {
    //dt.clearData();
    
    //for (let file of input.files) {
    //    dt.items.add(file);
    //}
}

function updateInputFiles(input) {
    input.value = '';

    input.files = dt.files;
}

function onInputFile(input) { 

    //dt.items = input.files;
    addFileToInptut(input, input.id);
}

function onDropFile(e, inputId) {

    console.log('Evento dropzone disparado!');
    e.preventDefault();

    // Getting dropzone control
    dz = document.getElementById(inputId + 'DZ');
    dz.files = e.dataTransfer.files;

    addFileToInptut(dz, inputId);                
}

function onDragOverFile(e) {
    e.preventDefault();
    return false;
}

function onDragLeave() {
    return false;
}