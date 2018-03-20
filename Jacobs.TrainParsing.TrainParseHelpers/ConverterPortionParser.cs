using System;
using System.Collections.Generic;
using Jacobs.TrainParsing.Common;
using Jacobs.TrainParsing.Common.ConverterPortion;

namespace Jacobs.TrainParsing.TrainParseHelpers
{
    public static class ConverterPortionParser
    {
        public static IEnumerable<ConverterPortion> Parse(string converterPortionText, Section section)
        {
            var lines = converterPortionText.Split(new[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var l in lines)
            {
                var line = l.Trim();

                // skip lines with header information etc.
                if(string.IsNullOrEmpty(line) || 
                    line.StartsWith(ConverterPortionKeywords.Header) ||
                    line.StartsWith(ConverterPortionKeywords.ColumnHeaderStart1) ||
                    line.StartsWith(ConverterPortionKeywords.ColumnHeaderStart2))
                    continue;

                // this line should have data we actually care about
                var converterPortionData = line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var converterPortion = PopulateConverterPortion(converterPortionData, section);

                yield return converterPortion;
            }
        }

        private static ConverterPortion PopulateConverterPortion(IReadOnlyList<string> converterPortionData, Section section)
        {
            var converterPortion = new ConverterPortion
            {
                AcNodeName = converterPortionData[ConverterPortionColumn.AcNodeName],
                DcNodeName = converterPortionData[ConverterPortionColumn.DcNodeName],
                VoltsAcNode = converterPortionData[ConverterPortionColumn.VoltsAcNode],
                VoltsDcNode = converterPortionData[ConverterPortionColumn.VoltsDcNode],
                Drop = converterPortionData[ConverterPortionColumn.Drop],
                PerUnitImpedance = converterPortionData[ConverterPortionColumn.PerUnitImpedance],
                Amps = converterPortionData[ConverterPortionColumn.Amps],
                Snapshot = section.Snapshot
            };

            return converterPortion;
        }
    }
}

