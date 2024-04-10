using System.ComponentModel.DataAnnotations;

namespace Hotel.WebPortal.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
