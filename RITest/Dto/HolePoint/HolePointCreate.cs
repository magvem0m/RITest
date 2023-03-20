using RITest.Dto.HolePoint.Interfaces;

namespace RITest.Dto.HolePoint
{
    public class HolePointCreate : IHolePointCreate
    {
        public int HoleId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
