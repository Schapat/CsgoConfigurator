using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class DriverInfo
    {
        public List<String> drivers;
        
        

        public DriverInfo()
        {
            drivers = new List<String>();
            getDriveName();
        }


        private void getDriveName()
        {
            var allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                drivers.Add(d.Name);
            }
        }
    }
}
