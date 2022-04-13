using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;

namespace MySqlCommunication
{
    public class Connection
    {
        public MySqlConnection connLogin;

        //string ConnectionString = "server=127.0.0.1; database=ascent_csgo; Uid=root; password=;";
        string ConnectionString = "f+F5FnPCwvgK7+GP6Z458tUkVBXqTvu+l7noAAP9yksAOnT99mZjRScS76A/YWG55K0ir+GGqUGMyr8X4j6jVk39zMd9seG7S+/4Oqhwb1tB1HEzTaQLpUuOYmdC8G37tHNjDou+dCPuJAMypRIuyjLqGJVQ7u0iPdG35l+XBHA=";
        string salt = "jk359sdi910dsa";
        //string backupConnectionString = "server=127.0.0.1; database=documentssystem; Uid=root; password=;";

        private static string Decrypt(string encryptedText, string salt)
        {
            encryptedText = encryptedText.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(encryptedText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(salt, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    encryptedText = Encoding.Unicode.GetString(mStream.ToArray());
                }
            }
            return encryptedText;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(Decrypt(ConnectionString,salt));
        }

        public MySqlConnection GetLoginConnection()
        {
            return this.connLogin = new MySqlConnection(Decrypt(ConnectionString,salt));
        }

        public void LoginConnOpen()
        {
            GetLoginConnection();
            connLogin.Open();
        }

        public void LoginConnClose()
        {
            GetLoginConnection();
            connLogin.Close();
        }
    }
}
