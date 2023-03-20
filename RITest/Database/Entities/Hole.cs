using RITest.Entities.abstracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace RITest.Entities
{
    [Table("Holes")]
    public class HoleEntity : BaseModel
    {
        [Column("name")]
        public string Name { get; set; }

        [ForeignKey("DrillBlock")]
        [Column("drill_block_id")]
        public int DrillBlockId { get; set; }

        [Column("DEPTH")]
        public int DEPTH { get; set; }

        public DrillBlockEntity? DrillBlock { get; set; }
    }
}
