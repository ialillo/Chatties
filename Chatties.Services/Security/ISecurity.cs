using System;
using System.ServiceModel;

namespace Chatties.Services.Security
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISecurity" in both code and config file together.
    [ServiceContract]
    public interface ISecurity
    {
        // Método que autentica un usuario en la base de datos
        [OperationContract]
        Chatties.DTO.General.Result<Chatties.DTO.Security.LoggedUser> Authenticate(Chatties.DTO.General.User user, string password);
    }
}
