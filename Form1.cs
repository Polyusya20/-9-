using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.Plottables;
using VoltageAnalyzer;
using CurrentAnalyzer;

namespace Practice
{
    public partial class MainForm : Form
    {
        private ThreePhaseVoltageAnalyzer voltageAnalyzer;
        private ThreePhaseCurrentAnalyzer currentAnalyzer;
        private List<double> ImpulsePeaks = new List<double> { 0, 0, 0 }; // Ударные токи для фаз A, B, C
        private List<double> MaxCurrents = new List<double> { 0, 0, 0 }; // Наибольшие токи до КЗ
        private string IncidentType = "Нет инцидента";
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
                "Приложение для практики НТЦ ЕЭС" +
                "\nПредназначено для чтения и обработки файлов Comtrade" +
                "\nВыполнила команда № 9" +
                "\nПриятного использования!" +
                "\nСПбПУ 2025",
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
                textBox1.Clear();
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
                currentAnalyzer = new ThreePhaseCurrentAnalyzer(filePath, 10, 10);

                this.Text = $"Осциллограф: {Path.GetFileName(filePath)}";

                string phaseInfo = voltageAnalyzer.GetPhaseIndicesInfo();
                //string phaseInfo2 = currentAnalyzer.GetPhaseIndicesInfo();
                InfoToolStripStatusLabel.Text = $"Start time: {voltageAnalyzer.TimeStampsOsc[0]}|{phaseInfo}";

