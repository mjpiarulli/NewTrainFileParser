namespace Jacobs.TrainParsing.Common.TsdReport
{
    public class TsdReportLine
    {
        public TsdReportLine()
        {
            Time = string.Empty;
            SpResMph = string.Empty;
            MilePost = string.Empty;
            SpeedMph = string.Empty;
            AccMphPs = string.Empty;
            GradePct = string.Empty;
            PwrOutW = string.Empty;
            PwrInW = string.Empty;
            MBrakeW = string.Empty;
            EnerOutWh = string.Empty;
            EnerInWh = string.Empty;
        }

        public string Time { get; set; }
        public string SpResMph { get; set; }
        public string MilePost { get; set; }
        public string SpeedMph { get; set; }
        public string AccMphPs { get; set; }
        public string GradePct { get; set; }
        public string PwrOutW { get; set; }
        public string PwrInW { get; set; }
        public string MBrakeW { get; set; }
        public string EnerOutWh { get; set; }
        public string EnerInWh { get; set; }
    }
}
