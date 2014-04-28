using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Chatties.DTO.General
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class User: Person
    {
        /// <summary>
        /// Constructor necesario para la serialización
        /// </summary>
        public User() { }

        /// <summary>
        /// Constructor basado en un usuario no autenticado
        /// </summary>
        /// <param name="usuario"></param>
        public User(string usuario) 
        {
            this.Usuario = usuario;
        }

        /// <summary>
        /// Propiedad que representa el login de un usuario en la base de datos
        /// </summary>
        [DataMember]
        public string Usuario { get; set; }

        /// <summary>
        /// Verifica el intento de Login de un usuario en la base de datos
        /// </summary>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns></returns>
        public Security.LoggedUser Authenticate(string password)
        {
            using (Chatties.Security.Encription.Encrypter enc = new Chatties.Security.Encription.Encrypter())
            {
                string encriptedPassword = enc.Encrypt(password);

                using (Chatties.DAL.DBAccess<Security.LoggedUser> loginAttempt = new DAL.DBAccess<Security.LoggedUser>())
                {
                    return loginAttempt.GetObject(string.Format("Seguridad.Authenticate {0}, {1}", this.Usuario, encriptedPassword));
                }
            }
        }
    }
}