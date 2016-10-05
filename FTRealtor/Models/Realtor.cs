using System;
using System.Collections.Generic;

namespace FTRealtor.Models
{
    public class Realtor
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime ListingDate { get; set; }

        public virtual ICollection<Listing> Listings{ get; set; }
    }
}