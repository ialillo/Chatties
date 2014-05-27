using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chatties.DTO.General.Controls
{
    public class Select
    {
        /// <summary>
        /// Representa el valor de un control select de HTML
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Representa la descripción o texto de un control select de HTML
        /// </summary>
        public string Description { get; set; }
    }
}
