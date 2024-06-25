using System.ComponentModel.DataAnnotations;

namespace FRCovadis.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int AutoId { get; set; }

        public string AutoName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string ?StartAdress { get; set; }
        public string ?EndAdress { get; set; }
        public double ?KmAmount { get; set; }

        public TimeOnly ?Time {  get; set; }

    }
}
