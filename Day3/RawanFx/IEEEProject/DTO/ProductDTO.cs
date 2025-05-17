using System.ComponentModel.DataAnnotations;

namespace IEEEProject.DTO
{
    public class ProductDTO
    {
       
        [MinLength(4, ErrorMessage = "Minimum length 4")]
        [Required(ErrorMessage = "Name can't be null")]
        public string name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Count must be greater than 0")]
        public int count { get; set; }

        public string? description { get; set; }
    }
}
