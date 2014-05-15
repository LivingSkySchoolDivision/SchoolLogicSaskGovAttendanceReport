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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.drpDistricts = new System.Windows.Forms.ComboBox();
            this.lstSchools = new System.Windows.Forms.CheckedListBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.btnGeneratePeriod = new System.Windows.Forms.Button();
            this.btnGenerateDaily = new System.Windows.Forms.Button();
            this.prgProgressBar = new System.Windows.Forms.ProgressBar();
            this.drpMonth = new System.Windows.Forms.ComboBox();
            this.drpYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDistrictDAN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDistrictPrefix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConfigDatabase = new System.Windows.Forms.Button();
            this.btnRetryLoadDistricts = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drpDistricts
            // 
            this.drpDistricts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpDistricts.FormattingEnabled = true;
            this.drpDistricts.Location = new System.Drawing.Point(8, 24);
            this.drpDistricts.Margin = new System.Windows.Forms.Padding(2);
            this.drpDistricts.Name = "drpDistricts";
            this.drpDistricts.Size = new System.Drawing.Size(225, 21);
            this.drpDistricts.TabIndex = 0;
            this.drpDistricts.SelectedValueChanged += new System.EventHandler(this.drpDistricts_SelectedValueChanged);
            // 
            // lstSchools
            // 
            this.lstSchools.CheckOnClick = true;
            this.lstSchools.Enabled = false;
            this.lstSchools.FormattingEnabled = true;
            this.lstSchools.Location = new System.Drawing.Point(6, 74);
            this.lstSchools.Margin = new System.Windows.Forms.Padding(2);
            this.lstSchools.Name = "lstSchools";
            this.lstSchools.Size = new System.Drawing.Size(225, 319);
            this.lstSchools.TabIndex = 1;
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.ForeColor = System.Drawing.Color.DimGray;
            this.lblAbout.Location = new System.Drawing.Point(3, 458);
            this.lblAbout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(397, 13);
            this.lblAbout.TabIndex = 2;
            this.lblAbout.Text = "Created by Mark Strendin (mark.strendin@lskysd.ca) for Living Sky School Division" +
    "";
            // 
            // btnGeneratePeriod
            // 
            this.btnGeneratePeriod.Enabled = false;
            this.btnGeneratePeriod.Location = new System.Drawing.Point(256, 362);
            this.btnGeneratePeriod.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeneratePeriod.Name = "btnGeneratePeriod";
            this.btnGeneratePeriod.Size = new System.Drawing.Size(209, 31);
            this.btnGeneratePeriod.TabIndex = 3;
            this.btnGeneratePeriod.Text = "Generate for PERIOD attendance";
            this.btnGeneratePeriod.UseVisualStyleBackColor = true;
            this.btnGeneratePeriod.Click += new System.EventHandler(this.btnGeneratePeriod_Click);
            // 
            // btnGenerateDaily
            // 
            this.btnGenerateDaily.Enabled = false;
            this.btnGenerateDaily.Location = new System.Drawing.Point(256, 327);
            this.btnGenerateDaily.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerateDaily.Name = "btnGenerateDaily";
            this.btnGenerateDaily.Size = new System.Drawing.Size(209, 31);
            this.btnGenerateDaily.TabIndex = 4;
            this.btnGenerateDaily.Text = "Generate for DAILY attendance";
            this.btnGenerateDaily.UseVisualStyleBackColor = true;
            this.btnGenerateDaily.Click += new System.EventHandler(this.btnGenerateDaily_Click);
            // 
            // prgProgressBar
            // 
            this.prgProgressBar.Location = new System.Drawing.Point(245, 413);
            this.prgProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.prgProgressBar.Name = "prgProgressBar";
            this.prgProgressBar.Size = new System.Drawing.Size(230, 21);
            this.prgProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgProgressBar.TabIndex = 5;
            this.prgProgressBar.Visible = false;
            // 
            // drpMonth
            // 
            this.drpMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpMonth.Enabled = false;
            this.drpMonth.FormattingEnabled = true;
            this.drpMonth.Location = new System.Drawing.Point(71, 19);
            this.drpMonth.Name = "drpMonth";
            this.drpMonth.Size = new System.Drawing.Size(132, 21);
            this.drpMonth.TabIndex = 6;
            // 
            // drpYear
            // 
            this.drpYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpYear.Enabled = false;
            this.drpYear.FormattingEnabled = true;
            this.drpYear.Location = new System.Drawing.Point(71, 46);
            this.drpYear.Name = "drpYear";
            this.drpYear.Size = new System.Drawing.Size(132, 21);
            this.drpYear.TabIndex = 7;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "School District";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Schools";
            // 
            // txtDistrictDAN
            // 
            this.txtDistrictDAN.Enabled = false;
            this.txtDistrictDAN.Location = new System.Drawing.Point(342, 74);
            this.txtDistrictDAN.Name = "txtDistrictDAN";
            this.txtDistrictDAN.Size = new System.Drawing.Size(123, 20);
            this.txtDistrictDAN.TabIndex = 12;
            this.txtDistrictDAN.TextChanged += new System.EventHandler(this.txtDistrictDAN_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "District DAN";
            // 
            // txtDistrictPrefix
            // 
            this.txtDistrictPrefix.Enabled = false;
            this.txtDistrictPrefix.Location = new System.Drawing.Point(342, 115);
            this.txtDistrictPrefix.Name = "txtDistrictPrefix";
            this.txtDistrictPrefix.Size = new System.Drawing.Size(123, 20);
            this.txtDistrictPrefix.TabIndex = 14;
            this.txtDistrictPrefix.TextChanged += new System.EventHandler(this.txtDistrictPrefix_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "District file prefix*";
            // 
            // btnConfigDatabase
            // 
            this.btnConfigDatabase.Location = new System.Drawing.Point(6, 413);
            this.btnConfigDatabase.Name = "btnConfigDatabase";
            this.btnConfigDatabase.Size = new System.Drawing.Size(199, 23);
            this.btnConfigDatabase.TabIndex = 16;
            this.btnConfigDatabase.Text = "Configure Database Connection";
            this.btnConfigDatabase.UseVisualStyleBackColor = true;
            this.btnConfigDatabase.Click += new System.EventHandler(this.btnConfigDatabase_Click);
            // 
            // btnRetryLoadDistricts
            // 
            this.btnRetryLoadDistricts.Location = new System.Drawing.Point(245, 24);
            this.btnRetryLoadDistricts.Name = "btnRetryLoadDistricts";
            this.btnRetryLoadDistricts.Size = new System.Drawing.Size(201, 23);
            this.btnRetryLoadDistricts.TabIndex = 17;
            this.btnRetryLoadDistricts.Text = "Retry connection";
            this.btnRetryLoadDistricts.UseVisualStyleBackColor = true;
            this.btnRetryLoadDistricts.Click += new System.EventHandler(this.btnRetryLoadDistricts_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(242, 398);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(22, 13);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "     ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 138);
            this.label7.MaximumSize = new System.Drawing.Size(240, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 26);
            this.label7.TabIndex = 19;
            this.label7.Text = "*The correct file prefix for your school division was sent to your division by Sa" +
    "skLearning";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drpMonth);
            this.groupBox1.Controls.Add(this.drpYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(256, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 81);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report date";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 480);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRetryLoadDistricts);
            this.Controls.Add(this.btnConfigDatabase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDistrictPrefix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDistrictDAN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prgProgressBar);
            this.Controls.Add(this.btnGenerateDaily);
            this.Controls.Add(this.btnGeneratePeriod);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.lstSchools);
            this.Controls.Add(this.drpDistricts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SaskLearning Attendance Report Generator for SchoolLogic";
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox drpDistricts;
        private System.Windows.Forms.CheckedListBox lstSchools;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Button btnGeneratePeriod;
        private System.Windows.Forms.Button btnGenerateDaily;
        private System.Windows.Forms.ProgressBar prgProgressBar;
        private System.Windows.Forms.ComboBox drpMonth;
        private System.Windows.Forms.ComboBox drpYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDistrictDAN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDistrictPrefix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConfigDatabase;
        private System.Windows.Forms.Button btnRetryLoadDistricts;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}