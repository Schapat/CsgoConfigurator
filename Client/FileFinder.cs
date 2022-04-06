using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class FileFinder
    {
        //private String userdataPath;
        private List<String> accUserdataDir { get; set; }
        public List<String> accDir { get; set; }
        public string UserdataPath { get; set; }
        public string CfgDir { get; set; }

        private static String cfgDirSnipped = "\\730\\local\\cfg\\";

        public FileFinder() 
        { 
            this.UserdataPath = "userdata\\";
            this.accUserdataDir = new List<String>();
            this.accDir = new List<String>();
            LocateCSGOAccDir();
            ShowAccountDir();
            
        }

        private void LocateCSGOAccDir()
        {
            DriverInfo driverInfo = new DriverInfo();
            foreach (var drive in driverInfo.drivers)
            {
                foreach (var dir in Directory.GetDirectories(drive))
                {
                    if (!File.GetAttributes(dir).HasFlag(FileAttributes.Hidden) && !dir.Contains("Win"))
                    {
                        if (checkSteamDir(dir))
                        {
                            var steamPath = Path.Combine(dir, this.UserdataPath);
                            if (Directory.Exists(steamPath))
                            {
                                accUserdataDir.Add(steamPath);
                            }
                        }

                        foreach (var subDir in Directory.GetDirectories(dir))
                        {
                            if (!File.GetAttributes(subDir).HasFlag(FileAttributes.Hidden) && !subDir.Contains("Win"))
                            {
                                if (checkSteamDir(subDir))
                                {
                                    var subSteamPath = Path.Combine(subDir, this.UserdataPath);
                                    if (Directory.Exists(subSteamPath))
                                    {
                                        accUserdataDir.Add(subSteamPath);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ShowAccountDir()
        {
            var userData = this.accUserdataDir;

            foreach (var item in userData)
            {                
                if (Directory.Exists(item))
                {
                    var acc = Directory.GetDirectories(item);

                    foreach (var dir in acc)
                    {

                        accDir.Add(Path.Combine(item, dir));
                    }
                }
            }; 
        }

        private bool checkSteamDir(string path)
        {
            if (path.Contains("Steam")) 
            { 
                return true; 
            }
            else 
            { 
                return false; 
            }
        }

        public string CreateCfgDirPath(string userpath)
        {
            if (Directory.Exists(userpath + cfgDirSnipped))
            {
                this.CfgDir = userpath + cfgDirSnipped;
                return this.CfgDir;
            }
            else return null;
        }

    }
}
