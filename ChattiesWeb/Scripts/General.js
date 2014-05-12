var chattiesObjects = {
    UsuarioEnSesion: {},
    BaseURL: null,
    regExValidators: {
        validPassword: function (str) {
            // Por lo menos un numero, por lo menos una letra minuscula y una mayuscula
            // Por lo menos 6 caracteres
            var re = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/;

            return re.test(str);
        }
    },
    Services: {
        URLs: {
            Seguridad: {
                subURL: "Services/Security",
                authenticate: "/Authenticate",
                changePassword: "/ChangePassword",
                currentUser: "/CurrentSessionUser"
            },
            UserManagement: {
                subUrl: "Services/Security.UserManagement",
                getUsers: "/GetUsersFromDB"
            },
            Navegacion: {
                subURL: "Services/Navegation",
                getMenu: "/GetMenu"
            }
        }
    },
    GlobalMessage: {
        autoHide: true,
        timeToHideInSeconds: 8,
        selectors: {
            containerId: "#globalMessageContainer",
            alertId: "#alertDiv",
            messageId: "#alertMessage",
        },
        alertHTMLString: "<div id='alertDiv' class='alert alert-dismissable' style='display:none;'></div>",
        Create: function () {
            $(this.selectors.containerId).append(this.alertHTMLString);
        },
        Show: function (message, errorStyle) {

            // Quitamos todos los estilos que pueda tener el mensaje
            $(this.selectors.alertId).removeClass("alert-danger");
            $(this.selectors.alertId).removeClass("alert-success");

            // Vemos que estilo va a tener el mensaje, si un estilo de error o de exito
            if (errorStyle) {
                $(this.selectors.alertId).addClass("alert-danger");
            } else {
                $(this.selectors.alertId).addClass("alert-success");
            }

            // Cambiamos el texto de la etiqueta del mesnaje y mostramos el mensaje
            $(this.selectors.alertId).html(message);
            $(this.selectors.alertId).show();

            // Si se especifica que el mensaje se auto oculte se hace un time out en el tiempo especificado en segundos, el valor default es 3
            if (this.autoHide) {
                setTimeout(function () {
                    chattiesObjects.GlobalMessage.Hide();
                }, (this.timeToHideInSeconds * 1000))
            }
        },
        Hide: function () {
            $(this.selectors.alertId).hide();
        }
    },
    PopUp: {
        popBootStrapSettigs: {
            title: "",
            placement: "",
            html: true,
            selector: "",
            content: ""
        },
        linkedControlId: "",
        Show: function (linkedControlId, title, placement, popUpHTML, autoHide, timeToHideInSeconds) {
            this.popBootStrapSettigs.title = "<strong>" + title + "</strong>";
            this.popBootStrapSettigs.placement = placement;
            this.popBootStrapSettigs.content = popUpHTML;
            this.linkedControlId = linkedControlId;

            $(linkedControlId).popover(this.popBootStrapSettigs);
            $(linkedControlId).popover("show");

            if (autoHide) {
                setTimeout(function () {
                    chattiesObjects.PopUp.Hide();
                }, timeToHideInSeconds * 1000)
            }
        },
        Hide: function () {
            $(this.linkedControlId).popover("hide");
            $(this.linkedControlId).popover("destroy");
        }
    },
    Modal: {
        autoHide: false,
        timeToHideInSeconds: 3,
        modalBaseHTML: "<div class='modal fade' id='modalGeneral' tabindex='-1' role='dialog' aria-labelledby='dialogTitle' aria-hidden='true'><div class='modal-dialog'>" +
            "<div class='modal-content'><div class='modal-header'><h4 class='modal-title' id='modalTitle'></h4></div><div class='modal-body'></div>" +
            "<div class='modal-footer'></div></div></div></div>",
        selectors: {
            myModal: "#modalGeneral",
            modalTitle: "#modalTitle",
            modalBody: "div[class='modal-body']",
            modalFooter: "div[class='modal-footer']"
        },
        Create: function (parentSelector, title, body, footer) {
            $(this.selectors.myModal).remove();
            $(parentSelector).append(this.modalBaseHTML);
            $(this.selectors.modalTitle).html("<strong>" + title + "</strong>");
            $(this.selectors.modalBody).html(body);
            $(this.selectors.modalFooter).html(footer);
        },
        Show: function () {
            $(this.selectors.myModal).modal({backdrop: 'static', keyboard: false});
            $(this.selectors.myModal).modal("show");

            if (this.autoHide) {
                setTimeout(function () {
                    chattiesObjects.Modal.Hide();
                }, this.timeToHideInSeconds * 1000)
            }
        },
        Hide: function () {
            $(this.selectors.myModal).modal("hide");
        }
    },
    Tools: {
        Redirectors: {
            RedirectToLogin: function () {
                window.location.href = chattiesObjects.BaseURL + "Login.aspx";
            },
            RedirectToHome: function () {
                window.location.href = chattiesObjects.BaseURL + "Home.aspx";
            }
        }
    }
};

// Funciones y acciones iniciales6
$(document).ready(function () {
    chattiesObjects.BaseURL = document.location.protocol + "//" + document.location.host + "/";
});