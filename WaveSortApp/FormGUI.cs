using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WaveSortApp
{
    public partial class FormGUI : Form
    {
        private readonly Dictionary<string, double> fileNameAmplitudeDictionary = new Dictionary<string, double>();
        private readonly Dictionary<string, double> fileNameAmplitudeSortedDictionary = new Dictionary<string, double>();
        private string[] fileNames;

        public FormGUI()
        {
            InitializeComponent();
        }

        private void FormGUI_Load(object sender, EventArgs e)
        {
            //chart title  
            amplitudeChart.Titles.Add("Volt Amplitude Per File");

            //Clear workspace
            Reset();
        }

        private void LoadCSVFilesButton_Click(object sender, EventArgs e)
        {
            //Clear workspace
            Reset();

            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                fileNames = openFileDialog.FileNames;

                //Update textbox text
                PrintTextBox("Loading.....");

                if (fileNames != null)
                {
                    //Set progress bar values
                    progressBar.Value = 0;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = 100;

                    //Clear dictionary
                    fileNameAmplitudeDictionary.Clear();

                    //Extract amplitude and save to Dictionary
                    foreach (string fileName in fileNames)
                    {
                        try
                        {
                            //Extract amplitude from file
                            double amplitude = GetAmplitude(fileName);

                            //Add filename and amplitude to a dictionary
                            AddDataToDictionary(fileName, amplitude);

                            //Update progress bar
                            progressBar.Value = (Array.IndexOf(openFileDialog.FileNames, fileName) + 1) * 100 / openFileDialog.FileNames.Length;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "GUI Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    //Update textbox text
                    PrintTextBox("Loading Error!");
                }

                //Update textbox text
                PrintTextBox("Loading Complete.");

                //Enable sort button
                sortVoltageAmplitude.Enabled = true;
            }
        }

        private void SortVoltageAmplitude_Click(object sender, EventArgs e)
        {
            //Set progress bar values and loop tracker
            int loopTracker = 0;
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;

            //Clear dictionary
            fileNameAmplitudeSortedDictionary.Clear();

            //Clear Chart
            amplitudeChart.Series["Volts"].Points.Clear();

            //Update textbox text
            PrintTextBox("Sorting....");

            if (fileNameAmplitudeDictionary != null)
            {
                foreach (KeyValuePair<string, double> entry in fileNameAmplitudeDictionary.OrderBy(key => key.Value))
                {
                    //Add filename and amplitude to a dictionary
                    AddDataToSortedDictionary(entry.Key, entry.Value );

                   //Chart visualization
                    AddDataToChart(entry.Key, entry.Value);

                    //Update progress bar
                    progressBar.Value = (loopTracker + 1) * 100 / fileNameAmplitudeDictionary.Count;
                    loopTracker++;
                }
            }
            else
            {
                //Update textbox text
                PrintTextBox("Sorting Error!");
            }

            //Show chart
            amplitudeChart.Visible = true;
            dataGridView.Visible = false;

            //Enable download button
            downloadCSVFileButton.Enabled = true;

            //Update textbox text
            PrintTextBox("Sorting Complete.");
        }

        private void DownloadCSVFile_Click(object sender, EventArgs e)
        {
            if (fileNameAmplitudeDictionary!= null)
            {
                string [] headerNames = { "File name", "Volt Amplitude" };

                //Acquire string values of CSV file
                string csvHeader = string.Join(",", headerNames);
                string csvRows = string.Join(Environment.NewLine, fileNameAmplitudeSortedDictionary.Select(d => $"{d.Key},{d.Value},"));
                string csv = string.Concat(csvHeader, ",", Environment.NewLine, csvRows);

                //Acquire filepath
                string fileFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileSavePath = fileFolder + "/SortedWave.csv";

                //Write to CSV file
                try
                {
                    File.WriteAllText(fileSavePath, csv);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "GUI Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //Update textbox text
                PrintTextBox("Download complete. CSV file located in the \"Documents\" folder.");
            }
            else
            {
                //Update textbox text
                PrintTextBox("Download Error!");
            }
        }

        private void Reset()
        {
            //Display datagridview to create a nice canvas over the UI.
            dataGridView.Visible = true;

            // Set dialog box filter, check path and check file settings.
            openFileDialog.Filter = "CSV Files | *.csv";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            //Set the Dialog box to multi-select.
            openFileDialog.Multiselect = true;

            //Disable selected buttons
            downloadCSVFileButton.Enabled = false;
            sortVoltageAmplitude.Enabled = false;

            //Textbox initial text
            textFilePath.Text = "No Files Added.";

            //Hide selected items
            textFilePath.Enabled = false;
            amplitudeChart.Visible = false;
        }

        private double GetAmplitude(string fileName)
        {
            //Read text all text in file
            string[] lines = File.ReadAllLines(fileName);

            //Get header labels
            string[] headerLabels = lines[0].Split(',');
            int voltsIndex = Array.IndexOf(headerLabels, "Volts");

            //List to store volts values
            List<double> volts = new List<double>();

            if (lines.Length > 0)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    //Obtaining string in cells of the row and adding volts to the volt list
                    string[] dataWords = lines[i].Split(',');
                    volts.Add(Convert.ToDouble(dataWords[voltsIndex]));
                }
            }

            return (double)volts.Max();
        }

        private void AddDataToDictionary(string fileName, double amplitude)
        {
            //Add values to dictionary
            fileNameAmplitudeDictionary.Add(Path.GetFileName(fileName), amplitude);
        }

        private void AddDataToSortedDictionary(string key, double value)
        {
            //Add values to sorted dictionary
            fileNameAmplitudeSortedDictionary.Add(key, value);
        }

        private void AddDataToChart(string key, double value)
        {
            //AddXY value in chart in series  
            amplitudeChart.Series["Volts"].Points.AddXY(key, value);
        }

        private void PrintTextBox(string text)
        {
            //Update textbox text
            textFilePath.Text = text;
            Application.DoEvents();
            Thread.Sleep(1000);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Are you sure you want to exit?", "GUI Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
