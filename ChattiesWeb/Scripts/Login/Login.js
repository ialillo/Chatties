function login(Login, Password) {
    this.Login = Login;
    this.Password = Password;
}

function LoginAttempt() {
    var objLogin = new login($("#txtUsuario").val(), $("#txtPassword").val());

    $.ajax({
        type: "POST",
        url: "../../Login.aspx/LoginAttempt",
        data: "{login: " + JSON.stringify(objLogin) + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: LoginCorrecto,
        error: function (xhr, status, error) {
            $("#lblMensaje").val(error);
            $("#alertDiv").css("display", "inline")
        }
    });
}

function LoginCorrecto(dObj) {
    var objeto = JSON.parse(getMain(dObj));

    if (objeto.nombreCompleto.indexOf("Error") > -1)
    {
        $("#lblMensaje").text(objeto.nombreCompleto);
        $("#alertDiv").css("display", "block")
    }
    else
    {
        window.location.href = "../../Home.aspx";
    }
}