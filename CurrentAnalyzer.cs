using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using VoltageAnalyzer;
using Wisp.Comtrade;
using Wisp.Comtrade.Models;

namespace CurrentAnalyzer
{
    public class ThreePhaseCurrentAnalyzer
    {
        private Wisp.Comtrade.RecordReader _comtradeData;
        private ConfigurationHandler configuration;

        private int _phaseACurrentIndex;
        private int _phaseBCurrentIndex;
        private int _phaseCCurrentIndex;
        private int _windowSizePeriods;
        private int _stepSizePeriods;
        private int _phaseAIndexCurrent;
        private int _phaseBIndexCurrent;
        private int _phaseCIndexCurrent;
        private double _nominalFrequency;
        public List<DateTime> TimeStampsCurrent { get; private set; }
        public List<double> PhaseACurrent { get; private set; }
        public List<double> PhaseBCurrent { get; private set; }
        public List<double> PhaseCCurrent { get; private set; }
        public List<DateTime> TimeStampsSequencesCurrent { get; private set; }
        public List<double> PositiveCurrentSequence { get; private set; }
        public List<double> NegativeCurrentSequence { get; private set; } 
        public List<double> ZeroCurrentSequence { get; private set; }
        public ThreePhaseCurrentAnalyzer(string comtradeFilePath, int windowSizePeriods, int stepSizePeriods)
        {
            _windowSizePeriods = windowSizePeriods;
            _stepSizePeriods = stepSizePeriods;

            configuration = new ConfigurationHandler(comtradeFilePath);
            _comtradeData = new RecordReader(comtradeFilePath);

            FindPhaseCurrentIndices();
            _nominalFrequency = configuration.Frequency;
            InitializeOscListsCurrent();
            ReadAllCurrents();
            CalculateAllCurrent();
        }
        private void InitializeOscListsCurrent()
        {
            TimeStampsCurrent = new List<DateTime>();
            PhaseACurrent = new List<double>();
            PhaseBCurrent = new List<double>();
            PhaseCCurrent = new List<double>();
            TimeStampsSequencesCurrent = new List<DateTime>();
            PositiveCurrentSequence = new List<double>();
            NegativeCurrentSequence = new List<double>();
            ZeroCurrentSequence = new List<double>();
        }
        public void ReadAllCurrents()
        {
            ClearOscResults();

            if (_phaseAIndexCurrent >= _comtradeData.Configuration.AnalogChannelsCount ||
                _phaseBIndexCurrent >= _comtradeData.Configuration.AnalogChannelsCount ||
                _phaseCIndexCurrent >= _comtradeData.Configuration.AnalogChannelsCount)
            {
                throw new IndexOutOfRangeException("Один или несколько индексов фазных токов выходят за пределы доступных каналов.");
            }

            PhaseACurrent = _comtradeData.GetAnalogPrimaryChannel(_phaseAIndexCurrent).ToList();
            PhaseBCurrent = _comtradeData.GetAnalogPrimaryChannel(_phaseBIndexCurrent).ToList();
            PhaseCCurrent = _comtradeData.GetAnalogPrimaryChannel(_phaseCIndexCurrent).ToList();

            for (int i = 0; i < PhaseACurrent.Count; i++)
            {
                DateTime timeStamp = _comtradeData.Configuration.StartTime.AddSeconds(
                    i / _comtradeData.Configuration.SampleRates[0].SamplingFrequency);
                TimeStampsCurrent.Add(timeStamp);
            }
        }
        private void ClearOscResults()
        {
            TimeStampsCurrent.Clear();
            PhaseACurrent.Clear();
            PhaseBCurrent.Clear();
            PhaseCCurrent.Clear();
        }
        public void FindPhaseCurrentIndices()
        {
            List<PhaseCurrentCandidate> phaseCurrentCandidates = new List<PhaseCurrentCandidate>();

            var phaseARegex = new Regex(@"(?:IA|VA|I[_\s]*A|V[_\s]*A|Ia|Va|Phase[\s_]*A|I1)", RegexOptions.IgnoreCase);
            var phaseBRegex = new Regex(@"(?:IB|VB|I[_\s]*B|V[_\s]*B|Ib|Vb|Phase[\s_]*B|I2)", RegexOptions.IgnoreCase);
            var phaseCRegex = new Regex(@"(?:IC|VC|I[_\s]*C|V[_\s]*C|Ic|Vc|Phase[\s_]*C|I3)", RegexOptions.IgnoreCase);

            for (int i = 0; i < configuration.AnalogChannelsCount; i++)
            {
                var channel = configuration.AnalogChannelInformationList[i];
                bool isCurrent = channel.Units.ToLower().Contains("a") ||
                                 channel.Units.ToLower().Contains("а");

                if (!isCurrent)
                    continue;

                string channelName = channel.Name;
                PhaseType detectedPhase = PhaseType.Unknown;

                if (phaseARegex.IsMatch(channelName))
                {
                    detectedPhase = PhaseType.PhaseACurrent;
                }
                else if (phaseBRegex.IsMatch(channelName))
                {
                    detectedPhase = PhaseType.PhaseBCurrent;
                }
                else if (phaseCRegex.IsMatch(channelName))
                {
                    detectedPhase = PhaseType.PhaseCCurrent;
                }

                if (detectedPhase != PhaseType.Unknown)
                {
                    phaseCurrentCandidates.Add(new PhaseCurrentCandidate
                    {
                        ChannelIndexCurrent = i,
                        PhaseTypeCurrent = detectedPhase,
                        ChannelNameCurrent = channelName
                    });
                }
            }

            if (phaseCurrentCandidates.Count < 3)
            {
                var currentChannels = new List<int>();
                for (int i = 0; i < configuration.AnalogChannelsCount; i++)
                {
                    var channel = configuration.AnalogChannelInformationList[i];
                    bool isCurrent = channel.Units.ToLower().Contains("a") ||
                                     channel.Units.ToLower().Contains("а");
                    if (isCurrent)
                    {
                        currentChannels.Add(i);
                    }
                }
                if (currentChannels.Count >= 3)
                {
                    phaseCurrentCandidates.Add(new PhaseCurrentCandidate
                    {
                        ChannelIndexCurrent = currentChannels[0],
                        PhaseTypeCurrent = PhaseType.PhaseACurrent,
                        ChannelNameCurrent = configuration.AnalogChannelInformationList[currentChannels[0]].Name
                    });
                    phaseCurrentCandidates.Add(new PhaseCurrentCandidate
                    {
                        ChannelIndexCurrent = currentChannels[1],
                        PhaseTypeCurrent = PhaseType.PhaseBCurrent,
                        ChannelNameCurrent = configuration.AnalogChannelInformationList[currentChannels[1]].Name
                    });
                    phaseCurrentCandidates.Add(new PhaseCurrentCandidate
                    {
                        ChannelIndexCurrent = currentChannels[2],
                        PhaseTypeCurrent = PhaseType.PhaseCCurrent,
                        ChannelNameCurrent = configuration.AnalogChannelInformationList[currentChannels[2]].Name
                    });
                }
                else
                {
                    throw new Exception($"Найдено меньше 3 каналов тока: {currentChannels.Count}. Проверь файл COMTRADE.");
                }
            }

            var phaseACurrent = phaseCurrentCandidates.FirstOrDefault(c => c.PhaseTypeCurrent == PhaseType.PhaseACurrent);
            var phaseBCurrent = phaseCurrentCandidates.FirstOrDefault(c => c.PhaseTypeCurrent == PhaseType.PhaseBCurrent);
            var phaseCCurrent = phaseCurrentCandidates.FirstOrDefault(c => c.PhaseTypeCurrent == PhaseType.PhaseCCurrent);

            if (phaseACurrent != null && phaseBCurrent != null && phaseCCurrent != null)
            {
                _phaseAIndexCurrent = phaseACurrent.ChannelIndexCurrent;
                _phaseBIndexCurrent = phaseBCurrent.ChannelIndexCurrent;
                _phaseCIndexCurrent = phaseCCurrent.ChannelIndexCurrent;
            }
            else
            {
                throw new Exception("Не удалось определить индексы всех трёх фазных токов. Проверь названия каналов в файле.");
            }
        }
        enum PhaseType
        {
            Unknown,
            PhaseACurrent,
            PhaseBCurrent,
            PhaseCCurrent
        }
        class PhaseCurrentCandidate
        {
            public int ChannelIndexCurrent { get; set; }
            public PhaseType PhaseTypeCurrent { get; set; }
            public string ChannelNameCurrent { get; set; }
        }
        public void CalculateAllCurrent()
        {
            CalculateSequencesCurrent();
        }
        private void CalculateSequencesCurrent()
        {
            PositiveCurrentSequence.Clear();
            NegativeCurrentSequence.Clear();
            ZeroCurrentSequence.Clear();
            TimeStampsSequencesCurrent.Clear();

            int samplingRate = (int)configuration.SampleRates[0].SamplingFrequency;
            int windowSizePoints = (int)(samplingRate * _windowSizePeriods / _nominalFrequency);
            int stepSizePoints = (int)(samplingRate * _stepSizePeriods / _nominalFrequency);

            // Операторы a и a^2 для симметричных составляющих
            Complex a = new Complex(-0.5, Math.Sqrt(3) / 2); // a = e^(j120°)
            Complex a2 = new Complex(-0.5, -Math.Sqrt(3) / 2); // a^2 = e^(j240°)

            for (int i = 0; i < PhaseACurrent.Count; i++)
            {
                Complex ia = new Complex(PhaseACurrent[i], 0);
                Complex ib = new Complex(PhaseBCurrent[i], 0);
                Complex ic = new Complex(PhaseCCurrent[i], 0);

                // Расчёт последовательностей
                Complex i1 = (ia + a * ib + a2 * ic) / 3.0; // Прямая
                Complex i2 = (ia + a2 * ib + a * ic) / 3.0; // Обратная
                Complex i0 = (ia + ib + ic) / 3.0; // Нулевая

                PositiveCurrentSequence.Add(i1.Magnitude);
                NegativeCurrentSequence.Add(i2.Magnitude);
                ZeroCurrentSequence.Add(i0.Magnitude);
            }
        }
        private double[] GetDataWindow(double[] data, int startIndex, int length)
        {
            double[] window = new double[length];
            Array.Copy(data, startIndex, window, 0, length);
            return window;
        }
    }
}
