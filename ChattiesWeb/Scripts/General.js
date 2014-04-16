var popoverSettings

// Funciones y acciones iniciales
$(document).ready(function () {
    // Arreglo en donde estan los settings del popover
    popoverSettings = {
        tittle: "Error",
        container: "body",
        placement: "top",
        selector: "",
        content: function () {
            return $("#popoverContent").html();
        }
    }

    //Insertamos el div del popover para todas las páginas
    $("body").append("<div id='popoverContent' style='display:none;'></div>");
});

// Muestra el error en la parte inferior de la pagina
function muestraError(errorMessage) {
    $("label[id$='errorMensaje']").text(errorMessage);
    $("div[id$='alertDiv']").show();
}

// Oculta el dialogo de error en la parte inferior de la pagina
function ocultaError() {
    $("div[id$='alertDiv']").hide();
}

// Muestra el dialogo de exito en la parte inferior de la pagina
function muestraExito(exitoMensaje) {
    $("label[id$='exitoMensaje']").text(exitoMensaje);
    $("div[id$='exitoDiv']").show();
}

// Oculta el dialogo de exito en la parte inferior de la pagina
function ocultaExito() {
    $("div[id$='exitoDiv']").hide();
}

// Muestra la ventana modal generica
function muestraModal(idModal) {
    $("#" + idModal).modal("show");
}

// Oculta la ventana modal generica
function ocultaModal(idModal) {
    $("#" + idModal).modal("hide");
}