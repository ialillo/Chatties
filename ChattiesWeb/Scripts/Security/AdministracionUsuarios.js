var admonUsuariosObjects = {
    escribeTablaUsuarios: function (serviceResult) {
        if (serviceResult.Success) {
            
            var usuarios = serviceResult.Object.LoggedUsers;
            var htmlTable = "";

            htmlTable += "<table id='tblUsuariosChatties' class='display' cellspacing='0' width='100%'>";

            htmlTable += "<thead>";
            htmlTable += "<tr><th>Nombre</th><th>Perfil</th><th>Editar</th><th>Eliminar</th></tr>";
            htmlTable += "</thead>";

            htmlTable += "<tbody>";
            $(usuarios).each(function (cont, LoggedUser) {
                htmlTable += "<tr>";
                htmlTable += "<td>" + LoggedUser.Nombre + " " + LoggedUser.ApellidoPaterno + " " + LoggedUser.ApellidoMaterno + "</td>";
                htmlTable += "<td>" + LoggedUser.Perfil + "</td>";
                htmlTable += "<td><button data-userid='" + LoggedUser.Id + "' type='button' class='btn btn-primary btn-xs' onclick='admonUsuariosObjects.editaUsuario(this);'><span class='glyphicon glyphicon-pencil'></span> Editar</button></td>";
                htmlTable += "<td><button data-userid='" + LoggedUser.Id + "' type='button' class='btn btn-danger btn-xs' onclick='admonUsuariosObjects.desactivaUsuario(this);'><span class='glyphicon glyphicon-remove-sign'></span> Eliminar</button></td>";
                htmlTable += "</tr>";
            });

            htmlTable += "</tbody>"
            htmlTable += "</table>"

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
            doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.UserManagement.subUrl, chattiesObjects.Services.URLs.UserManagement.getProfiles, {}, this.llenaModalAltaUsuario);
        },
        editaUsuario: function (btnUsuario) {
        },
        desactivaUsuario: function (btnUsuario) {
        },
        llenaModalAltaUsuario: function (serviceResult) {
            if (!serviceResult.Success)
            {
                chattiesObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
                return;
            }

            var modalTitle = "Alta de Usuario";
            var modalBody = "";
            var modalFooter = "";

            var perfilesSelect = "<select class='form-control'>";
            var perfiles = serviceResult.Object.Selects;

            $(perfiles).each(function (cont, perfil) {
                perfilesSelect += "<option value='" + perfil.Value + "'>" + perfil.Description + "</option>"
            });

            perfilesSelect += "</select>";

            modalBody += "<div class='form-group'>";
            modalBody += "<label for='txtNombre'>Nombre</label>";
            modalBody += "<input type='text' id='txtNombre' placeholder='Nombre'></input>";
            modalBody += "</div>";
            modalBody += "<div class='form-group'>";
            modalBody += "<label for='txtApPaterno'>Ap Paterno</label>";
            modalBody += "<input type='text' id='txtApPaterno' placeholder='Apellido Paterno'></input>";
            modalBody += "</div>";
            modalBody += "<div class='form-group'>";
            modalBody += "<label for='txtApMaterno'>Ap Materno</label>";
            modalBody += "<input type='text' id='txtApMaterno' placeholder='Apellido Materno'></input>";
            modalBody += "</div>";
            modalBody += "<div class='form-group'>";
            modalBody += "<label for='selPerfiles'>Perfil</label>";
            modalBody += perfilesSelect;
            modalBody += "</div>";

            modalFooter += "<button id='btnGuardar' type='button' class='btn btn-primary'>Guardar</button>";
            modalFooter += "<button id='btnCancelar' type='button' class='btn btn-default' onclick='chattiesObjects.Modal.Hide();'>Cancelar</button>";

            chattiesObjects.Modal.Create("body", modalTitle, modalBody, modalFooter);
            $(chattiesObjects.Modal.selectors.modalBody).addClass("form-horizontal");
            chattiesObjects.Modal.Show();
        }
    }
}

// Funciones que se ejecutan al cargar la pagina
$(document).ready(function () {
    //Traemos a todos los usuarios activos de la base de datos
    doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.UserManagement.subUrl, chattiesObjects.Services.URLs.UserManagement.getUsers, {}, admonUsuariosObjects.escribeTablaUsuarios);
});