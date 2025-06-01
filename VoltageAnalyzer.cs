using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using Wisp.Comtrade;
using Wisp.Comtrade.Models;

namespace VoltageAnalyzer
{
    public class ThreePhaseVoltageAnalyzer
    {
        private const double TWO_PI = 2 * Math.PI;

        private Wisp.Comtrade.RecordReader _comtradeData;
        private ConfigurationHandler configuration;

        private int _phaseAIndex;
        private int _phaseBIndex;
        private int _phaseCIndex;
        private int _windowSizePeriods;
        private int _stepSizePeriods;
        private double _nominalFrequency;

        // Списки для осциллограмм
        public List<DateTime> TimeStampsOsc { get; private set; }
        public List<double> PhaseA { get; private set; }
        public List<double> PhaseB { get; private set; }
        public List<double> PhaseC { get; private set; }

        // Списки для частот
        public List<DateTime> TimeStampsFreq { get; private set; }
        public List<double> PhaseAFreq { get; private set; }
        public List<double> PhaseBFreq { get; private set; }
        public List<double> PhaseCFreq { get; private set; }

        // Списки для RMS
        public List<DateTime> TimeStampsRms { get; private set; }
        public List<double> PhaseARms { get; private set; }
        public List<double> PhaseBRms { get; private set; }
        public List<double> PhaseCRms { get; private set; }

        // Списки для гармоник
        public List<DateTime> TimeStampsHarmonics { get; private set; }
        public List<List<double>> PhaseAHarmonicsAmplitudes { get; private set; }
        public List<List<double>> PhaseBHarmonicsAmplitudes { get; private set; }
        public List<List<double>> PhaseCHarmonicsAmplitudes { get; private set; }
        public List<List<double>> PhaseAHarmonicsPhases { get; private set; }
        public List<List<double>> PhaseBHarmonicsPhases { get; private set; }
        public List<List<double>> PhaseCHarmonicsPhases { get; private set; }

        // Новые списки для последовательностей
        public List<DateTime> TimeStampsSequences { get; private set; }
        public List<double> PositiveSequence { get; private set; } // Прямая последовательность
        public List<double> ZeroSequence { get; private set; } // Нулевая последовательность

        public ThreePhaseVoltageAnalyzer(string comtradeFilePath, int windowSizePeriods, int stepSizePeriods)
        {
            _windowSizePeriods = windowSizePeriods;
            _stepSizePeriods = stepSizePeriods;

            configuration = new ConfigurationHandler(comtradeFilePath);
            _comtradeData = new RecordReader(comtradeFilePath);

            FindPhaseVoltageIndices();
            _nominalFrequency = configuration.Frequency;

            InitializeOscLists();
            ReadAllVoltages();
            InitializeResultLists();
            CalculateAll();
        }

        private void InitializeOscLists()
        {
            TimeStampsOsc = new List<DateTime>();
            PhaseA = new List<double>();
            PhaseB = new List<double>();
            PhaseC = new List<double>();
        }

        private void InitializeResultLists()
        {
            // Частоты
            TimeStampsFreq = new List<DateTime>();
            PhaseAFreq = new List<double>();
            PhaseBFreq = new List<double>();
            PhaseCFreq = new List<double>();

            // RMS (оставляем пустыми, если не используем)
            TimeStampsRms = new List<DateTime>();
            PhaseARms = new List<double>();
            PhaseBRms = new List<double>();
            PhaseCRms = new List<double>();

            // Гармоники (оставляем пустыми, если не используем)
            TimeStampsHarmonics = new List<DateTime>();
            PhaseAHarmonicsAmplitudes = new List<List<double>>();
            PhaseBHarmonicsAmplitudes = new List<List<double>>();
            PhaseCHarmonicsAmplitudes = new List<List<double>>();
            PhaseAHarmonicsPhases = new List<List<double>>();
            PhaseBHarmonicsPhases = new List<List<double>>();
            PhaseCHarmonicsPhases = new List<List<double>>();

            // Последовательности
            TimeStampsSequences = new List<DateTime>();
            PositiveSequence = new List<double>();
            ZeroSequence = new List<double>();
        }

        public void CalculateAll()
        {
            CalculateFrequences();
            CalculateSequences(); // Добавляем расчёт последовательностей
        }

