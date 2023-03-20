using RITest.Dto.Hole.Interfaces;

namespace RITest.Dto.Hole
{
    public class HoleUpdate : IHoleUpdate
    {
        public int Id { get; set; }
        public string Name { get; set;  }
        public int DEPTH { get; set; }
        public int DrillBlockId { get; set; }
    }
}
