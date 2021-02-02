using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.models
{
    public class Person
    {
        public long Id{ get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }

    }
}
