namespace RITest.Dto.Hole.Interfaces
{
    public interface IHoleCreate
    {
        public string Name { get; set; }
        public int DrillBlockId { get; set; }
        public int DEPTH { get; set; }
    }
}
