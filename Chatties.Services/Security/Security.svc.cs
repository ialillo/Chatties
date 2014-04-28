using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chatties.Services.Security
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Security" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Security.svc or Security.svc.cs at the Solution Explorer and start debugging.
    public class Security : ISecurity
    {
        /// <summary>
        /// Autentica un usuario en la base de datos
        /// </summary>
        /// <param name="user">Contiene el usuario a autenticar</param>
        /// <param name="password">Password a autenticar</param>
        /// <returns></returns>
        public DTO.General.Result<DTO.Security.LoggedUser> Authenticate(DTO.General.User user, string password)
        {
            using (DTO.General.Result<DTO.Security.LoggedUser> result = new DTO.General.Result<DTO.Security.LoggedUser>())
            {
                try
                {
                    result.Object = user.Authenticate(password);

                    if (result.Object != null)
                    {
                        result.Object.SessionID = HttpContext.Current.Session.SessionID;
                    }

                    HttpContext.Current.Session["User"] = result.Object;
                    result.Success = true;
                    result.ServiceMessage = (result.Object == null) ? "Usuario o contraseña no válidos" : "OK";
                }
                catch(Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;
                }
                return result;
            }
        }
    }
}
