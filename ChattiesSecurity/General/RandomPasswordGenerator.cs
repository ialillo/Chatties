using System.Text;
using System.Security.Cryptography;

namespace Chatties.Security.General
{
    class RandomPasswordGenerator
    {
        public static string GetRandomPassword(int maxLength)
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
    }
}
