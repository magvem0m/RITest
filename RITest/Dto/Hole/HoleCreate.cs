using RITest.Dto.Hole.Interfaces;

namespace RITest.Dto.Hole
{
    public class HoleCreate : IHoleCreate
    {
        public string Name { get; set; }
        public int DrillBlockId { get; set; }
        public int DEPTH { get; set; }
    }
}
