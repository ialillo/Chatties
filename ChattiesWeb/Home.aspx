<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ChattiesWeb.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblEncripta" runat="server">Introduzca texto a encriptar</asp:Label>
        <asp:TextBox ID="txtEncripta" runat="server"></asp:TextBox>
        <asp:Button ID="btnEcripta" runat="server" Text="Ecriptar" OnClick="btnEcripta_Click" />
        <br />
        <asp:Label ID="lblMensajeEncritado" runat="server">Texto Encriptado: </asp:Label>
        <asp:Label ID="lblTextoEncriptado" runat="server"></asp:Label>
        <br />
        <br />
        <span>Empleados Activos</span>
        <asp:Button ID="btnEmpleadosActivos" runat="server" Text="Trae EmpleadosActivos" OnClick="btnEmpleadosActivos_Click" />
        <asp:GridView ID="gridEmpleadosActivos" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>