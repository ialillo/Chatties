<%@ Page Title="" Language="C#" MasterPageFile="~/Chatties.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ChattiesWeb.Security.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChattiesHeaderPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChattiesBodyPH" runat="server">
        <div class="well">
            <div class="page-header">Perfil</div>
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <label for="txtNombre" class="col-xs-3 col-md-2 control-label">Nombre</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <input type="text" class="form-control" id="txtNombre" placeholder="Nombre" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtApPaterno" class="col-xs-3 col-md-2 control-label">Apellido Paterno</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <input type="text" class="form-control" id="txtApPaterno" placeholder="Apellido Paterno" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtApMaterno" class="col-xs-3 col-md-2 control-label">Apellido Materno</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <input type="text" class="form-control" id="txtApMaterno" placeholder="Apellido Materno" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtEmail" class="col-xs-3 col-md-2 control-label">Email</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <input type="text" class="form-control" id="txtEmail" placeholder="e-mail" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-xs-3 col-md-2 control-label">Usuario</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <p class="form-control-static" id="csUsuario">iflores</p>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPassword" class="col-xs-3 col-md-2 control-label">Contraseña</label>
                    <div class="col-xs-9 col-sm-7 col-md-5">
                        <input type="text" class="form-control" id="txtPassword" placeholder="Contraseña" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-9 col-xs-offset-3 col-sm-7 col-sm-offset-3 col-md-5 col-md-offset-2">
                        <asp:Button ID="btnActualizarDatos" Text="Actualizar" runat="server" CssClass="btn btn-default" />
                        <a href="../Home.aspx" id="btnCancelar" class="btn btn-default">Cancelar</a>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>