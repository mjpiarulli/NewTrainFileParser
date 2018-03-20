using System;
using System.Collections.Generic;
using System.Linq;
using Jacobs.TrainParsing.Common.PReport;

namespace Jacobs.TrainParsing.TrainParseHelpers
{
    public static class PFileParser
    {
        public static IEnumerable<PReportLine> Parse(string inputFileLocation)
        {
            var fileText = System.IO.File.ReadAllText(inputFileLocation);
            var fileTextLines = fileText.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < fileTextLines.Length; i++)
            {
                // skip the first line. we don't need it
                if (i == 0)
                    continue;

                var reportLineArray = System.Text.RegularExpressions.Regex.Split(fileTextLines[i], @"\s{2,}")
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToArray();
                if (reportLineArray.Length < 10)
                    continue;

                yield return ParseReportLine(reportLineArray);
            }
        }

        private static PReportLine ParseReportLine(IReadOnlyList<string> reportLineArray)
        {
            return new PReportLine
            {
                Column1 = reportLineArray[PColumn.Column1].Trim(),
                Column2 = reportLineArray[PColumn.Column2].Trim(),
                Column3 = reportLineArray[PColumn.Column3].Trim(),
                Column4 = reportLineArray[PColumn.Column4].Trim(),
                Column5 = reportLineArray[PColumn.Column5].Trim(),
                Column6 = reportLineArray[PColumn.Column6].Trim(),
                Column7 = reportLineArray[PColumn.Column7].Trim(),
                Column8 = reportLineArray[PColumn.Column8].Trim(),
                Column9 = reportLineArray[PColumn.Column9].Trim(),
                Column10 = reportLineArray[PColumn.Column10].Trim()
            };
        }
    }
}
