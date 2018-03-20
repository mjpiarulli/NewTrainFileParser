using System;
using System.Collections.Generic;
using Jacobs.TrainParsing.Common;
using Jacobs.TrainParsing.Common.TrainInformation;

namespace Jacobs.TrainParsing.TrainParseHelpers
{
    public static class TrainInformationParser
    {
        public static IEnumerable<TrainInformation> Parse(string trainInformationText, Section section)
        {
            var lines = trainInformationText.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var l in lines)
            {
                var line = l.Trim();

                if (string.IsNullOrWhiteSpace(line) ||
                    line.StartsWith(TrainInfoKeywords.Header) ||
                    line.StartsWith(TrainInfoKeywords.ColumnHeaderStart1) ||
                    line.StartsWith(TrainInfoKeywords.ColumnHeaderStart2))
                    continue;

                var trainInfoData = line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var trainInfo = PopulateTrainInfo(trainInfoData, section);

                yield return trainInfo;
            }
        }

        private static TrainInformation PopulateTrainInfo(IReadOnlyList<string>trainInfoData, Section section)
        {
            var trainInfo = new TrainInformation
            {
                TrainNumber = trainInfoData[TrainInfoColumn.TrainNumber],
                TrainType = trainInfoData[TrainInfoColumn.TrainType],
                TrainPosition = trainInfoData[TrainInfoColumn.TrainPosition],
                TrackNumber = trainInfoData[TrainInfoColumn.TrackNumber],
                LineVolts = trainInfoData[TrainInfoColumn.LineVolts],
                LineAmps = trainInfoData[TrainInfoColumn.LineAmps],
                LinePower = trainInfoData[TrainInfoColumn.LinePower],
                AdjacentNodePosition = trainInfoData[TrainInfoColumn.AdjacentNodePosition],
                Current = trainInfoData[TrainInfoColumn.Current],
                FlowPosition = trainInfoData[TrainInfoColumn.FlowPosition],
                InformationCurrent = trainInfoData[TrainInfoColumn.InformationCurrent],
                Snapshot = section.Snapshot
            };

            return trainInfo;
        }
    }
}