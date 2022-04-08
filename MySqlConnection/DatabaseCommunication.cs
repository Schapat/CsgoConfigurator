using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySqlDatabase
{
    public class DatabaseCommunication
    {
        string ConnectionString = "server=127.0.0.1; database=documentssystem; Uid=root; password=;";
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public void SaveFile(string filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                string extn = new FileInfo(filePath).Extension;
                string query = "INSERT INTO backups (Config,Extension) VALUES (@config, @extn)";

                using (MySqlConnection cn = GetConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.Add("@config", MySqlDbType.LongBlob).Value = buffer;
                    cmd.Parameters.Add("@extn", MySqlDbType.VarChar).Value = extn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
