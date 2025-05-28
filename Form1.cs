using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.Plottables;
using VoltageAnalyzer;

namespace Practice
{
    public partial class MainForm : Form
    {
        private ThreePhaseVoltageAnalyzer voltageAnalyzer;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Приложение для практики НТЦ ЕЭС",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void openToolStripButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Файлы COMTRADE (*.cfg)|*.cfg|Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Открыть файл COMTRADE";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadComtradeFile(openFileDialog.FileName);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка прочтения файла: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null) // Пока не достигнут конец файла
                    {
                        textBox1.Text += line + Environment.NewLine;
                    }
                }
            }
        }

        private void saveToolStripButton1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Файлы COMTRADE (*.cfg)|*.cfg|Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.Title = "Сохранить файл COMTRADE";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string data = textBox1.Text;
                        File.WriteAllText(saveFileDialog.FileName, data);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения файла: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadComtradeFile(string filePath)
        {
            statusLabel.Text = $"Loading file: {Path.GetFileName(filePath)}";
            Application.DoEvents();
            try
            {
                voltageAnalyzer = new ThreePhaseVoltageAnalyzer(filePath, 10, 10);

                this.Text = $"Осциллограф: {Path.GetFileName(filePath)}";

                string phaseInfo = voltageAnalyzer.GetPhaseIndicesInfo();
                InfoToolStripStatusLabel.Text = $"Start time: {voltageAnalyzer.TimeStampsOsc[0]}|{phaseInfo}";

                PlotVoltageData();

            }
            catch (Exception ex)
            {
                InfoToolStripStatusLabel.Text = "Ошибка загрузки файла.";
                MessageBox.Show($"Error processing COMTRADE file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlotVoltageData()
        {
            if (voltageAnalyzer == null)
                return;

            OscPlot.Plot.Clear();

            int dataPoints = this.voltageAnalyzer.PhaseA.Count;

            double[] timeSeconds = new double[dataPoints];
            DateTime startTime = voltageAnalyzer.TimeStampsOsc[0];

            double[] phaseA = new double[dataPoints];
            double[] phaseB = new double[dataPoints];
            double[] phaseC = new double[dataPoints];

            for (int i = 0; i < dataPoints; i++)
            {
                timeSeconds[i] = (voltageAnalyzer.TimeStampsOsc[i] - startTime).TotalSeconds;

                phaseA[i] = voltageAnalyzer.PhaseA[i];
                phaseB[i] = voltageAnalyzer.PhaseB[i];
                phaseC[i] = voltageAnalyzer.PhaseC[i];

            }
            var phA = OscPlot.Plot.Add.SignalXY(timeSeconds, phaseA);
            phA.LegendText = "Ua";
            var phB = OscPlot.Plot.Add.SignalXY(timeSeconds, phaseB);
            phB.LegendText = "Ub";
            var phC = OscPlot.Plot.Add.SignalXY(timeSeconds, phaseC);
            phC.LegendText = "Uc";
            OscPlot.Plot.Axes.AutoScale();

            OscPlot.Plot.ShowLegend(Edge.Right);

            OscPlot.Refresh();
        }


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load_1(object sender, EventArgs e)
        {

        }

        private void InfoToolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
       