$(document).ready(function () {
    popoverSettings.container ="#modalGeneral";
    popoverSettings.selector = "[rel=popover]";
    popoverSettings.animation = true;

    //Le agregamos el evento click al boton de cambiar contraseña del modal del login
    $("#btnCambiaContrasena").bind("click", function (event) {
        $("#txtPwdNuevo").parent().removeClass("has-error");
        $("#txtPwdNuevoConfirm").parent().removeClass("has-error");

        var objLogin = new Object;
        objLogin.Login = $("#txtUsuario").val();
        objLogin.Password = $("#txtPwdNuevo").val();

        // Si las contraseñas escritas son distintas entre ellas
        if ($("#txtPwdNuevo").val() != $("#txtPwdNuevoConfirm").val()) {
            // Les ponemos el estilo de error a los textboxes
            $("#txtPwdNuevo").parent().addClass("has-error");
            $("#txtPwdNuevoConfirm").parent().addClass("has-error");

            // Establecemos el contenido del popup
            $("#popoverContent").html("Las contraseñas deben de coincidir");
            $("#modalGeneral").popover(popoverSettings);
            $("#modalGeneral").popover("show");
        }
    });

    // Le agregamos el vento click al boton de cancelar del modal del login
    $("#btnCancelar").bind("click", function (event) {
        ocultaModal("modalGeneral");
    });
});

//Funcion que se detonal al momento de darle click al boton de Login
function LoginAttempt() {
    //Creamos un objeto para pasarlo como parametro en el callback de ajax
    var objLogin = new Object;
    objLogin.Login = $("#txtUsuario").val();
    objLogin.Password = $("#txtPassword").val();

    //Llamamos a la funcion generica para hacer un callback
    doJsonObjectAjaxCallback("Login.aspx/LoginAttempt", "login", JSON.stringify(objLogin), LoginCorrecto);
}

//Es la funcion que se ejecuta cuando se hizo el callback correctamente.
var LoginCorrecto = function (dObj) {
    var objeto = JSON.parse(getMain(dObj));

    //Entra aqui si el password es incorrecto o el usuario no existe
    if (objeto.nombreCompleto.indexOf("Error") > -1)
    {
        muestraError(objeto.nombreCompleto);
    }
    //Entra aqui si el password del usuario todavia no esta encriptado
    if (objeto.nombreCompleto.indexOf("Viejo") > -1)
    {
        muestraModal("modalGeneral");
    }
    //Entra aqui cuando la operacion se realizo con exito
    else
    {
        window.location.href = "../../Home.aspx";
    }
}