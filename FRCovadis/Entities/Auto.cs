using System.ComponentModel.DataAnnotations;

namespace FRCovadis.Entities
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public bool IsReserved { get; set; }

        public List<int>? ReservationsById { get; set; }


        public Auto(String name) {
            Name = name;
        }
    }
}
