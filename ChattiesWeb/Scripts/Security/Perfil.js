var contCambioPass = 1;
var objCP = {};

$(document).ready(function (){
    doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.Seguridad.subURL, chattiesObjects.Services.URLs.Seguridad.currentUser, {}, muestraInfoUsuario);
});

muestraInfoUsuario = function (result) {
    if (result.Success) {
        $("#csNombre").html(result.Object.Nombre + ' ' + result.Object.ApellidoPaterno + ' ' + result.Object.ApellidoMaterno);
        $("#csEmail").html(result.Object.Email);
        $("#csPerfil").html(result.Object.Perfil);
    } else{
        chattiesObjects.Tools.Redirectors.RedirectToLogin();
    }
}

function CambiaPassword() {
    if (validaContrasena()) {
        if (contCambioPass === 1) {
            objCP.oldPassword = $("#txtPassword").val();

            $("#txtPassword").val("");
            $("#txtPassword").attr("placeholder", "Escriba su contraseña nueva");
            contCambioPass += 1;
        }
        else {
            objCP.newPassword = $("#txtPassword").val();
            doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.Seguridad.subURL, chattiesObjects.Services.URLs.Seguridad.changePassword, objCP, CredencialesCorrectas);
        }
    }
}

var CredencialesCorrectas = function (result) {
    if (!result.Success) {
        chattiesObjects.GlobalMessage.Show(result.ServiceMessage, true);
        resetAllControls();
    }
    else {
        chattiesObjects.GlobalMessage.Show("La contraseña se cambio exitosamente", false);
        resetAllControls();
    }
}

function resetAllControls() {
    contCambioPass = 1;
    $("#txtPassword").val("");
    $("#txtPassword").attr("placeholder", "Escriba su contraseña actual");
}

function validaContrasena() {
    if ($("#txtPassword").val() == "") {
        chattiesObjects.PopUp.Show("#txtPassword", "Error", "bottom", "La contraseña no puede ser un texto en blanco", true, 3);
        $("#txtPassword").focus();
        return false;
    }
    else if (!chattiesObjects.regExValidators.validPassword($("#txtPassword").val())) {
        var mensajePopOver;
        mensajePopOver = "<ul>";
        mensajePopOver += "<li>Debe contener al menos 6 caracteres.</li>";
        mensajePopOver += "<li> Al menos un numero.</li>";
        mensajePopOver += "<li>Al menos una letra mayuscula.</li>";
        mensajePopOver += "<li>Al menos una letra minuscula.</li>";
        mensajePopOver += "</ul>";

        chattiesObjects.PopUp.Show("#txtPassword", "Requerimientos de Contraseña:", "bottom", mensajePopOver, true, 8);
        $("#txtPassword").focus();
        return false;
    }
    return true;
}