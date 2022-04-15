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
using ProConfig;

namespace Client
{
    public partial class Client : Form
    {
        DbController dc = new DbController();
        PlayerDbController playerDb = new PlayerDbController();
        FileGrabber fg = new FileGrabber();

        public Client()
        {
            InitializeComponent();
            LaunchGUI();
        }

        private void LaunchGUI()
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
                mLabel3.Text = "Example path:";
                comboBox2.Text = "\"c:\\Program Files (x86)\\Steam\\userdata\\1234567\\\"";
                mLabel1.Text = "No folder found. Pls Select manually";
                mButton1.Visible = true;
                mLabel1.Visible = true;
                mLabel3.Visible = true;
            }

            dataGridView1.DataSource = dc.LoadFile();

            foreach (var player in playerDb.GetPlayerNames())
            {
                listBox1.Items.Add(player);
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
            var backupFiles = fg.SearchConfigurationFiles(comboBox2.Text);
            if (dc.CheckBackupCount())
            {
                dc.SaveFile(backupFiles);
                dataGridView1.DataSource = dc.LoadFile();
            }
            else
            {
                MessageBox.Show("BackupFull","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void Backup_Click(object sender, EventArgs e)
        {
            panelBackup.Visible = true;
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelBackup.Visible=false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<String> selected = new List<String>();
            var selectedCell = dataGridView1.SelectedCells;
            if (selectedCell.Count != 0)
            {
                foreach (var cell in selectedCell)
                {
                    selected.Add((string)((DataGridViewCell)cell).Value);
                }
                dc.DeleteBackup(selected);
                dataGridView1.DataSource = dc.LoadFile();
                System.Windows.Forms.MessageBox.Show("Backup deleted", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Backup selected", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelBackup.Visible = false;
            panel1.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxAutoexec.Enabled =  playerDb.CheckConfigExists(listBox1.SelectedItem.ToString());
            checkBoxConfig.Enabled = playerDb.CheckConfigExists(listBox1.SelectedItem.ToString());
            checkBoxVideo.Enabled = playerDb.CheckConfigExists(listBox1.SelectedItem.ToString());
        }

        private void btnUseConfig_Click(object sender, EventArgs e)
        {
            if (checkBoxAutoexec.Checked)
            {
                playerDb.DownloadAutoexec(listBox1.SelectedItem.ToString(), comboBox2.Text);
            }
            if (checkBoxConfig.Checked)
            {
                playerDb.DownloadCfg(listBox1.SelectedItem.ToString(), comboBox2.Text);
            }
            if (checkBoxVideo.Checked)
            {
                playerDb.DownloadVideo(listBox1.SelectedItem.ToString(), comboBox2.Text);
            }
        }
    }
}
