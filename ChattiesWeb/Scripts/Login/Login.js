$(document).ready(function () {

    //Establecemos el contenido del modal dialog
    modalTitle = "Renueva Contraseña";

    modalBody =     "<p>Hemos detectado que tu contrase&ntilde;a no est&aacute; encriptada, es necesario que cambies tu contrase&ntilde;a para poder usar el sistema.</p>";
    modalBody +=    "<div class='form' role='form'>";
    modalBody +=        "<div class='form-group'>";
    modalBody +=            "<label for='txtPwdNuevo'>Contraseña Nueva</label>";
    modalBody +=            "<div class='input-group col-xs-12 col-sm-12 col-md-12 col-lg-12'>";
    modalBody +=                "<input type='password' id='txtPwdNuevo' class='form-control' placeholder='Contraseña Nueva' autofocus />";
    modalBody +=            "</div>";
    modalBody +=        "</div>";
    modalBody +=        "<div class='form-group'>";
    modalBody +=            "<label for='txtPwdNuevoConfirm'>Confirmar Contraseña</label>";
    modalBody +=            "<div class='input-group col-xs-12 col-sm-12 col-md-12 col-lg-12'>";
    modalBody +=                "<input type='password' id='txtPwdNuevoConfirm' class='form-control' placeholder='Confirmar Contraseña' />";
    modalBody +=            "</div>";
    modalBody +=        "</div>";
    modalBody +=    "</div>";

    modalFooter = "<button id='btnCambiaContrasena' type='button' class='btn btn-primary'>Cambiar</button>";
    modalFooter += "<button id='btnCancelar' type='button' class='btn btn-default'>Cancelar</button>";

    preparaModal(modalTitle, modalBody, modalFooter);

    //Le agregamos el evento click al boton de cambiar contraseña del modal del login
    $("#btnCambiaContrasena").bind("click", function (event) {
        var objLogin = new Object;
        objLogin.Login = $("#txtUsuario").val();
        objLogin.Password = $("#txtPwdNuevo").val();

        // Si las contraseñas escritas son distintas entre ellas
        if ($("#txtPwdNuevo").val() != $("#txtPwdNuevoConfirm").val()) {
            //Mostramos el mensaje de error al usuario
            muestraPopover("#txtPwdNuevoConfirm", "Error", "bottom", "Ambas contraseñas deben ser identicas", 3);
        }
        else {
            doJsonObjectAjaxCallback("Login.aspx/CambiaPassword", "login", JSON.stringify(objLogin), cambioDeContrasenaCorrecto);
        }
    });

    //Validaciones para el primer textbox de contraseña
    $("#txtPwdNuevo")[0].onblur = function () {
        if ($("#txtPwdNuevo").val() == "") {
            muestraPopover("#txtPwdNuevo", "Error", "bottom", "La contraseña no puede ser un texto en blanco", 3);
            $("#txtPwdNuevo").focus();
        }
        else if (!passwordValido($("#txtPwdNuevo").val())) {
            var mensajePopOver;
            mensajePopOver = "<ul>";
            mensajePopOver +=   "<li>Debe contener al menos 6 caracteres.</li>";
            mensajePopOver +=   "<li> Al menos un numero.</li>";
            mensajePopOver +=   "<li>Al menos una letra mayuscula.</li>";
            mensajePopOver +=   "<li>Al menos una letra minuscula.</li>";
            mensajePopOver += "</ul>";

            muestraPopover("#txtPwdNuevo", "Requerimientos de Contraseña:", "bottom", mensajePopOver, 8);
            $("#txtPwdNuevo").focus();
        }
    }

    // Le agregamos el vento click al boton de cancelar del modal del login
    $("#btnCancelar").bind("click", function (event) {
        ocultaModal();
    });

    //Funcion que se detonal al momento de darle click al boton de Login
    $("#btnLogin").bind("click", function (event) {
        //Oculta el mensaje de error si es que existe
        ocultaError();
        //Limpiamos los textboxes del popup de cambio de contraseña 
        $("#txtPwdNuevo").val("");
        $("#txtPwdNuevoConfirm").val("");
        $("#txtPwdNuevo").parent().removeClass("has-error");
        $("#txtPwdNuevoConfirm").parent().removeClass("has-error");

        //Creamos un objeto para pasarlo como parametro en el callback de ajax
        var objLogin = new Object;
        objLogin.Login = $("#txtUsuario").val();
        objLogin.Password = $("#txtPassword").val();

        //Llamamos a la funcion generica para hacer un callback
        doJsonObjectAjaxCallback("Login.aspx/LoginAttempt", "login", JSON.stringify(objLogin), LoginCorrecto);
    });
});

//Es la funcion que se ejecuta cuando se hizo el callback correctamente.
var LoginCorrecto = function (dObj) {
    var objeto = JSON.parse(getMain(dObj));

    //Entra aqui si el password es incorrecto o el usuario no existe
    if (objeto.nombreCompleto.indexOf("Error") > -1)
    {
        muestraError(objeto.nombreCompleto);
    }
    //Entra aqui si el password del usuario todavia no esta encriptado
    else if (objeto.nombreCompleto.indexOf("Viejo") > -1)
    {
        muestraModal();
    }
    //Entra aqui cuando la operacion se realizo con exito
    else
    {
        window.location.href = "../../Home.aspx";
    }
}

// Funcion que se desencadena una ves que se ejecutó el método de cambio de contraseña en el servidor
function cambioDeContrasenaCorrecto(dObj) {
    var objeto = getMain(dObj);

    if (objeto.indexOf("Error") > -1) {
        muestraPopover("#btnCambiaContrasena", "Error:", "top", objeto, 8);
    } else {
        ocultaModal();
        $("#txtPassword").val("");
        $("#txtPassword").focus();
        muestraExito("Cambio de contraseña exitoso, por favor accesa con tus nuevas credenciales.");
    }
}