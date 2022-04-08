using System.Security.Cryptography;
using System.Text;

namespace EncryptString
{
  public partial class Form1 : Form {
    static readonly string DefaultSalt = "jk359sdi910dsa";
    public Form1()
    {
      InitializeComponent();
      saltTextBox.Text = DefaultSalt;
    }
    private static string Encrypt(string inText, string salt) {
      byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
      using (Aes aes = Aes.Create()) {
        Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(salt, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        aes.Key = crypto.GetBytes(32);
        aes.IV = crypto.GetBytes(16);
        using (MemoryStream mStream = new MemoryStream()) {
          using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write)) {
            cStream.Write(bytesBuff, 0, bytesBuff.Length);
            cStream.Close();
          }
          inText = Convert.ToBase64String(mStream.ToArray());
        }
      }
      return inText;
    }
    //Decrypting a string
    private static string Decrypt(string cryptTxt, string salt) {
      cryptTxt = cryptTxt.Replace(" ", "+");
      byte[] bytesBuff = Convert.FromBase64String(cryptTxt);
      using (Aes aes = Aes.Create()) {
        Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(salt, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        aes.Key = crypto.GetBytes(32);
        aes.IV = crypto.GetBytes(16);
        using (MemoryStream mStream = new MemoryStream()) {
          using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write)) {
            cStream.Write(bytesBuff, 0, bytesBuff.Length);
            cStream.Close();
          }
          cryptTxt = Encoding.Unicode.GetString(mStream.ToArray());
        }
      }
      return cryptTxt;
    }

    private void stringToEncryptTextBox_TextChanged(object sender, EventArgs e) {
      encryptedStringTextBox.Text = Encrypt(stringToEncryptTextBox.Text, saltTextBox.Text);
    }

    private void saltTextBox_TextChanged(object sender, EventArgs e) {
      encryptedStringTextBox.Text = Encrypt(stringToEncryptTextBox.Text, saltTextBox.Text);
    }
  }
}