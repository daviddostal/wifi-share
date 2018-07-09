namespace WifiShare
{
    partial class AboutDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.authorLabel = new System.Windows.Forms.Label();
            this.authorText = new System.Windows.Forms.Label();
            this.librariesLabel = new System.Windows.Forms.Label();
            this.librariesNativeWifiText = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.githubLabel = new System.Windows.Forms.Label();
            this.githubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.licenseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.licanseLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorLabel.Location = new System.Drawing.Point(11, 12);
            this.authorLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(48, 13);
            this.authorLabel.TabIndex = 0;
            this.authorLabel.Text = "Author:";
            // 
            // authorText
            // 
            this.authorText.AutoSize = true;
            this.authorText.Location = new System.Drawing.Point(76, 12);
            this.authorText.Name = "authorText";
            this.authorText.Size = new System.Drawing.Size(68, 13);
            this.authorText.TabIndex = 1;
            this.authorText.Text = "David Dostal";
            // 
            // librariesLabel
            // 
            this.librariesLabel.AutoSize = true;
            this.librariesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.librariesLabel.Location = new System.Drawing.Point(11, 37);
            this.librariesLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.librariesLabel.Name = "librariesLabel";
            this.librariesLabel.Size = new System.Drawing.Size(59, 13);
            this.librariesLabel.TabIndex = 2;
            this.librariesLabel.Text = "Libraries:";
            // 
            // librariesNativeWifiText
            // 
            this.librariesNativeWifiText.AutoSize = true;
            this.librariesNativeWifiText.Location = new System.Drawing.Point(76, 37);
            this.librariesNativeWifiText.Name = "librariesNativeWifiText";
            this.librariesNativeWifiText.Size = new System.Drawing.Size(218, 13);
            this.librariesNativeWifiText.TabIndex = 3;
            this.librariesNativeWifiText.Text = "NativeWifi by Ilya Konstantinov (MIT license)";
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(111, 131);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 28);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // githubLabel
            // 
            this.githubLabel.AutoSize = true;
            this.githubLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.githubLabel.Location = new System.Drawing.Point(11, 62);
            this.githubLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.githubLabel.Name = "githubLabel";
            this.githubLabel.Size = new System.Drawing.Size(50, 13);
            this.githubLabel.TabIndex = 5;
            this.githubLabel.Text = "GitHub:";
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.AutoSize = true;
            this.githubLinkLabel.Location = new System.Drawing.Point(76, 62);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(206, 13);
            this.githubLinkLabel.TabIndex = 6;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "https://github.com/david-dostal/wifi-share";
            this.githubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubLinkLabelClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.licenseLinkLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.authorLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.githubLinkLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.authorText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.githubLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.librariesLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.librariesNativeWifiText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.licanseLabel, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(303, 119);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // licenseLinkLabel
            // 
            this.licenseLinkLabel.AutoSize = true;
            this.licenseLinkLabel.Location = new System.Drawing.Point(76, 87);
            this.licenseLinkLabel.Name = "licenseLinkLabel";
            this.licenseLinkLabel.Size = new System.Drawing.Size(62, 13);
            this.licenseLinkLabel.TabIndex = 8;
            this.licenseLinkLabel.TabStop = true;
            this.licenseLinkLabel.Text = "MIT license";
            this.licenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.licenseLinkLabel_LinkClicked);
            // 
            // licanseLabel
            // 
            this.licanseLabel.AutoSize = true;
            this.licanseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.licanseLabel.Location = new System.Drawing.Point(11, 87);
            this.licanseLabel.Name = "licanseLabel";
            this.licanseLabel.Size = new System.Drawing.Size(55, 13);
            this.licanseLabel.TabIndex = 7;
            this.licanseLabel.Text = "License:";
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(303, 171);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label authorText;
        private System.Windows.Forms.Label librariesLabel;
        private System.Windows.Forms.Label librariesNativeWifiText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label githubLabel;
        private System.Windows.Forms.LinkLabel githubLinkLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label licanseLabel;
        private System.Windows.Forms.LinkLabel licenseLinkLabel;
    }
}