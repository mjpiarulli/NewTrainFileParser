namespace Jacobs.TrainParsing.Common.AoSummary
{
    public class AoSummaryPortion
    {
        public AoSummaryPortion()
        {
            Snapshot = string.Empty;
            Kw = string.Empty;
            KVar = string.Empty;
            Iterations = string.Empty;
            Accuracy = string.Empty;
            Converge = string.Empty;
        }

        public string Snapshot { get; set; }
        public string Kw { get; set; }
        public string KVar { get; set; }
        public string Iterations { get; set; }
        public string Accuracy { get; set; }
        public string Converge { get; set; }
    }
}
