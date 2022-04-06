using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class SteamAccount
    {
        public List<String> accountDirectorys;
        public SteamAccount()
        {
            accountDirectorys = new List<String>();
        }
        public void find(List<String> steamDirectorys)
        {

            foreach (var steamDirectory in steamDirectorys)
            {
                    var steamPath = Path.Combine(steamDirectory, "userdata\\");
                    

                if (Directory.Exists(steamPath))
                {
                    var accounts = Directory.GetDirectories(steamPath);
                
                    foreach (var dir in accounts)
                    {

                        accountDirectorys.Add(Path.Combine(steamPath, dir));
                    }
                }
            };
        }
    }
}
