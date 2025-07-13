using System.ComponentModel.DataAnnotations;

  namespace MyFirstAPI.DTOs.Product
  {
      public class UpdateProductDto
      {
          [Required(ErrorMessage = "Name is required")]
          [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
          public string Name { get; set; } = string.Empty;

          [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
          public string? Description { get; set; }

          [Required(ErrorMessage = "Price is required")]
          [Range(0, 999999.99, ErrorMessage = "Price must be between 0 and 999999.99")]
          public decimal Price { get; set; }

          [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be non-negative")]
          public int StockQuantity { get; set; }
      }
  }