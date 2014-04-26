using System;
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
    }
}
