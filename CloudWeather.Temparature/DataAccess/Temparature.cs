namespace CloudWeather.Temparature.DataAccess
{
    public class Temparature{
         public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal TempHighH { get; set; }
        public string TempLowF { get; set; }
        public string ZipCode { get; set; }
    }
    }
