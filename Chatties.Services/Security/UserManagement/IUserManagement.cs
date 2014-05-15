using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Chatties.Services.Security.UserManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserManagement" in both code and config file together.
    [ServiceContract]
    public interface IUserManagement
    {
        /// <summary>
        /// Trae todos los usuarios activos de la base de datos
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.Security.UserManagement> GetUsersFromDB();

        /// <summary>
        /// Traé todos los perfiles activos de la base de datos
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.Security.UserManagement> GetProfiles();

        /// <summary>
        /// Traé un usuario de la base de datos mediante su id
        /// </summary>
        /// <param name="idUsuario">El id del usuario</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.Security.LoggedUser> GetUserById(int idUsuario);
    }
}