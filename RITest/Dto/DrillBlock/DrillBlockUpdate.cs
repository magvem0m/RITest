using RITest.Dto.DrillBlock.Interfaces;

namespace RITest.Dto.DrillBlock
{
    public class DrillBlockUpdate : IDrillBlockUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
