namespace SKGovAtt
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.drpDistricts = new System.Windows.Forms.ComboBox();
            this.lstSchools = new System.Windows.Forms.CheckedListBox();
            this.btnGeneratePeriod = new System.Windows.Forms.Button();
            this.btnGenerateDaily = new System.Windows.Forms.Button();
            this.drpMonth = new System.Windows.Forms.ComboBox();
            this.drpYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDistrictDAN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDistrictPrefix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRetryLoadDistricts = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.stsStatusBar = new System.Windows.Forms.StatusStrip();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.mnuConfigureDatabase = new System.Windows.Forms.MenuItem();
            this.prgProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.stsStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // drpDistricts
            // 
            this.drpDistricts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpDistricts.FormattingEnabled = true;
            this.drpDistricts.Location = new System.Drawing.Point(5, 18);
            this.drpDistricts.Margin = new System.Windows.Forms.Padding(2);
            this.drpDistricts.Name = "drpDistricts";
            this.drpDistricts.Size = new System.Drawing.Size(237, 21);
            this.drpDistricts.TabIndex = 3;
            this.drpDistricts.SelectedValueChanged += new System.EventHandler(this.drpDistricts_SelectedValueChanged);
            // 
            // lstSchools
            // 
            this.lstSchools.CheckOnClick = true;
            this.lstSchools.Enabled = false;
            this.lstSchools.FormattingEnabled = true;
            this.lstSchools.Location = new System.Drawing.Point(5, 54);
            this.lstSchools.Margin = new System.Windows.Forms.Padding(2);
            this.lstSchools.Name = "lstSchools";
            this.lstSchools.Size = new System.Drawing.Size(237, 319);
            this.lstSchools.TabIndex = 4;
            // 
            // btnGeneratePeriod
            // 
            this.btnGeneratePeriod.Enabled = false;
            this.btnGeneratePeriod.Location = new System.Drawing.Point(642, 403);
            this.btnGeneratePeriod.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeneratePeriod.Name = "btnGeneratePeriod";
            this.btnGeneratePeriod.Size = new System.Drawing.Size(246, 31);
            this.btnGeneratePeriod.TabIndex = 8;
            this.btnGeneratePeriod.Text = "Generate for PERIOD attendance";
            this.btnGeneratePeriod.UseVisualStyleBackColor = true;
            this.btnGeneratePeriod.Click += new System.EventHandler(this.btnGeneratePeriod_Click);
            // 
            // btnGenerateDaily
            // 
            this.btnGenerateDaily.Enabled = false;
            this.btnGenerateDaily.Location = new System.Drawing.Point(642, 350);
            this.btnGenerateDaily.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerateDaily.Name = "btnGenerateDaily";
            this.btnGenerateDaily.Size = new System.Drawing.Size(246, 31);
            this.btnGenerateDaily.TabIndex = 7;
            this.btnGenerateDaily.Text = "Generate for DAILY attendance";
            this.btnGenerateDaily.UseVisualStyleBackColor = true;
            this.btnGenerateDaily.Click += new System.EventHandler(this.btnGenerateDaily_Click);
            // 
            // drpMonth
            // 
            this.drpMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpMonth.Enabled = false;
            this.drpMonth.FormattingEnabled = true;
            this.drpMonth.Location = new System.Drawing.Point(85, 19);
            this.drpMonth.Name = "drpMonth";
            this.drpMonth.Size = new System.Drawing.Size(155, 21);
            this.drpMonth.TabIndex = 5;
            // 
            // drpYear
            // 
            this.drpYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpYear.Enabled = false;
            this.drpYear.FormattingEnabled = true;
            this.drpYear.Location = new System.Drawing.Point(85, 46);
            this.drpYear.Name = "drpYear";
            this.drpYear.Size = new System.Drawing.Size(155, 21);
            this.drpYear.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Month";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Schools";
            // 
            // txtDistrictDAN
            // 
            this.txtDistrictDAN.Enabled = false;
            this.txtDistrictDAN.Location = new System.Drawing.Point(106, 13);
            this.txtDistrictDAN.Name = "txtDistrictDAN";
            this.txtDistrictDAN.Size = new System.Drawing.Size(133, 20);
            this.txtDistrictDAN.TabIndex = 1;
            this.txtDistrictDAN.TextChanged += new System.EventHandler(this.txtDistrictDAN_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "District DAN";
            // 
            // txtDistrictPrefix
            // 
            this.txtDistrictPrefix.Enabled = false;
            this.txtDistrictPrefix.Location = new System.Drawing.Point(106, 54);
            this.txtDistrictPrefix.Name = "txtDistrictPrefix";
            this.txtDistrictPrefix.Size = new System.Drawing.Size(133, 20);
            this.txtDistrictPrefix.TabIndex = 2;
            this.txtDistrictPrefix.TextChanged += new System.EventHandler(this.txtDistrictPrefix_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "District file prefix";
            // 
            // btnRetryLoadDistricts
            // 
            this.btnRetryLoadDistricts.Location = new System.Drawing.Point(5, 378);
            this.btnRetryLoadDistricts.Name = "btnRetryLoadDistricts";
            this.btnRetryLoadDistricts.Size = new System.Drawing.Size(237, 23);
            this.btnRetryLoadDistricts.TabIndex = 10;
            this.btnRetryLoadDistricts.Text = "Refresh";
            this.btnRetryLoadDistricts.UseVisualStyleBackColor = true;
            this.btnRetryLoadDistricts.Click += new System.EventHandler(this.btnRetryLoadDistricts_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 57);
            this.label7.MaximumSize = new System.Drawing.Size(240, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 26);
            this.label7.TabIndex = 19;
            this.label7.Text = "The file prefix was sent to your school division by SaskLearning in early May via" +
    " E-Mail.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drpMonth);
            this.groupBox1.Controls.Add(this.drpYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(642, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 81);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDistrictDAN);
            this.groupBox2.Controls.Add(this.txtDistrictPrefix);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(15, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 90);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "District numbers";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Step 1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(318, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Step 2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 25);
            this.label10.MaximumSize = new System.Drawing.Size(250, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(249, 26);
            this.label10.TabIndex = 24;
            this.label10.Text = "Fill in the DAN and file prefix for your school division below.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(637, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Step 3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(320, 25);
            this.label12.MaximumSize = new System.Drawing.Size(250, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(250, 39);
            this.label12.TabIndex = 26;
            this.label12.Text = "Select your school division from the list, and ensure that the schools that you w" +
    "ish to be included in the report are checked in the list below.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.drpDistricts);
            this.groupBox3.Controls.Add(this.lstSchools);
            this.groupBox3.Controls.Add(this.btnRetryLoadDistricts);
            this.groupBox3.Location = new System.Drawing.Point(323, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 408);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "School selection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 74);
            this.label3.MaximumSize = new System.Drawing.Size(250, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 26);
            this.label3.TabIndex = 28;
            this.label3.Text = "If no school divisions or schools show in the lists, you may have to press the \"R" +
    "efresh\" button below.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(639, 25);
            this.label13.MaximumSize = new System.Drawing.Size(250, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(249, 26);
            this.label13.TabIndex = 29;
            this.label13.Text = "Select the month and year for the report, and press one of the buttons to generat" +
    "e a report.";
            // 
            // stsStatusBar
            // 
            this.stsStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgProgressBar,
            this.lblStatus});
            this.stsStatusBar.Location = new System.Drawing.Point(0, 617);
            this.stsStatusBar.Name = "stsStatusBar";
            this.stsStatusBar.Size = new System.Drawing.Size(920, 22);
            this.stsStatusBar.SizingGrip = false;
            this.stsStatusBar.TabIndex = 30;
            this.stsStatusBar.Text = "statusStrip1";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuConfigureDatabase});
            this.menuItem1.Text = "Configure";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAbout});
            this.menuItem2.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Index = 0;
            this.mnuAbout.Text = "About this utility";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuConfigureDatabase
            // 
            this.mnuConfigureDatabase.Index = 0;
            this.mnuConfigureDatabase.Text = "Database Configuration";
            this.mnuConfigureDatabase.Click += new System.EventHandler(this.mnuConfigureDatabase_Click);
            // 
            // prgProgressBar
            // 
            this.prgProgressBar.Name = "prgProgressBar";
            this.prgProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 639);
            this.Controls.Add(this.stsStatusBar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGenerateDaily);
            this.Controls.Add(this.btnGeneratePeriod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SaskLearning Attendance Report Generator for SchoolLogic, created by Mark Strendi" +
    "n (mark.strendin@lskysd.ca)";
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.stsStatusBar.ResumeLayout(false);
            this.stsStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox drpDistricts;
        private System.Windows.Forms.CheckedListBox lstSchools;
        private System.Windows.Forms.Button btnGeneratePeriod;
        private System.Windows.Forms.Button btnGenerateDaily;
        private System.Windows.Forms.ComboBox drpMonth;
        private System.Windows.Forms.ComboBox drpYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDistrictDAN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDistrictPrefix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRetryLoadDistricts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.StatusStrip stsStatusBar;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuConfigureDatabase;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.ToolStripProgressBar prgProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}