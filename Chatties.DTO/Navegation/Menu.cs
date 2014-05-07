using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Chatties.DTO.Navegation
{
    /// <summary>
    /// Representa el menú asignado al usuario que se presenta del lado izquierdo de la pantalla del sitio.
    /// </summary>
    public class Menu :IDisposable
    {
        bool _disposed;

        /// <summary>
        /// Constructor necesario para la serialización.
        /// </summary>
        public Menu() { }

        [DataMember]
        public List<Modulo> Modulo { get; set; }

        /// <summary>
        /// Regresa el menú de un usuario
        /// </summary>
        /// <param name="idUsuario">El id del usuario en la base de datos</param>
        /// <returns></returns>
        public Menu ObtenerMenu(int idUsuario)
        {
            using (DAL.DBAccess<Menu> menu = new DAL.DBAccess<Menu>())
            {
                return menu.GetObject("Navegacion.ObtenMenu", idUsuario);
            }
        }

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