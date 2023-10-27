
namespace RocCurveVisualizer
{
    partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.InitialDataTable = new System.Windows.Forms.DataGridView();
            this.ColumnsCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfusionMatrixesFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TprFprDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.DataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.InitialDataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsCountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TprFprDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // InitialDataTable
            // 
            this.InitialDataTable.AllowUserToAddRows = false;
            this.InitialDataTable.AllowUserToDeleteRows = false;
            this.InitialDataTable.AllowUserToResizeColumns = false;
            this.InitialDataTable.AllowUserToResizeRows = false;
            this.InitialDataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InitialDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InitialDataTable.EnableHeadersVisualStyles = false;
            this.InitialDataTable.Location = new System.Drawing.Point(10, 10);
            this.InitialDataTable.MultiSelect = false;
            this.InitialDataTable.Name = "InitialDataTable";
            this.InitialDataTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.InitialDataTable.RowTemplate.Height = 25;
            this.InitialDataTable.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.InitialDataTable.Size = new System.Drawing.Size(953, 92);
            this.InitialDataTable.TabIndex = 0;
            // 
            // ColumnsCountNumeric
            // 
            this.ColumnsCountNumeric.Location = new System.Drawing.Point(49, 110);
            this.ColumnsCountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ColumnsCountNumeric.Name = "ColumnsCountNumeric";
            this.ColumnsCountNumeric.Size = new System.Drawing.Size(62, 20);
            this.ColumnsCountNumeric.TabIndex = 1;
            this.ColumnsCountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ColumnsCountNumeric.ValueChanged += new System.EventHandler(this.ColumnsCountNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "P (N)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "Fill with default data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(269, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(282, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 84);
            this.button3.TabIndex = 5;
            this.button3.Text = "Calculate and generate plot";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(969, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Confusion matrixes (N + 1)";
            // 
            // ConfusionMatrixesFlowPanel
            // 
            this.ConfusionMatrixesFlowPanel.AutoScroll = true;
            this.ConfusionMatrixesFlowPanel.Location = new System.Drawing.Point(969, 30);
            this.ConfusionMatrixesFlowPanel.Name = "ConfusionMatrixesFlowPanel";
            this.ConfusionMatrixesFlowPanel.Size = new System.Drawing.Size(229, 528);
            this.ConfusionMatrixesFlowPanel.TabIndex = 8;
            // 
            // TprFprDataGridView
            // 
            this.TprFprDataGridView.AllowUserToAddRows = false;
            this.TprFprDataGridView.AllowUserToDeleteRows = false;
            this.TprFprDataGridView.AllowUserToResizeColumns = false;
            this.TprFprDataGridView.AllowUserToResizeRows = false;
            this.TprFprDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TprFprDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TprFprDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.TprFprDataGridView.EnableHeadersVisualStyles = false;
            this.TprFprDataGridView.Location = new System.Drawing.Point(621, 133);
            this.TprFprDataGridView.MultiSelect = false;
            this.TprFprDataGridView.Name = "TprFprDataGridView";
            this.TprFprDataGridView.ReadOnly = true;
            this.TprFprDataGridView.RowHeadersWidth = 70;
            this.TprFprDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.TprFprDataGridView.RowTemplate.Height = 25;
            this.TprFprDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TprFprDataGridView.ShowEditingIcon = false;
            this.TprFprDataGridView.Size = new System.Drawing.Size(342, 423);
            this.TprFprDataGridView.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(621, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "TPR/FPR (N + 1)";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 138);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(269, 24);
            this.button4.TabIndex = 11;
            this.button4.Text = "Generate OB sequence";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(399, 109);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(214, 24);
            this.button5.TabIndex = 12;
            this.button5.Text = "Generate randomized Targets";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(399, 139);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(214, 24);
            this.button6.TabIndex = 13;
            this.button6.Text = "Generate only \"C\" targets";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(399, 169);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(214, 24);
            this.button7.TabIndex = 14;
            this.button7.Text = "Generate only \"Z\" targets";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // DataChart
            // 
            chartArea1.Name = "ChartArea1";
            this.DataChart.ChartAreas.Add(chartArea1);
            this.DataChart.IsSoftShadows = false;
            this.DataChart.Location = new System.Drawing.Point(7, 198);
            this.DataChart.Name = "DataChart";
            this.DataChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.LabelBorderWidth = 2;
            series1.Legend = "Legend1";
            series1.LegendText = "dawd";
            series1.LegendToolTip = "dawd";
            series1.MarkerBorderWidth = 2;
            series1.MarkerSize = 12;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series1.Name = "Series2";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.LabelBorderWidth = 4;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.DataChart.Series.Add(series1);
            this.DataChart.Series.Add(series2);
            this.DataChart.Size = new System.Drawing.Size(606, 360);
            this.DataChart.TabIndex = 15;
            this.DataChart.Text = "chart1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 566);
            this.Controls.Add(this.DataChart);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TprFprDataGridView);
            this.Controls.Add(this.ConfusionMatrixesFlowPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColumnsCountNumeric);
            this.Controls.Add(this.InitialDataTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TPR/FPR Calculator and ROC curve visualizer";
            ((System.ComponentModel.ISupportInitialize)(this.InitialDataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsCountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TprFprDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView InitialDataTable;
        private System.Windows.Forms.NumericUpDown ColumnsCountNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel ConfusionMatrixesFlowPanel;
        private System.Windows.Forms.DataGridView TprFprDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataVisualization.Charting.Chart DataChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

