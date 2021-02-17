using System.ComponentModel.DataAnnotations.Schema;

namespace Rest.models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}