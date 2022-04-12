using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    public class BackupData
    {
        public string name;
        public string config;
        public string autoexec;
        public string video;

        public BackupData()
        {
            name = "backup";
        }

        public void getUser()
        {

        }
    }
}
