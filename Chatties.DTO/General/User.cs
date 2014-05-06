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
        /// Verifica si existe el usuario en la base de datos
        /// </summary>
        /// <returns>Verdadero o falso</returns>
        public bool VerifyUserExists()
        {
            using (DAL.DBAccess<bool> loginAttempt = new DAL.DBAccess<bool>())
            {
                return loginAttempt.GetBoolean("Seguridad.ExisteUsuario", this.Usuario);
            }
        }

        /// <summary>
        /// Verifica si el usuario está activo en la base de datos
        /// </summary>
        /// <returns>Verdadero o falso</returns>
        public bool VerifyActiveUser()
        {
            using (DAL.DBAccess<bool> loginAttempt = new DAL.DBAccess<bool>())
            {
                return loginAttempt.GetBoolean("Seguridad.VerificaUsuarioActivo", this.Usuario);
            }
        }

        /// <summary>
        /// Verifica si el usuario tiene la seguridad antigua
        /// </summary>
        /// <param name="password">contraseña</param>
        /// <returns>Verdadero o falso</returns>
        public Security.LoggedUser VerifyOldUser(string password)
        {
            using (DAL.DBAccess<Security.LoggedUser> loginAttempt = new DAL.DBAccess<Security.LoggedUser>())
            {
                return loginAttempt.GetObject("Seguridad.VerificaUsuarioViejo", this.Usuario, password);
            }
        }

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

                using (DAL.DBAccess<Security.LoggedUser> loginAttempt = new DAL.DBAccess<Security.LoggedUser>())
                {
                    return loginAttempt.GetObject("Seguridad.Autenticar", this.Usuario, encriptedPassword);
                }
            }
        }

        /// <summary>
        /// Método que cambia la contraseña de un usuario
        /// </summary>
        /// <param name="password"></param>
        public string ChangePassword(string oldPassword, string newPassword)
        {
            using (Chatties.Security.Encription.Encrypter enc = new Chatties.Security.Encription.Encrypter())
            {
                string encriptedPassword = enc.Encrypt(newPassword);
                string encriptedOldPassword = VerifyOldUser(oldPassword) != null ? oldPassword : enc.Encrypt(oldPassword);

                using (DAL.DBAccess<string> cp = new DAL.DBAccess<string>())
                {
                    return (string)cp.ExecuteScalar("Usuarios.CambiaPassword", this.Usuario, encriptedOldPassword, encriptedPassword);
                }
            }
        }
    }
}