using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Directorys
    {
        private List<SteamDirectoryPath> steamDirectoryPaths;
        SteamDirectoryPath steamDirectoryPath;

        public Directorys()
        {
            steamDirectoryPaths = new List<SteamDirectoryPath>();
        }

        public List<SteamDirectoryPath> FindSteamDirectorys()
        {
            DriverInfo driverInfo = new DriverInfo();

            foreach (var drive in driverInfo.drivers)
            {
                foreach (var dir in Directory.GetDirectories(drive))
                {
                    if (!File.GetAttributes(dir).HasFlag(FileAttributes.Hidden) && !dir.Contains("Win"))
                    {
                        if (dir.Contains("Steam"))
                        {
                            steamDirectoryPath = new SteamDirectoryPath();
                            steamDirectoryPath.steamDir = dir;
                            FindAccountDirectorys(steamDirectoryPath.steamDir);
                        }
                        else
                        {
                            foreach (var subDir in Directory.GetDirectories(dir))
                            {
                                if (!File.GetAttributes(subDir).HasFlag(FileAttributes.Hidden) && !subDir.Contains("Win"))
                                {
                                    if (subDir.Contains("Steam"))
                                    {
                                        steamDirectoryPath = new SteamDirectoryPath();
                                        steamDirectoryPath.steamDir = subDir;
                                        FindAccountDirectorys(steamDirectoryPath.steamDir);
                                    }
                                }
                            }
                        }
                    }   
                }
            }
            return steamDirectoryPaths;
        }

        private void FindAccountDirectorys(String path)
        { 
               foreach(var dir in Directory.GetDirectories(path))
               {
                    if (dir.Contains("userdata"))
                    {
                        foreach(var account in Directory.GetDirectories(dir))
                        {
                            steamDirectoryPath.accountDir = account;
                            FindCfgDirectorys(steamDirectoryPath.accountDir);
                            break;
                        }
                    }
               }
        }

        private void FindCfgDirectorys(String path)
        {
            
            foreach (var dir in Directory.GetDirectories(path))
            {
                //IF CSGO is on this Account
                if (dir.Contains("730"))
                {
                    foreach (var subDir in Directory.GetDirectories(dir))
                    {
                        if (subDir.Contains("local"))
                        {
                            foreach(var subSubDir in Directory.GetDirectories(subDir)) 
                            {
                                if (subSubDir.Contains("cfg"))
                                {

                                    steamDirectoryPath.cfgDir = subSubDir;
                                    steamDirectoryPaths.Add(steamDirectoryPath);
                                    break;
                                }
                            }  
                        } 
                    } 
                }
            }
        }
    }
}
