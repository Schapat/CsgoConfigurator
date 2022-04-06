using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : MetroFramework.Forms.MetroForm
    {
        private FileFinder fileFinder;
        private Rar rar;
        private Backup backup;
        public Client()
        {
            InitializeComponent();

            fileFinder = new FileFinder();
            rar = new Rar();
            LaunchGUI1();
            
    }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            //das muss veraendert werden. neue klasse?
            rar.UnrarCompleteFiles(".\\cfg\\Se0rFPS.rar", fileFinder.CfgDir);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {            
            fileFinder.CfgDir = fileFinder.CreateCfgDirPath(comboBox2.Text);
            Properties.Settings.Default.User = "hi";
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////
        /// /////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /*
        private void LaunchGUI()
        {
            var filePath = fileFinder.accDir;

            if (filePath.Count != 0)
            {
                //GUI
                metroLabel3.Text = "Select your cfg folder";
                comboBox2.Text = "...";

                //Fill COMBOBOX WITH CFG PATH
                foreach (var path in filePath)
                {
                    comboBox2.Items.Add(path);
                }
            }
            else
            {
                //LOAD GUI FOR MANUAL PATH FINDING
                metroLabel3.Text = "Example path:";
                comboBox2.Text = "\"c:\\Program Files (x86)\\Steam\\userdata\\1234567\\\"";
                metroLabel1.Text = "No folder found. Pls Select manually";
                metroButton1.Visible = true;
                metroLabel1.Visible = true;
            }
        }
        */
        private void LaunchGUI1()
        {
            Directorys directorys = new Directorys();
            var steamDirectorys = directorys.FindCfgDirectorys();
            foreach (var steamDirectory in steamDirectorys)
            {
                comboBox2.Items.Add(steamDirectory.directoryPath);
            }
            
        }
        private void metroTile2_Click(object sender, EventArgs e)
        {
            var cfgDir = fileFinder.CreateCfgDirPath(comboBox2.Text);
            backup = new Backup(cfgDir, metroTextBox1.Text);
            backup.DoBackup();
            metroTextBox2.Text = backup.ShowBackup();
        }

        private void testButton_Click(object sender, EventArgs e)
        {

        }

       
    }

   
}
