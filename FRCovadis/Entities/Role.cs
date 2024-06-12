using System.ComponentModel.DataAnnotations;

namespace FRCovadis.Entities
{
    public class Role
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
