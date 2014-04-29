var contCambioPass = 1;

function CambiaPassword() {
    var objLogin = new Object;
    objLogin.Login = $("p[id$=csUsuario]").text();
    objLogin.Password = $("#txtPassword").val();

    var strongPassword = validaContrasena();

    if (strongPassword) {
        if (contCambioPass == 1) {
            doJsonObjectAjaxCallback("Perfil.aspx/VerificaCredenciales", "login", JSON.stringify(objLogin), CredencialesCorrectas);
        }
        else {
            doJsonObjectAjaxCallback("Perfil.aspx/CambiaPassword", "login", JSON.stringify(objLogin), CredencialesCorrectas);
        }
    }
}

var CredencialesCorrectas = function (dObj) {
    var objeto = getMain(dObj);

    $("#txtPassword").parent().removeClass("has-success");
    $("#txtPassword").parent().removeClass("has-error");

    if (objeto.indexOf("Error") > -1) {
        $("#txtPassword").parent().addClass("has-error");
        chattiesObjects.GlobalMessage.Show(objeto, true);
    }
    else {
        if (contCambioPass == 1) {
            $("#txtPassword").val("");
            $("#btnCambiaContraseña").removeClass("btn-default");
            $("#btnCambiaContraseña").addClass("btn-success");
            $("#txtPassword").parent().addClass("has-success");
            $("#txtPassword").attr("placeholder", "Contraseña nueva");
            contCambioPass += 1;
        }
        else {
            chattiesObjects.GlobalMessage.Show("La contraseña se cambio exitosamente", false);
            resetAllControls();
        }
    }
}

function resetAllControls() {
    contCambioPass = 1;
    $("#btnCambiaContraseña").removeClass("btn-success");
    $("#btnCambiaContraseña").addClass("btn-default");
    $("#txtPassword").val("");
    $("#txtPassword").parent().removeClass("has-success");
    $("#txtPassword").parent().removeClass("has-error");
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