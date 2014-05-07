using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Chatties.DTO.Navegation
{
    public class Modulo
    {
        /// <summary>
        /// Constructor necesario para la serialización.
        /// </summary>
        public Modulo() { }

        /// <summary>
        /// Identificador del módulo ligado a la base de datos
        /// </summary>
        [DataMember]
        public int IdModulo { get; set; }

        /// <summary>
        /// Representa el nombre del módulo, propiedad ligada a la base de datos
        /// </summary>
        [DataMember]
        public string DescModulo { get; set; }

        [DataMember]
        public List<SubModulo> Submodulo { get; set; }
    }
}