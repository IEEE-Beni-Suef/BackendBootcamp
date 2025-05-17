using System.ComponentModel.DataAnnotations;

namespace IEEEProject.Entity
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [MinLength(4)]
        [Required]
        public string name { get; set; }
        [Range(1,int.MaxValue)]
        public int count { get; set; }
        
        public string? description { get; set; }
    }
}
