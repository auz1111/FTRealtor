using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTRealtor.Models
{
    public class House
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HouseID { get; set; }
        public string Title { get; set; }
        public int MLSNum { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Neighborhood { get; set; }
        public int SalesPrice { get; set; }
        public DateTime DateListed { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string Photos { get; set; }
        public int GarageSize { get; set; }
        public int SquareFeet { get; set; }
        public int LotSize { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Listing> Listings { get; set; }
    }
}