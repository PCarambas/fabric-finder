using System.ComponentModel.DataAnnotations;

namespace FabricFinder.Models
{
    public class FabricType
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
