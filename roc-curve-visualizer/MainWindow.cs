using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RocCurveVisualizer
{
    public partial class MainWindow : Form
    {
        private static readonly Random RANDOM = new Random();

        private static readonly string[] COLUMNS_LEGENT = { "OB.", "Target" };
        private static readonly string[] CONFUSED_MATRIX_LEGEND = { "Z", "C" };
        private static readonly string[] TARGETS = { "c", "z" };

        private ObAndTarget[] _dataTable;
        private DataGridView[] _confusionGridViews;
        private Label[] _confusionMatrixLabels;
        private List<ConfusionMatrixData> _confusionMatrixesData = new List<ConfusionMatrixData>();
        private int _columnsCount;

        private static readonly ObAndTarget[] INITIAL_VALUES =
        {
            new ObAndTarget() { Target = "Z", Ob = 4 },
            new ObAndTarget() { Target = "Z", Ob = 5 },
            new ObAndTarget() { Target = "C", Ob = 7 },
            new ObAndTarget() { Target = "Z", Ob = 8 },
            new ObAndTarget() { Target = "Z", Ob = 9 },
            new ObAndTarget() { Target = "C", Ob = 11 },
            new ObAndTarget() { Target = "C", Ob = 15 },
            new ObAndTarget() { Target = "C", Ob = 20 },
        };

        public MainWindow()
        {
            InitializeComponent();
            _columnsCount = (int)ColumnsCountNumeric.Value;
            InitialDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            TprFprDataGridView.Columns[0].HeaderCell.Value = "TPR";
            TprFprDataGridView.Columns[1].HeaderCell.Value = "FPR";
            TprFprDataGridView.Columns[2].HeaderCell.Value = "ACC";
            DataChart.ChartAreas[0].AxisX.Title = "FPR";
            DataChart.ChartAreas[0].AxisY.Title = "TPR";
            GenerateColumnsAndRows();
            GenerateConfusionMatrixGrid();
        }

        private void GenerateConfusionMatrixGrid()
        {
            ConfusionMatrixesFlowPanel.Controls.Clear();
            _confusionGridViews = new DataGridView[_columnsCount + 1];
            _confusionMatrixLabels = new Label[_columnsCount + 1];
            for (int i = 0; i < _columnsCount + 1; i++)
            {
                TableLayoutPanel panel = new TableLayoutPanel();
                Label label = new Label();
                label.Width = 190;
                label.Text = $"{i + 1})";
                DataGridView dataGridView = new DataGridView();
                dataGridView.ColumnCount = 2;
                dataGridView.RowCount = 3;
                dataGridView.EnableHeadersVisualStyles = false;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;
                dataGridView.AllowUserToOrderColumns = false;
                dataGridView.AllowUserToResizeRows = false;
                dataGridView.AllowUserToResizeColumns = false;
                dataGridView.ReadOnly = true;
                dataGridView.Enabled = false;
                dataGridView.Width = 190;
                dataGridView.Height = 120;
                dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                for (int j = 0; j < CONFUSED_MATRIX_LEGEND.Length; j++)
                {
                    dataGridView.Rows[j].HeaderCell.Value = CONFUSED_MATRIX_LEGEND[j];
                    dataGridView.Columns[j].HeaderCell.Value = CONFUSED_MATRIX_LEGEND[j];
                }
                panel.Controls.Add(label, 0, 0);
                panel.Controls.Add(dataGridView, 0, 1);
                _confusionMatrixLabels[i] = label;
                _confusionGridViews[i] = dataGridView;
                ConfusionMatrixesFlowPanel.Controls.Add(panel);
            }
        }

        private void GenerateColumnsAndRows()
        {
            InitialDataTable.RowCount = COLUMNS_LEGENT.Length;
            InitialDataTable.Columns[0].HeaderCell.Value = $"p1";
            for (int i = 0; i < COLUMNS_LEGENT.Length; i++)
                InitialDataTable.Rows[i].HeaderCell.Value = COLUMNS_LEGENT[i];
            InitialDataTable.ColumnCount = _columnsCount;
            FillTableWithEmptyValues();
        }

        private void ColumnsCountNumeric_ValueChanged(object sender, EventArgs e)
        {
            _columnsCount = (int)((NumericUpDown)sender).Value;
            InitialDataTable.ColumnCount = _columnsCount;
            for (int i = 0; i < _columnsCount; i++)
                InitialDataTable.Columns[i].HeaderCell.Value = $"p{i + 1}";
            GenerateConfusionMatrixGrid();
            FillTableWithEmptyValues();
            CalculateTprFpr(true);
            for (int i = 0; i < 2; i++)
                DataChart.Series[i].Points.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _columnsCount = INITIAL_VALUES.Length;
            InitialDataTable.ColumnCount = _columnsCount;
            ColumnsCountNumeric.Value = _columnsCount;
            for (int i = 0; i < _columnsCount; i++)
                InitialDataTable.Columns[i].HeaderCell.Value = $"p{i + 1}";
            LoadValuesIntoGrid(INITIAL_VALUES);
        }

        private void LoadValuesIntoGrid(ObAndTarget[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                InitialDataTable[i, 0].Value = values[i].Ob;
                InitialDataTable[i, 1].Value = values[i].Target;
            }
        }

        private void FillTableWithEmptyValues()
        {
            for (int i = 0; i < InitialDataTable.RowCount; i++)
                for (int j = 0; j < InitialDataTable.ColumnCount; j++)
                    InitialDataTable[j, i].Value = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _columnsCount; i++)
                InitialDataTable[i, 0].Value = i + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _confusionMatrixesData.Clear();
            FillTableWithEmptyValues();
            InsertConfusionMatrixesData(true);
            CalculateTprFpr(true);
            for (int i = 0; i < 2; i++)
                DataChart.Series[i].Points.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
                DataChart.Series[i].Points.Clear();
            _confusionMatrixesData.Clear();
            double result = 0;
            _dataTable = new ObAndTarget[_columnsCount];
            for (int i = 0; i < InitialDataTable.ColumnCount; i++)
            {
                if (!double.TryParse(InitialDataTable[i, 0].Value.ToString(), out result))
                {
                    MessageBox.Show($"Value in OB at position  p{i} is invalidate. Only numeric values in valid.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InitialDataTable[i, 0].Value = string.Empty;
                    return;
                }
                if (!Array.Exists(TARGETS, element => element.Equals(InitialDataTable[i, 1].Value.ToString().ToLower())))
                {
                    MessageBox.Show($"Value in Target at position p{i} is invalidate. Validate values: [{string.Join(",", TARGETS)}]",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InitialDataTable[i, 1].Value = string.Empty;
                    return;
                }
                _dataTable[i] = new ObAndTarget()
                {
                    Target = InitialDataTable[i, 1].Value.ToString(),
                    Ob = double.Parse(InitialDataTable[i, 0].Value.ToString())
                };
                _dataTable[i].Ob = result;
                _dataTable[i].Target = InitialDataTable[i, 1].Value.ToString();
                for (int j = 0; j < InitialDataTable.RowCount; j++)
                {
                    if (InitialDataTable[i, j].Value == null || InitialDataTable[i, j].Value.Equals(string.Empty))
                    {
                        MessageBox.Show("All cells in table must have a value.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            for (int i = 0; i < _dataTable.Length + 1; i++)
            {
                int ZZ = 0, ZC = 0, CZ = 0, CC = 0;
                string[] aiOutputs = new string[_dataTable.Length];
                for (int j = 0; j < _dataTable.Length; j++)
                {
                    if (j < i)
                        aiOutputs[j] = "Z";
                    else
                        aiOutputs[j] = "C";
                }
                for (int j = 0; j < _dataTable.Length; j++)
                {
                    if (_dataTable[j].Target == "Z" && aiOutputs[j] == "Z")
                        ZZ++;
                    else if (_dataTable[j].Target == "Z" && aiOutputs[j] == "C")
                        ZC++;
                    else if (_dataTable[j].Target == "C" && aiOutputs[j] == "Z")
                        CZ++;
                    else if (_dataTable[j].Target == "C" && aiOutputs[j] == "C")
                        CC++;
                }

                string estimateText;
                if (i == 0)
                    estimateText = $"p < {_dataTable[0].Ob}";
                else if (i == _dataTable.Length)
                    estimateText = $"{_dataTable[_dataTable.Length - 1].Ob} < p";
                else
                    estimateText = $"{_dataTable[i - 1].Ob} < p < {_dataTable[i].Ob}";

                _confusionMatrixesData.Add(new ConfusionMatrixData()
                {
                    ConfusionMatrix = new double[2, 2] { { ZZ, ZC }, { CZ, CC } },
                    ObEstimate = estimateText,
                });
            }
            InsertConfusionMatrixesData(false);
            CalculateTprFpr(false);
        }

        private void CalculateTprFpr(bool clearInput)
        {
            TprFprDataGridView.ColumnCount = 3;
            TprFprDataGridView.RowCount = _confusionMatrixesData.Count;
            for (int i = 0; i < _confusionMatrixesData.Count; i++)
            {
                TprFprDataGridView.Rows[i].HeaderCell.Value = $"MX {i + 1}";
                if (clearInput)
                    for (int j = 0; j < 2; j++)
                        TprFprDataGridView[j, i].Value = "";
                else
                {
                    double[,] matrix = _confusionMatrixesData[i].ConfusionMatrix;
                    double FPR_X = 0, TPR_Y = 0, ACC = 0;
                    if ((matrix[1, 0] + matrix[1, 1]) != 0)
                        FPR_X = (matrix[1, 0] / (matrix[1, 0] + matrix[1, 1]));  //fpr
                    if ((matrix[0, 0] + matrix[0, 1]) != 0)
                        TPR_Y = (matrix[0, 0] / (matrix[0, 0] + matrix[0, 1]));  //tpr;
                    double numerator = matrix[0, 0] + matrix[1, 1];
                    if (numerator != 0)
                        ACC = numerator / (numerator + matrix[0, 1] + matrix[1, 0]);
                    TprFprDataGridView[0, i].Value = TPR_Y.ToString("0.000000000");
                    TprFprDataGridView[1, i].Value = FPR_X.ToString("0.000000000");
                    TprFprDataGridView[2, i].Value = ACC.ToString("0.00%");
                    for (int j = 0; j < 2; j++)
                        DataChart.Series[j].Points.AddXY(FPR_X, TPR_Y);
                }
            }
        }

        private void InsertConfusionMatrixesData(bool clearInput)
        {
            for (int i = 0; i < _confusionGridViews.Length; i++)
            {
                for (int j = 0; j < _confusionGridViews[i].ColumnCount; j++)
                {
                    for (int k = 0; k < _confusionGridViews[i].RowCount; k++)
                    {
                        if (clearInput)
                        {
                            _confusionMatrixLabels[i].Text = $"{i + 1})";
                            _confusionGridViews[i][k, j].Value = string.Empty;
                        }
                        else
                        {
                            _confusionMatrixLabels[i].Text = $"{i + 1}) {_confusionMatrixesData[i].ObEstimate}";
                            _confusionGridViews[i][k, j].Value = _confusionMatrixesData[i].ConfusionMatrix[k, j];
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _columnsCount; i++)
                InitialDataTable[i, 1].Value = CONFUSED_MATRIX_LEGEND[RANDOM.Next(0, CONFUSED_MATRIX_LEGEND.Length)];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _columnsCount; i++)
                InitialDataTable[i, 1].Value = "Z";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _columnsCount; i++)
                InitialDataTable[i, 1].Value = "C";
        }
    }
}
