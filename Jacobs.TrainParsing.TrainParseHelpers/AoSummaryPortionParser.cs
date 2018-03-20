using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Jacobs.TrainParsing.Common.AoSummary;

namespace Jacobs.TrainParsing.TrainParseHelpers
{
    public static class AoSummaryPortionParser
    {
        public static IEnumerable<AoSummaryPortion> Parse(string aoSummaryPortionText)
        {
            var lines = aoSummaryPortionText.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            var stopProcessing = false;
            foreach (var l in lines)
            {
                if (stopProcessing)
                    continue;

                var line = l.Trim();

                // skip lines with header information etc
                if (string.IsNullOrEmpty(line) ||
                    line.StartsWith(AoSummaryPortionKeywords.Header))
                    continue;
                if (line.StartsWith(AoSummaryPortionKeywords.EndOfData))
                {
                    stopProcessing = true;
                    continue;
                }

                var aoSummaryPortionData = Regex.Split(line, @"\s{2,}");

                // ignore stuff we dont' want.  mainly the summary info at the very bottom of the file
                if (aoSummaryPortionData.Length < 5)
                    continue;

                var aoSummaryPortion = PopulateAoSummaryPortion(aoSummaryPortionData);

                yield return aoSummaryPortion;
            }
        }

        private static AoSummaryPortion PopulateAoSummaryPortion(IReadOnlyList<string> aoSummaryPortionData)
        {
            var aoSummaryPortion = new AoSummaryPortion
            {
                Snapshot = $"'{aoSummaryPortionData[AoSummaryPortionColumn.Snapshot].Replace(" ", string.Empty).Substring(2)}",
                Kw = aoSummaryPortionData[AoSummaryPortionColumn.Kw],
                Iterations = aoSummaryPortionData[AoSummaryPortionColumn.Iterations],
                KVar = aoSummaryPortionData[AoSummaryPortionColumn.KVar]
            };
            var accuracy = aoSummaryPortionData[AoSummaryPortionColumn.Accuracy];
            var doesNotConverge = accuracy.Contains("DID NOT CONVERGE");
            aoSummaryPortion.Converge = doesNotConverge ?
                "D" :
                string.Empty;
            aoSummaryPortion.Accuracy = doesNotConverge ?
                accuracy.Split(' ')[0] :
                accuracy;

            return aoSummaryPortion;
        }
    }
}
