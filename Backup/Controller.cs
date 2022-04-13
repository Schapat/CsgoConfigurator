using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlCommunication;

namespace Backup
{
    public class Controller
    {
        Connection conn = new Connection();
        string query;
        byte[] config = new byte[0];
        byte[] video = new byte[0];
        byte[] autoexec = new byte[0];
        string uploadTime;
        public void SaveFile(Data backupData)
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
            query = "INSERT INTO backup (Config, Autoexec, Video, UserID, UploadTime, BackupName) VALUES (@config, @autoexec, @video, @userID, @uploadTime, @BackupName)";

            using (MySqlConnection cn = conn.GetBackupConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, cn);
                
                cmd.Parameters.Add("@config", MySqlDbType.LongBlob).Value = config;
                cmd.Parameters.Add("@autoexec", MySqlDbType.LongBlob).Value = autoexec;
                cmd.Parameters.Add("@video", MySqlDbType.LongBlob).Value = video;
                cmd.Parameters.Add("@uploadTime", MySqlDbType.VarChar).Value = uploadTime;
                cmd.Parameters.Add("@userID", MySqlDbType.Int32).Value = Session.userID;
                cmd.Parameters.Add("@BackupName", MySqlDbType.VarChar).Value = backupData.name;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public DataTable LoadFile()
        {
            string query = "SELECT BackupName, UploadTime FROM backup WHERE UserID=@userID";

            using (MySqlConnection cn = conn.GetBackupConnection())
            {
                MySqlDataAdapter adp = new MySqlDataAdapter(query, cn);
                adp.SelectCommand.Parameters.Add("@userID",MySqlDbType.Int64).Value = Session.userID;

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
                string query = "SELECT Config FROM backup WHERE BackupName=@backupName AND UploadTime=@uploadTime AND UserID=@userID";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@backupName",MySqlDbType.VarChar).Value = identifier[0];
                cmd.Parameters.Add("@uploadTime", MySqlDbType.VarChar).Value = identifier[1];
                cmd.Parameters.Add("@userID", MySqlDbType.Int64).Value = Session.userID;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name =  "config.cfg";
                    var config = (byte[])reader["Config"];
                    var filePath = steamCfgPath + name;

                    File.WriteAllBytes(filePath, config);
                }
                cn.Close();
            }

            using (MySqlConnection cn = conn.GetBackupConnection())
            {
                string query = "SELECT Video FROM backup WHERE BackupName=@backupName AND UploadTime=@uploadTime AND UserID=@userID";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@backupName", MySqlDbType.VarChar).Value = identifier[0];
                cmd.Parameters.Add("@uploadTime", MySqlDbType.VarChar).Value = identifier[1];
                cmd.Parameters.Add("@userID", MySqlDbType.Int64).Value = Session.userID;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = "video.txt";
                    var video = (byte[])reader["Video"];
                    var filePath = steamCfgPath + name;

                    File.WriteAllBytes(filePath, video);
                }
                cn.Close();
            }

            using (MySqlConnection cn = conn.GetBackupConnection())
            {
                string query = "SELECT Autoexec FROM backup WHERE BackupName=@backupName AND UploadTime=@uploadTime AND UserID=@userID";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.Add("@backupName", MySqlDbType.VarChar).Value = identifier[0];
                cmd.Parameters.Add("@uploadTime", MySqlDbType.VarChar).Value = identifier[1];
                cmd.Parameters.Add("@userID", MySqlDbType.Int64).Value = Session.userID;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = "autoexec.cfg";
                    var config = (byte[])reader["Autoexec"];
                    var filePath = steamCfgPath + name;

                    File.WriteAllBytes(filePath, config);
                }
                cn.Close();
            }
        }
    }
}
