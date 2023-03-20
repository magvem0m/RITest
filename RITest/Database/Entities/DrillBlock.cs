using RITest.Entities.abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RITest.Entities
{
    [Table("DrillBlocks")]
    public class DrillBlockEntity: BaseModel
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        [ForeignKey("DrillBlockId")]
        public ICollection<HoleEntity>? Holes { get; set; }
    }
}
