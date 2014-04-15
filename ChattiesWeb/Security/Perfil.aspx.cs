using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChattiesModel.User_Management.DTO;

namespace ChattiesWeb.Security
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
                Response.Redirect("~/../Login.aspx");
            }
        }
    }
}