using System;
using System.Xml.Serialization;

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
        [XmlElement(ElementName = "IdModulo")]
        public int IdModulo { get; set; }

        /// <summary>
        /// Representa el nombre del módulo, propiedad ligada a la base de datos
        /// </summary>
        [XmlElement(ElementName = "DescModulo")]
        public string DescModulo { get; set; }

        [XmlElement(ElementName = "SubModulo")]
        public SubModulo[] SubModulos { get; set; }
    }
}