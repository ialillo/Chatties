using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChattiesSecurity.Encription;
using ChattiesModel.UserManagement;
using System.Configuration;

namespace ChattiesWeb
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool loginValido;

            using (UserManagement um = new UserManagement())
            {
                loginValido = um.validaLogin(txtUsuario.Value, txtPassword.Value);
            }

            if (loginValido)
            {
                lblMensaje.Text = "El usuario es valido";
            }
            else
            {
                lblMensaje.Text = "Usuario o Password Incorrecto";
            }
        }
    }
}