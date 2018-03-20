namespace Jacobs.TrainParsing.Common
{
    public class VoltageAcPortion
    {
        public VoltageAcPortion()
        {
            LineName = string.Empty;
            NodeA = string.Empty;
            NodeB = string.Empty;
            VoltsNodeA = string.Empty;
            VoltsNodeB = string.Empty;
            Drop = string.Empty;
            Amps = string.Empty;
        }

        public string LineName { get; set; }
        public string NodeA { get; set; }
        public string NodeB { get; set; }
        public string VoltsNodeA { get; set; }
        public string VoltsNodeB { get; set; }
        public string Drop { get; set; }
        public string Amps { get; set; }
    }
}