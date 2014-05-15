using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LSKYSLData;

namespace SKGovAtt
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            btnRetryLoadDistricts.Enabled = false;

            // Populate the list of years and months
            drpYear.Items.Clear();
            drpMonth.Items.Clear();
            for (int year = DateTime.Now.Year + 1; year >= DateTime.Now.Year - 1; year--)
            {
                drpYear.Items.Add(year);
            }
            drpYear.SelectedIndex = 1;

            for (int month = 1; month <= 12; month++)
            {
                drpMonth.Items.Add(Helpers.GetMonthName(month));
            }
            drpMonth.SelectedIndex = DateTime.Now.Month - 1;

            // Check if the config file has valid data in it, and if not, display the config screen
            if (AppConfiguration.IsFirstRun())
            {
                MessageBox.Show("First run detected - The database connection configuration window will now appear",
                    "First Run", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayRetryButton();
                ShowDatabaseConfigWindow();
            }
            else
            {
                // Load info from the config file
                txtDistrictPrefix.Text = AppConfiguration.GetDivisionPrefix();
                txtDistrictDAN.Text = AppConfiguration.GetDivisionDAN();
                txtDistrictDAN.Enabled = true;
                txtDistrictPrefix.Enabled = true;

                // Load the list of school districts
                drpDistricts.Items.Clear();
                drpDistricts.Items.Add("Loading...");
                drpDistricts.SelectedIndex = 0;
                drpDistricts.Enabled = false;

                // Do this in a background thread so we don't hang the UI
                BackgroundWorker backgroundThread = new BackgroundWorker();
                backgroundThread.DoWork += new DoWorkEventHandler(LoadSchoolDistricts);
                backgroundThread.RunWorkerAsync();
            }
        }

        #region General UI Helper methods

        private void DisableControls()
        {
            drpDistricts.Items.Clear();
            lstSchools.Items.Clear();
            btnGenerateDaily.Enabled = false;
            btnGeneratePeriod.Enabled = false;
            drpMonth.Enabled = false;
            drpYear.Enabled = false;
        }

        private void EnableControls()
        {
            btnGenerateDaily.Enabled = true;
            btnGeneratePeriod.Enabled = true;
            drpMonth.Enabled = true;
            drpYear.Enabled = true;
            lstSchools.Enabled = true;
            txtDistrictDAN.Enabled = true;
            txtDistrictPrefix.Enabled = true;
        }

        private static void ShowDatabaseConfigWindow()
        {
            DatabaseConnectionConfig configWindow = new DatabaseConnectionConfig();
            configWindow.Show();
        }

        private void DisplayRetryButton()
        {
            btnRetryLoadDistricts.Visible = true;
            btnRetryLoadDistricts.Enabled = true;
        }

        private void UpdateProgressBar(int value, int max)
        {
            if (prgProgressBar.InvokeRequired)
            {
                prgProgressBar.BeginInvoke((MethodInvoker) delegate {
                    prgProgressBar.Maximum = max;
                    prgProgressBar.Value = value;
                });
            }
            else
            {
                prgProgressBar.Maximum = max;
                prgProgressBar.Value = value;
            }
        }

        private void UpdateStatusBar(string message)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.BeginInvoke((MethodInvoker) delegate {
                    lblStatus.Text = message;
                    lblStatus.Refresh();
                });
                
            }
            else
            {
                lblStatus.Text = message;
                lblStatus.Refresh();
            }
        }

        #endregion

        // This is static so that methods can check if data has been successfully loaded from the database,
        // specifically the dropdown list on-selected-change (so that it doesn't crash when I add an invalid item 
        // to the list to indicate that it's loading)        
        List<SchoolDistrict> AllDistricts = new List<SchoolDistrict>();

        private void LoadSchoolDistricts(object sender, DoWorkEventArgs e)
        {
            // Load the list of districts
            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.GetConnectionString()))
                {
                    AllDistricts = SchoolDistrict.LoadAll(connection);
                }

                if (AllDistricts.Count > 0)
                {
                    drpDistricts.BeginInvoke((MethodInvoker)delegate
                    {
                        drpDistricts.Items.Clear();
                        drpDistricts.Enabled = true;
                        foreach (SchoolDistrict sd in AllDistricts)
                        {
                            drpDistricts.Items.Add(sd);
                        }
                        drpDistricts.SelectedIndex = 0;
                        EnableControls();
                    });
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to connect to database: " + ex.Message, "Database connection error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Invoke(new Action(ShowDatabaseConfigWindow));
                this.Invoke(new Action(DisplayRetryButton));
            }
        }

        private void GenerateAndSaveReport(bool IsDaily)
        {
            // Figure out what the "group" should be
            string fileNameGroup = "EM";
            if (IsDaily)
            {
                fileNameGroup = "Sec";
            }

            // Parse the selected month and year
            int selectedYear = (int) drpYear.SelectedItem;
            int selectedMonth = Helpers.GetMonthNumber((string) drpMonth.SelectedItem);

            DateTime dateFrom = new DateTime(selectedYear, selectedMonth, 1);
            DateTime dateTo = new DateTime(selectedYear, selectedMonth,
                DateTime.DaysInMonth(selectedYear, selectedMonth));

            // Generate a filename that we expect the user to save as
            string expectedFileName = AppConfiguration.GetDivisionPrefix() + "_" + fileNameGroup + "_" +
                                      Helpers.GetMonthName(selectedMonth).ToUpper().Substring(0, 3) + ".xlsx";

            // Check if the DAN and Prefix are set

            // Prompt for a file name to save
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "Excel Worksheet|*.xlsx";
                saveFileDialog1.Title = "Select a filename for the output file";
                saveFileDialog1.FileName = expectedFileName;
                DialogResult result = saveFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                    {
                        prgProgressBar.Style = ProgressBarStyle.Blocks;
                        prgProgressBar.Visible = true;

                        // Do heavy lifting in a background thread so that we don't block the UI
                        Task backgroundTask = Task.Factory.StartNew(() => {
                            // Get a list of all selected items
                            List<School> selectedSchools = new List<School>();
                            foreach (object obj in lstSchools.CheckedItems)
                            {
                                if (obj.GetType() == typeof(School))
                                {
                                    selectedSchools.Add((School)obj);
                                }
                            }

                            // Progress bar:
                            //  Get a count of students before loading any actual data
                            //  Load students data, and after each, progress the progress bar a little more

                            prgProgressBar.BeginInvoke((MethodInvoker) delegate
                            {
                                prgProgressBar.Maximum = selectedSchools.Count;
                                prgProgressBar.Value = 0;
                            });

                            // Disable generate buttons
                            btnGenerateDaily.BeginInvoke((MethodInvoker) delegate
                            {
                                btnGenerateDaily.Enabled = false;
                                btnGeneratePeriod.Enabled = false;
                            });

                            // Load students for selected schools
                            int studentTotalCount = 0;
                            Dictionary<School, List<Student>> studentsBySchool = new Dictionary<School, List<Student>>();
                            using (SqlConnection connection = new SqlConnection(AppConfiguration.GetConnectionString()))
                            {
                                int schoolCounter = 0;
                                foreach (School school in selectedSchools)
                                {
                                    if (!studentsBySchool.ContainsKey(school))
                                    {
                                        studentsBySchool.Add(school, new List<Student>());
                                    }

                                    UpdateStatusBar("Loading student list (" + schoolCounter + "/" + selectedSchools.Count +
                                                     ")");
                                    if (IsDaily)
                                    {
                                        studentsBySchool[school].AddRange(
                                            Student.LoadForSchool(connection, school, dateFrom, dateTo)
                                                .Where(c => c.Track.IsDailyAttendance == true)
                                                .ToList());
                                    }
                                    else
                                    {
                                        studentsBySchool[school].AddRange(
                                            Student.LoadForSchool(connection, school, dateFrom, dateTo)
                                                .Where(c => c.Track.IsDailyAttendance == false)
                                                .ToList());
                                    }
                                    schoolCounter++;
                                    prgProgressBar.BeginInvoke((MethodInvoker) delegate
                                    {
                                        prgProgressBar.Value = schoolCounter;
                                    });
                                    studentTotalCount += studentsBySchool[school].Count;
                                }

                                prgProgressBar.BeginInvoke((MethodInvoker) delegate
                                {
                                    prgProgressBar.Maximum = studentTotalCount;
                                    prgProgressBar.Value = 0;
                                });

                                int studentCounter = 0;
                                foreach (School school in selectedSchools)
                                {
                                    foreach (Student student in studentsBySchool[school])
                                    {
                                        UpdateStatusBar("Loading student data (" + studentCounter + "/" + studentTotalCount +
                                                         ")");
                                        student.Attendance = new StudentAttendance(connection, student, student.School,
                                            dateFrom,
                                            dateTo);
                                        student.Schedule = new StudentSchedule(connection, student);
                                        studentCounter++;
                                        prgProgressBar.BeginInvoke((MethodInvoker) delegate
                                        {
                                            prgProgressBar.Value = studentCounter;
                                        });
                                    }
                                }
                            }

                            // Generate the report
                            UpdateStatusBar("Generating file...");
                            prgProgressBar.BeginInvoke((MethodInvoker) delegate
                            {
                                prgProgressBar.Style = ProgressBarStyle.Marquee;
                                prgProgressBar.Maximum = 2;
                                prgProgressBar.Value = 1;
                            });

                            MemoryStream outputFileContents = new MemoryStream();
                            if (IsDaily)
                            {
                                outputFileContents = XLSXGenerator.GenerateXLSX_Daily(studentsBySchool, dateFrom, dateTo,
                                    AppConfiguration.GetDivisionDAN());
                            }
                            else
                            {
                                outputFileContents = XLSXGenerator.GenerateXLSX_Period(studentsBySchool, dateFrom, dateTo,
                                    AppConfiguration.GetDivisionDAN());
                            }

                            // Save the report
                            if (outputFileContents.Length > 0)
                            {
                                UpdateStatusBar("Writing file to disk...");

                                try
                                {
                                    using (
                                        FileStream outputFile = new FileStream(saveFileDialog1.FileName, FileMode.Create,
                                            FileAccess.Write))
                                    {
                                        outputFile.Write(outputFileContents.GetBuffer(), 0, (int)outputFileContents.Length);
                                    }

                                    MessageBox.Show("File saved!", "File Saved", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                    prgProgressBar.BeginInvoke((MethodInvoker)delegate
                                    {
                                        prgProgressBar.Visible = false;
                                    });
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to save file: " + ex.Message, "File save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                
                                UpdateStatusBar("");
                                btnGenerateDaily.BeginInvoke((MethodInvoker)delegate
                                {
                                    btnGenerateDaily.Enabled = true;
                                    btnGeneratePeriod.Enabled = true;
                                });
                            }
                            else
                            {
                                MessageBox.Show("Output file would be empty! Skipping file save", "File save error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        });

                        
                    }
                    else
                    {
                        MessageBox.Show("No filename entered - no report generated");
                    }
                }

            }
        }
    

        private void drpDistricts_SelectedValueChanged(object sender, EventArgs e)
        {
            // Load the schools from the selected district
            if (AllDistricts.Count > 0)
            {
                if (drpDistricts.SelectedItem != null)
                {
                    if (drpDistricts.SelectedItem.GetType() == typeof(SchoolDistrict))
                    {
                        List<School> DistrictSchools = new List<School>();

                        SchoolDistrict selectedSchoolDistrict = drpDistricts.SelectedItem as SchoolDistrict;

                        using (SqlConnection connection = new SqlConnection(AppConfiguration.GetConnectionString()))
                        {
                            DistrictSchools = School.LoadAll(connection, selectedSchoolDistrict);
                        }

                        lstSchools.Items.Clear();
                        foreach (School school in DistrictSchools)
                        {
                            lstSchools.Items.Add(school);
                        }

                        for (int i = 0; i < lstSchools.Items.Count; i++)
                        {
                            lstSchools.SetItemChecked(i, true);
                        }

                        if (DistrictSchools.Count > 0)
                        {
                            EnableControls();
                        }
                        else
                        {
                            DisableControls();
                        }
                    }
                }
            }
        }

        private void btnGenerateDaily_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateAndSaveReport(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeneratePeriod_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateAndSaveReport(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfigDatabase_Click(object sender, EventArgs e)
        {
            DisableControls();
            ShowDatabaseConfigWindow();
        }

        private void btnRetryLoadDistricts_Click(object sender, EventArgs e)
        {
            MainWindow_Shown(sender, e);
        }

        private void txtDistrictPrefix_TextChanged(object sender, EventArgs e)
        {
            AppConfiguration.SetDivisionPrefix(txtDistrictPrefix.Text);
        }

        private void txtDistrictDAN_TextChanged(object sender, EventArgs e)
        {
            AppConfiguration.SetDivisionDAN(txtDistrictDAN.Text);
        }
        
    }
}