        public void CalculateFrequences()
        {
            PhaseAFreq.Clear();
            PhaseBFreq.Clear();
            PhaseCFreq.Clear();

            int samplingRate = (int)configuration.SampleRates[0].SamplingFrequency;
            int windowSizePoints = (int)(samplingRate * _windowSizePeriods / _nominalFrequency);
            int stepSizePoints = (int)(samplingRate * _stepSizePeriods / _nominalFrequency);

            for (int startPoint = 0; startPoint <= PhaseA.Count - windowSizePoints; startPoint += stepSizePoints)
            {
                double[] phaseAWindow = GetDataWindow(PhaseA.ToArray(), startPoint, windowSizePoints);
                double[] phaseBWindow = GetDataWindow(PhaseB.ToArray(), startPoint, windowSizePoints);
                double[] phaseCWindow = GetDataWindow(PhaseC.ToArray(), startPoint, windowSizePoints);

                double frequencyA = CalculateFrequencesByZeroCrossings(phaseAWindow, samplingRate);
                double frequencyB = CalculateFrequencesByZeroCrossings(phaseBWindow, samplingRate);
                double frequencyC = CalculateFrequencesByZeroCrossings(phaseCWindow, samplingRate);

                int middlePoint = startPoint + windowSizePoints / 2;
                DateTime timeStamp = _comtradeData.Configuration.StartTime.AddSeconds(
                    (double)middlePoint / samplingRate);

                TimeStampsFreq.Add(timeStamp);
                PhaseAFreq.Add(frequencyA);
                PhaseBFreq.Add(frequencyB);
                PhaseCFreq.Add(frequencyC);
            }
        }

        private void CalculateSequences()
        {
            PositiveSequence.Clear();
            ZeroSequence.Clear();
            TimeStampsSequences.Clear();

            int samplingRate = (int)configuration.SampleRates[0].SamplingFrequency;
            int windowSizePoints = (int)(samplingRate * _windowSizePeriods / _nominalFrequency);
            int stepSizePoints = (int)(samplingRate * _stepSizePeriods / _nominalFrequency);

            // Операторы a и a^2 для симметричных составляющих
            Complex a = new Complex(-0.5, Math.Sqrt(3) / 2); // a = e^(j120°)
            Complex a2 = new Complex(-0.5, -Math.Sqrt(3) / 2); // a^2 = e^(j240°)

            for (int i = 0; i < PhaseA.Count; i++)
            {

                // Усредняем значения в окне для получения одного значения на окно
                Complex va = new Complex(PhaseA[i], 0);
                Complex vb = new Complex(PhaseB[i], 0);
                Complex vc = new Complex(PhaseC[i], 0);


                // Расчёт последовательностей
                Complex v1 = (va + a * vb + a2 * vc) / 3.0; // Прямая
                Complex v0 = (va + vb + vc) / 3.0; // Нулевая

                PositiveSequence.Add(v1.Magnitude);
                ZeroSequence.Add(v0.Magnitude);
            }

        }

        private double[] GetDataWindow(double[] data, int startIndex, int length)
        {
            double[] window = new double[length];
            Array.Copy(data, startIndex, window, 0, length);
            return window;
        }