                PlotVoltageData();
                PlotVoltagePositiveSequence();
                PlotVoltageZeroSequence();
                PlotCurrentData();
                PlotCurrentPositiveSequence();
                PlotCurrentNegativeSequence();
                PlotCurrentZeroSequence();
                DisplaySequenceValues();
                DisplayFaultAnalysis();
            }
            catch (Exception ex)
            {
                InfoToolStripStatusLabel.Text = "Ошибка загрузки файла.";
                MessageBox.Show($"Error processing COMTRADE file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PlotVoltagePositiveSequence()
        {
            if (voltageAnalyzer == null)
                return;
            OscPlot1.Plot.Clear();
            int dataPoints = this.voltageAnalyzer.PhaseA.Count;

            double[] timeSeconds = new double[dataPoints];
            DateTime startTime = voltageAnalyzer.TimeStampsOsc[0];

            double[] PositiveSequence = new double[dataPoints];

            for (int i = 0; i < dataPoints; i++)
            {
                timeSeconds[i] = (voltageAnalyzer.TimeStampsOsc[i] - startTime).TotalSeconds;

                PositiveSequence[i] = voltageAnalyzer.PositiveSequence[i];

            }
            var rIG = OscPlot1.Plot.Add.SignalXY(timeSeconds, PositiveSequence);
            rIG.LegendText = "Напряжение \nпрямой \nпоследовательности";
            OscPlot1.Plot.Axes.AutoScale();
            OscPlot1.Plot.XLabel("Время (с)");
            OscPlot1.Plot.YLabel("Напряжение (В)");

            OscPlot1.Plot.ShowLegend(Edge.Right);

            OscPlot1.Refresh();
        }
        private void PlotCurrentPositiveSequence()
        {
            if (currentAnalyzer == null)
                return;
            OscPlotCurrent2.Plot.Clear();
            int dataPoints = this.currentAnalyzer.PhaseACurrent.Count;

            double[] timeSeconds = new double[dataPoints];
            DateTime startTime = currentAnalyzer.TimeStampsCurrent[0];

            double[] PositiveCurrentSequence = new double[dataPoints];

            for (int i = 0; i < dataPoints; i++)
            {
                timeSeconds[i] = (currentAnalyzer.TimeStampsCurrent[i] - startTime).TotalSeconds;

                PositiveCurrentSequence[i] = currentAnalyzer.PositiveCurrentSequence[i];

            }
            var rIGP = OscPlotCurrent2.Plot.Add.SignalXY(timeSeconds, PositiveCurrentSequence);
            rIGP.LegendText = "Ток \nпрямой \nпоследовательности";
            OscPlotCurrent2.Plot.Axes.AutoScale();
            OscPlotCurrent2.Plot.XLabel("Время (с)");
            OscPlotCurrent2.Plot.YLabel("Ток (А)");

            OscPlotCurrent2.Plot.ShowLegend(Edge.Right);

            OscPlotCurrent2.Refresh();
        }
        private void PlotCurrentNegativeSequence()
        {
            if (currentAnalyzer == null)
                return;
            OscPlotCurrent3.Plot.Clear();
            int dataPoints = this.currentAnalyzer.PhaseACurrent.Count;

            double[] timeSeconds = new double[dataPoints];
            DateTime startTime = currentAnalyzer.TimeStampsCurrent[0];

            double[] NegativeCurrentSequence = new double[dataPoints];

            for (int i = 0; i < dataPoints; i++)
            {
                timeSeconds[i] = (currentAnalyzer.TimeStampsCurrent[i] - startTime).TotalSeconds;

                NegativeCurrentSequence[i] = currentAnalyzer.NegativeCurrentSequence[i];

            }
            var rIGN = OscPlotCurrent3.Plot.Add.SignalXY(timeSeconds, NegativeCurrentSequence);
            rIGN.LegendText = "Ток \nобратной \nпоследовательности";
            OscPlotCurrent3.Plot.Axes.AutoScale();
            OscPlotCurrent3.Plot.XLabel("Время (с)");
            OscPlotCurrent3.Plot.YLabel("Ток (А)");

            OscPlotCurrent3.Plot.ShowLegend(Edge.Right);

            OscPlotCurrent3.Refresh();
        }
        private void PlotCurrentZeroSequence()
        {
            if (currentAnalyzer == null)
                return;
            OscPlotCurrent4.Plot.Clear();
            int dataPoints = this.currentAnalyzer.PhaseACurrent.Count;

            double[] timeSeconds = new double[dataPoints];
            DateTime startTime = currentAnalyzer.TimeStampsCurrent[0];

            double[] ZeroCurrentSequence = new double[dataPoints];

            for (int i = 0; i < dataPoints; i++)
            {
                timeSeconds[i] = (currentAnalyzer.TimeStampsCurrent[i] - startTime).TotalSeconds;

                ZeroCurrentSequence[i] = currentAnalyzer.ZeroCurrentSequence[i];

            }
            var rIGZ = OscPlotCurrent4.Plot.Add.SignalXY(timeSeconds, ZeroCurrentSequence);
            rIGZ.LegendText = "Ток \nнулевой \nпоследовательности";
            OscPlotCurrent4.Plot.Axes.AutoScale();
            OscPlotCurrent4.Plot.XLabel("Время (с)");
            OscPlotCurrent4.Plot.YLabel("Ток (А)");

            OscPlotCurrent4.Plot.ShowLegend(Edge.Right);

            OscPlotCurrent4.Refresh();
        }
        private void PlotVoltageZeroSequence()
        {
            if (voltageAnalyzer == null)
                return;
            OscPlot2.Plot.Clear();
            int dataPoints = this.voltageAnalyzer.PhaseA.Count;

            double[] timeSeconds = new double[dataPoints];
            DateTime startTime = voltageAnalyzer.TimeStampsOsc[0];

            double[] ZeroSequence = new double[dataPoints];

            for (int i = 0; i < dataPoints; i++)
            {
                timeSeconds[i] = (voltageAnalyzer.TimeStampsOsc[i] - startTime).TotalSeconds;

                ZeroSequence[i] = voltageAnalyzer.ZeroSequence[i];

            }
            var nUL = OscPlot2.Plot.Add.SignalXY(timeSeconds, ZeroSequence);
            nUL.LegendText = "Напряжение \nнулевой \nпоследовательности";
            OscPlot2.Plot.Axes.AutoScale();
            OscPlot2.Plot.XLabel("Время (с)");
            OscPlot2.Plot.YLabel("Напряжение (В)");

            OscPlot2.Plot.ShowLegend(Edge.Right);

            OscPlot2.Refresh();
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
            OscPlot.Plot.XLabel("Время (с)");
            OscPlot.Plot.YLabel("Напряжение (В)");

            OscPlot.Plot.ShowLegend(Edge.Right);

            OscPlot.Refresh();
        }
        private void PlotCurrentData()
        {
            if (currentAnalyzer == null)
                return;

            OscPlotCurrent1.Plot.Clear();

            int dataPoints = this.currentAnalyzer.PhaseACurrent.Count;

            double[] timeSeconds = new double[dataPoints];
            DateTime startTime = currentAnalyzer.TimeStampsCurrent[0];

            double[] phaseACurrent = new double[dataPoints];
            double[] phaseBCurrent = new double[dataPoints];
            double[] phaseCCurrent = new double[dataPoints];

            for (int i = 0; i < dataPoints; i++)
            {
                timeSeconds[i] = (currentAnalyzer.TimeStampsCurrent[i] - startTime).TotalSeconds;

                phaseACurrent[i] = currentAnalyzer.PhaseACurrent[i];
                phaseBCurrent[i] = currentAnalyzer.PhaseBCurrent[i];
                phaseCCurrent[i] = currentAnalyzer.PhaseCCurrent[i];

            }
            var phACur = OscPlotCurrent1.Plot.Add.SignalXY(timeSeconds, phaseACurrent);
            phACur.LegendText = "Ia";
            var phBCur = OscPlotCurrent1.Plot.Add.SignalXY(timeSeconds, phaseBCurrent);
            phBCur.LegendText = "Ib";
            var phCCur = OscPlotCurrent1.Plot.Add.SignalXY(timeSeconds, phaseCCurrent);
            phCCur.LegendText = "Ic";
            OscPlotCurrent1.Plot.Axes.AutoScale();
            OscPlotCurrent1.Plot.XLabel("Время (с)");
            OscPlotCurrent1.Plot.YLabel("Ток (А)");

            OscPlotCurrent1.Plot.ShowLegend(Edge.Right);

            OscPlotCurrent1.Refresh();
        }
        private void DisplaySequenceValues()
        {
            if (currentAnalyzer == null || voltageAnalyzer == null)
                return;

            // 1) Токи последовательностей
            double avgPositiveCurrent = currentAnalyzer.PositiveCurrentSequence.Average();
            double avgNegativeCurrent = currentAnalyzer.NegativeCurrentSequence.Average();
            double avgZeroCurrent = currentAnalyzer.ZeroCurrentSequence.Average();
            labelCurrentPositive.Text = $"Средний ток прямой последовательности: {avgPositiveCurrent:F2} A";
            labelCurrentNegative.Text = $"Средний ток обратной последовательности: {avgNegativeCurrent:F2} A";
            labelCurrentZero.Text = $"Средний ток нулевой последовательности: {avgZeroCurrent:F2} A";

            // 2) Напряжения последовательностей
            double avgPositiveVoltage = voltageAnalyzer.PositiveSequence.Average();
            double avgZeroVoltage = voltageAnalyzer.ZeroSequence.Average();
            labelVoltagePositive.Text = $"Среднее напряжение прямой последовательности: {avgPositiveVoltage:F2} V";
            labelVoltageZero.Text = $"Среднее напряжение нулевой последовательности: {avgZeroVoltage:F2} V";
        }
        //Определение момента кз, учитываем только 10% входных данных (до максимума токов, т.е. КЗ, если оно вообще есть)
        private bool IsCurrentPeak(List<double> currentData, int idx)
        {
            if (idx <= 0 || idx >= currentData.Count - 1)
                return false;

            double val = currentData[idx];
            double prev = currentData[idx - 1];
            double next = currentData[idx + 1];

            return (val > prev && val > next) || (val < prev && val < next);
        }

        private void AnalyzeSurges()
        {
            ImpulsePeaks.Clear();
            ImpulsePeaks.AddRange(new double[] { 0, 0, 0 }); // Ударные токи
            MaxCurrents.Clear();
            MaxCurrents.AddRange(new double[] { 0, 0, 0 }); // Максимальные токи до КЗ

            double[] peakTrackA = new double[currentAnalyzer.PhaseACurrent.Count];
            double[] peakTrackB = new double[currentAnalyzer.PhaseBCurrent.Count];
            double[] peakTrackC = new double[currentAnalyzer.PhaseCCurrent.Count];

            // Начальные пики для сравнения
            double initialPeakA = 0, initialPeakB = 0, initialPeakC = 0;
            bool initialAFound = false, initialBFound = false, initialCFound = false;
            bool surgeAFound = false, surgeBFound = false, surgeCFound = false;

            for (int i = 1; i < currentAnalyzer.PhaseACurrent.Count - 1; i++)
            {
                // Поиск начальных пиков
                if (!initialAFound && IsCurrentPeak(currentAnalyzer.PhaseACurrent, i))
                {
                    initialPeakA = Math.Abs(currentAnalyzer.PhaseACurrent[i]);
                    initialAFound = true;
                }
                if (!initialBFound && IsCurrentPeak(currentAnalyzer.PhaseBCurrent, i))
                {
                    initialPeakB = Math.Abs(currentAnalyzer.PhaseBCurrent[i]);
                    initialBFound = true;
                }
                if (!initialCFound && IsCurrentPeak(currentAnalyzer.PhaseCCurrent, i))
                {
                    initialPeakC = Math.Abs(currentAnalyzer.PhaseCCurrent[i]);
                    initialCFound = true;
                }

                // Поиск ударных токов (превышение в 1.5 раза начального пика)
                if (initialAFound && IsCurrentPeak(currentAnalyzer.PhaseACurrent, i) &&
                    Math.Abs(currentAnalyzer.PhaseACurrent[i]) > initialPeakA * 1.5)
                {
                    peakTrackA[i] = Math.Abs(currentAnalyzer.PhaseACurrent[i]);
                }
                if (initialBFound && IsCurrentPeak(currentAnalyzer.PhaseBCurrent, i) &&
                    Math.Abs(currentAnalyzer.PhaseBCurrent[i]) > initialPeakB * 1.5)
                {
                    peakTrackB[i] = Math.Abs(currentAnalyzer.PhaseBCurrent[i]);
                }
                if (initialCFound && IsCurrentPeak(currentAnalyzer.PhaseCCurrent, i) &&
                    Math.Abs(currentAnalyzer.PhaseCCurrent[i]) > initialPeakC * 1.5)
                {
                    peakTrackC[i] = Math.Abs(currentAnalyzer.PhaseCCurrent[i]);
                }

                // Определение максимального ударного тока при смене знака
                if (peakTrackA.Any(x => x > 0) && Math.Sign(currentAnalyzer.PhaseACurrent[i]) != Math.Sign(currentAnalyzer.PhaseACurrent[i - 1]))
                {
                    ImpulsePeaks[0] = peakTrackA.Max();
                    surgeAFound = true;
                }
                if (peakTrackB.Any(x => x > 0) && Math.Sign(currentAnalyzer.PhaseBCurrent[i]) != Math.Sign(currentAnalyzer.PhaseBCurrent[i - 1]))
                {
                    ImpulsePeaks[1] = peakTrackB.Max();
                    surgeBFound = true;
                }
                if (peakTrackC.Any(x => x > 0) && Math.Sign(currentAnalyzer.PhaseCCurrent[i]) != Math.Sign(currentAnalyzer.PhaseCCurrent[i - 1]))
                {
                    ImpulsePeaks[2] = peakTrackC.Max();
                    surgeCFound = true;
                }

                if (surgeAFound && surgeBFound && surgeCFound)
                    break;
            }

            // Максимальные токи до КЗ
            MaxCurrents[0] = currentAnalyzer.PhaseACurrent.Select(Math.Abs).Max();
            MaxCurrents[1] = currentAnalyzer.PhaseBCurrent.Select(Math.Abs).Max();
            MaxCurrents[2] = currentAnalyzer.PhaseCCurrent.Select(Math.Abs).Max();
        }

        private void ClassifySurgeType()
        {
            // Определение типа КЗ на основе наличия ударных токов
            if (ImpulsePeaks[0] > 0 && ImpulsePeaks[1] > 0 && ImpulsePeaks[2] > 0)
                IncidentType = "Трехфазное КЗ";
            else if (ImpulsePeaks[0] == 0 && ImpulsePeaks[1] > 0 && ImpulsePeaks[2] > 0)
                IncidentType = "Двухфазное КЗ - B и C";
            else if (ImpulsePeaks[0] > 0 && ImpulsePeaks[1] == 0 && ImpulsePeaks[2] > 0)
                IncidentType = "Двухфазное КЗ - A и C";
            else if (ImpulsePeaks[0] > 0 && ImpulsePeaks[1] > 0 && ImpulsePeaks[2] == 0)
                IncidentType = "Двухфазное КЗ - A и B";
            else if (ImpulsePeaks[0] == 0 && ImpulsePeaks[1] == 0 && ImpulsePeaks[2] > 0)
                IncidentType = "Однофазное КЗ - C";
            else if (ImpulsePeaks[0] > 0 && ImpulsePeaks[1] == 0 && ImpulsePeaks[2] == 0)
                IncidentType = "Однофазное КЗ - A";
            else if (ImpulsePeaks[0] == 0 && ImpulsePeaks[1] > 0 && ImpulsePeaks[2] == 0)
                IncidentType = "Однофазное КЗ - B";
            else
                IncidentType = "Нет КЗ";
        }

        private void DisplayFaultAnalysis()
        {
            if (currentAnalyzer == null || voltageAnalyzer == null)
                return;

            // Анализ и отображение результатов
            AnalyzeSurges();
            ClassifySurgeType();

            /*labelFaultCurrentA.Text = $"Наибольший ток до КЗ (фаза A): {MaxCurrents[0]:F2} A";
            labelFaultCurrentB.Text = $"Наибольший ток до КЗ (фаза B): {MaxCurrents[1]:F2} A";
            labelFaultCurrentC.Text = $"Наибольший ток до КЗ (фаза C): {MaxCurrents[2]:F2} A";*/

            labelFaultType.Text = $"Тип КЗ: {IncidentType}";
            labelShockCurrentA.Text = ImpulsePeaks[0] > 0 ? $"Ударный ток КЗ (фаза A): {ImpulsePeaks[0]:F2} A" : "Ударный ток КЗ (фаза A): отсутствует";
            labelShockCurrentB.Text = ImpulsePeaks[1] > 0 ? $"Ударный ток КЗ (фаза B): {ImpulsePeaks[1]:F2} A" : "Ударный ток КЗ (фаза B): отсутствует";
            labelShockCurrentC.Text = ImpulsePeaks[2] > 0 ? $"Ударный ток КЗ (фаза C): {ImpulsePeaks[2]:F2} A" : "Ударный ток КЗ (фаза C): отсутствует";
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

        private void formsPlot3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OscPlot_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
       