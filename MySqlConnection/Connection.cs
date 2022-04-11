using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySqlDatabase
{
    public class Connection
    {
        public MySqlConnection connLogin;

        string loginConnectionString = "server=127.0.0.1; database=login; Uid=root; password=;";
        string backupConnectionString = "server=127.0.0.1; database=documentssystem; Uid=root; password=;";

        public MySqlConnection GetBackupConnection()
        {
            return new MySqlConnection(backupConnectionString);
        }

        public MySqlConnection GetLoginConnection()
        {
            return this.connLogin = new MySqlConnection(loginConnectionString);
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
