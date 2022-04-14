using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlCommunication;
using System.IO;

namespace ProConfig
{
    internal class DbController
    {
        Connection conn = new Connection();
        public void DownloadCfg(string steamCfgPath, string playerName)
        {
            using (MySqlConnection cn = conn.GetConnection())
            {
                string query = "SELECT Config FROM proPlayer WHERE PlayerName=@playerName";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@playerName", MySqlDbType.VarChar).Value = playerName;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = "config.cfg";
                    var config = (byte[])reader["Config"];
                    var filePath = steamCfgPath + name;

                    File.WriteAllBytes(filePath, config);
                }
                cn.Close();
            }
        }

        public void DownloadAutoexec(string playerName, string steamCfgPath)
        {
            using (MySqlConnection cn = conn.GetConnection())
            {
                string query = "SELECT Autoexec FROM proPlayer WHERE PlayerName=@playerName";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@playerName", MySqlDbType.VarChar).Value = playerName;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = "autoexec.cfg";
                    var autoexec = (byte[])reader["Autoexec"];
                    var filePath = steamCfgPath + name;

                    File.WriteAllBytes(filePath, autoexec);
                }
                cn.Close();
            }
        }

        public void DownloadVideo(string playerName, string steamCfgPath)
        {
            using (MySqlConnection cn = conn.GetConnection())
            {
                string query = "SELECT Video FROM proPlayer WHERE PlayerName=@playerName";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@playerName", MySqlDbType.VarChar).Value = playerName;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = "video.txt";
                    var autoexec = (byte[])reader["Video"];
                    var filePath = steamCfgPath + name;

                    File.WriteAllBytes(filePath, autoexec);
                }
                cn.Close();
            }
        }

        public bool CheckConfigExists(string playerName)
        {
            using (MySqlConnection cn = conn.GetConnection())
            {
                string query = "SELECT Config FROM proPlayer WHERE PlayerName=@playerName";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@playerName", MySqlDbType.VarChar).Value = playerName;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.FieldCount > 0)
                {
                    return true;
                }
                cn.Close();
                return false;
            }
            
        }

        public bool CheckAutoexecExists(string playerName)
        {
            using (MySqlConnection cn = conn.GetConnection())
            {
                string query = "SELECT Autoexec FROM proPlayer WHERE PlayerName=@playerName";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@playerName", MySqlDbType.VarChar).Value = playerName;
                cn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.FieldCount > 0)
                {
                    return true;
                }
                
                cn.Close();
                return false;
            }

        }

        public bool CheckVideoExists(string playerName)
        {
            using (MySqlConnection cn = conn.GetConnection())
            {
                string query = "SELECT Video FROM proPlayer WHERE PlayerName=@playerName";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@playerName", MySqlDbType.VarChar).Value = playerName;
                cn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.FieldCount > 0)
                {
                    return true;
                }

                cn.Close();
                return false;
            }

        }

        public List<string> GetPlayerNames()
        {
            List<string> playerNames = new List<string>();
            using (MySqlConnection cn = conn.GetConnection())
            {
                string query = "SELECT PlayerName FROM proPlayer";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        playerNames.Add(reader[i].ToString());
                    }
                    cn.Close();
                }
            }
            return playerNames;
        }
    }
}