        private double CalculateFrequencesByZeroCrossings(double[] data, int samplingRate)
        {
            int minPoints = 3;
            List<int> zeroCrossingIndices = new List<int>();
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i - 1] <= 0 && data[i] > 0)
                {
                    zeroCrossingIndices.Add(i);
                }
            }
            if (zeroCrossingIndices.Count < minPoints)
            {
                return _nominalFrequency;
            }
            double totalPeriods = 0;
            int periodCount = 0;

            for (int i = 1; i < zeroCrossingIndices.Count; i++)
            {
                int samplesBetweenCrossings = zeroCrossingIndices[i] - zeroCrossingIndices[i - 1];
                double estimatedFreq = (double)samplingRate / samplesBetweenCrossings;
                if (estimatedFreq >= 0.5 * _nominalFrequency && estimatedFreq <= 2.0 * _nominalFrequency)
                {
                    totalPeriods += samplesBetweenCrossings;
                    periodCount++;
                }
            }
            if (periodCount == 0)
            {
                return _nominalFrequency;
            }

            double averagePeriodInSamples = totalPeriods / periodCount;
            double frequency = samplingRate / averagePeriodInSamples;

            return frequency;
        }

        public void ClearOsc()
        {
            TimeStampsOsc.Clear();
            PhaseA.Clear();
            PhaseB.Clear();
            PhaseC.Clear();
        }

        public string GetPhaseIndicesInfo()
        {
            return $"Phase Voltage Indexes: A={_phaseAIndex}, B={_phaseBIndex}, C={_phaseCIndex}; " +
                   $"Channel Name: A={configuration.AnalogChannelInformationList[_phaseAIndex].Name}, " +
                   $"B={configuration.AnalogChannelInformationList[_phaseBIndex].Name}, " +
                   $"C={configuration.AnalogChannelInformationList[_phaseCIndex].Name}";
        }

        public void ReadAllVoltages()
        {
            ClearOsc();

            PhaseA = _comtradeData.GetAnalogPrimaryChannel(_phaseAIndex).ToList();
            PhaseB = _comtradeData.GetAnalogPrimaryChannel(_phaseBIndex).ToList();
            PhaseC = _comtradeData.GetAnalogPrimaryChannel(_phaseCIndex).ToList();

            for (int i = 0; i < PhaseA.Count; i++)
            {
                DateTime timeStamp = _comtradeData.Configuration.StartTime.AddSeconds(
                    i / _comtradeData.Configuration.SampleRates[0].SamplingFrequency);
                TimeStampsOsc.Add(timeStamp);
            }
        }

        public void FindPhaseVoltageIndices()
        {
            List<PhaseVoltageCandidate> phaseVoltageCandidates = new List<PhaseVoltageCandidate>();

            var phaseARegex = new Regex(@"(?:UA|VA|U[_\s]*A|V[_\s]*A|Ua|Va|Phase[\s_]*A)", RegexOptions.IgnoreCase);
            var phaseBRegex = new Regex(@"(?:UB|VB|U[_\s]*B|V[_\s]*B|Ub|Vb|Phase[\s_]*B)", RegexOptions.IgnoreCase);
            var phaseCRegex = new Regex(@"(?:UC|VC|U[_\s]*C|V[_\s]*C|Uc|Vc|Phase[\s_]*C)", RegexOptions.IgnoreCase);

            for (int i = 0; i < configuration.AnalogChannelsCount; i++)
            {
                var channel = configuration.AnalogChannelInformationList[i];
                bool isVoltage = channel.Units.ToLower().Contains("v") ||
                                 channel.Units.ToLower().Contains("в");

                if (!isVoltage)
                    continue;

                string channelName = channel.Name;
                PhaseType detectedPhase = PhaseType.Unknown;

                if (phaseARegex.IsMatch(channelName))
                {
                    detectedPhase = PhaseType.PhaseA;
                }
                else if (phaseBRegex.IsMatch(channelName))
                {
                    detectedPhase = PhaseType.PhaseB;
                }
                else if (phaseCRegex.IsMatch(channelName))
                {
                    detectedPhase = PhaseType.PhaseC;
                }

                if (detectedPhase != PhaseType.Unknown)
                {
                    phaseVoltageCandidates.Add(new PhaseVoltageCandidate
                    {
                        ChannelIndex = i,
                        PhaseType = detectedPhase,
                        ChannelName = channelName
                    });
                }
            }

            if (phaseVoltageCandidates.Count == 0)
            {
                var voltageChannels = new List<int>();

                for (int i = 0; i < configuration.AnalogChannelsCount; i++)
                {
                    var channel = configuration.AnalogChannelInformationList[i];
                    bool isVoltage = channel.Units.ToLower().Contains("v") ||
                                     channel.Units.ToLower().Contains("в");

                    if (isVoltage)
                    {
                        voltageChannels.Add(i);
                    }
                }

                if (voltageChannels.Count >= 3)
                {
                    phaseVoltageCandidates.Add(new PhaseVoltageCandidate
                    {
                        ChannelIndex = voltageChannels[0],
                        PhaseType = PhaseType.PhaseA,
                        ChannelName = configuration.AnalogChannelInformationList[voltageChannels[0]].Name
                    });
                    phaseVoltageCandidates.Add(new PhaseVoltageCandidate
                    {
                        ChannelIndex = voltageChannels[1],
                        PhaseType = PhaseType.PhaseB,
                        ChannelName = configuration.AnalogChannelInformationList[voltageChannels[1]].Name
                    });
                    phaseVoltageCandidates.Add(new PhaseVoltageCandidate
                    {
                        ChannelIndex = voltageChannels[2],
                        PhaseType = PhaseType.PhaseC,
                        ChannelName = configuration.AnalogChannelInformationList[voltageChannels[2]].Name
                    });
                }
            }

            var phaseA = phaseVoltageCandidates.FirstOrDefault(c => c.PhaseType == PhaseType.PhaseA);
            var phaseB = phaseVoltageCandidates.FirstOrDefault(c => c.PhaseType == PhaseType.PhaseB);
            var phaseC = phaseVoltageCandidates.FirstOrDefault(c => c.PhaseType == PhaseType.PhaseC);

            if (phaseA != null && phaseB != null && phaseC != null)
            {
                _phaseAIndex = phaseA.ChannelIndex;
                _phaseBIndex = phaseB.ChannelIndex;
                _phaseCIndex = phaseC.ChannelIndex;
            }
            else
            {
                throw new Exception("Не удалось автоматически определить индексы всех трёх фазных напряжений. " +
                    "Пожалуйста, укажите индексы фаз явно.");
            }
        }
    }

    class PhaseVoltageCandidate
    {
        public int ChannelIndex { get; set; }
        public PhaseType PhaseType { get; set; }
        public string ChannelName { get; set; }
    }

    enum PhaseType
    {
        Unknown,
        PhaseA,
        PhaseB,
        PhaseC
    }
}