using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chatties.Services.Navegation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Navegation" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Navegation.svc or Navegation.svc.cs at the Solution Explorer and start debugging.
    public class Navegation : INavegation
    {
        /// <summary>
        /// Servicio que regresa el menú de un usuario en sesión
        /// </summary>
        /// <returns>El Menu</returns>
        public DTO.General.ResultGeneric<DTO.Navegation.Menu> GetMenu()
        {
            using (DTO.General.ResultGeneric<DTO.Navegation.Menu> result = new DTO.General.ResultGeneric<DTO.Navegation.Menu>())
            {
                try
                {
                    DTO.Security.LoggedUser usuario = (DTO.Security.LoggedUser)HttpContext.Current.Session["User"];

                    using (DTO.Navegation.Menu menu = new DTO.Navegation.Menu())
                    {
                        result.Object =  menu.ObtenerMenu(usuario.Id);
                        result.Success = true;
                        result.ServiceMessage = "OK";
                    }
                   
                }
                catch(System.Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;
                }
                return result;
            }
        }
    }
}
