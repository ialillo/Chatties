<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChattiesWeb.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span>Usuario: </span>
        <input id="txtUsuario" type="text" name="txtUsuario" runat="server" />
        <br />
        <span>Contraseña: </span>
        <input id="txtPassword" type="text" name="txtPassword" runat="server" />
        <br />
        <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
        <br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>