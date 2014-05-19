using System;
using System.Text;
using System.Security.Cryptography;

namespace Chatties.Security.General
{
    public class RandomPasswordGenerator : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Obtiene una contraseña aleatoria
        /// </summary>
        /// <param name="maxLength">Tamaño máximo de la contraseña aleatoria</param>
        /// <returns></returns>
        public string GetRandomPassword(int maxLength)
        {
            char[] chars = new char[62];
            byte[] data = new byte[1];

            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            
            crypto.GetNonZeroBytes(data);
            data = new byte[maxLength];
            crypto.GetNonZeroBytes(data);

            StringBuilder result = new StringBuilder(maxLength);

            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Destruye las instancias creadas asincronamente
        /// </summary>
        ~RandomPasswordGenerator()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destruye las instancias de manera condicional
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        /// <summary>
        /// Usa el garbage collector para destruir las instancias.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
