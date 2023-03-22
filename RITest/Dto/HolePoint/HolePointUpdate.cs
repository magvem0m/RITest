using RITest.Dto.HolePoint.Interfaces;
using RITest.Entities.abstracts;

namespace RITest.Dto.HolePoint
{
    public class HolePointUpdate : BaseModel, IHolePointUpdate
    {
        public float? X { get; set; }
        public float? Y { get; set; }
        public float? Z { get; set; }
    }
}
