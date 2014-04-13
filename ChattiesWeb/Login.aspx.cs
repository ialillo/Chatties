using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChattiesModel.User_Management.DTO;
using ChattiesSecurity.Encription;
using ChattiesModel.UserManagement;
using System.Configuration;

namespace ChattiesWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoggedUserDTO usuario = new LoggedUserDTO();

            try
            {
                using (UserManagement um = new UserManagement())
                {
                    usuario = um.validaLogin(txtUsuario.Value, txtPassword.Value);

                    if (usuario.ID != 0)
                    {
                        Session["usuario"] = usuario;
                    }
                }
                Response.Redirect("~/Home.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
    }
}