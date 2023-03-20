using RITest.Entities.abstracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace RITest.Entities
{
    [Table("HolePoints")]
    public class HolePointEntity : BaseModel
    {
        [ForeignKey("Hole")]
        [Column("hole_id")]
        public int HoleId { get; set; }

        [Column("x")]
        public float X { get; set; }

        [Column("y")]
        public float Y { get; set; }

        [Column("z")]
        public float Z { get; set; }

        public HoleEntity? Hole { get; set; }
    }
}
