using System;
using System.Web.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chatties.Model.UserManagement;
using Chatties.Model.UserManagement.DTO;

namespace Chatties.Web
{
    public partial class Chatties : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoggedUserDTO usuario = (LoggedUserDTO)Session["usuario"];

                hdnFieldUserName.Value = usuario.nombreCompleto;
            }
            catch(Exception)
            {
                Response.Redirect(ResolveUrl("Login.aspx"));
            }
        }

        /// <summary>
        /// Metodo que obtiene el menu de la pagina maestra
        /// </summary>
        /// <returns>El menu</returns>
        [WebMethod]
        public static string ObtenMenu(int numero)
        {
            List<MenuDTO> menuList = new List<MenuDTO>();
            LoggedUserDTO usuario = new LoggedUserDTO();

            try
            {
                usuario = (LoggedUserDTO)HttpContext.Current.Session["usuario"];

                using (UserManagement user = new UserManagement())
                {
                    menuList = user.obtenMenu(usuario.ID);
                }
            }
            catch(Exception ex)
            {
                if (usuario.ID == 0)
                {
                    HttpContext.Current.Response.Redirect("~/Login.aspx");
                }
                
                MenuDTO menu = new MenuDTO();
                menu.descModulo = "Error: " + ex.Message;
                menuList.Add(menu);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(menuList);
        }
    }
}