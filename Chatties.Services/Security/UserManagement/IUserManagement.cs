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
        DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetProfiles();

        /// <summary>
        /// Traé un usuario de la base de datos mediante su id
        /// </summary>
        /// <param name="idUsuario">El id del usuario</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.Security.LoggedUser> GetUserById(int idUsuario);

        /// <summary>
        /// Guarda un nuevo usuario en la base de datos y envía correo con sus credenciales.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.Result SaveNewUser(DTO.Security.LoggedUser user);

        /// <summary>
        /// Edita un usuario existente en la base de datos.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.Result SaveUser(DTO.Security.LoggedUser user);

        /// <summary>
        /// Desactiva un usuario existente en la base de datos.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.Result DeactivateUser(int idUsuario);
    }
}