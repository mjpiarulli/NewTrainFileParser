namespace Jacobs.TrainParsing.Common.CurrentAtFixedPosition
{
    public class CurrentAtFixedPositionPortion : Section
    {
        public CurrentAtFixedPositionPortion()
        {
            Name = string.Empty;
            Position = string.Empty;
            TrackNumber = string.Empty;
            Amps = string.Empty;
        }

        public string Name { get; set; }
        public string Position { get; set; }
        public string TrackNumber { get; set; }
        public string Amps { get; set; }
    }
}
