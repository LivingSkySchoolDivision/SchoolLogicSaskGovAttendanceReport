namespace SKGovAtt
{
    partial class DatabaseConnectionConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseConnectionConfig));
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnCreateConnectionString = new System.Windows.Forms.Button();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblTestStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtTrustedDatabaseName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTrustedServerName = new System.Windows.Forms.TextBox();
            this.btnBuildConnStringTrusted = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectionString.Location = new System.Drawing.Point(6, 19);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConnectionString.Size = new System.Drawing.Size(726, 50);
            this.txtConnectionString.TabIndex = 6;
            // 
            // btnCreateConnectionString
            // 
            this.btnCreateConnectionString.Location = new System.Drawing.Point(251, 230);
            this.btnCreateConnectionString.Name = "btnCreateConnectionString";
            this.btnCreateConnectionString.Size = new System.Drawing.Size(167, 23);
            this.btnCreateConnectionString.TabIndex = 5;
            this.btnCreateConnectionString.Text = "Create connection string";
            this.btnCreateConnectionString.UseVisualStyleBackColor = true;
            this.btnCreateConnectionString.Click += new System.EventHandler(this.btnCreateConnectionString_Click);
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(134, 36);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(271, 20);
            this.txtDatabaseName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Database Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 85);
            this.label5.MaximumSize = new System.Drawing.Size(400, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(399, 26);
            this.label5.TabIndex = 6;
            this.label5.Text = "* The user that you use here should have READ ONLY access to the SchoolLogic data" +
    "base. Do not give this user write access to the School Logic database. ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(134, 143);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(271, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(134, 62);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(271, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username*";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(134, 12);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(271, 20);
            this.txtServerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server name (FQDN)";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(675, 481);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(6, 75);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblTestStatus
            // 
            this.lblTestStatus.AutoSize = true;
            this.lblTestStatus.Location = new System.Drawing.Point(87, 80);
            this.lblTestStatus.MaximumSize = new System.Drawing.Size(640, 40);
            this.lblTestStatus.MinimumSize = new System.Drawing.Size(640, 40);
            this.lblTestStatus.Name = "lblTestStatus";
            this.lblTestStatus.Size = new System.Drawing.Size(640, 40);
            this.lblTestStatus.TabIndex = 5;
            this.lblTestStatus.Text = "Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 69);
            this.label7.MaximumSize = new System.Drawing.Size(300, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(284, 65);
            this.label7.TabIndex = 6;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtConnectionString);
            this.groupBox2.Controls.Add(this.lblTestStatus);
            this.groupBox2.Controls.Add(this.btnTest);
            this.groupBox2.Location = new System.Drawing.Point(12, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(738, 136);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection String";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Connection Strings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(13, 37);
            this.label8.MaximumSize = new System.Drawing.Size(300, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(295, 26);
            this.label8.TabIndex = 9;
            this.label8.Text = "You will need the help of your IT department to fill in this information.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 190);
            this.label10.MaximumSize = new System.Drawing.Size(300, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(297, 52);
            this.label10.TabIndex = 11;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(117, 118);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(12, 140);
            this.linkLabel1.MaximumSize = new System.Drawing.Size(300, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(300, 42);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "If you wish to create your own, or if you are having difficulty getting one to wo" +
    "rk, the following website may help: http://www.connectionstrings.com/sql-server/" +
    "";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(318, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 285);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtDatabaseName);
            this.tabPage1.Controls.Add(this.btnCreateConnectionString);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtServerName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.txtUsername);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(424, 259);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User & Password";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtTrustedDatabaseName);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtTrustedServerName);
            this.tabPage2.Controls.Add(this.btnBuildConnStringTrusted);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(424, 259);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trusted Connection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtTrustedDatabaseName
            // 
            this.txtTrustedDatabaseName.Location = new System.Drawing.Point(134, 36);
            this.txtTrustedDatabaseName.Name = "txtTrustedDatabaseName";
            this.txtTrustedDatabaseName.Size = new System.Drawing.Size(271, 20);
            this.txtTrustedDatabaseName.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Database Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Server name (FQDN)";
            // 
            // txtTrustedServerName
            // 
            this.txtTrustedServerName.Location = new System.Drawing.Point(134, 12);
            this.txtTrustedServerName.Name = "txtTrustedServerName";
            this.txtTrustedServerName.Size = new System.Drawing.Size(271, 20);
            this.txtTrustedServerName.TabIndex = 10;
            // 
            // btnBuildConnStringTrusted
            // 
            this.btnBuildConnStringTrusted.Location = new System.Drawing.Point(251, 230);
            this.btnBuildConnStringTrusted.Name = "btnBuildConnStringTrusted";
            this.btnBuildConnStringTrusted.Size = new System.Drawing.Size(167, 23);
            this.btnBuildConnStringTrusted.TabIndex = 12;
            this.btnBuildConnStringTrusted.Text = "Create connection string";
            this.btnBuildConnStringTrusted.UseVisualStyleBackColor = true;
            this.btnBuildConnStringTrusted.Click += new System.EventHandler(this.btnBuildConnStringTrusted_Click);
            // 
            // DatabaseConnectionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 512);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseConnectionConfig";
            this.Text = "Configure database connection";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.DatabaseConnectionConfig_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblTestStatus;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCreateConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtTrustedDatabaseName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTrustedServerName;
        private System.Windows.Forms.Button btnBuildConnStringTrusted;

    }
}