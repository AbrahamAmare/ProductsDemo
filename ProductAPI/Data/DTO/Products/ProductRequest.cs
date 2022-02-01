using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Data.DTO.Products
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "You must enter a value greater than 0")]
        public decimal Price { get; set; }
    }
}
