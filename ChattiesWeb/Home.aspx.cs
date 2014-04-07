using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChattiesModel.GeneralTools;
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
                String textEcriptado = cm.Encrypt(txtEncripta.Text, ConfigurationManager.AppSettings["PwdKey"].ToString(), new byte[] { 24, 76, 60, 200, 20, 19, 50, 64, 91, 12, 88, 25, 18 });

                lblTextoEncriptado.Text = textEcriptado;
            }
        }
    }
}