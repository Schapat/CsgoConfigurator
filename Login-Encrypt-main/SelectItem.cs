using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlCommunication;

namespace LoginEncrpyt
{
    class SelectItem
    {
        Connection con = new Connection();
        insertData insrdt = new insertData();

        public string SelectData(string userInsert, string passInsert)
        {
            try
            {
                con.GetLoginConnection();
                con.LoginConnOpen();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = ("Select * from users where (Username, Password) = (@name, @password)");
                command.Parameters.AddWithValue("@name", userInsert);
                command.Parameters.AddWithValue("@password", Encrypt.HashString(passInsert));
                command.Connection = con.connLogin;
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    //System.Windows.Forms.MessageBox.Show("Hi :D", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    Session.username = (string)reader["Username"];
                    Session.userID = (int)reader["ID"];
                    Client.Client clt = new Client.Client();
                    clt.ShowDialog();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Error", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

                return userInsert + passInsert;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return null;
            }
            finally
            {
                con.LoginConnClose();
            }

        }
    }
}
