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
        string query;
        byte[] config = new byte[0];
        byte[] video = new byte[0];
        byte[] autoexec = new byte[0];
        string uploadTime;
        public void SaveFile(BackupData backupData)
        {
            if (backupData.config != null)
            {
                using (Stream stream = File.OpenRead(backupData.config))
                {
                    config = new byte[stream.Length];
                    stream.Read(config, 0, config.Length);
                }
            }
            if (backupData.video != null)
            {
                using (Stream stream = File.OpenRead(backupData.video))
                {
                    video = new byte[stream.Length];
                    stream.Read(video, 0, video.Length);
                } 
            }
            if (backupData.autoexec != null)
            {
                using (Stream stream = File.OpenRead(backupData.autoexec))
                {
                    autoexec = new byte[stream.Length];
                    stream.Read(autoexec, 0, autoexec.Length);
                }
            }

            uploadTime = DateTime.Now.ToString("dd.MM.yyyy hh.mm.ss");
            query = "INSERT INTO backups1 (Config, Autoexec, Video, Username, UploadTime) VALUES (@config, @autoexec, @video,@username, @uploadTime)";

            using (MySqlConnection cn = conn.GetBackupConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@config", MySqlDbType.LongBlob).Value = config;
                cmd.Parameters.Add("@autoexec", MySqlDbType.LongBlob).Value = autoexec;
                cmd.Parameters.Add("@video", MySqlDbType.LongBlob).Value = video;
                cmd.Parameters.Add("@uploadTime", MySqlDbType.VarChar).Value = uploadTime;
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = backupData.name;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable LoadFile()
        {
            using(MySqlConnection cn = conn.GetBackupConnection())
            {
                string query = "SELECT Username, UploadTime FROM backups1";
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

        public void DownloadBackup(List<String> identifier, string steamCfgPath)
        {          
            using (MySqlConnection cn = conn.GetBackupConnection())
            {
                string query = "SELECT Config FROM backups1 WHERE Username=@backupName AND UploadTime=@uploadTime";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@backupName",MySqlDbType.VarChar).Value = identifier[0];
                cmd.Parameters.Add("@uploadTime", MySqlDbType.VarChar).Value = identifier[1];
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name =  "config.cfg";
                    var config = (byte[])reader["Config"];
                    var filePath = steamCfgPath + name;

                    File.WriteAllBytes(filePath, config);
                }
            }

            using (MySqlConnection cn = conn.GetBackupConnection())
            {
                string query = "SELECT Video FROM backups1 WHERE Username=@backupName AND UploadTime=@uploadTime";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@backupName", MySqlDbType.VarChar).Value = identifier[0];
                cmd.Parameters.Add("@uploadTime", MySqlDbType.VarChar).Value = identifier[1];
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = "video.txt";
                    var video = (byte[])reader["Video"];
                    var filePath = steamCfgPath + name;

                    File.WriteAllBytes(filePath, video);
                }
            }

            using (MySqlConnection cn = conn.GetBackupConnection())
            {
                string query = "SELECT Autoexec FROM backups1 WHERE Username=@backupName AND UploadTime=@uploadTime";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@backupName", MySqlDbType.VarChar).Value = identifier[0];
                cmd.Parameters.Add("@uploadTime", MySqlDbType.VarChar).Value = identifier[1];
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = "autoexec.cfg";
                    var config = (byte[])reader["Autoexec"];
                    var filePath = steamCfgPath + name;

                    File.WriteAllBytes(filePath, config);
                }
            }
        }
    }
}
