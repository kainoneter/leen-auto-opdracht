using System.ComponentModel.DataAnnotations;

namespace FRCovadis.Entities
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }

        public bool IsReserved { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
