using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;
using MyFirstAPI.Services;
using MyFirstAPI.DTOs.Product;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

  namespace MyFirstAPI.CONTROLLERS
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService
productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [AllowAnonymous]
        public async
Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int
 id)
        {
            var product = await
_productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto createDto)
        {
            var product = _mapper.Map<Product>(createDto);
            var createdProduct = await _productService.CreateAsync(product);
            var productDto = _mapper.Map<ProductDto>(createdProduct);
            return CreatedAtAction(nameof(GetById), new
            {
                id = productDto.Id
            }, productDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<ProductDto>> Update(int
        id, [FromBody] UpdateProductDto updateDto)
        {
            var product = _mapper.Map<Product>(updateDto);
            product.Id = id;
            var updatedProduct = await
            _productService.UpdateProductAsync(id, product);
            var productDto =
            _mapper.Map<ProductDto>(updatedProduct);
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }


        [HttpGet("profile")]
        public IActionResult GetMyProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = User.Identity?.Name;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            return Ok(new
            {
                UserID = userId,
                Username = username,
                Role = userRole
            });
        }
    }
}
