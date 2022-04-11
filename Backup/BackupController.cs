using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlDatabase;

namespace Backup
{
    public class BackupController
    {
        Connection conn = new Connection();
        public void SaveFile(BackupData pcp)
        {
        
            using (Stream stream = File.OpenRead(""))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                string uploadTime = DateTime.Now.ToString("dd.MM.yyyy hh.mm.ss");
                string query = "INSERT INTO backups (Config, Autoexec, Video, Username, UploadTime) VALUES (@cofig, @autoexec, @video,@username, @uploadTime)";

                using (MySqlConnection cn = conn.GetBackupConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.Add("@config", MySqlDbType.LongBlob).Value = buffer;
                    cmd.Parameters.Add("@autoexec", MySqlDbType.LongBlob).Value = buffer;
                    cmd.Parameters.Add("@video", MySqlDbType.LongBlob).Value = buffer;
                    cmd.Parameters.Add("@uploadTime", MySqlDbType.VarChar).Value = uploadTime;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            
        }

        public DataTable LoadFile()
        {
            using(MySqlConnection cn = conn.GetBackupConnection())
            {
                string query = "SELECT FileName, UploadTime FROM backups";
                MySqlDataAdapter adp = new MySqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                  return dt;
                }
                return null;
            }
        }

        public void DownloadBackup(string fileName, string steamCfgPath)
        {
            using (MySqlConnection cn = conn.GetBackupConnection())
            {
                string query = "SELECT Config, Extension, FileName FROM backups WHERE FileName=@fileName";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@fileName",MySqlDbType.VarChar).Value = fileName;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name =reader["FileName"].ToString();
                    var config = (byte[])reader["Config"];
                    var extn = reader["Extension"].ToString();
                    var filePath = steamCfgPath + name;

                    File.WriteAllBytes(filePath, config);
                    //System.Diagnostics.Process.Start(filePath);
                }
            }
        }


    }
}
