using System;
using System.Web;

namespace Chatties.Web.UserControls
{
    public partial class ValidateSession : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}