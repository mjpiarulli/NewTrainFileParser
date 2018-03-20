namespace Jacobs.TrainParsing.Common.ConverterPortion
{
    public class ConverterPortion : Section
    {

        public ConverterPortion()
        {

            AcNodeName = string.Empty;
            DcNodeName = string.Empty;
            VoltsAcNode = string.Empty;
            VoltsDcNode = string.Empty;
            Drop = string.Empty;
            PerUnitImpedance = string.Empty;
            Amps = string.Empty;
        }

        public string AcNodeName { get; set; }
        public string DcNodeName { get; set; }
        public string VoltsAcNode { get; set; }
        public string VoltsDcNode { get; set; }
        public string Drop { get; set; }
        public string PerUnitImpedance { get; set; }
        public string Amps { get; set; }
    }
}