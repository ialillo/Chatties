var admonUsuarios = {
    objects:{
        perfiles: new Object,
        currentUserId: 0
    },
    establecePerfiles: function (serviceResult) {
        //Si la llamada al servicio traé un error, lo mostramos
        if (!serviceResult.Success) {
            //Mostramos el mensaje del error.
            chattiesObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
            //Salimos de la función.
            return;
        }

        // Guardamos los perfiles en una arreglo global
        admonUsuarios.objects.perfiles = serviceResult.Object.Selects;
        
        //Traemos la lista de usuarios activos de la base de datos
        admonUsuarios.traerUsuarios();
    },
    traerUsuarios: function () {
        //Traemos a todos los usuarios activos de la base de datos
        doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.UserManagement.subUrl, chattiesObjects.Services.URLs.UserManagement.getUsers, {}, admonUsuarios.escribeTablaUsuarios);
    },
    escribeTablaUsuarios: function (serviceResult) {
        if (serviceResult.Success) {

            //Eliminamos la tabla del dom si es que existe
            $("#tblUsuariosChatties").remove();
            
            //Guardamos el arreglo de usuarios en una variable-
            var usuarios = serviceResult.Object.LoggedUsers;
            var htmlTable = "";

            //Construimos el html de los usuarios.
            htmlTable += "<table id='tblUsuariosChatties' class='display' cellspacing='0' width='100%'>";

            htmlTable += "<thead>";
            htmlTable += "<tr><th>Nombre</th><th>Perfil</th><th>Editar</th><th>Eliminar</th></tr>";
            htmlTable += "</thead>";

            htmlTable += "<tbody>";
            $(usuarios).each(function (cont, LoggedUser) {
                htmlTable += "<tr>";
                htmlTable += "<td>" + LoggedUser.Nombre + " " + LoggedUser.ApellidoPaterno + " " + LoggedUser.ApellidoMaterno + "</td>";
                htmlTable += "<td>" + LoggedUser.Perfil + "</td>";
                htmlTable += "<td><button data-userid='" + LoggedUser.Id + "' type='button' class='btn btn-primary btn-xs' onclick='admonUsuarios.Modal.editaUsuario(this);'><span class='glyphicon glyphicon-pencil'></span> Editar</button></td>";
                htmlTable += "<td><button data-userid='" + LoggedUser.Id + "' type='button' class='btn btn-danger btn-xs' onclick='admonUsuarios.Modal.desactivaUsuario(this);'><span class='glyphicon glyphicon-remove-sign'></span> Eliminar</button></td>";
                htmlTable += "</tr>";
            });

            htmlTable += "</tbody>"
            htmlTable += "</table>"

            //Insertamos el HTML de la tabla.
            $("#contentBody:first").append(htmlTable);
            $("#tblUsuariosChatties").dataTable({ ordering: false, bSort: false, bLengthChange: false, iDisplayLength: 10, sPaginationType: "full_numbers"});
        }
        else {
            // Si existe un error en la llamada del servicio mostramos el mensaje de error
            chattiesObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
        }
    },
    Modal: {
        altaUsuario: function () {
            //Creamos el modal del usuario.
            this.creaModalUsuario(true);
            //Mostramos el modal con los controles necesarios.
            chattiesObjects.Modal.Show();
        },
        editaUsuario: function (btnUsuario) {
            // Creamos el modal con los controles default
            this.creaModalUsuario(false);
            //Establecemos el usuario que queremos editar
            admonUsuarios.objects.currentUserId = $(btnUsuario).data("userid");
            //Traemos la información del usuario seleccionado.
            doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.UserManagement.subUrl, chattiesObjects.Services.URLs.UserManagement.getUser, {idUsuario: admonUsuarios.objects.currentUserId}, this.llenaModalConDatosDeUsuario)
        },
        llenaModalConDatosDeUsuario: function (serviceResult) {
            //Si la llamada al servicio regresa un error lo mostramos.
            if (!serviceResult.Success) {
                //Mostramos el error de la llamada al servicio.
                chattiesObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
                //Salimos de la función.
                return;
            }

            // Obtenemos el Objeto y se lo asignamos a una variable.
            var currentUser = serviceResult.Object;

            // Llenamos los datos del usuario.
            $("#txtNombre").val(currentUser.Nombre);
            $("#txtApPaterno").val(currentUser.ApellidoPaterno);
            $("#txtApMaterno").val(currentUser.ApellidoMaterno);
            $("#txtUsuario").val(currentUser.Usuario);
            $("#txtEmail").val(currentUser.Email);

            //Iteramos en el selector para establecer el perfil actual del usuario de la lista de perfiles.
            $("#selPerfiles").val(currentUser.IdPerfil);

            //Mostramos el modal con la información del usuario.
            chattiesObjects.Modal.Show();
        },
        desactivaUsuario: function (btnUsuario) {
        },
        creaModalUsuario: function (esAlta) {
            //Establecemos el titulo del modal.
            var modalTitle = esAlta ? "Alta de Usuario" : "Edici&oacute;n de Usuario";
            var modalBody = "";
            var modalFooter = "";

            //Establecemos el cuerpo del modal.
            modalBody += chattiesObjects.Tools.HTMLControls.FormGroups.codeSnippets.openFormContainer;
            modalBody += chattiesObjects.Tools.HTMLControls.FormGroups.labelWithTextBox("Nombre", "txtNombre", "Nombre", 20);
            modalBody += chattiesObjects.Tools.HTMLControls.FormGroups.labelWithTextBox("A Paterno", "txtApPaterno", "Apellido Paterno", 20);
            modalBody += chattiesObjects.Tools.HTMLControls.FormGroups.labelWithTextBox("A Materno", "txtApMaterno", "Apellido Materno", 20);
            modalBody += chattiesObjects.Tools.HTMLControls.FormGroups.labelWithTextBox("Usuario", "txtUsuario", "Usuario", 10);
            modalBody += chattiesObjects.Tools.HTMLControls.FormGroups.labelWithTextBox("Email", "txtEmail", "e-mail", 30);
            modalBody += chattiesObjects.Tools.HTMLControls.FormGroups.labelWithSelect("Perfiles", "selPerfiles", admonUsuarios.objects.perfiles);
            modalBody += chattiesObjects.Tools.HTMLControls.FormGroups.codeSnippets.closeFormContainer;

            //Establecemos el footer en donde están los botones del modal.
            var btnGuardarModifier = esAlta ? "A" : "E";
            modalFooter += "<button id='btnGuardar' data-modifier='" + btnGuardarModifier + "' type='button' class='btn btn-sm btn-primary'>Guardar</button>";
            modalFooter += "<button id='btnCancelar' type='button' class='btn btn-sm btn-default' onclick='chattiesObjects.Modal.Hide();'>Cancelar</button>";

            //Insertamos el html del modal en el DOM
            chattiesObjects.Modal.Create("body", modalTitle, modalBody, modalFooter);
            $(chattiesObjects.Modal.selectors.modalBody + " div .form ").removeClass("form").addClass("form-horizontal");
        }
    }
}

// Funciones que se ejecutan al cargar la pagina
$(document).ready(function () {
    //Traemos los perfiles y los guardamos en un arreglo global
    doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.UserManagement.subUrl, chattiesObjects.Services.URLs.UserManagement.getProfiles, {}, admonUsuarios.establecePerfiles);
});