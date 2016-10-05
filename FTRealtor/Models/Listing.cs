namespace FTRealtor.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Listing
    {
        public int ListingID { get; set; }
        public int HouseID { get; set; }
        public int RealtorID { get; set; }
        public Grade? Grade { get; set; }

        public virtual House House { get; set; }
        public virtual Realtor Realtor { get; set; }
    }
}