using System;
using System.Runtime.Serialization;

namespace Chatties.DTO.Navegation
{
    public class SubModulo
    {
        /// <summary>
        /// Constructor necesario para la serialización.
        /// </summary>
        public SubModulo() { }

        /// <summary>
        /// Identificador del submódulo del menu, propiedad ligada a la base de datos
        /// </summary>
        [DataMember]
        public int IdSubmodulo { get; set; }

        /// <summary>
        /// Representa el nombre del submódulo, propiedad ligada a la base de datos
        /// </summary>
        [DataMember]
        public string DescSubmodulo { get; set; }

        /// <summary>
        /// Representa la url del submódulo del menú, propiedad ligada a la base de datos
        /// </summary>
        [DataMember]
        public string Url { get; set; }
    }
}
