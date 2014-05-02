using System;
using System.Runtime.Serialization;

namespace Chatties.DTO.General
{
    [DataContract]
    public class ResultGeneric<T>: IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Constructor base requerido para la serialización
        /// </summary>
        public ResultGeneric() { }

        /// <summary>
        /// Describe si la llamada al servicio fué satisfactoria o no
        /// </summary>
        [DataMember]
        public bool Success { get; set; }

        /// <summary>
        /// Describe el resultado de la llamada al servicio
        /// </summary>
        [DataMember]
        public string ServiceMessage { get; set; }

        /// <summary>
        /// Instancia de la clase de tipo de resultado requerida en la llamada al servicio
        /// </summary>
        [DataMember]
        public T Object { get; set; }

        /// <summary>
        /// Utiliza el Garbage Collector para destruir las instancias propias
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destruye las instancias creadas asincronamente
        /// </summary>
        ~ResultGeneric()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destruye las instancias internas condicionalmente
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}
