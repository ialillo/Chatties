<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChattiesWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bag City</title>
    <link href='http://fonts.googleapis.com/css?family=PT+Sans&subset=latin,cyrillic-ext,cyrillic,latin-ext' rel='stylesheet' type='text/css'>
    <link href="Styles/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/Login.css" rel="stylesheet" />

    <script src="Scripts/JQuery/jquery-2.1.0.min.js" type="text/javascript"></script>
    <script src="Scripts/JSON2/json2.min.js" type="text/javascript"></script>
    <script src="Scripts/JSON2/JSONHelper.js" type="text/javascript"></script>
    <script src="Scripts/Login/Login.js" type="text/javascript"></script>
</head>
<body>
    <div class="container">
        <form class="form-signin" role="form" runat="server">
            <h2 class="form-signin-heading">Bag City Sign in</h2>
            <input id="txtUsuario" type="text" class="form-control" placeholder="Usuario" required autofocus />
            <input id="txtPassword" type="password" class="form-control" placeholder="Contraseña" required />
            <input type="button" id="btnLogin" class="btn btn-lg btn-primary btn-block" onclick="LoginAttempt()" value="Login" />
        </form>
        <div class="navbar-fixed-bottom">
            <div id="alertDiv" class="alert alert-danger" style="display:none">
                <span id="lblMensaje" ></span>
            </div>
        </div>
    </div>
</body>
</html>