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
using MySqlCommunication;
using Steam;
using Backup;

namespace Client
{
    public partial class Client : Form
    {
        BackupController dc = new BackupController();
        public Client()
        {
            InitializeComponent();
            LaunchGUI1();
            dataGridView1.DataSource = dc.LoadFile();
        }

        private void LaunchGUI1()
        {           
            SteamDirectorys directorys = new SteamDirectorys();
            var steamDirectorys = directorys.FindSteamDirectorys();
            foreach (var steamDirectory in steamDirectorys)
            {
                comboBox2.Items.Add(steamDirectory.cfgDir);                
            }
            
            if(steamDirectorys.Count != 0)
            {
                comboBox2.SelectedIndex = 0;
            }          
            
            if(steamDirectorys.Count == 0)
            {
                //LOAD GUI FOR MANUAL PATH FINDING
                metroLabel3.Text = "Example path:";
                comboBox2.Text = "\"c:\\Program Files (x86)\\Steam\\userdata\\1234567\\\"";
                metroLabel1.Text = "No folder found. Pls Select manually";
                metroButton1.Visible = true;
                metroLabel1.Visible = true;
                metroLabel3.Visible = true;
            }           
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            List<String> selected = new List<String>();
            var selectedCell = dataGridView1.SelectedCells;
            if (selectedCell.Count != 0)
            {
                foreach (var cell in selectedCell)
                {
                    selected.Add((string)((DataGridViewCell)cell).Value);
                }
                dc.DownloadBackup(selected, comboBox2.Text);
                System.Windows.Forms.MessageBox.Show("Download Complete", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Create Backup first", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            FileGrabber fg = new FileGrabber();
            var backupFiles = fg.SearchConfigurationFiles(comboBox2.Text);
            dc.SaveFile(backupFiles);
            dataGridView1.DataSource = dc.LoadFile();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void Backup_Click(object sender, EventArgs e)
        {
            panelBackup.Visible = true; ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelBackup.Visible=false;
        }
    }
}
