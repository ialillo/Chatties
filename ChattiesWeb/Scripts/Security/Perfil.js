var contCambioPass = 1;

function CambiaPassword() {
    var objLogin = new Object;
    objLogin.Login = $("p[id$=csUsuario]").text();
    objLogin.Password = $("#txtPassword").val();

    if (contCambioPass == 1) {
        doJsonObjectAjaxCallback("Perfil.aspx/VerificaCredenciales", "login", JSON.stringify(objLogin), CredencialesCorrectas);
    }
    else {
        doJsonObjectAjaxCallback("Perfil.aspx/CambiaPassword", "login", JSON.stringify(objLogin), CredencialesCorrectas);
    }
}

var CredencialesCorrectas = function (dObj) {
    var objeto = getMain(dObj);

    ocultaExito();
    ocultaError();
    $("#txtPassword").parent().removeClass("has-success");
    $("#txtPassword").parent().removeClass("has-error");

    if (objeto.indexOf("Error") > -1) {
        $("#txtPassword").parent().addClass("has-error");
        muestraError(objeto);
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
            muestraExito("La contraseña se cambio exitosamente");
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