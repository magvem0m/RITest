using RITest.Entities.abstracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace RITest.Entities
{
    [Table("DrillBlockPoints")]
    public class DrillBlockPointEntity : BaseModel
    {
        [ForeignKey("DrillBlock")]
        [Column("drill_block_id")]
        public int DrillBlockId { get; set; }

        [Column("sequence")]
        public int Sequence { get; set; }

        [Column("x")]
        public float X { get; set; }

        [Column("y")]
        public float Y { get; set; }

        [Column("z")]
        public float Z { get; set; }

        public DrillBlockEntity? DrillBlock { get; set; }
    }
}
