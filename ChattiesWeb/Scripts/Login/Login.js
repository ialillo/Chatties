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

    chattiesObjects.Modal.Create("body", modalTitle, modalBody, modalFooter);
    chattiesObjects.GlobalMessage.Create();

    //Le agregamos el evento click al boton de cambiar contraseña del modal del login
    $("#btnCambiaContrasena").bind("click", function (event) {
        var objLogin = {
            user: { Usuario: $("#txtUsuario").val() },
            oldPassword: $("#txtPassword").val(),
            newPassword: $("#txtPwdNuevo").val()
        }

        // Si las contraseñas escritas son distintas entre ellas
        if ($("#txtPwdNuevo").val() !== $("#txtPwdNuevoConfirm").val()) {
            //Mostramos el mensaje de error al usuario
            chattiesObjects.PopUp.Show("#txtPwdNuevoConfirm", "Error", "bottom", "Ambas contraseñas deben ser identicas", true, 3);
        }
        else {
            // Si pasa el filtro de validaciones se hace la llamda asincrona al servidor para cambiar la contraseña
            doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.Seguridad.subURL, chattiesObjects.Services.URLs.Seguridad.changePassword, objLogin, cambioDeContrasenaCorrecto);
        }
    });

    //Validaciones para el primer textbox de contraseña
    $("#txtPwdNuevo")[0].onblur = function () {
        if ($("#txtPwdNuevo").val() === "") {
            chattiesObjects.PopUp.Show("#txtPwdNuevo", "Error", "bottom", "La contraseña no puede ser un texto en blanco", true, 3);
            $("#txtPwdNuevo").focus();
        }
        else if (!chattiesObjects.regExValidators.validPassword($("#txtPwdNuevo").val())) {
            var mensajePopOver;
            mensajePopOver = "<ul>";
            mensajePopOver +=   "<li>Debe contener al menos 6 caracteres.</li>";
            mensajePopOver +=   "<li> Al menos un numero.</li>";
            mensajePopOver +=   "<li>Al menos una letra mayuscula.</li>";
            mensajePopOver +=   "<li>Al menos una letra minuscula.</li>";
            mensajePopOver += "</ul>";

            chattiesObjects.PopUp.Show("#txtPwdNuevo", "Requerimientos de Contraseña:", "bottom", mensajePopOver, true, 8);
            $("#txtPwdNuevo").focus();
        }
    };

    // Le agregamos el vento click al boton de cancelar del modal del login
    $("#btnCancelar").bind("click", function (event) {
        chattiesObjects.Modal.Hide();
    });

    //Funcion que se detonal al momento de darle click al boton de Login
    $("#btnLogin").bind("click", function (event) {
        //Limpiamos los textboxes del popup de cambio de contraseña 
        $("#txtPwdNuevo").val("");
        $("#txtPwdNuevoConfirm").val("");
        $("#txtPwdNuevo").parent().removeClass("has-error");
        $("#txtPwdNuevoConfirm").parent().removeClass("has-error");

        //Creamos un objeto para pasarlo como parametro en el callback de ajax
        var objUsuario = {
            user: { Usuario: $("#txtUsuario").val() },
            password: $("#txtPassword").val()
        };

        //Llamamos a la funcion generica para hacer un callback
        doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.Seguridad.subURL, chattiesObjects.Services.URLs.Seguridad.authenticate, objUsuario, LoginCorrecto);
    });
});

//Es la funcion que se ejecuta cuando se hizo el callback correctamente.
var LoginCorrecto = function (result) {
    //Entra aqui si el password es incorrecto o el usuario no existe
    if (!result.Success) {
        chattiesObjects.GlobalMessage.Show(result.ServiceMessage, true);
    }
        //Entra aqui si el password del usuario todavia no esta encriptado
    else if (result.Success && result.ServiceMessage.indexOf("Viejo") > -1) {
        chattiesObjects.Modal.Show();
    }
        //Entra aqui cuando la operacion se realizo con exito
    else {
        chattiesObjects.Tools.Redirectors.RedirectToHome();
    }
};

// Funcion que se desencadena una ves que se ejecutó el método de cambio de contraseña en el servidor
function cambioDeContrasenaCorrecto(result) {

    if (!result.Success) {
        chattiesObjects.PopUp.Show("#btnCambiaContrasena", "Error:", "top", result.ServiceMessage, true, 8);
    } else {
        chattiesObjects.Modal.Hide();
        chattiesObjects.GlobalMessage.Show("Cambio de contraseña exitoso, por favor accesa con tus nuevas credenciales.", false);
        $("#txtPassword").val("");
        $("#txtPassword").focus();
    }
}