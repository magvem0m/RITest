using RITest.Dto.DrillBlock.Interfaces;
using RITest.Entities.abstracts;

namespace RITest.Dto.DrillBlock
{
    public class DrillBlockUpdate : BaseModel, IDrillBlockUpdate
    {
        public string? Name { get; set; }
    }
}
