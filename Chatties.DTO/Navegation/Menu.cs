using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Chatties.DTO.Navegation
{
    /// <summary>
    /// Representa el menú asignado al usuario que se presenta del lado izquierdo de la pantalla del sitio.
    /// </summary>
    [DataContract]
    public class Menu : List<Modulo>, IDisposable
    {
        bool _disposed;

        /// <summary>
        /// Constructor necesario para la serialización.
        /// </summary>
        public Menu() { }

        /// <summary>
        /// Destruya las instancias creadas asincronamente
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destruye las instancias internas condicionalmente
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}