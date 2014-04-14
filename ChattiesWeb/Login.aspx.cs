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
        [WebMethod]
        public static string LoginAttempt(LoginDTO login)
        {
            ChattiesModel.User_Management.DTO.LoggedUserDTO usuario = new ChattiesModel.User_Management.DTO.LoggedUserDTO();

            try
            {
                using (UserManagement um = new UserManagement())
                {
                    usuario = um.validaLogin(login.Login, login.Password);

                    if (usuario.ID != 0)
                    {
                        HttpContext.Current.Session["usuario"] = usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                usuario.nombreCompleto = ex.Message;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(usuario);
        }
    }
}