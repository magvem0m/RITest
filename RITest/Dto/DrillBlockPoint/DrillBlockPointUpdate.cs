using RITest.Dto.DrillBlockPoint.Interfaces;
using RITest.Entities.abstracts;

namespace RITest.Dto.DrillBlockPoint
{
    public class DrillBlockPointUpdate : BaseModel, IDrillBlockPointUpdate
    {
        public float? X { get; set; }
        public float? Y { get; set; }
        public float? Z { get; set; }
    }
}
