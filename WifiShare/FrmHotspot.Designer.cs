namespace WifiShare
{
    partial class FrmHotspot
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
            this.components = new System.ComponentModel.Container();
            this.hotspotNameTbx = new System.Windows.Forms.TextBox();
            this.hotspotPasswordTbx = new System.Windows.Forms.TextBox();
            this.hotspotNameLbl = new System.Windows.Forms.Label();
            this.hotspotPasswordLbl = new System.Windows.Forms.Label();
            this.hotspotActionsTlp = new System.Windows.Forms.TableLayoutPanel();
            this.startHotspotBtn = new System.Windows.Forms.Button();
            this.stopHotspotBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.clientsTsL = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTsL = new System.Windows.Forms.ToolStripStatusLabel();
            this.updateClientsTimer = new System.Windows.Forms.Timer(this.components);
            this.hotspotActionsTlp.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotspotNameTbx
            // 
            this.hotspotNameTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hotspotNameTbx.Location = new System.Drawing.Point(12, 25);
            this.hotspotNameTbx.Name = "hotspotNameTbx";
            this.hotspotNameTbx.Size = new System.Drawing.Size(234, 20);
            this.hotspotNameTbx.TabIndex = 0;
            // 
            // hotspotPasswordTbx
            // 
            this.hotspotPasswordTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hotspotPasswordTbx.Location = new System.Drawing.Point(12, 69);
            this.hotspotPasswordTbx.Name = "hotspotPasswordTbx";
            this.hotspotPasswordTbx.Size = new System.Drawing.Size(234, 20);
            this.hotspotPasswordTbx.TabIndex = 1;
            this.hotspotPasswordTbx.UseSystemPasswordChar = true;
            // 
            // hotspotNameLbl
            // 
            this.hotspotNameLbl.AutoSize = true;
            this.hotspotNameLbl.Location = new System.Drawing.Point(12, 9);
            this.hotspotNameLbl.Name = "hotspotNameLbl";
            this.hotspotNameLbl.Size = new System.Drawing.Size(73, 13);
            this.hotspotNameLbl.TabIndex = 2;
            this.hotspotNameLbl.Text = "Hotspot name";
            // 
            // hotspotPasswordLbl
            // 
            this.hotspotPasswordLbl.AutoSize = true;
            this.hotspotPasswordLbl.Location = new System.Drawing.Point(12, 53);
            this.hotspotPasswordLbl.Name = "hotspotPasswordLbl";
            this.hotspotPasswordLbl.Size = new System.Drawing.Size(53, 13);
            this.hotspotPasswordLbl.TabIndex = 3;
            this.hotspotPasswordLbl.Text = "Password";
            // 
            // hotspotActionsTlp
            // 
            this.hotspotActionsTlp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hotspotActionsTlp.ColumnCount = 2;
            this.hotspotActionsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hotspotActionsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hotspotActionsTlp.Controls.Add(this.startHotspotBtn, 0, 0);
            this.hotspotActionsTlp.Controls.Add(this.stopHotspotBtn, 1, 0);
            this.hotspotActionsTlp.Location = new System.Drawing.Point(9, 102);
            this.hotspotActionsTlp.Margin = new System.Windows.Forms.Padding(0);
            this.hotspotActionsTlp.Name = "hotspotActionsTlp";
            this.hotspotActionsTlp.RowCount = 1;
            this.hotspotActionsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hotspotActionsTlp.Size = new System.Drawing.Size(240, 36);
            this.hotspotActionsTlp.TabIndex = 4;
            // 
            // startHotspotBtn
            // 
            this.startHotspotBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startHotspotBtn.Location = new System.Drawing.Point(2, 2);
            this.startHotspotBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startHotspotBtn.Name = "startHotspotBtn";
            this.startHotspotBtn.Size = new System.Drawing.Size(116, 32);
            this.startHotspotBtn.TabIndex = 0;
            this.startHotspotBtn.Text = "&Start";
            this.startHotspotBtn.UseVisualStyleBackColor = true;
            this.startHotspotBtn.Click += new System.EventHandler(this.StartHotspotBtn_Click);
            // 
            // stopHotspotBtn
            // 
            this.stopHotspotBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopHotspotBtn.Enabled = false;
            this.stopHotspotBtn.Location = new System.Drawing.Point(122, 2);
            this.stopHotspotBtn.Margin = new System.Windows.Forms.Padding(2);
            this.stopHotspotBtn.Name = "stopHotspotBtn";
            this.stopHotspotBtn.Size = new System.Drawing.Size(116, 32);
            this.stopHotspotBtn.TabIndex = 1;
            this.stopHotspotBtn.Text = "S&top";
            this.stopHotspotBtn.UseVisualStyleBackColor = true;
            this.stopHotspotBtn.Click += new System.EventHandler(this.StopHotspotBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientsTsL,
            this.statusTsL});
            this.statusStrip1.Location = new System.Drawing.Point(0, 152);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(258, 27);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // clientsTsL
            // 
            this.clientsTsL.BackColor = System.Drawing.SystemColors.Control;
            this.clientsTsL.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.clientsTsL.Margin = new System.Windows.Forms.Padding(1, 4, 0, 4);
            this.clientsTsL.Name = "clientsTsL";
            this.clientsTsL.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clientsTsL.Size = new System.Drawing.Size(67, 19);
            this.clientsTsL.Text = "Clients: 0";
            // 
            // statusTsL
            // 
            this.statusTsL.BackColor = System.Drawing.SystemColors.Control;
            this.statusTsL.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.statusTsL.Name = "statusTsL";
            this.statusTsL.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusTsL.Size = new System.Drawing.Size(116, 19);
            this.statusTsL.Text = "Status: initializing...";
            // 
            // updateClientsTimer
            // 
            this.updateClientsTimer.Interval = 1500;
            this.updateClientsTimer.Tick += new System.EventHandler(this.UpdateClientsTimer_Tick);
            // 
            // FrmHotspot
            // 
            this.AcceptButton = this.startHotspotBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(258, 179);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.hotspotActionsTlp);
            this.Controls.Add(this.hotspotPasswordLbl);
            this.Controls.Add(this.hotspotNameLbl);
            this.Controls.Add(this.hotspotPasswordTbx);
            this.Controls.Add(this.hotspotNameTbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHotspot";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WifiShare";
            this.hotspotActionsTlp.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hotspotNameTbx;
        private System.Windows.Forms.TextBox hotspotPasswordTbx;
        private System.Windows.Forms.Label hotspotNameLbl;
        private System.Windows.Forms.Label hotspotPasswordLbl;
        private System.Windows.Forms.TableLayoutPanel hotspotActionsTlp;
        private System.Windows.Forms.Button startHotspotBtn;
        private System.Windows.Forms.Button stopHotspotBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel clientsTsL;
        private System.Windows.Forms.ToolStripStatusLabel statusTsL;
        private System.Windows.Forms.Timer updateClientsTimer;
    }
}

