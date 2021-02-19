using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Rest.models.Base;
using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Abstract;

namespace Rest.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        
        public string Author { get; set; }
        
        public DateTime LaunchDate { get; set; }
        
        public decimal  Price { get; set; }
                
        public string  Title { get; set; }
        public List<HyperMediaLink> Links { get; set; }
    }
}


