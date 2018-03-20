using System;
using System.Linq;
using System.Text.RegularExpressions;
using Jacobs.TrainParsing.Common;

namespace Jacobs.TrainParsing.TrainParseHelpers
{
    public static class SnapshotParser
    {
        public static Section Parse(string snapShotSection)
        {
            var regexPattern = $@".*{KeyWords.Snapshot}.*";
            var regex = new Regex(regexPattern, RegexOptions.IgnoreCase);

            var snapShotLine = snapShotSection
                .Split(new[] { "\r\n" }, StringSplitOptions.None)
                .FirstOrDefault(l => regex.IsMatch(l));

            if (snapShotLine == null)
                return new Section();

            var index = snapShotLine.IndexOf(KeyWords.Snapshot, StringComparison.Ordinal) + KeyWords.Snapshot.Length;
            var snapshot = $"'{snapShotLine.Substring(index).Trim().Replace(" ", string.Empty).Substring(2)}";
            return new Section { Snapshot = snapshot };
        }
    }
}