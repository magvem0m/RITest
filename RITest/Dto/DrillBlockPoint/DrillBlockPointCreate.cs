using RITest.Dto.DrillBlockPoint.Interfaces;

namespace RITest.Dto.DrillBlockPoint
{
    public class DrillBlockPointCreate : IDrillBlockPointCreate
    {
        public int DrillBlockId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
