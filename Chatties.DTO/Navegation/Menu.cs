using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Chatties.DTO.Navegation
{
    /// <summary>
    /// Representa el menú asignado al usuario que se presenta del lado izquierdo de la pantalla del sitio.
    /// </summary>
    [DataContract]
    public class Menu
    {
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