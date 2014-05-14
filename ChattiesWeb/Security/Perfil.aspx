<%@ Page Title="" Language="C#" MasterPageFile="~/Chatties.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Chatties.Web.Security.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChattiesHeaderPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChattiesBodyPH" runat="server">
    <asp:ScriptManager ID="smPerfil" runat="server" LoadScriptsBeforeUI="true">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/Security/Perfil.js" />
        </Scripts>
    </asp:ScriptManager>
        <div class="page-header">Perfil</div>
        <div> <%--class="col-xs-10 col-xs-offset-1 col-sm-10 col-sm-offset-1 col-md-10 col-md-offset-1 col-lg-10 col-lg-offset-1">--%>
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <label for="txtNombre" class="col-xs-4 col-md-3 control-label">Nombre</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <p class="form-control-static" id="csNombre"></p>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtEmail" class="col-xs-4 col-md-3 control-label">Email</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <p class="form-control-static" id="csEmail"></p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-4 col-md-3 control-label">Perfil</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <p class="form-control-static" id="csPerfil"></p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-4 col-md-3 control-label">Cambiar Contraseña</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <div class="input-group">
                            <input type="password" id="txtPassword" class="form-control" placeholder="Escriba su contraseña actual" />
                            <span class="input-group-btn">
                                <button id="btnCambiaContraseña" class="btn btn-success" onclick="perfilObjects.CambiaPassword();" type="button">Cambiar</button>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>