namespace Jacobs.TrainParsing.Common.TrainInformation
{
    public class TrainInformation : Section
    {

        public TrainInformation()
        {
            TrainNumber = string.Empty;
            TrainType = string.Empty;
            TrainPosition = string.Empty;
            TrackNumber = string.Empty;
            LineVolts = string.Empty;
            LineAmps = string.Empty;
            LinePower = string.Empty;
            AdjacentNodePosition = string.Empty;
            Current = string.Empty;
            FlowPosition = string.Empty;
            InformationCurrent = string.Empty;
        }

        public string TrainNumber { get; set; }
        public string TrainType { get; set; }
        public string TrainPosition { get; set; }
        public string TrackNumber { get; set; }
        public string LineVolts { get; set; }
        public string LineAmps { get; set; }
        public string LinePower { get; set; }
        public string AdjacentNodePosition { get; set; }
        public string Current { get; set; }
        public string FlowPosition { get; set; }
        public string InformationCurrent { get; set; }
    }
}