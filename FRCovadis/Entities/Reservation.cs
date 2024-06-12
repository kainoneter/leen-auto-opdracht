using System.ComponentModel.DataAnnotations;

namespace FRCovadis.Entities
{
    public class Reservation
    {
        [Key]
        public int id { get; set; }

        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public int autoId { get; set; }
        public int userId { get; set; }

    }
}
