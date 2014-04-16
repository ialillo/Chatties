function muestraError(errorMessage) {
    $("label[id$='errorMensaje']").text(errorMessage);
    $("div[id$='alertDiv']").show();
}

function ocultaError() {
    $("div[id$='alertDiv']").hide();
}

function muestraExito(exitoMensaje) {
    $("label[id$='exitoMensaje']").text(exitoMensaje);
    $("div[id$='exitoDiv']").show();
}

function ocultaExito() {
    $("div[id$='exitoDiv']").hide();
}