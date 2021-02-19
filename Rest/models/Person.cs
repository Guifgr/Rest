﻿using System.ComponentModel.DataAnnotations.Schema;
using Rest.models.Base;

namespace Rest.models
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("adress")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }

    }
}
