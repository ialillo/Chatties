using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Chatties.Security.Encription;
using Chatties.Model.UserManagement;
using Chatties.Model.UserManagement.DTO;

namespace Chatties.Web.Security
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoggedUserDTO usuario = (LoggedUserDTO)Session["usuario"];

                csNombre.InnerText = usuario.nombreCompleto;
                csEmail.InnerText = usuario.correo;
                csUsuario.InnerText = usuario.usuario;
                csPerfil.InnerText = usuario.descNivelAcceso;
            }
            catch (Exception)
            {
                Response.Redirect(ResolveUrl("~/Login.aspx"));
            }
        }

        [WebMethod]
        public static string VerificaCredenciales(LoginDTO login)
        {
            bool credencialesCorrectas = false;
            string mensajeError = string.Empty;

            try
            {
                using (Encrypter enc = new Encrypter())
                {
                    login.Password = enc.Encrypt(login.Password);
                }

                using (UserManagement um = new UserManagement())
                {
                    credencialesCorrectas = um.validaPasswordActual(login);
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error: " + ex.Message;
            }

            return credencialesCorrectas ? "Exito" : mensajeError;
        }

        [WebMethod]
        public static string CambiaPassword(LoginDTO login)
        {
            bool cambioExitoso = false;
            string mensajeError = string.Empty;

            try
            {
                using(Encrypter enc = new Encrypter())
                {
                    login.Password = enc.Encrypt(login.Password);
                }

                using (UserManagement um = new UserManagement())
                {
                    cambioExitoso = um.cambiaPassword(login);
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error: " + ex.Message;
            }

            return cambioExitoso ? "Exito" : mensajeError;
        }
    }
}