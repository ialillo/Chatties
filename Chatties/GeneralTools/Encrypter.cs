﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ChattiesModel.GeneralTools
{
    public sealed class Encrypter: Rijndael
    {
        readonly RijndaelManaged m_Managed = new RijndaelManaged();
        bool m_Disposed;

        public Encrypter() { }

        public string Encrypt(string password, string key, byte[] arrBytes)
        {
            using(PasswordDeriveBytes pwdDB = new PasswordDeriveBytes(password, arrBytes))
            {
                this.Key = pwdDB.GetBytes(32);
                this.IV = pwdDB.GetBytes(16);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, this.CreateEncryptor(), CryptoStreamMode.Write);

                byte[] clearData = Encoding.Unicode.GetBytes(key);
                cs.Write(clearData, 0, clearData.Length);
                cs.Close();

                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
        {
            if (m_Disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            return m_Managed.CreateDecryptor(rgbKey, rgbIV);
        }

        public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
        {
            if (m_Disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            return m_Managed.CreateEncryptor(rgbKey, rgbIV);
        }

        public override void GenerateIV()
        {
            GenerateIV();
        }

        public override void GenerateKey()
        {
            GenerateKey();
        }

        ~Encrypter()
        {
            Dispose(true);
        }

        protected override void Dispose(bool disposing)
        {
            m_Managed.Clear();
            m_Managed.Dispose();
            GC.SuppressFinalize(this);
            m_Disposed = true;
        }
    }
}
