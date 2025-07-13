namespace MyFirstAPI.DTOs.Product
  {
      public class ProductDto
      {
          public int Id { get; set; }
          public string Name { get; set; } = string.Empty;
          public string? Description { get; set; }
          public decimal Price { get; set; }
          public int StockQuantity { get; set; }
          public DateTime CreatedDate { get; set; }

         
      }
  }