namespace Lemon.Common
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class CriptoProvider : ICriptoProvider
    {
        public string ComputeHash(string str)
        {
            var md5 = MD5.Create();
            var encoding = Encoding.UTF8;
            return Convert.ToBase64String(md5.ComputeHash(encoding.GetBytes(str)));
        }

        public string ComputeHash(string str, string salt)
        {
            return ComputeHash(str + salt);
        }
    }
}
