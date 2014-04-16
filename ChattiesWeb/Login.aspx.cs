using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using ChattiesSecurity.Encription;
using ChattiesModel.UserManagement;
using ChattiesModel.User_Management.DTO;

namespace ChattiesWeb
{
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Recibe un objeto de LoginDTO que contiene usuario y contrasena
        /// </summary>
        /// <param name="login"></param>
        /// <returns>El usuario logeado</returns>
        [WebMethod]
        public static string LoginAttempt(LoginDTO login)
        {
            ChattiesModel.User_Management.DTO.LoggedUserDTO usuario = new ChattiesModel.User_Management.DTO.LoggedUserDTO();

            try
            {
                using (UserManagement um = new UserManagement())
                {
                    using(Encrypter enc = new Encrypter())
                    {
                        usuario = um.validaLogin(login.Login, login.Password, enc.Encrypt(login.Password));
                    }

                    if (usuario.ID != 0)
                    {
                        if(usuario.nombreCompleto != "Viejo")
                        {
                            HttpContext.Current.Session["usuario"] = usuario;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                usuario.nombreCompleto = "Error: " + ex.Message;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(usuario);
        }

        /// <summary>
        /// Renueva el password por uno encriptado
        /// </summary>
        /// <param name="login">objeto de login</param>
        /// <returns>Exito o Error</returns>
        [WebMethod]
        public static string CambiaPassword(LoginDTO login)
        {
            bool cambioExitoso = false;
            string mensajeError = string.Empty;

            try
            {
                using (Encrypter enc = new Encrypter())
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