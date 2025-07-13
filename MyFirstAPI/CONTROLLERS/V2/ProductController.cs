 using Microsoft.AspNetCore.Mvc;
  using MyFirstAPI.Models;
  using MyFirstAPI.Services;
  using MyFirstAPI.DTOs.Product;
  using AutoMapper;

  namespace MyFirstAPI.CONTROLLERS.V2  // 注意：命名空間加上 V2
  {
      [ApiController]
      [Route("api/v{version:apiVersion}/[controller]")]
      [ApiVersion("2.0")]  
      public class ProductController : ControllerBase
      {
          private readonly IProductService _productService;
          private readonly IMapper _mapper;
          private readonly ILogger<ProductController> _logger;
  

          public ProductController(
              IProductService productService, 
              IMapper mapper,
              ILogger<ProductController> logger)  
          {
              _productService = productService;
              _mapper = mapper;
              _logger = logger;
          }

          [HttpGet]
          [MapToApiVersion("2.0")]
          public async
  Task<ActionResult<IEnumerable<ProductDto>>> GetAll(
              [FromQuery] int? page = 1,  
              [FromQuery] int? pageSize = 10) 
          {
              _logger.LogInformation($"Getting products - Page: {page}, PageSize: {pageSize}"); 

              var products = await _productService.GetAllAsync();
              var totalCount = products.Count();  
              var pagedProducts = products
                  .Skip((page.Value - 1) * pageSize.Value)  
                  .Take(pageSize.Value);  

              var productDtos =
  _mapper.Map<IEnumerable<ProductDto>>(pagedProducts);

              // V2 新增：回傳分頁資訊在 Header 中
              Response.Headers.Add("X-Total-Count",
  totalCount.ToString());  // 總筆數
              Response.Headers.Add("X-Page", page.ToString());
  // 當前頁碼
              Response.Headers.Add("X-Page-Size",
  pageSize.ToString());  // 每頁筆數

              return Ok(productDtos);
          }
      }
  }