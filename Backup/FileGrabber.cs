using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    public class FileGrabber
    {
        BackupData playerConfigurationPath;
        public FileGrabber()
        {
            playerConfigurationPath = new BackupData();
        }

        public BackupData SearchConfigurationFiles(String cfgDir)
        {
            var cfgFiles = Directory.GetFiles(cfgDir);

            foreach (var cfgFile in cfgFiles)
            {
                if (cfgFile.Contains("config.cfg"))
                {
                    playerConfigurationPath.config = cfgFile;
                }
                if (cfgFile.Contains("autoexec.cfg"))
                {
                    playerConfigurationPath.autoexec = cfgFile;
                }
                if (cfgFile.Contains("video.txt"))
                {
                    playerConfigurationPath.video = cfgFile;
                }
            }

            return playerConfigurationPath;
        }
    }
}
