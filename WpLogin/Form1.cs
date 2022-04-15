using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpLogin
{
    public partial class Form1 : Form
    {
        string salt = CryptSharp.Crypter.Phpass.GenerateSalt(8);

        public Form1()
        {
            InitializeComponent();
        }
        public static bool ValidatePassword(string pass, string passCriptat, string salt)
        {
            string CryptedInput = CryptSharp.Crypter.Phpass.Crypt(Encoding.ASCII.GetBytes(pass), salt);
            string CryptedPassword = CryptSharp.Crypter.Phpass.Crypt(Encoding.ASCII.GetBytes(passCriptat), salt);
            return string.Equals(CryptedInput, CryptedPassword);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userLogat = txtBoxUser.Text;
            MySqlConnection sqlcon = new MySqlConnection(@"server=rdbms.strato.de;userid=dbu1283153;password=GermanRapE(uHb1;persistsecurityinfo=False;database=dbs4318686;sslmode=None;");
            string query = "Select * from ki_users Where user_login= '" + txtBoxUser.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                string savedPasswordHash = dtbl.Rows[0][3].ToString();

                if (ValidatePassword(txtBoxPass.Text, savedPasswordHash, salt))
                {
                    MessageBox.Show($"Wellcome {txtBoxUser.Text} !");
                    //FormMain openMain = new FormMain(userLogat);
                    //openMain.Show();
                    //this.Hide();
                }
                else
                {
                    MessageBox.Show($"Password for  {userLogat} error.");
                }
            }
            else
            {
                MessageBox.Show($"Username error!");
            }
            sqlcon.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection(@"server=xx.xx.xx.xx;user id=user;password=password;persistsecurityinfo=False;database=website;sslmode=None;");
            string query = "Select * from users Where username= '" + txtBoxUser.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count > 0)
            {
                MessageBox.Show("Username exist!");
            }
            else
            {
                if (txtBoxUser.Text == "" | txtBoxPass.Text == "")
                {
                    MessageBox.Show("Fill in properly !");
                }
                else
                {
                    try
                    {
                        string commString = "INSERT INTO users (username, password, permissions, homedir) VALUES (@val1, @val2, @val3, @val4)";
                        string constring = @"server=xx.xx.xx.xx;user id=user;password=password;persistsecurityinfo=False;database=website;sslmode=None;";
                        string savedPasswordHash = CryptSharp.Crypter.Phpass.Crypt(txtBoxPass.Text, salt);
                        using (MySqlConnection conn = new MySqlConnection(constring))
                        {
                            using (MySqlCommand comm = new MySqlCommand())
                            {
                                comm.Connection = conn;
                                comm.CommandText = commString;
                                comm.Parameters.AddWithValue("@val1", txtBoxUser.Text);
                                comm.Parameters.AddWithValue("@val2", savedPasswordHash);
                                comm.Parameters.AddWithValue("@val3", "rwu");
                                comm.Parameters.AddWithValue("@val4", "/var/www/repository/HOME");
                                conn.Open();
                                comm.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                        MessageBox.Show("Register OK!");
                        txtBoxPass.Text = null;
                        sqlcon.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Eroare. Contact admin!");
                    }
                }
            }
        
    }
    }
}
