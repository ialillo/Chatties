using System.Runtime.Serialization;

namespace Chatties.DTO.General
{
    /// <summary>
    /// Clase base que representa a una persona
    /// </summary>
    [DataContract]
    public class Person
    {
        /// <summary>
        /// Nombre de la persona
        /// </summary>
        [DataMember]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido Paterno de la persona
        /// </summary>
        [DataMember]
        public string ApellidoPaterno { get; set; }

        /// <summary>
        /// Apellido Materno de la persona
        /// </summary>
        [DataMember]
        public string ApellidoMaterno { get; set; }
    }
}
