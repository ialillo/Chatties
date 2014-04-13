<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChattiesWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chatties Login</title>
    <link href='http://fonts.googleapis.com/css?family=PT+Sans&subset=latin,cyrillic-ext,cyrillic,latin-ext' rel='stylesheet' type='text/css'>
    <link href="Styles/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/Login.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <form class="form-signin" role="form" runat="server">
            <h2 class="form-signin-heading">Bag City Sign in</h2>
            <input id="txtUsuario" type="text" class="form-control" placeholder="Usuario" runat="server" required autofocus>
            <input id="txtPassword" type="password" class="form-control" placeholder="Contraseña" runat="server" required>
            <%--<button class="btn btn-lg btn-primary btn-block" type="submit">Login</button>--%>
            <asp:Button ID="btnLogin" Text="Login" runat="server" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnLogin_Click" />
        </form>
        <div class="navbar-fixed-bottom">
            <div class="alert alert-danger"><asp:Label ID="lblMensaje" runat="server"></asp:Label></div>
        </div>
    </div>
</body>
</html>