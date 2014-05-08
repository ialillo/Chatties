using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Chatties.Services.Navegation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INavegation" in both code and config file together.
    [ServiceContract]
    public interface INavegation
    {
        /// <summary>
        /// Servicio que obtiene el menu de un usuario que esté en sesión.
        /// </summary>
        /// <returns>El menu del usuario</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        Chatties.DTO.General.ResultGeneric<DTO.Navegation.Menu> GetMenu();
    }
}