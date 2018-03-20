using System.Collections.Generic;
using Jacobs.TrainParsing.Common.AoSummary;
using Jacobs.TrainParsing.Common.CurrentAtFixedPosition;

namespace Jacobs.TrainParsing.Common
{
    public class Report
    {
        public Report()
        {
            VoltageAcPortion = new List<VoltageAcPortion>();
            ConverterPortion = new List<ConverterPortion.ConverterPortion>();
            CurrentAtPosition = new List<CurrentAtFixedPositionPortion>();
            TrainInformation = new List<TrainInformation.TrainInformation>();
            Section = new Section();
            AoSummaryPortion = new List<AoSummaryPortion>();
        }

        public Section Section { get; set; }
        public List<VoltageAcPortion> VoltageAcPortion { get; set; }
        public List<ConverterPortion.ConverterPortion> ConverterPortion { get; set; }
        public List<CurrentAtFixedPositionPortion> CurrentAtPosition { get; set; }
        public List<TrainInformation.TrainInformation> TrainInformation { get; set; }
        public List<AoSummaryPortion> AoSummaryPortion { get; set; }
    }
}