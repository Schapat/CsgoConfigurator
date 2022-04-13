using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Backup
{
    public class FileGrabber
    {
        BackupData backupData;
        public FileGrabber()
        {
            backupData = new BackupData();
        }

        public BackupData SearchConfigurationFiles(String cfgDir)
        {
            Regex regEx = new Regex(@"(?<=userdata\\)(.*)(?=\\730)");
            backupData.name ="Account: "+ regEx.Match(cfgDir).ToString() ;

            var cfgFiles = Directory.GetFiles(cfgDir);
            foreach (var cfgFile in cfgFiles)
            {
                if (cfgFile.Contains("config.cfg"))
                {
                    backupData.config = cfgFile;
                }
                if (cfgFile.Contains("autoexec.cfg"))
                {
                    backupData.autoexec = cfgFile;
                }
                if (cfgFile.Contains("video.txt"))
                {
                    backupData.video = cfgFile;
                }
            }
            return backupData;
        }
    }
}
