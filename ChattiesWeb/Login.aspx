<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChattiesWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bag City</title>
    <link href='http://fonts.googleapis.com/css?family=PT+Sans&subset=latin,cyrillic-ext,cyrillic,latin-ext' rel='stylesheet' type='text/css'>
    <link href="<%= ResolveUrl("Styles/Bootstrap/bootstrap.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("Styles/Login.css") %>" rel="stylesheet" />

    <script src="<%= ResolveUrl("~/Scripts/JQuery/jquery-2.1.0.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/Bootstrap/bootstrap.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/JSON2/json2.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/JSON2/JSONHelper.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("Scripts/General.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("Scripts/Login/Login.js") %>" type="text/javascript"></script>
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
    <div class="modal fade" id="modalGeneral" tabindex="-1" role="dialog" aria-labelledby="dialogTitle" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>--%>
                    <h4 class="modal-title" id="dialogTitle">Renueva Contraseña</h4>
                </div>
                <div class="modal-body">
                    <p>Hemos detectado que tu contrase&ntilde;a no est&aacute; encriptada, es necesario que cambies tu contrase&ntilde;a para poder usar el sistema.</p>
                    <div class="form" role="form">
                        <div class="form-group">
                            <label for="txtPwdNuevo">Contraseña Nueva</label>
                            <div class="input-group">
                                <input type="password" id="txtPwdNuevo" class="form-control" placeholder="Contraseña Nueva" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtPwdNuevoConfirm">Confirmar Contraseña</label>
                            <div class="input-group">
                                <input type="password" id="txtPwdNuevoConfirm" class="form-control" placeholder="Confirmar Contraseña" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btnCambiaContrasena" type="button" class="btn btn-primary" rel="popover">Cambiar</button>
                    <button id="btnCancelar" type="button" class="btn btn-default">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
</body>
</html>