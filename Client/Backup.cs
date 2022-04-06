using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Backup
    {
        public string CfgDir { get; set; }
        public string ZipName { get; set; }
        public string BackupDestinationDir { get; set; }
        public Rar rar;
        public Backup(string cfgDir, string zipName)
        {
            this.CfgDir = cfgDir;
            this.ZipName = zipName;
            this.BackupDestinationDir = ".\\backups\\";
            this.rar = new Rar();
        }
        public void DoBackup()
        {
            rar.AddFoldersToZIP(this.ZipName, this.BackupDestinationDir);           
        }

        public void LoadBackup()
        {
            var backupLocation = this.BackupDestinationDir + this.ZipName;
            rar.UnrarCompleteFiles(backupLocation, this.CfgDir);
        }
        
        public String ShowBackup()
        {
            return this.ZipName;
        }
    }
}
