using System;
using System.Collections.Generic;
using System.Linq;
using Jacobs.TrainParsing.Common.TsdReport;

namespace Jacobs.TrainParsing.TrainParseHelpers
{
    public static class TsdFileParser
    {
        public static IEnumerable<TsdReportLine> Parse(string inputFileLocation)
        {
            var fileText = System.IO.File.ReadAllText(inputFileLocation);
            var fileTextFiles = fileText.Split((char)12);

            foreach (var file in fileTextFiles)
            {
                var fileLines = file.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (fileLines.Length < 1)
                    continue;

                if (DoesLineHaveCorrectHeaders(fileLines[0]))
                    return ParseReportText(fileLines);

            }

            return Enumerable.Empty<TsdReportLine>();
        }

        private static bool DoesLineHaveCorrectHeaders(string line)
        {
            var reportLineArray = System.Text.RegularExpressions.Regex.Split(line, @"\s{2,}");

            return reportLineArray.Length == 11 &&
                       reportLineArray[TsdColumn.MBrakeW].Trim() == TsdHeader.MBrakeW &&
                       reportLineArray[TsdColumn.AccMphPs].Trim() == TsdHeader.AccMphPs &&
                       reportLineArray[TsdColumn.EnerInWh].Trim() == TsdHeader.EnerInWh &&
                       reportLineArray[TsdColumn.EnerOutWh].Trim() == TsdHeader.EnerOutWh &&
                       reportLineArray[TsdColumn.GradePct].Trim() == TsdHeader.GradePct &&
                       reportLineArray[TsdColumn.MilePost].Trim() == TsdHeader.MilePost &&
                       reportLineArray[TsdColumn.PwrInW].Trim() == TsdHeader.PwrInW &&
                       reportLineArray[TsdColumn.PwrOutW].Trim() == TsdHeader.PwrOutW &&
                       reportLineArray[TsdColumn.SpResMph].Trim() == TsdHeader.SpResMph &&
                       reportLineArray[TsdColumn.SpeedMph].Trim() == TsdHeader.SpeedMph &&
                       reportLineArray[TsdColumn.Time].Trim() == TsdHeader.Time;
        }

        private static IEnumerable<TsdReportLine> ParseReportText(IReadOnlyList<string> reportLines)
        {
            for(var i = 0; i < reportLines.Count; i++)
            {
                // the first line is the header line
                if (i == 0)
                    continue;

                var reportLineArray = System.Text.RegularExpressions.Regex.Split(reportLines[i], @"\s{2,}")
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToArray();

                if (reportLineArray.Length != 11)
                    continue;


                yield return ParseReportLine(reportLineArray);
            }
        }

        private static TsdReportLine ParseReportLine(IReadOnlyList<string> reportLineArray)
        {
            return new TsdReportLine
            {
                MBrakeW = reportLineArray[TsdColumn.MBrakeW].Trim(),
                AccMphPs = reportLineArray[TsdColumn.AccMphPs].Trim(),
                EnerInWh = reportLineArray[TsdColumn.EnerInWh].Trim(),
                EnerOutWh = reportLineArray[TsdColumn.EnerOutWh].Trim(),
                GradePct = reportLineArray[TsdColumn.GradePct].Trim(),
                MilePost = reportLineArray[TsdColumn.MilePost].Trim(),
                PwrInW = reportLineArray[TsdColumn.PwrInW].Trim(),
                PwrOutW = reportLineArray[TsdColumn.PwrOutW].Trim(),
                SpResMph = reportLineArray[TsdColumn.SpResMph].Trim(),
                SpeedMph = reportLineArray[TsdColumn.SpeedMph].Trim(),
                Time = reportLineArray[TsdColumn.Time].Trim()
            };
        }
    }
}
