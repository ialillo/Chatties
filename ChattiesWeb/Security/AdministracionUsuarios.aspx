<%@ Page Title="" Language="C#" MasterPageFile="~/Chatties.Master" AutoEventWireup="true" CodeBehind="AdministracionUsuarios.aspx.cs" Inherits="Chatties.Web.Security.AdministracionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChattiesHeaderPH" runat="server">
    <link rel="stylesheet" href="../Components/DataTables/css/jquery.dataTables.min.css"  type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChattiesBodyPH" runat="server">
    <asp:ScriptManager ID="smAdministracionUsuarios" runat="server" LoadScriptsBeforeUI="true">
        <Scripts>
            <asp:ScriptReference Path="~/Components/DataTables/js/jquery.dataTables.min.js" />
            <asp:ScriptReference Path="~/Scripts/Security/AdministracionUsuarios.js" />
        </Scripts>
    </asp:ScriptManager>
    <div class="page-header">Administraci&oacute;n de Usuarios</div>
    <div id="contentBody">
        <div>
            <button type="button" class="btn btn-success btn-sm right" onclick="admonUsuarios.Modal.altaUsuario()">
                <span class="glyphicon glyphicon-user"></span> Alta Usuario
            </button>
        </div>
    </div>
</asp:Content>