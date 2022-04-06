using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Player
    {
        public String playername;
        public String playerRarPath;
        public bool config;
        public bool autoexec;
        public bool video;


        public Player()
        {
            this.playerRarPath = ".\\cfg\\";
        }
    }
}
