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

        protected void btnEcripta_Click(object sender, EventArgs e)
        {
            using (Encrypter cm = new Encrypter())
            {
                String textEcriptado = cm.Encrypt(txtEncripta.Text);

                lblTextoEncriptado.Text = textEcriptado;
            }
        }

        protected void btnEmpleadosActivos_Click(object sender, EventArgs e)
        {
            using (UserManagement um = new UserManagement())
            {
                gridEmpleadosActivos.DataSource = um.ObtieneEmpleadosActivos();
                gridEmpleadosActivos.DataBind();
            }
        }
    }
}