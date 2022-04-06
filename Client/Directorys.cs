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
        public List<SteamDirectory> steamDirectorys;
        public List<AccountDirectory> accountDirectorys;
        public List<CfgDirectory> cfgDirectorys;


        public Directorys()
        {
            steamDirectorys = new List<SteamDirectory>();
            accountDirectorys = new List<AccountDirectory>();
            cfgDirectorys = new List<CfgDirectory>();
        }

        public List<SteamDirectory> FindSteamDirectorys()
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
                            SteamDirectory steamDirectory = new SteamDirectory(dir);
                            this.steamDirectorys.Add(steamDirectory);
                        }
                        else
                        {
                            foreach (var subDir in Directory.GetDirectories(dir))
                            {
                                if (!File.GetAttributes(subDir).HasFlag(FileAttributes.Hidden) && !subDir.Contains("Win"))
                                {
                                    if (subDir.Contains("Steam"))
                                    {
                                        SteamDirectory steamDirectory = new SteamDirectory(subDir);
                                        this.steamDirectorys.Add(steamDirectory);
                                    }
                                }
                            }
                        }
                    }   
                }
            }
            return steamDirectorys;
        }

        public List<AccountDirectory> FindAccountDirectorys()
        {

            if (this.steamDirectorys.Count == 0)
            {
                FindSteamDirectorys();
            }
            
            foreach (var steamdirectory in this.steamDirectorys)
            {
               foreach(var dir in Directory.GetDirectories(steamdirectory.directoryPath))
               {
                    if (dir.Contains("userdata"))
                    {
                        foreach(var account in Directory.GetDirectories(dir))
                        {
                            AccountDirectory accountDirectory = new AccountDirectory(account);
                            this.accountDirectorys.Add(accountDirectory);
                        }
                    }
               }
            }
            return accountDirectorys;
        }

        public List<CfgDirectory> FindCfgDirectorys()
        {
            if (this.accountDirectorys.Count == 0)
            {
                FindAccountDirectorys();
            }

            foreach (var accountdirectory in this.accountDirectorys)
            {
                foreach (var dir in Directory.GetDirectories(accountdirectory.directoryPath))
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
                                        
                                        CfgDirectory cfgDirectory = new CfgDirectory(subSubDir);
                                        this.cfgDirectorys.Add(cfgDirectory);
                                        break;
                                    }
                                }
                                break;  
                            } 
                        } 
                    }
                }
            }
            return cfgDirectorys;
        }
    }
}
