using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateAt { get; set; } 
        public DateTime UpdateAt { get; set; }
    }
}
