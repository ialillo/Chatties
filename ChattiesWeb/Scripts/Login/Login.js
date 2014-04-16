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

    if (objeto.nombreCompleto.indexOf("Error") > -1)
    {
        muestraError(objeto.nombreCompleto);
    }
    else
    {
        window.location.href = "../../Home.aspx";
    }
}