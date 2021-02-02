using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.models
{
    [Table("person")]
    public class Person
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("first_name")]
        public string Firstname { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("adress")]
        public string Adress { get; set; }
        [Column("gender")]
        public string Gender { get; set; }

    }
}
