using RITest.Dto.DrillBlockPoint.Interfaces;

namespace RITest.Dto.DrillBlockPoint
{
    public class DrillBlockPointUpdate : IDrillBlockPointUpdate
    {
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
