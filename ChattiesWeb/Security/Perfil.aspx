<%@ Page Title="" Language="C#" MasterPageFile="~/Chatties.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ChattiesWeb.Security.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChattiesHeaderPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChattiesBodyPH" runat="server">
    <asp:ScriptManager ID="smPerfil" runat="server" LoadScriptsBeforeUI="true">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/Security/Perfil.js" />
        </Scripts>
    </asp:ScriptManager>
        <div class="page-header">Perfil</div>
        <div class="col-xs-10 col-xs-offset-1 col-sm-10 col-sm-offset-1 col-md-10 col-md-offset-1 col-lg-10 col-lg-offset-1">
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <label for="txtNombre" class="col-xs-3 col-md-2 control-label">Nombre</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <p class="form-control-static" id="csNombre" runat="server" placeholder="Nombre"></p>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtEmail" class="col-xs-3 col-md-2 control-label">Email</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <p class="form-control-static" id="csEmail" runat="server"></p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-md-2 control-label">Usuario</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <p class="form-control-static" id="csUsuario" runat="server"></p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-md-2 control-label">Perfil</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <p class="form-control-static" id="csPerfil" runat="server"></p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-md-2 control-label">Cambiar Contraseña</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <div class="input-group">
                            <input type="password" id="txtPassword" class="form-control" placeholder="Contraseña Actual" />
                            <span class="input-group-btn">
                                <button id="btnCambiaContraseña" class="btn btn-default" onclick="CambiaPassword();" type="button">Cambiar</button>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-9 col-xs-offset-3 col-sm-7 col-sm-offset-3 col-md-5 col-md-offset-2">
                        <a href="../Home.aspx" id="btnCancelar" class="btn btn-default">Cancelar</a>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>