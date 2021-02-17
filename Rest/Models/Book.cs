using System;
using System.ComponentModel.DataAnnotations.Schema;
using Rest.models.Base;

namespace Rest.models
{
    [Table("book")]
    public class Book : BaseEntity
    {
      
        [Column("author")]
        public string Author { get; set; }
        
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
        
        [Column("price")]
        public decimal  Price { get; set; }
                
        [Column("title")]
        public string  Title { get; set; }
    }
}


