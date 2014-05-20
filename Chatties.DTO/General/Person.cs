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
        /// Constructor necesario para la serializacion
        /// </summary>
        public Person() { }

        /// <summary>
        /// Constructor para 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellidoPaterno"></param>
        /// <param name="apellidoMaterno"></param>
        public Person(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
        }

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
