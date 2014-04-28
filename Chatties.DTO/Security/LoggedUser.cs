using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Chatties.DTO.Security
{
    /// <summary>
    /// Representa un usuario loggeado en el sistema
    /// </summary>
    [DataContract]
    public class LoggedUser: General.User
    {
        /// <summary>
        /// Constructor necesario para la serialización
        /// </summary>
        public LoggedUser() { }

        /// <summary>
        /// Constructor basado en un usuario no autenticado
        /// </summary>
        /// <param name="usuario"></param>
        public LoggedUser(General.User user) : base(user.Usuario) { }

        /// <summary>
        /// Representa el id unico de la sesión del usuario
        /// </summary>
        [DataMember]
        public string SessionID { get; set; }

        /// <summary>
        /// Representa el id del usuario en la base de datos
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Representa el nombre completo del usuario Loggeado
        /// </summary>
        [DataMember]
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Representa el perfil del usuario Loggeado
        /// </summary>
        [DataMember]
        public string Perfil { get; set; }
    }
}
