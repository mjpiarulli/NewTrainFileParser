using System;
using System.Collections.Generic;
using Jacobs.TrainParsing.Common;
using Jacobs.TrainParsing.Common.CurrentAtFixedPosition;

namespace Jacobs.TrainParsing.TrainParseHelpers
{
    public static class CurrentAtFixedPositionParser
    {
        public static IEnumerable<CurrentAtFixedPositionPortion> Parse(string currentAtFixedPositionText, Section section)
        {
            var lines = currentAtFixedPositionText.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var l in lines)
            {
                var line = l.Trim();

                if (string.IsNullOrEmpty(line) ||
                    line.StartsWith(CurrentAtFixedPositionKeywords.Header1) ||
                    line.StartsWith(CurrentAtFixedPositionKeywords.Header2) ||
                    line.StartsWith(CurrentAtFixedPositionKeywords.ColumnHeader1))
                    continue;

                var currentAtFixedPositionPortionData = line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var currentAtFixedPositionPortion = PopulateCurrentAtFixedPositionPortion(currentAtFixedPositionPortionData, section);

                yield return currentAtFixedPositionPortion;
            }
        }

        private static CurrentAtFixedPositionPortion PopulateCurrentAtFixedPositionPortion(IReadOnlyList<string> currentAtFixedPositionPortionData, Section section)
        {
            var currentAtFixedPositionPortion = new CurrentAtFixedPositionPortion
            {
                Snapshot = section.Snapshot,
                Name = currentAtFixedPositionPortionData[CurrentAtFixedPositionColumn.Name],
                Amps = currentAtFixedPositionPortionData[CurrentAtFixedPositionColumn.Amps],
                Position = currentAtFixedPositionPortionData[CurrentAtFixedPositionColumn.Position],
                TrackNumber = currentAtFixedPositionPortionData[CurrentAtFixedPositionColumn.TrackNumber]
            };

            return currentAtFixedPositionPortion;
        }
    }
}
