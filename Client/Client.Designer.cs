namespace Client
{
    partial class Client
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.metroButton1 = new System.Windows.Forms.Button();
            this.metroLabel1 = new System.Windows.Forms.Label();
            this.metroLabel3 = new System.Windows.Forms.Label();
            this.downloadButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.IntegralHeight = false;
            this.comboBox2.ItemHeight = 24;
            this.comboBox2.Location = new System.Drawing.Point(26, 130);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(457, 32);
            this.comboBox2.TabIndex = 10;
            // 
            // metroButton1
            // 
            this.metroButton1.Font = new System.Drawing.Font("Agency FB", 18F);
            this.metroButton1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.metroButton1.Location = new System.Drawing.Point(26, 83);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(110, 41);
            this.metroButton1.TabIndex = 11;
            this.metroButton1.Text = "find File";
            this.metroButton1.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.ForeColor = System.Drawing.Color.Red;
            this.metroLabel1.Location = new System.Drawing.Point(142, 111);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 13);
            this.metroLabel1.TabIndex = 12;
            this.metroLabel1.Text = "metroLabel1";
            this.metroLabel1.Visible = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Font = new System.Drawing.Font("Ink Free", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroLabel3.ForeColor = System.Drawing.Color.Red;
            this.metroLabel3.Location = new System.Drawing.Point(16, 9);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(162, 60);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Ascent";
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.downloadButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(21)))), ((int)(((byte)(219)))));
            this.downloadButton.FlatAppearance.BorderSize = 3;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Font = new System.Drawing.Font("Agency FB", 18F);
            this.downloadButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.downloadButton.Location = new System.Drawing.Point(247, 324);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(236, 94);
            this.downloadButton.TabIndex = 18;
            this.downloadButton.Text = "download Backup";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uploadButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(21)))), ((int)(((byte)(219)))));
            this.uploadButton.FlatAppearance.BorderSize = 3;
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadButton.Font = new System.Drawing.Font("Agency FB", 18F);
            this.uploadButton.ForeColor = System.Drawing.Color.White;
            this.uploadButton.Location = new System.Drawing.Point(26, 324);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(215, 94);
            this.uploadButton.TabIndex = 22;
            this.uploadButton.Text = "do Backup";
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(26, 168);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(457, 150);
            this.dataGridView1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(69, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "CsGo Configuration Backup";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(507, 435);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.comboBox2);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Client";
            this.Text = "CS:GO Easy Config";
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button metroButton1;
        private System.Windows.Forms.Label metroLabel1;
        private System.Windows.Forms.Label metroLabel3;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
    }
}

