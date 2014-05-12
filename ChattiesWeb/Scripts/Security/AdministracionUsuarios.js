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
    altaUsuario: function(){

    },
    editaUsuario: function (btnUsuario) {

    },
    desactivaUsuario: function (btnUsuario) {


    }
}

// Funciones que se ejecutan al cargar la pagina
$(document).ready(function () {
    //Traemos a todos los usuarios activos de la base de datos
    doJsonObjectAjaxCallback(chattiesObjects.Services.URLs.UserManagement.subUrl, chattiesObjects.Services.URLs.UserManagement.getUsers, {}, admonUsuariosObjects.escribeTablaUsuarios);
});