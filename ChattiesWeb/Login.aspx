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
    <script src="Scripts/General.js" type="text/javascript"></script>
    <script src="Scripts/Login/Login.js" type="text/javascript"></script>
</head>
<body>
    <div class="container">
        <div class="col-xs-6 col-xs-offset-3 col-sm-6 col-sm-offset-3 col-md-3 col-md-offset-4 col-lg-3 col-lg-offset-4" role="form">
            <h3>Bag City Sign in</h3>
            <input id="txtUsuario" type="text" class="form-control input-sm" placeholder="Usuario" required autofocus />
            <input id="txtPassword" type="password" class="form-control input-sm" placeholder="Contraseña" required />
            <input type="button" id="btnLogin" class="btn btn-sm btn-primary btn-block" onclick="LoginAttempt()" value="Login" />
        </div>
        <div class="navbar-fixed-bottom col-xs-10 col-xs-offset-1 col-sm-10 col-sm-offset-1 col-md-10 col-md-offset-1 col-lg-10 col-lg-offset-1">
            <div id="alertDiv" class="alert alert-danger alert-dismissable" style="display:none">
                <label id="errorMensaje" ></label>
                <button type="button" class="close" onclick="ocultaError();">&times;</button>
            </div>
        </div>
    </div>
</body>
</html>