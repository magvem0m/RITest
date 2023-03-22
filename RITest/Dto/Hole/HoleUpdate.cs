using RITest.Dto.Hole.Interfaces;
using RITest.Entities.abstracts;

namespace RITest.Dto.Hole
{
    public class HoleUpdate : BaseModel, IHoleUpdate
    {
        public string? Name { get; set;  }
        public int? DEPTH { get; set; }
    }
}
