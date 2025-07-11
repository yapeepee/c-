
using System.ComponentModel.DataAnnotations;


namespace MyFirstAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; } = string.Empty;
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        [Display(Name = "Product Description")]
        public string? Description { get; set; }
        [Range(0, 999999.99, ErrorMessage = "Price must be between 0 and 999999.99")]
        [Required(ErrorMessage = "價格為必填欄位")]
        [Display(Name = "price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "stock quantity must be a non-negative integer")]
        [Display(Name = "stock quantity")]
        public int StockQuantity { get; set; }
        
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}