namespace WaveSortApp
{
    partial class FormGUI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGUI));
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.loadCSVFilesButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.exitButton = new System.Windows.Forms.Button();
            this.downloadCSVFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.amplitudeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sortVoltageAmplitude = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textFilePath
            // 
            this.textFilePath.Location = new System.Drawing.Point(14, 377);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(311, 20);
            this.textFilePath.TabIndex = 0;
            // 
            // loadCSVFilesButton
            // 
            this.loadCSVFilesButton.Location = new System.Drawing.Point(341, 374);
            this.loadCSVFilesButton.Name = "loadCSVFilesButton";
            this.loadCSVFilesButton.Size = new System.Drawing.Size(103, 23);
            this.loadCSVFilesButton.TabIndex = 7;
            this.loadCSVFilesButton.Text = "Load CSV Files";
            this.loadCSVFilesButton.UseVisualStyleBackColor = true;
            this.loadCSVFilesButton.Click += new System.EventHandler(this.LoadCSVFilesButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 415);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(772, 23);
            this.progressBar.TabIndex = 2;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(698, 374);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(86, 23);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // downloadCSVFileButton
            // 
            this.downloadCSVFileButton.Location = new System.Drawing.Point(579, 374);
            this.downloadCSVFileButton.Name = "downloadCSVFileButton";
            this.downloadCSVFileButton.Size = new System.Drawing.Size(103, 23);
            this.downloadCSVFileButton.TabIndex = 5;
            this.downloadCSVFileButton.Text = "Download CSV";
            this.downloadCSVFileButton.UseVisualStyleBackColor = true;
            this.downloadCSVFileButton.Click += new System.EventHandler(this.DownloadCSVFile_Click);
            // 
            // amplitudeChart
            // 
            this.amplitudeChart.BorderlineColor = System.Drawing.Color.Black;
            this.amplitudeChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.amplitudeChart.BorderSkin.BackColor = System.Drawing.SystemColors.GrayText;
            this.amplitudeChart.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.amplitudeChart.BorderSkin.BorderWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.amplitudeChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.amplitudeChart.Legends.Add(legend1);
            this.amplitudeChart.Location = new System.Drawing.Point(14, 12);
            this.amplitudeChart.Name = "amplitudeChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Volts";
            this.amplitudeChart.Series.Add(series1);
            this.amplitudeChart.Size = new System.Drawing.Size(772, 341);
            this.amplitudeChart.TabIndex = 1;
            this.amplitudeChart.Text = "Amplitude Chart";
            // 
            // sortVoltageAmplitude
            // 
            this.sortVoltageAmplitude.Location = new System.Drawing.Point(460, 374);
            this.sortVoltageAmplitude.Name = "sortVoltageAmplitude";
            this.sortVoltageAmplitude.Size = new System.Drawing.Size(103, 23);
            this.sortVoltageAmplitude.TabIndex = 8;
            this.sortVoltageAmplitude.Text = "Sort Amplitude";
            this.sortVoltageAmplitude.UseVisualStyleBackColor = true;
            this.sortVoltageAmplitude.Click += new System.EventHandler(this.SortVoltageAmplitude_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(14, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(772, 341);
            this.dataGridView.TabIndex = 9;
            // 
            // FormGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.sortVoltageAmplitude);
            this.Controls.Add(this.amplitudeChart);
            this.Controls.Add(this.downloadCSVFileButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.loadCSVFilesButton);
            this.Controls.Add(this.textFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormGUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGUI";
            this.Load += new System.EventHandler(this.FormGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.Button loadCSVFilesButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button downloadCSVFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataVisualization.Charting.Chart amplitudeChart;
        private System.Windows.Forms.Button sortVoltageAmplitude;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

