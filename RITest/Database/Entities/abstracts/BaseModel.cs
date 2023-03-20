using System.ComponentModel.DataAnnotations.Schema;

namespace RITest.Entities.abstracts
{
    public abstract class BaseModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
