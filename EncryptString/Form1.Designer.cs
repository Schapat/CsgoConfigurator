namespace EncryptString
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.stringToEncryptTextBox = new System.Windows.Forms.TextBox();
      this.saltTextBox = new System.Windows.Forms.TextBox();
      this.encryptedStringTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(98, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "String to encrypt:";
      // 
      // stringToEncryptTextBox
      // 
      this.stringToEncryptTextBox.Location = new System.Drawing.Point(116, 12);
      this.stringToEncryptTextBox.Name = "stringToEncryptTextBox";
      this.stringToEncryptTextBox.Size = new System.Drawing.Size(672, 23);
      this.stringToEncryptTextBox.TabIndex = 1;
      this.stringToEncryptTextBox.TextChanged += new System.EventHandler(this.stringToEncryptTextBox_TextChanged);
      // 
      // saltTextBox
      // 
      this.saltTextBox.Location = new System.Drawing.Point(116, 41);
      this.saltTextBox.Name = "saltTextBox";
      this.saltTextBox.Size = new System.Drawing.Size(672, 23);
      this.saltTextBox.TabIndex = 2;
      this.saltTextBox.TextChanged += new System.EventHandler(this.saltTextBox_TextChanged);
      // 
      // encryptedStringTextBox
      // 
      this.encryptedStringTextBox.Location = new System.Drawing.Point(116, 70);
      this.encryptedStringTextBox.Name = "encryptedStringTextBox";
      this.encryptedStringTextBox.Size = new System.Drawing.Size(672, 23);
      this.encryptedStringTextBox.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(29, 15);
      this.label2.TabIndex = 4;
      this.label2.Text = "Salt:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 73);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(87, 15);
      this.label3.TabIndex = 5;
      this.label3.Text = "Encrypte String";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 106);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.encryptedStringTextBox);
      this.Controls.Add(this.saltTextBox);
      this.Controls.Add(this.stringToEncryptTextBox);
      this.Controls.Add(this.label1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label label1;
    private TextBox stringToEncryptTextBox;
    private TextBox saltTextBox;
    private TextBox encryptedStringTextBox;
    private Label label2;
    private Label label3;
  }
}