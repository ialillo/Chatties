﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Chatties.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bag City</title>
    <link href='http://fonts.googleapis.com/css?family=Raleway' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Great+Vibes' rel='stylesheet' type='text/css'>
    <link href="<%= ResolveUrl("~/Styles/Bootstrap/bootstrap.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/Styles/Login.css") %>" rel="stylesheet" />

    <script src="<%= ResolveUrl("~/Scripts/JQuery/jquery-2.1.0.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/Bootstrap/bootstrap.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/JSON2/json2.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/JSON2/JSONHelper.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/General.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/Login/Login.js") %>" type="text/javascript"></script>
</head>
<body>
    <div class="container mainBody">
        <div class="col-xs-6 col-xs-offset-3 col-sm-6 col-sm-offset-3 col-md-3 col-md-offset-4 col-lg-3 col-lg-offset-4" role="form">
            <span class="loginTitle">Enlasys</span>
            <input id="txtUsuario" type="text" class="form-control input-sm" placeholder="Usuario" required autofocus />
            <input id="txtPassword" type="password" class="form-control input-sm" placeholder="Contraseña" required />
            <button type="button" id="btnLogin" class="btn btn-sm btn-primary btn-block">Login</button>
        </div>
        <div id="globalMessageContainer" class='navbar-fixed-bottom col-sm-6 col-sm-offset-3 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2'></div>
    </div>
</body>
</html>