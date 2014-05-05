﻿var masterPageObject = {
    EstableceItemMenuActivo: function () {
        //Quitamos la clase de activo al elemento que la tenga
        $("li[class='active']").removeClass("active");

        // Obtenemos el nombre de la pagina actual
        var curPage = window.location.href.split("/")[window.location.href.split("/").length - 1];

        // Buscamos al elemento del menú que tiene el link y le ponemos la clase de activo
        $("#menu li .submodulo").each(function (inc, obj) {
            var aLinkPage = $(obj).data("link").split("/")[$(obj).data("link").split("/").length - 1];

            if (aLinkPage === curPage) {
                $(obj).addClass("active");
            }
        });
    },
    PreparaModal: function (serviceResult) {
        if (serviceResult.Success) {
            // Traemos el usuario que está en sesión.
            chattiesObjects.UsuarioEnSesion = serviceResult.Object;

            //Preparamos el modal de ayuda.
            var loggedUserName = chattiesObjects.UsuarioEnSesion.Nombre + ' ' + chattiesObjects.UsuarioEnSesion.ApellidoPaterno + ' ' +
                chattiesObjects.UsuarioEnSesion.ApellidoMaterno;
            var mailToCesar = "mailto:admin@bagcity.mx?subject=" + loggedUserName + "(Ayuda Chatties)";
            var mailToIsai = "mailto:isai.alillo@outlook.com?subject=" + loggedUserName + "(Ayuda Chatties)";

            // Preparamos el contenido del modal de ayuda
            var dialogTitle = "";
            var dialogBody = "";
            var dialogFooter = "";

            dialogTitle += "Ayuda";

            dialogBody += "<p>Si tienes alg&uacute;n problema con el sistema, puedes enviar un correo al &aacute;rea de sistemas con las siguientes personas:</p>";
            dialogBody += "<p><a href = '" + mailToCesar + "'><span class = 'glyphicon glyphicon-envelope'></span> Cesar Torres</a><p>";
            dialogBody += "<p><a href = '" + mailToIsai + "'><span class = 'glyphicon glyphicon-envelope'></span> Isaí Alillo</a><p>";

            dialogFooter += "<button id='btnAyudaOK' type='button' class='btn btn-default'>OK</button>";

            // Insertamos el html del modal
            chattiesObjects.Modal.Create("body", dialogTitle, dialogBody, dialogFooter);

            // Boton que oculta el modal de ayuda
            $("#btnAyudaOK").bind("click", function () {
                chattiesObjects.Modal.Hide();
            });

            // Le ponemos al link de ayuda la funcionalidad
            $("#linkAyuda").bind("click", function () {
                chattiesObjects.Modal.Show();
            });
        } else {
            // Re dirijimos al login ya que la sesión expiró.
            chattiesObjects.Tools.Redirectors.RedirectToLogin();
        }
    }
}


$(document).ready(function () {
    //Creamos el objeto de mensajes globales del sitio
    chattiesObjects.GlobalMessage.Create();

    //Insertamos el menu
    doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.Seguridad.subURL, chattiesObjects.Services.URLs.Seguridad.currentUser, {}, masterPageObject.PreparaModal);

    //Ponemos la clase de activo al elemnto que representa la pagina actual en el menu del sitio
    masterPageObject.EstableceItemMenuActivo();
});