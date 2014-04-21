var popoverSettings;
var tmpTimeOut = null;
var modalTitle = "";
var modalBody = "";
var modalFooter = "";

// Funciones y acciones iniciales
$(document).ready(function () {
    // Arreglo en donde estan los settings del popover
    popoverSettings = {
        title: "",
        placement: "",
        html: true,
        selector: "",
        content: function () {
            return $("#popoverContent").html();
        }
    }

    var strMensajeExitoError;

    strMensajeExitoError =  "<div class='navbar-fixed-bottom col-sm-6 col-sm-offset-3 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2'>";
    strMensajeExitoError +=     "<div id='alertDiv' class='alert alert-danger alert-dismissable' style='display:none;'>";
    strMensajeExitoError +=         "<label id='errorMensaje'></label>";
    strMensajeExitoError +=         "<button type='button' class='close' onclick='ocultaError();'>&times;</button>";
    strMensajeExitoError +=     "</div>";
    strMensajeExitoError +=     "<div id='exitoDiv' class='alert alert-success alert-dismissable' style='display:none;'>";
    strMensajeExitoError +=         "<label id='exitoMensaje'></label>";
    strMensajeExitoError +=         "<button type='button' class='close' onclick='ocultaExito();'>&times;</button>";
    strMensajeExitoError +=     "</div>";
    strMensajeExitoError += "</div>";

    $("div[class~='mainBody']").append(strMensajeExitoError);

    var strModal;

    strModal = "<div class='modal fade' id='modalGeneral' tabindex='-1' role='dialog' aria-labelledby='dialogTitle' aria-hidden='true'>";
    strModal +=     "<div class='modal-dialog'>";
    strModal +=         "<div class='modal-content'>";
    strModal +=             "<div class='modal-header'>";
    strModal +=                 "<h4 class='modal-title' id='dialogTitle'></h4>";
    strModal +=             "</div>";
    strModal +=             "<div class='modal-body'>";
    strModal +=             "</div>";
    strModal +=             "<div class='modal-footer'>";
    strModal +=             "</div>";
    strModal +=         "</div>";
    strModal +=     "</div>";
    strModal += "</div>";

    $("body").append(strModal);

    //Insertamos el div del popover para todas las páginas
    $("body").append("<div id='popoverContent' style='display:none;'></div>");
});

// Funcion para mostrar el popover en cualquier lugar
// El controlLigado es el elemento en donde se mostrara el popover
function muestraPopover(controlLigado, tituloPopover, posicionamientoPopover, contenidoPopover, duracionEnSegundos) {
    //Agregamos el atributo al control ligado al popover
    $(controlLigado).attr("rel", "popover");

    //Convertimos la duracion en segundos
    duracionEnSegundos = duracionEnSegundos * 1000;

    popoverSettings.selector = "[rel=popover]";
    popoverSettings.title = "<strong>" + tituloPopover + "</strong>";
    popoverSettings.placement = posicionamientoPopover;

    // Establecemos el contenido del popup
    $("#popoverContent").html(contenidoPopover);

    $("[rel=popover]").popover(popoverSettings);
    $("[rel=popover]").popover("show");

    setTimeout(function () {
        $("[rel=popover]").popover('hide');
        $("[rel=popover]").popover('destroy');
        $(controlLigado).removeAttr("rel");
    }, duracionEnSegundos);
}

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

// Establecemos el html del modal
function preparaModal(pmodalTitle, pmodalBody, pmodalFooter) {
    $("#dialogTitle").text(pmodalTitle);
    $("#modalGeneral div[class='modal-body']").html(pmodalBody);
    $("#modalGeneral div[class='modal-footer']").html(pmodalFooter);
}

// Muestra la ventana modal generica
function muestraModal(pmodalTitle, pmodalBody, pmodalFooter) {
    $("#modalGeneral").modal("show");
}

// Oculta la ventana modal generica
function ocultaModal() {
    $("#modalGeneral").modal("hide");
}

// Funcion que checa que la contraseña cumpla con ciertos requerimientos
function passwordValido(str) {
    // Por lo menos un numero, por lo menos una letra minuscula y una mayuscula
    // Por lo menos 6 caracteres
    var re = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/;

    return re.test(str);
}